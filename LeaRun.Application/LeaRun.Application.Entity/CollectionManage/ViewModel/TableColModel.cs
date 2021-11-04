using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    public  class TableColModel
    {
        public  List<SubColModel> SubColModelList = new List<SubColModel>();

        private string _colName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ColName
        {
            get { return _colName; }
            set
            {
                _colName = value;
               var arr= value.Split('|');

               foreach (var r in arr)
               {
                   SubColModel m = new SubColModel()
                   {
                         ColName=r,
                         ColSpan=1
                   };
                   SubColModelList.Add(m);
               }

            }
        }
       
    }

    /// <summary>
    /// 
    /// </summary>
    public class SubColModel
    {
        /// <summary>
        /// 列占格子数
        /// </summary>
        public int ColSpan { get; set; } =1;

        /// <summary>
        /// 行占格子数
        /// </summary>
        public int RowSpan { get; set; } = 1;
        /// <summary>
        /// 列名称
        /// </summary>
        public string  ColName { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool Hide { get; set; } = false;
    }
}
