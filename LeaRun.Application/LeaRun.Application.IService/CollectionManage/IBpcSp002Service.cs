using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.WebControl;
using System.Linq.Expressions;
using System;
using LeaRun.Application.Entity.BaseManage;

namespace LeaRun.Application.IService.CollectionManage
{
    public interface IBpcSp002Service
    {
        IEnumerable<TaskInfoModel> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<BpcSp002Entity> GetUserTableList(string year,string userId);

        void CreateTask(string year, List<BpcSp002Entity> entities);

        /// <summary>
        /// 获取单个实体信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        BpcSp002Entity GetEntity(string keyValue);

        /// <summary>
        /// 获取任务信息管理实体
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        BpcSp002Entity GetEntity(Expression<Func<BpcSp002Entity, bool>> condition);

        void AdjustTaskDate(BpcSp002Entity entity);

        TaskInfoModel GetTaskInfo(string keyValue);

        PMR001MorEntity GetOrganization();

        void AdjustTasksDate(string taskIds, string startDate, string endDate);
    }
}
