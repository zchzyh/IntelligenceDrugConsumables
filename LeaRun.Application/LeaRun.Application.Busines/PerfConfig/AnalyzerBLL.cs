using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Application.Service.PerfConfig;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.PerfConfig
{
    /// <summary>
    /// 分析器设置
    /// </summary>
    public class AnalyzerBLL
    {
        private IStandardDataService standardDataModelService = new StandardDataService();
        private IMetadataService metadataModelService = new MetadataService();
        private IBpcSM006Service bpcSM006Service = new BpcSM006Service();

        #region 获取数据

        /// <summary>
        /// 数据项库基本表列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<StandardDataModel> GetStandardDataList(Pagination pagination, string queryJson)
        {
            return standardDataModelService.GetListForAnalyzer(pagination, queryJson);
        }

        /// <summary>
        /// 元数据库基本表列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<MetadataModel> GetMetadataList(Pagination pagination, string queryJson)
        {
            return metadataModelService.GetListForAnalyzer(pagination, queryJson);
        }

        /// <summary>
        /// 分析器基本信息表列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpcSM006Entity> GetAnalyzerList(Pagination pagination, string queryJson)
        {
            return bpcSM006Service.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 分析器基本信息表
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        /// <returns></returns>
        public BpcSM006Entity GetAnalyzerEntity(string fxqbm)
        {
            return bpcSM006Service.GetEntity(fxqbm);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除分析器基本信息
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        public void RemoveAnalyzerForm(string fxqbm)
        {
            try
            {
                bpcSM006Service.RemoveForm(fxqbm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增分析器基本信息表单
        /// </summary>
        /// <param name="entity">分析器基本信息实体</param>
        /// <returns></returns>
        public void CreateAnalyzerForm(BpcSM006Entity entity)
        {
            try
            {
                var data = bpcSM006Service.GetEntity(entity.FXQBM);
                if (data == null)
                {
                    bpcSM006Service.SaveForm(null, entity);
                }
                else if (data.STATUS == "0")
                {
                    entity.CREATEAT = DateTime.Now;
                    entity.CREATOR = OperatorProvider.Provider.Current().UserName;
                    entity.STATUS = "1";
                    bpcSM006Service.SaveForm(entity.FXQBM, entity);
                }
                else
                {
                    throw new Exception("编码重复");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改分析器基本信息表单
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        /// <param name="entity">分析器基本信息实体</param>
        /// <returns></returns>
        public void ModifyAnalyzerForm(string fxqbm, BpcSM006Entity entity)
        {
            try
            {
                bpcSM006Service.SaveForm(fxqbm, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 绑定数据项分析器
        /// </summary>
        /// <param name="jcsjbm">数据项编码</param>
        /// <param name="fxqbm">分析器编码</param>
        public void StandardDataBindAnalyzer(string jcsjbm, string fxqbm)
        {
            try
            {
                standardDataModelService.BindAnalyzer(jcsjbm, fxqbm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 绑定元数据分析器
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="metaCode">元数据编码</param>
        /// <param name="fxqbm">分析器编码</param>
        public void MetadataBindAnalyzer(string jxbm, string metaCode, string fxqbm)
        {
            try
            {
                metadataModelService.BindAnalyzer(jxbm, metaCode, fxqbm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}