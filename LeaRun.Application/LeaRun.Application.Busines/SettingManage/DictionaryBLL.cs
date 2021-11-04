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
    /// 基础数据分类
    /// </summary>
    public class DictionaryBLL
    {
        private IS101TypeService typeService = new S101TypeService();
        private IS102VerService verService = new S102VerService();
        private IS103CodeService codeService = new S103CodeService();
        private IBpcSM002Service dataTypeService = new BpcSM002Service();
        private IBpeVA002Service bpeVA002Service = new BpeVA002Service();
        private IPMR025UnitService pmr025unitService = new PMR025UnitService();


        /// <summary>
        /// 缓存key
        /// </summary>
        public string cCacheKey = "standardCodeCache";
        public string TCacheKey = "standardTypeCache";
        public string pmr025CacheKey = "pmr025UnitCache";


        #region 获取数据

        /// <summary>
        /// 基础数据分类列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<S101TypeEntity> GetStandardTypes(Pagination pagination, string queryJson)
        {
            return typeService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 获取所有标准编码类别
        /// </summary>
        /// <returns></returns>
        public IEnumerable<S101TypeEntity> GetStandardTypes()
        {
            return typeService.GetList();
        }

        /// <summary>
        /// 基础数据分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public S101TypeEntity GetStandardTypeEntity(string keyValue)
        {
            return typeService.GetEntity(keyValue);
        }

        /// <summary>
        /// 基础数据版本列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<S102VerEntity> GetStandardVers(string typeId)
        {
            return verService.GetList(typeId);
        }

        /// <summary>
        /// 基础数据版本实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public S102VerEntity GetStandardVerEntity(string typeId, string verId)
        {
            return verService.GetEntity(typeId, verId);
        }

        /// <summary>
        /// 基础数据编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<S103CodeEntity> GetStandardCodes(string typeId, string typeName = "")
        {
            return codeService.GetList(typeId, typeName);
        }

        /// <summary>
        /// 基础数据编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<S103CodeEntity> GetStandardCodes(Pagination pagination, string queryJson)
        {
            return codeService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 基础数据编码实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public S103CodeEntity GetStandardCodeEntity(string typeId, string verId, string code)
        {
            return codeService.GetEntity(typeId, verId, code);
        }

        /// <summary>
        /// 数据项分类列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpcSM002Entity> GetDataTypes(string queryJson)
        {
            return dataTypeService.GetList(queryJson);
        }

        /// <summary>
        /// 数据项分类列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpcSM002Entity> GetDataTypes(Pagination pagination, string queryJson)
        {
            return dataTypeService.GetList(pagination, queryJson);
        }

        #region 行政区域

        /// <summary>
        /// 行政区域列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR025UnitEntity> GetPMR025UnitList(Pagination pagination, string queryJson)
        {
            return pmr025unitService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 获取所有行政区域
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PMR025UnitEntity> GetPMR025UnitList()
        {
            return pmr025unitService.GetList();
        }

        /// <summary>
        /// 行政区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR025UnitEntity GetPMR025UnitEntity(string keyValue)
        {
            return pmr025unitService.GetEntity(keyValue);
        }

        #endregion

        #region 维度设置

        /// <summary>
        /// 维度基本信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeVA002Entity> GetDimensionalities(Pagination pagination, string queryJson)
        {
            return bpeVA002Service.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 维度基本信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BpeVA002Entity GetDimensionalityEntity(string keyValue)
        {
            return bpeVA002Service.GetEntity(keyValue);
        }

        #endregion

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除基础数据分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveStandardTypeForm(string keyValue)
        {
            try
            {
                typeService.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增基础数据分类表单
        /// </summary>
        /// <param name="s101TypeEntity">基础数据分类实体</param>
        /// <returns></returns>
        public void CreateStandardTypeForm(S101TypeEntity s101TypeEntity)
        {
            try
            {
                typeService.SaveForm(null, s101TypeEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改基础数据分类表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="s101TypeEntity">基础数据分类实体</param>
        /// <returns></returns>
        public void ModifyStandardTypeForm(string keyValue, S101TypeEntity s101TypeEntity)
        {
            try
            {
                typeService.SaveForm(keyValue, s101TypeEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除基础数据版本
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveStandardVerForm(string typeId, string verId)
        {
            try
            {
                verService.RemoveForm(typeId, verId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增基础数据版本表单
        /// </summary>
        /// <param name="s102VerEntity">基础数据版本实体</param>
        /// <returns></returns>
        public void CreateStandardVerForm(S102VerEntity s102VerEntity)
        {
            try
            {
                if (s102VerEntity.STATUS == "1")
                {
                    var type = typeService.GetEntity(s102VerEntity.TYPEID);
                    if (type.STATUS != "1")
                    {
                        throw new Exception("基础数据分类未启用");
                    }
                }
                verService.SaveForm(null, null, s102VerEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改基础数据版本表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="s102VerEntity">基础数据版本实体</param>
        /// <returns></returns>
        public void ModifyStandardVerForm(string typeId, string verId, S102VerEntity s102VerEntity)
        {
            try
            {
                if (s102VerEntity.STATUS == "1")
                {
                    var type = typeService.GetEntity(typeId);
                    if (type.STATUS != "1")
                    {
                        throw new Exception("基础数据分类未启用");
                    }
                }
                verService.SaveForm(typeId, verId, s102VerEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除基础数据代码
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveStandardCodeForm(string typeId, string verId, string code)
        {
            try
            {
                codeService.RemoveForm(typeId, verId, code);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增基础数据代码表单
        /// </summary>
        /// <param name="s102VerEntity">基础数据代码实体</param>
        /// <returns></returns>
        public void CreateStandardCodeForm(S103CodeEntity s103CodeEntity)
        {
            try
            {
                if (s103CodeEntity.STATUS == "1")
                {
                    var ver = verService.GetEntity(s103CodeEntity.TYPEID, s103CodeEntity.VERID);
                    if (ver.STATUS != "1")
                    {
                        throw new Exception("版本号未启用");
                    }
                }
                codeService.SaveForm(null, null, null, s103CodeEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改基础数据代码表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="s103CodeEntity">基础数据代码实体</param>
        /// <returns></returns>
        public void ModifyStandardCodeForm(string typeId, string verId, string code, S103CodeEntity s103CodeEntity)
        {
            try
            {
                if (s103CodeEntity.STATUS == "1")
                {
                    var ver = verService.GetEntity(typeId, verId);
                    if (ver.STATUS != "1")
                    {
                        throw new Exception("版本号未启用");
                    }
                }
                codeService.SaveForm(typeId, verId, code, s103CodeEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region 行政区域

        /// <summary>
        /// 删除行政区域
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemovePMR025UnitForm(string keyValue)
        {
            pmr025unitService.RemoveForm(keyValue);
        }

        /// <summary>
        /// 保存行政区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="pmr025UnitEntity">基础数据分类实体</param>
        /// <returns></returns>
        public void SavePMR025UnitForm(string keyValue, PMR025UnitEntity pmr025UnitEntity)
        {
            pmr025unitService.SaveForm(keyValue, pmr025UnitEntity);
        }

        #endregion

        #region 维度设置

        /// <summary>
        /// 删除维度基本信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDimensionalityForm(string keyValue)
        {
            try
            {
                bpeVA002Service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增维度基本信息表单
        /// </summary>
        /// <param name="entity">维度基本信息实体</param>
        /// <returns></returns>
        public void CreateDimensionalityForm(BpeVA002Entity entity)
        {
            try
            {
                bpeVA002Service.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改维度基本信息表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">维度基本信息实体</param>
        /// <returns></returns>
        public void ModifyDimensionalityForm(string keyValue, BpeVA002Entity entity)
        {
            try
            {
                bpeVA002Service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion
    }
}