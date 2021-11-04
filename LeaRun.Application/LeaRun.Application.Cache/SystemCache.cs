using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Cache
{
    public class SystemCache
    {
        private SystemBLL busines = new SystemBLL();

        /// <summary>
        /// 医疗机构注册列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PMR005OrgEntity> Get005Orgs()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<PMR005OrgEntity>>(busines.pmr005OrgCacheKey);
            if (cacheList == null)
            {
                var data = busines.Get005Orgs(null);
                CacheFactory.Cache().WriteCache(data, busines.pmr005OrgCacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }
      
        /// <summary>
        /// 医疗机构注册
        /// </summary>
        /// <param name="organizeId"></param>
        /// <returns></returns>
        public PMR005OrgEntity Get005OrgEntity(string organizeId)
        {
            var data = this.Get005Orgs();
            if (!string.IsNullOrEmpty(organizeId))
            {
                var d = data.Where(t => t.ORGID == organizeId).ToList<PMR005OrgEntity>();
                if (d.Count > 0)
                {
                    return d[0];
                }
            }
            return new PMR005OrgEntity();
        }
    }
}
