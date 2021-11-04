using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Code;


namespace LeaRun.Application.Entity.PerfStrategy
{
    /// <summary>
    /// 关键成功因素表   
    /// </summary>
    public class BpeVa004Entity : BaseEntity
    {
    /// <summary>
    /// CSF编号    
    /// </summary>
    public string CSFBH { get; set; }

    /// <summary>
    /// CSF名称    
    /// </summary>
    public string CSFMC { get; set; }

    /// <summary>
    /// 主题编号    
    /// </summary>
    public string ZTBH { get; set; }

    /// <summary>
    /// 创建人    
    /// </summary>
    public string CREATOR { get; set; }

    /// <summary>
    /// 创建时间    
    /// </summary>
    public DateTime? CREATEAT { get; set; }

    /// <summary>
    /// 修改人    
    /// </summary>
    public string MODIFOR { get; set; }

    /// <summary>
    /// 修改时间    
    /// </summary>
    public DateTime? MODIFYAT { get; set; }

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
        this.CSFBH = Guid.NewGuid().ToString().Replace("-","");//DateTime.Now.ToString("yyyyMMddHHmmssfff");
        this.CREATOR = OperatorProvider.Provider.Current().UserName;
        this.CREATEAT = DateTime.Now;
        this.STATUS = "1";
    }

    /// <summary>
    /// 编辑调用
    /// </summary>
    /// <param name="keyvalue"></param>
    public override void Modify(string keyvalue)
    {
        this.MODIFOR = OperatorProvider.Provider.Current().UserName;
        this.MODIFYAT = DateTime.Now;
    }

    #endregion
    }

}
