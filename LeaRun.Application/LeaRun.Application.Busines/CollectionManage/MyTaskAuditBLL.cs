using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.CollectionManage
{
    /// <summary>
    /// 我的审核任务
    /// </summary>
    public class MyTaskAuditBLL
    {
        private IMyTaskAuditService myTaskAudiService = new MyTaskAuditService();

        //采集日常监控表
        private IBpcSP006Service bpcSP006Service = new BpcSP006Service();

        #region 获取数据

        /// <summary>
        /// 获取我的审核任务列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<MyTaskAuditModel> GetMyTaskAudit(Pagination pagination, string queryJson)
        {
            return myTaskAudiService.GetMyTaskAuditList(pagination, queryJson);
        }


        #endregion




        #region 提交数据

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="shzt">审核状态(1未通过/2已通过)</param>
        public void Audit(string keyvalue, string shzt)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyvalue) && ( shzt == Config.GetValue("AuditStatusTypePass") || shzt == Config.GetValue("AuditStatusTypeReject")))
                {
                    var entity = bpcSP006Service.GetEntity(keyvalue);
                    if (entity != null && entity.SQZT == Config.GetValue("ApplyStatusTypeDone"))
                    {
                        entity.SHZT = shzt;
                        entity.RWCD = shzt == Config.GetValue("AuditStatusTypeReject") ? Config.GetValue("CollectStatusTypeDoing") : entity.RWCD;
                        entity.SQZT = shzt == Config.GetValue("AuditStatusTypeReject") ? Config.GetValue("ApplyStatusTypeReject") : entity.SQZT;
                        entity.SHSJ = DateTime.Now;
                        bpcSP006Service.UpdateEntity(keyvalue, entity);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

    }
}
