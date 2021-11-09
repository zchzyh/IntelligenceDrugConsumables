using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.DrugConsumableManage
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DrugCompanyEntity : BaseEntity
    {

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_Code { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_Name_ZC { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_JX { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_GG { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_Name_SP { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_BZCZ { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int? Drug_BZ_Min { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_BZ_Unit { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_BZ_Unit_ZJ { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_QY_Code { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_PZWH { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_BWM { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_YB_Type { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_YB_Code { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_YB_Name { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_YB_JX { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Drug_YB_Comment { get; set; }


        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.CREATOR = OperatorProvider.Provider.Current().UserName;
            //this.CREATEAT = DateTime.Now;
            //this.STATUS = "1";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            //this.JCSJBM = keyvalue;
            //this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            //this.MODIFYAT = DateTime.Now;
        }
        #endregion

    }
}
