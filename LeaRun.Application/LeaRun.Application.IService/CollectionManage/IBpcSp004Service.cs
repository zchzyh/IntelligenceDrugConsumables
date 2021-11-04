using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.CollectionManage
{
  public  interface IBpcSp004Service
    {
        IEnumerable<UserAuthTableInfoModel> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<BpcSp004Entity> GetUserTableList(string year, string userId);
        void SaveData(string year, string userId, List<BpcSp004Entity> entities);


        /// <summary>
        /// 获取审核权限分配实体
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        BpcSp004Entity GetEntity(Expression<Func<BpcSp004Entity, bool>> condition);


        bool ExistsRecord(string userId, List<BpcSp004Entity> entities, out BpcSp004Entity existEntity);

    }
}
