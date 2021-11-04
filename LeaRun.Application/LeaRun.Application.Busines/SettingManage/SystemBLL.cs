using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Application.Service.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.SettingManage
{
    /// <summary>
    /// 系统设置
    /// </summary>
    public class SystemBLL
    {
        private IPMR001MorService orgService = new PMR001MorService();
        private IPMR005OrgService pmr005OrgService = new PMR005OrgService();
        private IPMR008OffiecesService pmr008OffiecesService = new PMR008OffiecesService();
        private IPMR009UserService pmr009UserService = new PMR009UserService();
        private IPMR002MorDeptService pmr002MorDeptService = new PMR002MorDeptService();

        /// <summary>
        /// 缓存的KEY
        /// </summary>
        public string pmr005OrgCacheKey = "pmr005OrgCache";
        #region 获取数据

        /// <summary>
        /// 主管机构信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR001MorEntity> GetOrgs(string queryJson)
        {
            return orgService.GetList(queryJson);
        }

        /// <summary>
        /// 主管机构信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR001MorEntity GetOrgEntity(string keyValue)
        {
            return orgService.GetEntity(keyValue);
        }

        #region 主管机构部门
        /// <summary>
        /// 主管机构部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PMR002MorDeptEntity> GetPMR002MorDeptList()
        {
            return pmr002MorDeptService.GetList();
        }

        /// <summary>
        /// 主管机构部门列表
        /// </summary>
        /// <param name="parentId">父部门Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns></returns>
        public IEnumerable<PMR002MorDeptEntity> GetPMR002MorDeptList(string parentId, string keyword = "")
        {
            return pmr002MorDeptService.GetList(parentId, keyword);
        }

        /// <summary>
        /// 主管机构部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR002MorDeptEntity GetPMR002MorDeptEntity(string keyValue)
        {
            return pmr002MorDeptService.GetEntity(keyValue);
        }
        #endregion

        #region 注册机构
        /// <summary>
        /// 注册机构列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR005OrgEntity> Get005Orgs(Pagination pagination, string queryJson)
        {
            return pmr005OrgService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 注册机构列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR005OrgEntity> Get005Orgs(string queryJson)
        {
            return pmr005OrgService.GetList(queryJson);
        }

        /// <summary>
        /// 注册机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR005OrgEntity Get005OrgEntity(string keyValue)
        {
            return pmr005OrgService.GetEntity(keyValue);
        }
        #endregion

        #region 医疗机构科室信息
        /// <summary>
        /// 医疗机构科室信息列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PMR008OffiecesEntity> GetPMR008OffiecesList()
        {
            return pmr008OffiecesService.GetList();
        }

        /// <summary>
        /// 医疗机构科室信息列表(分页)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<PMR008OffiecesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return pmr008OffiecesService.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 医疗机构科室信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR008OffiecesEntity GetPMR008OffiecesEntity(string keyValue)
        {
            return pmr008OffiecesService.GetEntity(keyValue);
        }
        #endregion

        #region 医疗卫生人员表
        /// <summary>
        /// 医疗卫生人员列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR009UserEntity> GetPMR009UserList(Pagination pagination, string queryJson)
        {
            return pmr009UserService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 医疗卫生人员列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR009UserEntity> GetPMR009UserList(string queryJson)
        {
            return pmr009UserService.GetList(queryJson);
        }

        /// <summary>
        /// 医疗卫生人员实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR009UserEntity GetPMR009UserEntity(string keyValue)
        {
            return pmr009UserService.GetEntity(keyValue);
        }
        #endregion
        #endregion

        #region 验证数据
        /// <summary>
        /// 医疗机构科室编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistPMR008OffiecesEnCode(string enCode, string keyValue)
        {
            return pmr008OffiecesService.ExistEnCode(enCode, keyValue);
        }
        /// <summary>
        /// 医疗机构科室名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistPMR008OffiecesFullName(string fullName, string keyValue)
        {
            return pmr008OffiecesService.ExistFullName(fullName, keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除主管机构信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveOrgForm(string keyValue)
        {
            try
            {
                orgService.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增主管机构信息表单
        /// </summary>
        /// <param name="entity">主管机构信息实体</param>
        /// <returns></returns>
        public void CreateOrgForm(PMR001MorEntity entity)
        {
            try
            {
                orgService.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改主管机构信息表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">主管机构信息实体</param>
        /// <returns></returns>
        public void ModifyOrgForm(string keyValue, PMR001MorEntity entity)
        {
            try
            {
                orgService.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region 主管机构部门
        /// <summary>
        /// 删除主管机构部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemovePMR002MorDeptForm(string keyValue)
        {
            pmr002MorDeptService.RemoveForm(keyValue);
        }
        /// <summary>
        /// 保存主管机构部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="{">区域实体</param>
        /// <returns></returns>
        public void SavePMR002MorDeptForm(string keyValue, PMR002MorDeptEntity deptEntity)
        {
            pmr002MorDeptService.SaveForm(keyValue, deptEntity);
        }
        #endregion

        #region 注册机构

        /// <summary>
        /// 删除注册机构信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void Remove005OrgForm(string keyValue)
        {
            try
            {
                pmr005OrgService.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增注册机构表单
        /// </summary>
        /// <param name="entity">注册机构信息实体</param>
        /// <returns></returns>
        public void Create005OrgtForm(PMR005OrgEntity entity)
        {
            try
            {
                pmr005OrgService.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改注册机构表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">注册机构实体</param>
        /// <returns></returns>
        public void Modify005OrgForm(string keyValue, PMR005OrgEntity entity)
        {
            try
            {
                pmr005OrgService.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 医疗机构科室信息
        /// <summary>
        /// 删除医疗机构科室
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemovePMR008OffiecesForm(string keyValue)
        {
            pmr008OffiecesService.RemoveForm(keyValue);
        }
        /// <summary>
        /// 保存医疗机构科室表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        public void SavePMR008OffiecesForm(string keyValue, PMR008OffiecesEntity offiecesEntity)
        {
            pmr008OffiecesService.SaveForm(keyValue, offiecesEntity);
        }
        #endregion

        #region 医疗卫生人员表
        /// <summary>
        /// 删除医疗卫生人员表
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemovePMR009UserForm(string keyValue)
        {
            pmr009UserService.RemoveForm(keyValue);
        }
        /// <summary>
        /// 保存医疗卫生人员表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">主管机构信息实体</param>
        /// <returns></returns>
        public void SavePMR009UserForm(string keyValue, PMR009UserEntity entity)
        {
            pmr009UserService.SaveForm(keyValue, entity);
        }
        #endregion
        #endregion

      
    }
}