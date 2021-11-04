using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 采集管理-任务管理
    /// </summary>
    public class TaskMagController : MvcControllerBase
    {
        MyTaskMagBLL bll;
        DictionaryBLL dicBll;
        /// <summary>
        /// 
        /// </summary>
        public TaskMagController()
        {
            bll = new MyTaskMagBLL();
            dicBll = new DictionaryBLL();
        }

        #region 视图功能
        /// <summary>
        /// 我的采集任务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 采集数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DetailForm(string keyValue, string xh, bool canOpt = false, bool collecting = true)
        {
            if (canOpt && !collecting)
            {
                bll.StartCollect(xh);
            }
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取我的采集任务列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTaskListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var tasks = bll.GetMyTaskMag(pagination, queryJson).ToList().Select(t => new
            {
                XH = t.XH,
                RWBH = t.RWBH,
                CJBBM = t.CJBBM,
                CJBQM = t.CJBQM,
                CJPLNAME = t.CJPLNAME,
                OFFICENAME = t.OFFICENAME,
                ND = t.ND,
                YD = t.YD,
                KSSJ = t.KSSJ,
                JZSJ = t.JZSJ,
                NAME = t.NAME,
                RWCD = t.RWCD ?? "0",
                SQZT = t.SQZT ?? "0",
                SHZT = t.SHZT ?? "0",
                ZT = (t.RWCD ?? "0") + (t.SQZT ?? "0") + (t.SHZT ?? "0") + ((t.JZSJ < DateTime.Now) ? "0" : "1")
            });
            var JsonData = new
            {
                rows = tasks,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取我的采集任务详情列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListJson(string keyValue)
        {
            List<Dictionary<string, object>> models = new List<Dictionary<string, object>>();
            var lcodes = (Session["GridHeaders"] as IEnumerable<string>).ToList();
            if (lcodes.Count > 0)
            {
                var rows = bll.GetCollectionTableRow(keyValue);
                var datas = bll.GetCollectionTableData(keyValue);
                Session["BPC_SC004_DATA"] = datas;
                if (rows.Count() > 0)
                {//具备行公共数据
                    var commonLcode = "";
                    int maxGrade = rows.Select(t => int.Parse(t.GRADE)).Max();
                    var newRows = rows.Where(r => int.Parse(r.GRADE) == maxGrade);
                    foreach (var item in newRows)
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        row.Add("HCODE", item.HCODE);
                        #region 添加行公共数据
                        //最低级的行数据
                        var lastcol = lcodes[maxGrade - 1] ?? "col" + maxGrade;
                        if (!commonLcode.Contains(lastcol))
                        {
                            commonLcode += lastcol + ";";
                        }
                        row.Add(lastcol, item.NAME);
                        //低一级的行编码
                        var hxbm = item.HXBM;
                        for (int i = maxGrade - 1; i > 0; i--)
                        {
                            var cur = rows.Where(r => r.HXBM == rows.Where(ro => ro.HXBM == hxbm).FirstOrDefault().PARENT).FirstOrDefault();
                            if (cur != null)
                            {
                                lastcol = lcodes[i - 1] ?? "col" + i;
                                if (!commonLcode.Contains(lastcol))
                                {
                                    commonLcode += lastcol + ";";
                                }
                                row.Add(lastcol, cur.NAME);
                                hxbm = cur.HXBM;
                            }
                        }
                        #endregion

                        #region 添加行录入数据
                        for (int i = maxGrade; i < lcodes.Count; i++)
                        {
                            var data = datas.Where(d => d.HCODE == item.HCODE && d.LCODE == lcodes[i]).FirstOrDefault();
                            if (data == null)
                            {
                                if (!string.IsNullOrEmpty(lcodes[i]))
                                {
                                    row.Add(lcodes[i], "");
                                }
                                continue;
                            }
                            row.Add(lcodes[i], data.CCVALUE);
                        }
                        #endregion

                        models.Add(row);
                    }
                    Session["CommonLcode"] = commonLcode;
                }
                else
                {
                    var hcodes = datas.Select(d => d.HCODE);
                    foreach (var hcode in hcodes)
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        row.Add("HCODE", hcode);
                        for (int i = 0; i < lcodes.Count; i++)
                        {
                            var data = datas.Where(d => d.HCODE == hcode && d.LCODE == lcodes[i]).FirstOrDefault();
                            if (data == null)
                            {
                                row.Add(lcodes[i], "");
                                continue;
                            }
                            row.Add(lcodes[i], data.CCVALUE);
                        }
                    }
                }
            }

            return ToJsonResult(models);
        }

        /// <summary>
        /// 获取我的采集任务详情列信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetHeadersJson(string keyValue)
        {
            var headers = bll.GetCollectionTableHeader(keyValue);
            Session["GridHeaders"] = headers.Select(h => h.LCODE);
            return ToJsonResult(headers);
        }

        /// <summary>
        /// 获取数据列合并规则
        /// </summary>
        /// <param name="rowJson"></param>
        /// <returns></returns>
        public ActionResult SetTableRowsSpan(string rowJson)
        {
            List<object> rules = new List<object>();
            List<Dictionary<string, string>> rows = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(rowJson);
            List<Dictionary<string, string>> spanRows = new List<Dictionary<string, string>>();
            List<int> spanRowid = new List<int>();
            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i].Where(r => r.Key.Contains(""));
                foreach (var cell in row)
                {
                    var r = spanRows.Where(d => d["value"] == cell.Value).FirstOrDefault();
                    if (r != null)
                    {
                        int count = int.Parse(r["spanCount"]) + 1;
                        r["spanCount"] = count.ToString();
                    }
                    else
                    {
                        r = new Dictionary<string, string>();
                        r.Add("name", cell.Key);
                        r.Add("value", cell.Value);
                        r.Add("spanCount", "1");
                        spanRows.Add(r);
                        spanRowid.Add(i + 1);
                    }
                }
            }
            foreach (var item in spanRows)
            {
                int ind = spanRows.IndexOf(item);
                int rowid = spanRowid[ind];
                rules.Add(new
                {
                    cell = item["name"],
                    row = rowid,
                    spanCount = item["spanCount"]
                });
            }
            return ToJsonResult(rules);
        }


        /// <summary>
        /// 获取采集状态
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCollectJson(bool forSearch = false)
        {
            var months = dicBll.GetStandardCodes(Config.GetValue("CollectStatusType")).OrderBy(t => t.IX);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限采集状态");
            foreach (var item in months)
            {
                items.Add(item.CODE, item.NAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }


        /// <summary>
        /// 获取申请状态
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetApplyJson(bool forSearch = false)
        {
            var months = dicBll.GetStandardCodes(Config.GetValue("ApplyStatusType")).OrderBy(t => t.IX);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限申请状态");
            foreach (var item in months)
            {
                items.Add(item.CODE, item.NAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }


        /// <summary>
        /// 获取审核状态
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAuditJson(bool forSearch = false)
        {
            var months = dicBll.GetStandardCodes(Config.GetValue("AuditStatusType")).OrderBy(t => t.IX);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限审核状态");
            foreach (var item in months)
            {
                items.Add(item.CODE, item.NAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 申请审核
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Apply(string keyValues)
        {
            var list = keyValues.ToList<ApplyModel>();
            foreach (var item in list)
            {
                bll.Apply(item.XH, item.RWBH);
            }
            return Success("操作成功");
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="task">数据实例入参</param>
        /// <param name="rwbh">任务编号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveTask(string task, string rwbh)
        {
            List<MyTableDataModel> models = new List<MyTableDataModel>();
            List<Dictionary<string, string>> tasks = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(task);
            var datas = Session["BPC_SC004_DATA"] as IEnumerable<MyTableDataModel>;
            try
            {
                foreach (var item in tasks)
                {
                    var hcode = "";
                    foreach (var kv in item)
                    {
                        var commonLcode = Session["CommonLcode"] as string;
                        if (string.IsNullOrEmpty(commonLcode))
                        {
                            commonLcode = "";
                        }
                        if (commonLcode.Contains(kv.Key)) continue;
                        else if (kv.Key == "HCODE") hcode = kv.Value;
                        else
                        {
                            if (string.IsNullOrEmpty(kv.Value))
                            {
                                continue;
                            }
                            decimal ccvalue = decimal.Parse(kv.Value.Trim());
                            if (datas.Where(d => d.HCODE == hcode && d.LCODE == kv.Key && d.CCVALUE == ccvalue).Count() <= 0)
                            {
                                models.Add(new MyTableDataModel
                                {
                                    HCODE = hcode,
                                    LCODE = kv.Key,
                                    CCVALUE = ccvalue
                                });
                                //bll.SaveMyTableData(new MyTableDataModel
                                //{
                                //    HCODE = hcode,
                                //    LCODE = kv.Key,
                                //    CCVALUE = ccvalue
                                //}, rwbh);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return Error("当前表格包含非数值类型的数据，请重新输入！");
            }
            bll.SaveMyTableData(models, rwbh);
            return Success("操作成功");
        }

        /// <summary>
        /// 复制上期数据
        /// </summary>
        /// <param name="rwbh">任务编号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CopyTask(string rwbh)
        {
            var datas = bll.GetCollectionTablePreData(rwbh);
            if (datas == null)
            {
                return ToJsonResult("");
            }
            return ToJsonResult(datas);
        }
        #endregion
    }
}
