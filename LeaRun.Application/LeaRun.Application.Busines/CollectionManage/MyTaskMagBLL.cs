using LeaRun.Application.Code;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.CollectionManage
{
    /// <summary>
    /// 我的采集任务
    /// </summary>
    public class MyTaskMagBLL
    {

        private IMyTaskMagService myTaskMagService = new MyTaskMagService();

        //采集日常监控表
        private IBpcSP006Service bpcSP006Service = new BpcSP006Service();
        //任务信息管理表
        private IBpcSp002Service bpcSp002Service = new BpcSp002Service();
        //采集存储值表
        private IBpcSC004Service bpcSC004Service = new BpcSC004Service();
        //审核权限分配表
        private IBpcSp004Service bpcSp004Service = new BpcSp004Service();

        #region 获取数据

        /// <summary>
        /// 获取我的采集任务列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<MyTaskMagModel> GetMyTaskMag(Pagination pagination, string queryJson)
        {
            return myTaskMagService.GetMyTaskMagList(pagination, queryJson);
        }

        /// <summary>
        /// 获取采集表表头
        /// </summary>
        /// <param name="rwbh">任务编号</param>
        /// <returns></returns>
        public IEnumerable<MyTableHeaderModel> GetCollectionTableHeader(string rwbh)
        {
            var entity = bpcSp002Service.GetEntity(rwbh);
            if (entity == null)
            {
                return null;
            }

            return myTaskMagService.GetCollectionTableHeader(entity);
        }

        /// <summary>
        /// 获取采集表行
        /// </summary>
        /// <param name="rwbh">任务编号</param>
        /// <returns></returns>
        public IEnumerable<MyTableRowModel> GetCollectionTableRow(string rwbh)
        {
            var entity = bpcSp002Service.GetEntity(rwbh);
            if (entity == null)
            {
                return null;
            }

            return myTaskMagService.GetCollectionTableRow(entity);
        }

        /// <summary>
        /// 获取采集表数据
        /// </summary>
        /// <param name="rwbh">任务编号</param>
        /// <returns></returns>
        public IEnumerable<MyTableDataModel> GetCollectionTableData(string rwbh)
        {
            var entity = bpcSp002Service.GetEntity(rwbh);
            if (entity == null)
            {
                return null;
            }

            return myTaskMagService.GetCollectionTableData(entity);
        }

        /// <summary>
        /// 获取采集表上期数据
        /// </summary>
        /// <param name="rwbh">任务编号</param>
        /// <returns></returns>
        public IEnumerable<MyTableDataModel> GetCollectionTablePreData(string rwbh)
        {
            var entity = bpcSp002Service.GetEntity(rwbh);
            if (entity == null)
            {
                return null;
            }

            var yd = entity.YD == 1 ? 12 : (entity.YD - 1);
            var nd = entity.YD == 1 ? (entity.ND - 1) : entity.ND;

            var expression = LinqExtensions.True<BpcSp002Entity>();
            expression = expression.And(t => t.CJBBM == entity.CJBBM && t.JGDM == entity.JGDM && t.YD == yd && t.ND == nd);

            var preEntity = bpcSp002Service.GetEntity(expression);
            if (preEntity == null)
            {
                return null;
            }

            return myTaskMagService.GetCollectionTableData(preEntity);
        }

        #endregion




        #region 提交数据

        /// <summary>
        /// 申请审核
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="rwbh">任务编号</param>
        public void Apply(string keyvalue, string rwbh)
        {
            var task = bpcSp002Service.GetEntity(rwbh);
            if (task == null)
            {
                return;
            }

            try
            {
                if (!string.IsNullOrEmpty(keyvalue))
                {
                    var expression = LinqExtensions.True<BpcSp004Entity>();
                    expression = expression.And(t => t.CJBBM == task.CJBBM && t.ND == task.ND.ToString());
                    var auditEntity = bpcSp004Service.GetEntity(expression);

                    var entity = bpcSP006Service.GetEntity(keyvalue);
                    if (entity != null && entity.RWCD != Config.GetValue("CollectStatusTypeUnDone") && entity.SQZT != Config.GetValue("ApplyStatusTypeDone") && entity.SHZT != Config.GetValue("AuditStatusTypePass"))
                    {
                        entity.SQZT = Config.GetValue("ApplyStatusTypeDone");
                        entity.SQSJ = DateTime.Now;
                        entity.SQR = OperatorProvider.Provider.Current().Account;
                        entity.SHZT = Config.GetValue("AuditStatusTypeUndone");
                        entity.SHR = auditEntity != null ? auditEntity.USERID : string.Empty;
                        entity.RWCD = Config.GetValue("CollectStatusTypeDone");
                        bpcSP006Service.UpdateEntity(keyvalue, entity);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 开始采集
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void StartCollect(string keyvalue)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyvalue))
                {
                    var entity = bpcSP006Service.GetEntity(keyvalue);
                    if (entity != null)
                    {
                        if (entity.RWCD == Config.GetValue("CollectStatusTypeUndone"))
                        {//未采集变为采集中
                            entity.RWCD = Config.GetValue("CollectStatusTypeDoing");
                            bpcSP006Service.UpdateEntity(keyvalue, entity);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 保存我的采集任务表数据
        /// </summary>
        /// <param name="model"></param>
        public void SaveMyTableData(MyTableDataModel model, string RWBH)
        {
            try
            {
                #region 以序号主键作为判断重复的依据

                //if (!string.IsNullOrEmpty(model.XH))
                //{
                //    var entity = bpcSC004Service.GetEntity(model.XH);
                //    if (entity != null)
                //    {
                //        entity.CCVALUE = model.CCVALUE;
                //        bpcSC004Service.SaveForm(model.XH, entity);
                //    }
                //}
                //else
                //{
                //    if (!string.IsNullOrEmpty(model.RWBH) && !string.IsNullOrEmpty(model.LCODE) && !string.IsNullOrEmpty(model.HCODE))
                //    {
                //        var taskMag = bpcSp002Service.GetEntity(model.RWBH);
                //        if (taskMag != null)
                //        {
                //            var entity = new BpcSC004Entity();
                //            entity.RWBH = taskMag.RWBH;
                //            entity.CJBBM = taskMag.CJBBM;
                //            entity.JXND = Convert.ToDecimal(taskMag.ND);
                //            entity.JXYD = Convert.ToDecimal(taskMag.YD);
                //            entity.ORGID = taskMag.JGDM;
                //            entity.LCODE = model.LCODE;
                //            entity.HCODE = model.HCODE;
                //            entity.CCVALUE = model.CCVALUE;
                //            bpcSC004Service.SaveForm(null, entity);
                //        }
                //    }
                //}


                #endregion

                #region 以联合主键作为判断重复的依据

                if (!string.IsNullOrEmpty(RWBH) && !string.IsNullOrEmpty(model.LCODE) && !string.IsNullOrEmpty(model.HCODE))
                {
                    var taskMag = bpcSp002Service.GetEntity(RWBH);
                    if (taskMag != null)
                    {
                        var oldEntity = bpcSC004Service.GetEntity(RWBH, model.LCODE, model.HCODE);

                        if (oldEntity != null)
                        {
                            oldEntity.CCVALUE = model.CCVALUE;
                            bpcSC004Service.SaveForm(oldEntity.XH, oldEntity);
                        }
                        else
                        {
                            var entity = new BpcSC004Entity();
                            entity.RWBH = taskMag.RWBH;
                            entity.CJBBM = taskMag.CJBBM;
                            entity.JXND = Convert.ToDecimal(taskMag.ND);
                            entity.JXYD = Convert.ToDecimal(taskMag.YD);
                            entity.ORGID = taskMag.JGDM;
                            entity.LCODE = model.LCODE;
                            entity.HCODE = model.HCODE;
                            entity.CCVALUE = model.CCVALUE;
                            bpcSC004Service.SaveForm(null, entity);
                        }
                    }
                }

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 保存我的采集任务表数据
        /// </summary>
        /// <param name="model"></param>
        public void SaveMyTableData(List<MyTableDataModel> dataModelList, string RWBH)
        {
            try
            {
                var insertList = new List<BpcSC004Entity>();
                var updateList = new List<BpcSC004Entity>();

                var taskMag = bpcSp002Service.GetEntity(RWBH);
                foreach (var item in dataModelList)
                {
                    if (!string.IsNullOrEmpty(RWBH) && !string.IsNullOrEmpty(item.LCODE) && !string.IsNullOrEmpty(item.HCODE))
                    {
                        if (taskMag != null)
                        {
                            var oldEntity = bpcSC004Service.GetEntity(RWBH, item.LCODE, item.HCODE);

                            if (oldEntity != null)
                            {
                                if (oldEntity.CCVALUE != item.CCVALUE)
                                {
                                    oldEntity.CCVALUE = item.CCVALUE;
                                    oldEntity.Modify(oldEntity.XH);
                                    updateList.Add(oldEntity);
                                }
                            }
                            else
                            {
                                var entity = new BpcSC004Entity();
                                entity.RWBH = taskMag.RWBH;
                                entity.CJBBM = taskMag.CJBBM;
                                entity.JXND = Convert.ToDecimal(taskMag.ND);
                                entity.JXYD = Convert.ToDecimal(taskMag.YD);
                                entity.ORGID = taskMag.JGDM;
                                entity.LCODE = item.LCODE;
                                entity.HCODE = item.HCODE;
                                entity.CCVALUE = item.CCVALUE;
                                entity.Create();
                                insertList.Add(entity);
                            }
                        }
                    }
                }

                bpcSC004Service.InsertList(insertList);
                bpcSC004Service.UpdateList(updateList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
