using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.IService.PerfScheme;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Application.Service.PerfScheme;
using LeaRun.Application.Service.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.Entity.PerfScheme.ViewModel;
using LeaRun.Util;
using LeaRun.Application.Code;
using LeaRun.Application.IService.PerfGoal;
using LeaRun.Application.Service.PerfGoal;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Application.Service.PerfConfig;

namespace LeaRun.Application.Busines.PerfScheme
{
    /// <summary>
    /// 绩效方案设置
    /// </summary>
    public class PerfSchemeSettingBLL
    {
        private IPerfSchemeDataService perfSchemedataService = new PerfSchemeDataService();
        private IPerfDeptSchemedataService perfDeptSchemedataService = new PerfDeptSchemedataService();
        private IPerfSchemeWeightService perfSchemeWeightService = new PerfSchemeWeightService();
        private IPerfDeptSchemeAppraisedataService perfDeptSchemeAppraisedataService = new PerfDeptSchemeAppraisedataService();
        private IBpePA001Service ibpePA001Service = new BpePA001Service();
        private IBpePA002Service ibpePA002Service = new BpePA002Service();
        private IBpeEA004Service bpeEA004Service = new BpeEA004Service();
        private IBpePA003Service ibpePA003Service = new BpePA003Service();
        private IBpePA004Service ibpePA004Service = new BpePA004Service();
        private IBpcSP007Service ibpcsp007Service = new BpcSP007Service();

        #region 基础绩效方案

        #region 获取数据
        /// <summary>
        /// 获取绩效方案数据
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpePA001Entity> GetPerfSchemedataList(Pagination pagination, string queryJson)
        {
            return perfSchemedataService.GetList(pagination, queryJson);
        }
        /// <summary>
        /// 获取绩效方案名称列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BaseperfSchemesettingModel> GetPerfSchemeNameList(Pagination pagination, string queryJson)
        {
            return perfSchemedataService.GetBaseperfNameList(pagination, queryJson);
        }
        /// <summary>
        /// 获取绩效基础方案数据列表编码
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpePA001Entity> GetPerfSchemedataBms(string queryJson)
        {
            return perfSchemedataService.GetBmList(queryJson);
        }
        /// <summary>
        /// 获取绩效科室方案数据列表编码
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpePA003Entity> GetPerfDeptSchemedataBms(string queryJson)
        {
            return perfDeptSchemedataService.GetBmList(queryJson);
        }
        /// <summary>
        /// 获取所有指标的列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<KpiAll> GetKPIListJson(Pagination pagination, string queryJson)
        {
            return perfSchemedataService.GetKPIListJson(pagination, queryJson);
        }

        /// <summary>
        /// 获取绩效基础方案数据实体
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public BpePA001Entity GetBasePerfSchemeEntity(string FABH)
        {
            return ibpePA001Service.GetEntity(FABH);
        }


        #endregion 获取数据   


        #region 提交数据
        /// <summary>
        /// 新增绩效基础方案数据
        /// </summary>
        /// <param name="bpepa001"></param>
        public void AddBasePerfScheme(BpePA001Entity bpepa001)
        {
            try
            {
                ibpePA001Service.SaveForm(null, bpepa001);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改基础绩效方案数据
        /// </summary>
        /// <param name="fabh"></param>
        /// <param name="bpepa001"></param>
        public void ModifyBasePerfScheme(string fabh, BpePA001Entity bpepa001)
        {
            try
            {
                ibpePA001Service.SaveForm(fabh, bpepa001);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 删除基础绩效方案
        /// </summary>
        /// <param name="fabh"></param>
        public void DelBasePerfScheme(string fabh)
        {
            try
            {
                ibpePA001Service.RemoveForm(fabh);
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 删除基础绩效方案对应的指标明细数据
        /// </summary>
        /// <param name="fabh"></param>
        public void DelBasePerfSchemeKPI(string fabh)
        {
            try
            {
                ibpePA002Service.DelDataByFABH(fabh);
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 保存基础绩效方案配置的指标列表
        /// </summary>
        /// <param name="dataEntity"></param>
        public void SaveSchemeKpiList(List<BpePA002Entity> dataEntity)
        {
            ibpePA002Service.InsertList(dataEntity);
        }
        #endregion 提交数据

        #endregion 基础绩效方案

        #region 科室绩效方案
        #region 获取数据
        /// <summary>
        /// 获取科室绩效方案数据实体
        /// </summary>
        /// <param name="jxfabh"></param>
        /// <returns></returns>
        public BpePA003Entity GetDepSchemeEntity(string JGFABH)
        {
            return ibpePA003Service.GetEntity(JGFABH);
        }
        /// <summary>
        /// 获取科室方案数据
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DepPerfSchemeSettingModel> GetDepSchemeDataList(Pagination pagination, string queryJson)
        {
            PerfSchemeDataService perfSchemeDataService = new PerfSchemeDataService();
            return perfSchemeDataService.GetDepSchemeDataList(pagination, queryJson);
        }


        public IEnumerable<BpePA003Entity> GetSchemeDepList(string year, string fabh)
        {
            return ibpePA003Service.GetSchemeDepList(year, fabh);
        }
        public List<string> GetYearDeptCode(string year)
        {
            return ibpcsp007Service.GetYearDeptCode(year);
        }
        /// <summary>
        /// 科室方案明细查看列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DepSchemeZBModel> GetDepZBList(Pagination pagination, string queryJson)
        {
            return perfDeptSchemedataService.GetKPIListJson(pagination, queryJson);
        }


        #endregion 获取数据

        #region 提交数据
        public void SaveSchemeDepList(string fabh, string jxbm, string jgfabh,string jgfamc,string jgbm,string status)
        {
            // fabh 获取指标列表
            var zbList = ibpePA002Service.GetList(fabh);

            // pa003 增加科室方案
            ibpePA003Service.SaveForm(null, new BpePA003Entity
            {
                JGFABH = jgfabh,
                JGFAMC = jgfamc,
                JGBM = jgbm,
                FABH = fabh,
                JXBM = jxbm,
                STATUS = status
            }); ;

            // pa004 插入指标
            List<BpePA004Entity> jgZbList = new List<BpePA004Entity>();
            foreach (var item in zbList)
            {
                jgZbList.Add(new BpePA004Entity
                {
                    XH = item.XH,
                    JGFABH =jgfabh,
                    KPIBH = item.KPIBH,
                    ZBLX = item.ZBLX,
                    CREATOR = item.CREATOR,
                    CREATEAT = item.CREATEAT,
                    MODIFOR = item.MODIFOR,
                    MODIFYAT = item.MODIFYAT,
                    STATUS = item.STATUS

                });
            }
            ibpePA004Service.InsertList(jgZbList);
        }
        /// <summary>
        /// 删除对象绩效方案
        /// </summary>
        /// <param name="jgfabh"></param>
        public void DelDepPerfScheme(string jgfabh)
        {
            try
            {
                ibpePA003Service.RemoveForm(jgfabh);
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 删除基础绩效方案对应的指标明细数据
        /// </summary>
        /// <param name="jgfabh"></param>
        public void DelDepPerfSchemeKPI(string jgfabh)
        {
            try
            {
                ibpePA004Service.DelDataByJGFABH(jgfabh);    
            }
            catch (Exception)
            {

            }
        }

        #endregion 提交数据

        #endregion 科室绩效方案

        #region 绩效方案权重

        #region 获取数据

        /// <summary>
        /// 绩效权重设置列表
        /// </summary>
        /// <param name="fabh">方案编号</param>
        /// <param name="level">指标等级</param>
        /// <returns></returns>
        public IEnumerable<PerfSchemeWeightModel> GetPerfSchemeWeightList(string fabh, string level)
        {
            var result = new List<PerfSchemeWeightModel>();

            // 获取方案所有指标
            var zbList = perfSchemeWeightService.GetZBList(fabh).ToList();
            if (zbList.Count == 0)
            {
                return result;
            }

            // 获取方案所有权重设置
            var weightList = perfSchemeWeightService.GetWeightList(fabh).ToList();

            // 筛选指标级别
            if (level == "1")
            {
                foreach (var item in zbList)
                {
                    if (!result.Exists(i => i.FirstZBBH == item.FirstZBBH))
                    {
                        var weight = weightList.FirstOrDefault(w => w.ThirdZBBH == item.FirstZBBH);

                        result.Add(new PerfSchemeWeightModel
                        {
                            FABH = item.FABH,
                            FAMC = item.FAMC,
                            SYND = item.SYND,
                            FirstZBBH = item.FirstZBBH,
                            FirstZBMC = item.FirstZBMC,
                            FirstExplain = item.FirstExplain,
                            QZBZ = weight == null ? 0 : weight.QZBZ
                        });
                    }
                }
            }
            else if (level == "2")
            {
                foreach (var item in zbList)
                {
                    if (!result.Exists(i => i.SecZBBH == item.SecZBBH))
                    {
                        var weight = weightList.FirstOrDefault(w => w.ThirdZBBH == item.SecZBBH);

                        result.Add(new PerfSchemeWeightModel
                        {
                            FABH = item.FABH,
                            FAMC = item.FAMC,
                            SYND = item.SYND,
                            FirstZBBH = item.FirstZBBH,
                            FirstZBMC = item.FirstZBMC,
                            FirstExplain = item.FirstExplain,
                            SecZBBH = item.SecZBBH,
                            SecZBMC = item.SecZBMC,
                            SecExplain = item.SecExplain,
                            QZBZ = weight == null ? 0 : weight.QZBZ
                        });
                    }
                }
            }
            else if (level == "3")
            {
                zbList.ForEach(z =>
                {
                    var weight = weightList.FirstOrDefault(w => w.ThirdZBBH == z.ThirdZBBH);
                    z.QZBZ = weight == null ? 0 : weight.QZBZ;
                });
                result.AddRange(zbList);
            }

            return result;
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 修改绩效权重表单
        /// </summary>
        /// <param name="datas">绩效权重设置列表</param>
        /// <returns></returns>
        public void ModifyPerfSchemeWeightList(List<PerfSchemeWeightModel> datas)
        {
            try
            {
                #region 检查数据有效性

                if (datas == null || datas.Count == 0)
                {
                    return;
                }

                string fabh = datas.First().FABH;
                string level = null;
                if (!string.IsNullOrWhiteSpace(datas.First().ThirdZBBH))
                {
                    level = "3";
                }
                else if (!string.IsNullOrWhiteSpace(datas.First().SecZBBH))
                {
                    level = "2";
                }
                else if (!string.IsNullOrWhiteSpace(datas.First().FirstZBBH))
                {
                    level = "1";
                }

                if (string.IsNullOrWhiteSpace(fabh) || string.IsNullOrWhiteSpace(level))
                {
                    throw new Exception("传入数据不正确");
                }

                #endregion

                var oldDatas = GetPerfSchemeWeightList(fabh, level).ToList();
                if (oldDatas.Count == 0)
                {
                    return;
                }
                switch (level)
                {
                    case "1":
                        oldDatas.ForEach(d =>
                        {
                            var data = datas.FirstOrDefault(i => i.FirstZBBH == d.FirstZBBH);
                            if (data != null)
                            {
                                d.QZBZ = data.QZBZ;
                            }
                            else
                            {
                                d.QZBZ = 0;
                            }
                        });
                        if (oldDatas.Sum(s => s.QZBZ) != 100)
                        {
                            throw new Exception("权重总和不等于100%");
                        }
                        break;
                    case "2":
                        oldDatas.ForEach(d =>
                        {
                            var data = datas.FirstOrDefault(i => i.SecZBBH == d.SecZBBH);
                            if (data != null)
                            {
                                d.QZBZ = data.QZBZ;
                            }
                            else
                            {
                                d.QZBZ = 0;
                            }
                        });

                        var firstSums = from d in oldDatas
                                        group d by d.FirstZBBH into g
                                        select new
                                        {
                                            g.Key,
                                            s = g.Sum(a => a.QZBZ)
                                        };
                        if (firstSums.Count(s => s.s != 100) != 0)
                        {
                            throw new Exception("权重总和不等于100%");
                        }
                        break;
                    case "3":
                        oldDatas.ForEach(d =>
                        {
                            var data = datas.FirstOrDefault(i => i.ThirdZBBH == d.ThirdZBBH);
                            if (data != null)
                            {
                                d.QZBZ = data.QZBZ;
                            }
                            else
                            {
                                d.QZBZ = 0;
                            }
                        });

                        var secSums = from d in oldDatas
                                      group d by d.SecZBBH into g
                                      select new
                                      {
                                          g.Key,
                                          s = g.Sum(a => a.QZBZ)
                                      };
                        if (secSums.Count(s => s.s != 100) != 0)
                        {
                            throw new Exception("权重总和不等于100%");
                        }
                        break;
                }

                perfSchemeWeightService.ModifyWeightList(oldDatas, level);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion 绩效方案权重

        #region 科室绩效评价

        #region 获取数据

        /// <summary>
        /// 部门绩效评价设置列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PerfDeptSchemeAppraisedataModel> GetPerfDeptSchemeAppraisedataList(Pagination pagination, string queryJson)
        {
            var result = perfDeptSchemeAppraisedataService.GetList(pagination, queryJson).ToList();

            if (result.Count != 0)
            {
                string enableFwzt = Config.GetValue("ServiceStatusTypeNormal");
                result.ForEach(r => r.IsEnable = r.FWZT == enableFwzt);
            }

            return result;
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 修改评价方法明细表单
        /// </summary>
        /// <param name="jgfabh">部门方案编号</param>
        /// <param name="pjffbh">评价方法编号</param>
        /// <returns></returns>
        public void ModifyPerfDeptSchemeAppraisedataForm(string jgfabh, string pjffbh)
        {
            try
            {
                string enableFwzt = Config.GetValue("ServiceStatusTypeNormal");
                if (perfDeptSchemedataService.GetPertFwzt(jgfabh) != enableFwzt)
                {
                    throw new Exception("历年绩效不允许更改");
                }

                var data = bpeEA004Service.GetEntityByJGFABH(jgfabh);
                if (data == null)
                {
                    bpeEA004Service.SaveForm(null, new BpeEA004Entity
                    {
                        JGFABH = jgfabh,
                        PJFFBH = pjffbh
                    });
                }
                else
                {
                    // 评价方法有变化才更改
                    if (data.PJFFBH != pjffbh)
                    {
                        data.PJFFBH = pjffbh;
                        if (data.STATUS != "1")
                        {
                            data.CREATEAT = DateTime.Now;
                            data.CREATOR = OperatorProvider.Provider.Current().UserName;
                            data.STATUS = "1";
                        }
                        bpeEA004Service.SaveForm(data.XH, data);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion 科室绩效评价
    }
}
