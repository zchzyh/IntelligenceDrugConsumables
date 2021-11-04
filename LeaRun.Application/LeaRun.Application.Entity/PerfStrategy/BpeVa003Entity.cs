using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.PerfStrategy
{
    /// <summary>
    /// 战略主题信息表   
    /// </summary>
    public class BpeVa003Entity : BaseEntity
    {
    /// <summary>
    /// 主题编号    
    /// </summary>
    public string ZTBH { get; set; }

    /// <summary>
    /// 主题名称    
    /// </summary>
    public string ZTMC { get; set; }

    /// <summary>
    /// BSC编号    
    /// </summary>
    public string BSCBH { get; set; }

    /// <summary>
    /// 使命编号    
    /// </summary>
    public string SMBH { get; set; }

    /// <summary>
    /// 备注信息    
    /// </summary>
    public string REMARK { get; set; }

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

    public override void Create()
    {
        this.ZTBH = Guid.NewGuid().ToString().Replace("-", "");// DateTime.Now.ToString("yyyyMMddHHmmssfff");
        this.CREATOR = OperatorProvider.Provider.Current().UserName;
        this.CREATEAT = DateTime.Now;
        this.STATUS = "1";
    }

    /// <summary>
    /// 编辑调用
    /// </summary>
    /// <param name="keyValue"></param>
    public override void Modify(string keyValue)
    {
        this.MODIFOR = OperatorProvider.Provider.Current().UserName;
        this.MODIFYAT = DateTime.Now;
    }

    }

}
