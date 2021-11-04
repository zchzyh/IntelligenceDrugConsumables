using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Application.Service.PerfConfig;
using LeaRun.Application.Service.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.PerfConfig
{
    /// <summary>
    /// KPI设置
    /// </summary>
    public class KpiSettingBLL
    {
        /// <summary>
        /// 数据项
        /// </summary>
        private IBpcSM001Service standardDataService = new BpcSM001Service();
        private IStandardDataService standardDataModelService = new StandardDataService();

        /// <summary>
        /// 元数据
        /// </summary>
        private IBpeMA001Service metadataService = new BpeMA001Service();
        private IMetadataService metadataModelService = new MetadataService();

        /// <summary>
        /// 定量指标
        /// </summary>
        private IBpeTA001Service bpeTA001Service = new BpeTA001Service();
        private IQuantitativeIndicatorsService quanIService = new QuantitativeIndicatorsService();

        /// <summary>
        /// 定性指标
        /// </summary>
        private IBpeTB001Service bpeTB001Service = new BpeTB001Service();
        private IQualitativeIndicatorsService qualISdervice = new QualitativeIndicatorsService();

        /// <summary>
        /// 绩效定量指标
        /// </summary>
        private IBpeTA002Service bpeTA002Service = new BpeTA002Service();
        private IJxQuantitativeIndicatorsService jxquanIService = new JxQuantitativeIndicatorsService();

        #region 获取数据

        #region 数据项

        /// <summary>
        /// 数据项基本信息键值列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<StandardDataModel> GetStandardDataKeyValueList(string queryJson)
        {
            return standardDataModelService.GetKeyValueList(queryJson);
        }

        /// <summary>
        /// 数据项基本信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<StandardDataModel> GetStandardDataList(Pagination pagination, string queryJson)
        {
            return standardDataModelService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 数据项基本信息实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpcSM001Entity GetStandardDataEntity(string keyvalue)
        {
            return standardDataService.GetEntity(keyvalue);
        }

        #endregion

        #region 元数据

        /// <summary>
        /// 元数据库基本表列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<MetadataModel> GetMetadataList(Pagination pagination, string queryJson)
        {
            return metadataModelService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 元数据库基本表实体
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="metaCode">元数据编码</param>
        /// <returns></returns>
        public BpeMA001Entity GetMetadataEntity(string jxbm, string metaCode)
        {
            return metadataService.GetEntity(jxbm, metaCode);
        }

        #endregion

        #region 定量指标

        /// <summary>
        /// 获取定量指标列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QuantitativeIndicatorsModel> GetQuantitativeIndicators(Pagination pagination, string queryJson)
        {
            return quanIService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 获取定量指标等级列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>定量指标等级列表</returns>
        public IEnumerable<BpeTA001Entity> GetQuantitativeIndicatorLevels(string queryJson)
        {
            return bpeTA001Service.GetLevelList(queryJson);
        }

        /// <summary>
        /// 获取定量指标设置
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <returns></returns>
        public BpeTA001Entity GetQuantitativeIndicatorsEntity(string zbbh, string jxbm)
        {
            return bpeTA001Service.GetEntity(zbbh, jxbm);
        }

        #endregion

        #region 定性指标

        /// <summary>
        /// 获取定性指标列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QualitativeIndicatorsModel> GetQualitativeIndicators(Pagination pagination, string queryJson)
        {
            return qualISdervice.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 获取定性指标等级列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>定性指标等级列表</returns>
        public IEnumerable<BpeTB001Entity> GetQualitativeIndicatorsLevels(string queryJson)
        {
            return bpeTB001Service.GetLevelList(queryJson);
        }

        /// <summary>
        /// 获取定性指标设置
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <returns></returns>
        public BpeTB001Entity GetQualitativeIndicatorsEntity(string zbbh, string jxbm)
        {
            return bpeTB001Service.GetEntity(zbbh, jxbm);
        }

        #endregion

        #region 绩效定量指标

        /// <summary>
        /// 获取绩效定量指标列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<JxQuantitativeIndicatorsModel> GetJxQuantitativeIndicators(Pagination pagination, string queryJson)
        {
            return jxquanIService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 获取绩效定量指标设置
        /// </summary>
        /// <param name="kpibh">KPI编号</param>
        /// <returns></returns>
        public BpeTA002Entity GetJxQuantitativeIndicatorsEntity(string kpibh)
        {
            return bpeTA002Service.GetEntity(kpibh);
        }

        #endregion

        #endregion

        #region 提交数据

        #region 数据项

        /// <summary>
        /// 删除数据项基本信息
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void RemoveStandardDataForm(string keyvalue)
        {
            try
            {
                standardDataService.RemoveForm(keyvalue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增数据项基本信息表单
        /// </summary>
        /// <param name="entity">数据项基本信息实体</param>
        /// <returns></returns>
        public void CreateStandardDataForm(BpcSM001Entity entity)
        {
            try
            {
                standardDataService.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改数据项基本信息表单
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">数据项基本信息实体</param>
        /// <returns></returns>
        public void ModifyStandardDataForm(string keyvalue, BpcSM001Entity entity)
        {
            try
            {
                standardDataService.SaveForm(keyvalue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 元数据

        /// <summary>
        /// 删除元数据库基本表
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="metaCode">元数据编码</param>
        public void RemoveMetadataForm(string jxbm, string metaCode)
        {
            try
            {
                metadataService.RemoveForm(jxbm, metaCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增元数据库基本表表单
        /// </summary>
        /// <param name="entity">元数据库基本表实体</param>
        /// <returns></returns>
        public void CreateMetadataForm(BpeMA001Entity entity)
        {
            try
            {
                metadataService.SaveForm(null, null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改元数据库基本表表单
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="metaCode">元数据编码</param>
        /// <param name="entity">元数据库基本表实体</param>
        /// <returns></returns>
        public void ModifyMetadataForm(string jxbm, string metaCode, BpeMA001Entity entity)
        {
            try
            {
                metadataService.SaveForm(jxbm, metaCode, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 定量指标

        /// <summary>
        /// 删除定量指标设置
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        public void RemoveQuantitativeIndicatorsForm(string zbbh, string jxbm)
        {
            try
            {
                bpeTA001Service.RemoveForm(zbbh, jxbm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增定量指标设置表单
        /// </summary>
        /// <param name="entity">定量指标设置实体</param>
        /// <returns></returns>
        public void CreateQuantitativeIndicatorsForm(BpeTA001Entity entity)
        {
            try
            {
                bpeTA001Service.SaveForm(null, null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改定量指标设置表单
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="entity">定量指标设置实体</param>
        /// <returns></returns>
        public void ModifyQuantitativeIndicatorsForm(string zbbh, string jxbm, BpeTA001Entity entity)
        {
            try
            {
                bpeTA001Service.SaveForm(zbbh, jxbm, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 定性指标

        /// <summary>
        /// 删除定性指标设置
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        public void RemoveQualitativeIndicatorsForm(string zbbh, string jxbm)
        {
            try
            {
                bpeTB001Service.RemoveForm(zbbh, jxbm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增定性指标设置表单
        /// </summary>
        /// <param name="entity">定性指标设置实体</param>
        /// <returns></returns>
        public void CreateQualitativeIndicatorsForm(BpeTB001Entity entity)
        {
            try
            {
                bpeTB001Service.SaveForm(null, null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改定性指标设置表单
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="entity">定性指标设置实体</param>
        /// <returns></returns>
        public void ModifyQualitativeIndicatorsForm(string zbbh, string jxbm, BpeTB001Entity entity)
        {
            try
            {
                bpeTB001Service.SaveForm(zbbh, jxbm, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 绩效定量指标

        /// <summary>
        /// 删除绩效定量指标
        /// </summary>
        /// <param name="kpibh">KPI编号</param>
        public void RemoveJxQuantitativeIndicatorsForm(string kpibh)
        {
            try
            {
                bpeTA002Service.RemoveForm(kpibh);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增绩效定量指标表单
        /// </summary>
        /// <param name="entity">绩效定量指标实体</param>
        /// <returns></returns>
        public void CreateJxQuantitativeIndicatorsForm(BpeTA002Entity entity)
        {
            try
            {
                if (bpeTA002Service.IsEntityExist(entity.ZBBH, entity.JXBM))
                {
                    throw new Exception("已为该定量指标设置过计算公式");
                }

                entity.METCODELIST = string.Join("|", GetMetacodes(entity.ZBGS));

                bpeTA002Service.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改绩效定量指标表单
        /// </summary>
        /// <param name="kpibh">定量绩效指标编码</param>
        /// <param name="entity">绩效定量指标实体</param>
        /// <param name="isModifyStatus">是否为修改状态</param>
        /// <returns></returns>
        public void ModifyJxQuantitativeIndicatorsForm(string kpibh, BpeTA002Entity entity)
        {
            try
            {
                entity.METCODELIST = string.Join("|", GetMetacodes(entity.ZBGS));

                bpeTA002Service.SaveForm(kpibh, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 提取指标公式中的元数据编码列表
        /// </summary>
        /// <param name="zbgs">指标公式</param>
        /// <returns>指标公式中的元数据编码列表</returns>
        private List<string> GetMetacodes(string zbgs)
        {
            List<string> codes = new List<string>();

            foreach (Match match in Regex.Matches(zbgs, "(?<=({))[.\\s\\S]*?(?=(}))"))
            {
                string code = "{" + match.Value + "}";
                if (!codes.Contains(code))
                {
                    codes.Add(code);
                }
            }

            return codes;
        }

        #endregion

        #endregion
    }
}