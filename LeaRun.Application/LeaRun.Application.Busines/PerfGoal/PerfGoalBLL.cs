using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.Entity.PerfGoal.ViewModel;
using LeaRun.Application.IService.PerfGoal;
using LeaRun.Application.Service.PerfGoal;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.PerfGoal
{
    /// <summary>
    /// 绩效目标
    /// </summary>
    public class PerfGoalBLL
    {
        private IBpePA003Service bpePA003Service = new BpePA003Service();
        private IBpeTA004Service bpeTA004Service = new BpeTA004Service();
        private IQuantitativeGoalAuditService quantitativeGoalAudit = new QuantitativeGoalAuditService();
        private IQuantitativeGoalService quantitativeGoal = new QuantitativeGoalService();

        #region 获取数据

        /// <summary>
        /// 定量指标目标值设置检索列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QuantitativeGoalModel> GetQuantitativeGoalList(Pagination pagination, string queryJson)
        {
            var result = quantitativeGoal.GetList(pagination, queryJson);

            foreach (var item in result)
            {
                if (string.IsNullOrWhiteSpace(item.XH))  // 未设定过目标值
                {
                    // 获取该部门绩效方案的所有定量指标
                    var reportDatas = quantitativeGoal.GetReportDataList(item.JGFABH);

                    // 检查每个定量指标是否设定过目标值
                    foreach (var data in reportDatas)
                    {
                        var goal = bpeTA004Service.GetEntity(item.JXBM, item.JGFABH, data.KPIBH);
                        if (goal == null)
                        {
                            goal = new BpeTA004Entity
                            {
                                JXBM = item.JXBM,
                                JGFABH = item.JGFABH,
                                BSCBH = data.BSCBH ?? "",
                                BSCMC = data.BSCMC,
                                CSFBH = data.CSFBH ?? "",
                                CSFMC = data.CSFMC,
                                KPIBH = data.KPIBH,
                                HGMBZ = 0,
                                YXMBZ = 0,
                                YLMBZ = 0,
                                BGMBZ = data.BGMBZ,
                                CKZ1 = data.CKZ1,
                                CKZ2 = data.CKZ2,
                                CKZ3 = data.CKZ3,
                                SQZT = 0
                            };
                            goal.Create();
                            bpeTA004Service.SaveForm(null, goal);
                        }
                        else if (goal.STATUS == "0")
                        {
                            goal.BSCBH = item.BSCBH;
                            goal.BSCMC = item.BSCMC;
                            goal.CSFBH = item.CSFBH;
                            goal.CSFMC = item.CSFMC;
                            goal.HGMBZ = 0;
                            goal.YXMBZ = 0;
                            goal.YLMBZ = 0;
                            goal.BGMBZ = data.BGMBZ;
                            goal.CKZ1 = data.CKZ1;
                            goal.CKZ2 = data.CKZ2;
                            goal.CKZ3 = data.CKZ3;
                            goal.SQZT = 0;
                            goal.Modify(goal.XH);
                            bpeTA004Service.SaveForm(goal.XH, goal);
                        }

                        var currentItem = result.FirstOrDefault(r => r.JXBM == data.JXBM
                                                                 && r.JGFABH == data.JGFABH
                                                                 && r.ThirdZBBH == data.ThirdZBBH);
                        if (currentItem != null)
                        {
                            currentItem.XH = goal.XH;
                            currentItem.KPIBH = goal.KPIBH;
                            currentItem.HGMBZ = goal.HGMBZ;
                            currentItem.YXMBZ = goal.YXMBZ;
                            currentItem.YLMBZ = goal.YLMBZ;
                            currentItem.BGMBZ = goal.BGMBZ;
                            currentItem.CKZ1 = goal.CKZ1;
                            currentItem.CKZ2 = goal.CKZ2;
                            currentItem.CKZ3 = goal.CKZ3;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 定量指标目标值审核列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QuantitativeGoalAuditModel> GetQuantitativeGoalAuditList(Pagination pagination, string queryJson)
        {
            return quantitativeGoalAudit.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 定量指标目标值设置检索实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BpeTA004Entity GetQuantitativeGoalEntity(string keyValue)
        {
            return bpeTA004Service.GetEntity(keyValue);
        }

        /// <summary>
        /// 定量指标目标值审核实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BpePA003Entity GetQuantitativeGoalAuditEntity(string keyValue)
        {
            return bpePA003Service.GetEntity(keyValue);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 新增定量指标目标值设置检索表单
        /// </summary>
        /// <param name="entity">定量指标目标值设置检索实体</param>
        /// <returns></returns>
        public void CreateQuantitativeGoalForm(BpeTA004Entity entity)
        {
            try
            {
                bpeTA004Service.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改定量指标目标值设置检索表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">定量指标目标值实体</param>
        /// <returns></returns>
        public void ModifyQuantitativeGoalForm(string keyValue, BpeTA004Entity entity)
        {
            try
            {
                // 检查科室方案审核状态
                var jgfa = bpePA003Service.GetEntity(entity.JGFABH);
                if (jgfa == null)
                {
                    throw new Exception("方案不存在");
                }
                else if (jgfa.STATUS == "1") // 已审核不可修改
                {
                    throw new Exception("方案已审核，不可修改");
                }

                bpeTA004Service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 定量指标目标值申请
        /// </summary>
        /// <param name="jgfabh">机构方案编号</param>
        /// <param name="applyStatus">申请状态(0未申请/1已申请)</param>
        public void ApplyQuantitativeGoal(string jgfabh, int applyStatus)
        {
            try
            {
                // 检查科室方案审核状态
                var jgfa = bpePA003Service.GetEntity(jgfabh);
                if (jgfa == null)
                {
                    throw new Exception("方案不存在");
                }
                else if (jgfa.STATUS == "1") // 已审核不可修改
                {
                    throw new Exception("方案已审核，不可修改");
                }

                quantitativeGoal.Apply(jgfabh, applyStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增定量指标目标值审核表单
        /// </summary>
        /// <param name="entity">定量指标目标值审核实体</param>
        /// <returns></returns>
        public void CreateQuantitativeGoalAuditForm(BpePA003Entity entity)
        {
            try
            {
                bpePA003Service.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改定量指标目标值审核表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">定量指标目标值实体</param>
        /// <returns></returns>
        public void ModifyQuantitativeGoalForm(string keyValue, BpePA003Entity entity)
        {
            try
            {
                bpePA003Service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}