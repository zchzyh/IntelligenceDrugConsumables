using System.Collections.Generic;
using System.Linq;
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
    public class TaskAdjustManageController : MvcControllerBase
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

        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditTask(string keyValue)
        {
            return View();
        }


        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditTasks(string keyValue)
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTaskInfo(string keyValue)
        {
            var year = _bpcSp002Bll.GetTaskInfo(keyValue);
            return ToJsonResult(year);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult AdjustTaskDate(BpcSp002Entity entity)
        {
            _bpcSp002Bll.AdjustTaskDate(entity);
            return Success("操作成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult AdjustTaskDates(string taskIds, string startDate, string endDate)
        {
            _bpcSp002Bll.AdjustTasksDate(taskIds, startDate, endDate);
            return Success("操作成功");
        }
    }
}