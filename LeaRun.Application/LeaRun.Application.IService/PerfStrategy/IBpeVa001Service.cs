﻿using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.PerfStrategy;
using LeaRun.Application.Entity.PerfStrategy.ViewModel;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.PerfStrategy
{
    /// <summary>
    /// 使命远景信息
    /// </summary>
    public interface IBpeVa001Service
    {
        IEnumerable<BpeVa001Model> GetPageList(Pagination pagination, string queryJson);

        BpeVa001Entity GetRecord(string keyValue);

        void DeleteRecord(string keyValue);

        void AddOrUpdateRecord(BpeVa001Entity entity);
    }
}
