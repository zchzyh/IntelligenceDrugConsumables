using System.Collections.Generic;
using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using LeaRun.Util;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Util.Extension;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 采集表年度管理
    /// </summary>
    public class TableYearManageController : MvcControllerBase
    {
        private readonly BpcSp003BLL _bpcSp003Bll = new BpcSp003BLL();

        #region 视图功能

        /// <summary>
        /// 采集表年度管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region 获取数据

        #region 采集年度列表

        /// <summary>
        /// 采集年度列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var list = _bpcSp003Bll.GetPageList(pagination, queryJson);
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

        #endregion

        /// <summary>
        /// 单个年度信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetEntityJson(string keyValue)
        {
            var year = _bpcSp003Bll.GetEntity(keyValue);
            return ToJsonResult(year);
        }

        #endregion

        #region 保存数据

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="tableIds">多个表Id,用逗号分隔</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveData(string year, string tableIds)
        {
            if (year.IsEmpty())
            {
                return Error("请选择其中一项记录");
            }
            var entities = new List<BpcSp003Entity>();
            var tbIds = tableIds.Split(',');
            foreach (var id in tbIds)
            {
                if (id.Length <= 3)
                    continue;
                var entity = new BpcSp003Entity {ND = year, CJBBM = id, STATUS = "1"};
                entities.Add(entity);
            }

            _bpcSp003Bll.SaveForm(year,entities);
            return Success("操作成功");
        }

        #endregion
    }
}