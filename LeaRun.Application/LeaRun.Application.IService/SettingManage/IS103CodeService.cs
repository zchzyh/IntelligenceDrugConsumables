using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.SettingManage
{
    /// <summary>
    /// 基础数据编码
    /// </summary>
    public interface IS103CodeService
    {
        #region 获取数据
        /// <summary>
        /// 基础数据编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<S103CodeEntity> GetList(string queryJson,string typeName="");
        /// <summary>
        /// 基础数据编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<S103CodeEntity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 基础数据编码实体
        /// </summary>
        /// <param name="keyValues">主键值</param>
        /// <returns></returns>
        S103CodeEntity GetEntity(string typeId, string verId, string code);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除基础数据编码
        /// </summary>
        /// <param name="keyValues">主键</param>
        void RemoveForm(string typeId, string verId, string code);
        /// <summary>
        /// 保存基础数据编码表单（新增、修改）
        /// </summary>
        /// <param name="typeId">主键值</param>
        /// <param name="s101TypeEntity">基础数据编码实体</param>
        /// <returns></returns>
        void SaveForm(string typeId, string verId, string code, S103CodeEntity s101TypeEntity);
        #endregion
    }
}