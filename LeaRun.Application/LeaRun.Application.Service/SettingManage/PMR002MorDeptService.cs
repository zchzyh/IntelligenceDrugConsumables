using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Data.Repository;
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.SettingManage
{
    /// <summary>
    /// 主管机构部门
    /// </summary>
    public class PMR002MorDeptService : RepositoryFactory<PMR002MorDeptEntity>, IPMR002MorDeptService
    {
        #region 获取数据
        /// <summary>
        /// 主管机构部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PMR002MorDeptEntity> GetList()
        {
            return this.HQPASRepository().IQueryable().OrderBy(t => t.CREATEAT).ToList();
        }
        /// <summary>
        /// 主管机构部门列表
        /// </summary>
        /// <param name="parentId">父部门Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns></returns>
        public IEnumerable<PMR002MorDeptEntity> GetList(string parentId, string keyword)
        {
            var expression = LinqExtensions.True<PMR002MorDeptEntity>();
            if (!string.IsNullOrEmpty(parentId))
            {
                expression = expression.And(t => t.PARENTDEPT == parentId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.DEPTID.Contains(keyword));
                expression = expression.Or(t => t.DEPTNAME.Contains(keyword));
            }
            return this.HQPASRepository().IQueryable(expression).OrderBy(t => t.CREATEAT).ToList();
        }
        /// <summary>
        /// 主管机构部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR002MorDeptEntity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除主管机构部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.HQPASRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存主管机构部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="{">区域实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, PMR002MorDeptEntity deptEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                deptEntity.Modify(keyValue);
                this.HQPASRepository().Update(deptEntity);
            }
            else
            {
                deptEntity.Create();
                this.HQPASRepository().Insert(deptEntity);
            }
        }
        #endregion
    }
}
