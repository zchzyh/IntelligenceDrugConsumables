using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TableRowColManageController : MvcControllerBase
    {
        private readonly BpcSc001BLL _bpcSc001Bll = new BpcSc001BLL();
        private readonly BpcSc002BLL _bpcSc002Bll = new BpcSc002BLL();
        private readonly BpcSc003BLL _bpcSc003Bll = new BpcSc003BLL();
        private readonly BpcSp003BLL _bpcSp003Bll = new BpcSp003BLL();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbBm"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RowSetting(string tbBm, string year)
        {
            return View();
        }

        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ColSetting(string tbBm, string year)
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult TablePreview(string tbBm, string year)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelRecord(string keyValue)
        {
         //   var yearObject = _yearSettingBll.GetYearSettingEntity(jxbm);
            _bpcSc003Bll.DeleteRecord(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetRowColPageList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var list = _bpcSp003Bll.GetRowColPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(jsonData.ToJson());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetRowDataSort(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var list = _bpcSc002Bll.GetRowDataSort(pagination, queryJson);

            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(jsonData.ToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="year"></param>
        /// <param name="tbBm"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetColSetting(Pagination pagination, string year, string tbBm)
        {
            var watch = CommonHelper.TimerStart();
            var list = _bpcSc003Bll.GetList(pagination, year, tbBm);

            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(jsonData.ToJson());
        }

        /// <summary>
        /// 取行字典
        /// </summary>
        /// <param name="rowName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetRowDicListJson(string rowName)
        {
            var year = _bpcSc001Bll.GetList(rowName);
            return ToJsonResult(year);
        }

        /// <returns></returns>
        [HttpGet]
        public ActionResult GetColInfo(string keyValue)
        {
            var year = _bpcSc003Bll.GetEntity(keyValue);
            return ToJsonResult(year);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tableNo"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetHeadersJson(string year,string tableNo)
        {
            var headers = _bpcSc003Bll.GetTableHeader(year, tableNo);
            Session["GridHeaders"] = headers.Select(h => h.LCODE);
            return ToJsonResult(headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tableNo"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListJson(string year, string tableNo)
        {
            List<Dictionary<string, object>> models = new List<Dictionary<string, object>>();
            var lcodes = (Session["GridHeaders"] as IEnumerable<string>).ToList();
            if (lcodes.Count > 0)
            {
                var rows = _bpcSc003Bll.GetTableRow(year, tableNo);
                //  var datas = _bpcSc003Bll.GetCollectionTableData(keyValue);
                //Session["BPC_SC004_DATA"] = datas;
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
                        if (lcodes.Count < maxGrade) break;
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

                        //#region 添加行录入数据
                        //for (int i = maxGrade; i < lcodes.Count; i++)
                        //{
                        //    var data = datas.Where(d => d.HCODE == item.HCODE && d.LCODE == lcodes[i]).FirstOrDefault();
                        //    if (data == null)
                        //    {
                        //        if (!string.IsNullOrEmpty(lcodes[i]))
                        //        {
                        //            row.Add(lcodes[i], "");
                        //        }
                        //        continue;
                        //    }
                        //    row.Add(lcodes[i], data.CCVALUE);
                        //}
                        //#endregion

                        models.Add(row);
                    }
                    Session["CommonLcode"] = commonLcode;
                }
                //else
                //{
                //    var hcodes = datas.Select(d => d.HCODE);
                //    foreach (var hcode in hcodes)
                //    {
                //        Dictionary<string, object> row = new Dictionary<string, object>();
                //        row.Add("HCODE", hcode);
                //        for (int i = 0; i < lcodes.Count; i++)
                //        {
                //            var data = datas.Where(d => d.HCODE == hcode && d.LCODE == lcodes[i]).FirstOrDefault();
                //            if (data == null)
                //            {
                //                row.Add(lcodes[i], "");
                //                continue;
                //            }
                //            row.Add(lcodes[i], data.CCVALUE);
                //        }
                //    }
                //}
            }

            return ToJsonResult(models);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowName"></param>
        /// <param name="tbBm"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTableRowTreeJson(string rowName, string tbBm, string year)
        {
            var treeList = GetTreeList(rowName, tbBm, year);
            return Content(treeList.TreeToJson());
        }

        private List<TreeEntity> GetTreeList(string rowName, string tbBm, string year)
        {
            var rowList = _bpcSc001Bll.GetList(rowName);
            var tableRowList = _bpcSc002Bll.GetList(year, tbBm).ToList();
            var treeList = new List<TreeEntity>();
            foreach (var item in rowList)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = rowList.Count(t => t.PARENT == item.HXBM) == 0 ? false : true;
                tree.id = item.HXBM;
                tree.text = item.NAME.Trim();
                tree.value = item.HXBM;
                tree.isexpand = false;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = hasChildren;
                tree.parentId = string.IsNullOrWhiteSpace(item.PARENT) ? "0" : item.PARENT;
                tree.img = "fa fa-sitemap";
                if (tableRowList.Exists(t => t.HXBM == item.HXBM))
                {
                    tree.checkstate = 1;
                    var parentItem = treeList.FirstOrDefault(l => l.id == tree.parentId);
                    if (parentItem != null) parentItem.checkstate = 1;
                }

                treeList.Add(tree);
            }

            return treeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tbBm"></param>
        /// <param name="hxbms"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveRowSetting(string year, string tbBm, string hxbms)
        {
            var entities = new List<BpcSc002Entity>();
            string[] hxbm = hxbms.Split(',');
            foreach (var bm in hxbm)
            {
                BpcSc002Entity entity = new BpcSc002Entity {ND = year, CJBBM = tbBm, HXBM = bm, STATUS = "1"};
                entities.Add(entity);
            }

            _bpcSc002Bll.SaveData(year, tbBm, entities);
            return Success("操作成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveColSetting(BpcSc003Entity entity)
        {
            _bpcSc003Bll.SaveData(entity);
            return Success("操作成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tbBm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CopyLastYearRowSetting(string year, string tbBm)
        {
            _bpcSc002Bll.CopyLastYearRowSetting(year);
            return Success("操作成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tbBm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CopyLastYearColSetting(string year, string tbBm)
        {
            _bpcSc003Bll.CopyLastYearColSetting(year);
            return Success("操作成功");
        }
    }
}