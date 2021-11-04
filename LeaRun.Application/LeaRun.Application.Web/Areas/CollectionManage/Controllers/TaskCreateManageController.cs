using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using LeaRun.Util;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 采集权限分配
    /// </summary>
    public class TaskCreateManageController : MvcControllerBase
    {
        private readonly BpcSp002BLL _bpcSp002Bll = new BpcSp002BLL();
        private readonly YearSettingBLL _yearSettingBll = new YearSettingBLL();
        private readonly DictionaryBLL _dictionaryBll = new DictionaryBLL();
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
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var list = _bpcSp002Bll.GetPageList(pagination, queryJson);
            FillTaskList(list);
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

        private void FillTaskList(IEnumerable<TaskInfoModel> taskList)
        {
            var plList = GetCjplList();
            foreach (var task in taskList)
            {
                var list = plList.FirstOrDefault(p => p.CODE == task.CJPL);
                if (list != null) task.CJPLMC = list.NAME;
            }

        }

        /// <summary>
        /// 采集频率
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCjplJson()
        {
            var codeList = GetCjplList();
            return Content(codeList.ToJson());
        }
        private IEnumerable<S103CodeEntity> GetCjplList()
        {
            return _dictionaryBll.GetStandardCodes("PMS.2001");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forSearch"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetYearStrJson(bool forSearch = true)
        {
            var years = _yearSettingBll.GetYearBms().OrderByDescending(t => t.JXND);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "全部");
            foreach (var item in years)
            {
                items.Add(item.JXBM, item.JXND);
            }

            return ToJsonResult(SetComboBoxValue(items));
        }

        private List<TreeEntity> FillYearTreeTable(List<BpcSM002Entity> tableTypes, List<BpcSp001Entity> yearTables)
        {
            var treeList = new List<TreeEntity>();
            //过滤列表
            foreach (var item in tableTypes)
            {
                var tbList = yearTables.Where(t => t.SSLB == item.TYPEID).ToList();

                TreeEntity tree = new TreeEntity();
                bool hasChildren = yearTables.Count(t => t.SSLB == item.TYPEID) == 0 ? false : true;
                tree.id = "C_" + item.TYPEID;
                tree.text = item.NAME.Trim();
                tree.value = "0";
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = hasChildren;
                tree.parentId = "0";
                tree.img = "fa fa-sitemap";
                treeList.Add(tree);


                foreach (var tb in tbList)
                {
                    TreeEntity subTree = new TreeEntity();
                    subTree.id = tb.CJBBM;
                    subTree.text = tb.CJBMC.Trim();
                    subTree.value = tb.CJBBM;
                    subTree.isexpand = true;
                    subTree.complete = true;
                    subTree.showcheck = true;
                    subTree.hasChildren = false;
                    subTree.parentId = tree.id;
                    subTree.title = tb.CJBQM.Trim();
                    //tree.img = "fa fa-sitemap";
                    treeList.Add(subTree);
                }
            }

            return treeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeEntites"></param>
        /// <param name="userTables"></param>
        /// <returns></returns>
        public void FillCheckTable(List<TreeEntity> treeEntites, List<BpcSp004Entity> userTables)
        {
            foreach (var item in treeEntites)
            {
                if (userTables.Exists(t => t.CJBBM == item.id))
                {
                    item.checkstate = 1;
                    var parentItem = treeEntites.FirstOrDefault(l => l.id == item.parentId);
                    if (parentItem != null) parentItem.checkstate = 1;
                }
            }
        }


        /// <summary>
        /// 任务生成
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CreateTask(string jxbm)
        {
            var yearObject = _yearSettingBll.GetYearSettingEntity(jxbm);
            if (yearObject == null)
            {
                return Error("当前年度不存在");
            }

            if (yearObject.YXZT != "1")
            {
                return Error("当前年度没启用服务");
            }

            _bpcSp002Bll.CreateTask(jxbm, yearObject.JXND);
            return Success("操作成功");
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult checkTableOffice(string jxbm)
        {
            var yearObject = _yearSettingBll.GetYearSettingEntity(jxbm);
            if (yearObject == null)
            {
                return Error("当前年度不存在");
            }

            if (yearObject.YXZT != "1")
            {
                return Error("当前年度没启用服务");
            }
            var tables= _bpcSp002Bll.GetNotExistsOfficeTable(yearObject.JXND);
            if (tables.Count < 1) return Content("");

            StringBuilder sb=new StringBuilder();
            sb.Append($"存在{tables.Count}个采集表未配置科室：</br>");
            for (int i = 0; i < tables.Count; i++)
            {
                sb.Append($"{tables[i]}</br>");
                if (i >= 10)
                {
                    sb.Append("...");
                    break;
                }
            }
            return ToJsonResult(sb.ToString());
        }
    }
}