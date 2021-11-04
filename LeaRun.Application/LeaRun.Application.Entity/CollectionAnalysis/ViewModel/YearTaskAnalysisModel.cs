using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionAnalysis.ViewModel
{
    /// <summary>
    /// 年度任务分析
    /// </summary>
    public class YearTaskAnalysisModel
    {
        /// <summary>
        /// 任务人ID
        /// </summary>
        public string USERID { get; set; }
        /// <summary>
        /// 任务人
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 绩效年度编码
        /// </summary>
        public string JXBM { get; set; }
        /// <summary>
        /// 总任务量
        /// </summary>
        public int RwCount { get; set; }
        /// <summary>
        /// 各月数量
        /// </summary>
        public List<YearTaskAnalysisMonth> MonthDatas { get; set; }

        /// <summary>
        /// 添加各月数量
        /// </summary>
        /// <param name="items">年度任务项</param>
        /// <param name="collectStatusTypeDone">已完成采集状态</param>
        public void AddMonthDatas(List<YearTaskAnalysisItemModel> items, string collectStatusTypeDone)
        {
            MonthDatas = new List<YearTaskAnalysisMonth>();
            if (items.Count == 0)
            {
                return;
            }

            decimal nd = items.First().ND;
            for (int y = 1; y <= 12; y++)
            {
                MonthDatas.Add(new YearTaskAnalysisMonth
                {
                    ND = nd,
                    YD = y,
                    TotalCount = items.Count(i => i.YD == y && i.USERID == USERID),
                    DoneCount = items.Count(i => i.YD == y && i.USERID == USERID && i.RWCD == collectStatusTypeDone),
                    UndoCount = items.Count(i => i.YD == y && i.USERID == USERID && i.RWCD != collectStatusTypeDone)
                });
            }
        }
    }

    /// <summary>
    /// 年度任务分析各月数据
    /// </summary>
    public class YearTaskAnalysisMonth
    {
        /// <summary>
        /// 年度
        /// </summary>
        public decimal ND { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        public decimal YD { get; set; }
        /// <summary>
        /// 任务数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 已完成任务数
        /// </summary>
        public int DoneCount { get; set; }
        /// <summary>
        /// 未完成数
        /// </summary>
        public int UndoCount { get; set; }
    }

    /// <summary>
    /// 任务项
    /// </summary>
    public class YearTaskAnalysisItemModel
    {
        /// <summary>
        /// 任务人ID
        /// </summary>
        public string USERID { get; set; }
        /// <summary>
        /// 采集状态(0未采集/1已进行/2已采集)
        /// </summary>
        public string RWCD { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public decimal ND { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        public decimal YD { get; set; }
    }
}