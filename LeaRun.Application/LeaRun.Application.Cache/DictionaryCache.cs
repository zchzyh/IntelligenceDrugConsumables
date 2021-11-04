using LeaRun.Application.Busines;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.Entity.SystemManage.ViewModel;
using LeaRun.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Cache
{
    /// <summary>
    /// 版 本 6.1
    /// Admin Studio
    /// 创建人：LYL
    /// 日 期：2019.01.15
    /// 描 述：标准编码字典缓存
    /// </summary>
    public class DictionaryCache
    {
        private DictionaryBLL busines = new DictionaryBLL();

        /// <summary>
        /// 标准编码字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<S103CodeEntity> GetStandardCodeList()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<S103CodeEntity>>(busines.cCacheKey);
            if (cacheList == null)
            {             
                var data = busines.GetStandardCodes("");
                CacheFactory.Cache().WriteCache(data, busines.cCacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }
        /// <summary>
        /// 标准类型字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<S101TypeEntity> GetStandardTypes()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<S101TypeEntity>>(busines.TCacheKey);
            if (cacheList == null)
            {
                var data = busines.GetStandardTypes();
                CacheFactory.Cache().WriteCache(data, busines.TCacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }

        /// <summary>
        /// 标准编码字典列表
        /// </summary>
        /// <param name="typeName">分类名称</param>
        /// <returns></returns>
        public IEnumerable<S103CodeEntity> GetStandardCodeList(string typeName)
        {
           
            if(!string.IsNullOrEmpty(typeName))
            {
                S101TypeEntity TypeEntity = GetStandardTypes().Where(x => x.NAME == typeName).FirstOrDefault();
                if (TypeEntity != null)
                {
                    return this.GetStandardCodeList().Where(t => t.TYPEID == TypeEntity.TYPEID);
                }
            }
            else
            {
                return this.GetStandardCodeList();
            }
            return null;
        }

        public IEnumerable<PMR025UnitEntity> GetPMR025UnitList()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<PMR025UnitEntity>>(busines.pmr025CacheKey);
            if (cacheList == null)
            {
                var data = busines.GetPMR025UnitList();
                CacheFactory.Cache().WriteCache(data, busines.pmr025CacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }

    }
}
