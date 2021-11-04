using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创 建：超级管理员
    /// 日 期：2017-02-22 21:03
    /// 描 述：系统功能表
    /// </summary>
    public class Base_ModuleEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 功能主键
        /// </summary>
        /// <returns></returns>
        public string ModuleId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        /// <returns></returns>
        public string ParentId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        /// <returns></returns>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        public string FullName { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        /// <returns></returns>
        public string Icon { get; set; }
        /// <summary>
        /// 导航地址
        /// </summary>
        /// <returns></returns>
        public string UrlAddress { get; set; }
        /// <summary>
        /// 导航目标
        /// </summary>
        /// <returns></returns>
        public string Target { get; set; }
        /// <summary>
        /// 菜单选项
        /// </summary>
        /// <returns></returns>
        public int? IsMenu { get; set; }
        /// <summary>
        /// 允许展开
        /// </summary>
        /// <returns></returns>
        public int? AllowExpand { get; set; }
        /// <summary>
        /// 是否公开
        /// </summary>
        /// <returns></returns>
        public int? IsPublic { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        /// <returns></returns>
        public int? AllowEdit { get; set; }
        /// <summary>
        /// 允许删除
        /// </summary>
        /// <returns></returns>
        public int? AllowDelete { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        public int? SortCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ModuleId = Guid.NewGuid().ToString();
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
            this.ModuleId = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}