using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 数据项分类信息表  
    /// </summary>
    public partial class BpcSm002Entity : BaseEntity
    {
    /// <summary>
    /// 分类编码    
    /// </summary>
    public string TYPEID { get; set; }

    /// <summary>
    /// 分类名称    
    /// </summary>
    public string NAME { get; set; }

    /// <summary>
    /// 上级编码    
    /// </summary>
    public string PARENT { get; set; }

    /// <summary>
    /// 级别    
    /// </summary>
    public string GRADE { get; set; }

    /// <summary>
    /// 状态    
    /// </summary>
    public string STATUS { get; set; }

    #region 扩展操作
    /// <summary>
    /// 新增调用
    /// </summary>
    public override void Create()
    {
        //this.TYPEID = DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }
    /// <summary>
    /// 编辑调用
    /// </summary>
    /// <param name="keyvalue"></param>
    public override void Modify(string keyvalue)
    {
    }
    #endregion

    }
}
