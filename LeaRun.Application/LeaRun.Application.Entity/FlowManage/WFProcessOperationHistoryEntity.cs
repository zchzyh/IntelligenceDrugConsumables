using LeaRun.Application.Code;
using System;

namespace LeaRun.Application.Entity.FlowManage
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2016.03.18 09:58
    /// 描 述：工作流实例操作记录
    /// </summary>
    public class WFProcessOperationHistoryEntity : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 实例进程ID
        /// </summary>
        public string ProcessId { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>		
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>		
        public string CreateUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Id = keyValue;
        }
        #endregion
    }
}
