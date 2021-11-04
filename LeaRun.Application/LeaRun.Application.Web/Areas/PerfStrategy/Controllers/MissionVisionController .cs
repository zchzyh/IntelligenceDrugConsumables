using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.PerfStrategy;
using LeaRun.Application.Entity.PerfStrategy;
using LeaRun.Application.Entity.PerfStrategy.ViewModel;
using LeaRun.Util;
using Newtonsoft.Json;

namespace LeaRun.Application.Web.Areas.PerfStrategy.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class MissionVisionController : MvcControllerBase
    {
        private readonly BpeVa001BLL _bpeVa001Bll = new BpeVa001BLL();

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
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditMissionVision(string keyValue)
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
        public ActionResult DeleteRecord(string keyValue)
        {
            _bpeVa001Bll.DeleteRecord(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = _bpeVa001Bll.GetPageList(pagination, queryJson);
            var entities = data as BpeVa001Model[] ?? data.ToArray();
            var jsonData = new
            {
                rows = entities,
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
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetEntityJson(string keyValue)
        {
            var entity = _bpeVa001Bll.GetRecord(keyValue);
            return ToJsonResult(entity);
        }

        /// <summary>
        /// 获取使命远景列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMissionVisionList(string jxbm)
        {
            var dimensions = _bpeVa001Bll.GetPageList(GetDefaultPagination("CREATEAT"), JsonConvert.SerializeObject(new { jxbm}));
            return Content(dimensions.ToJson());
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(BpeVa001Entity entity)
        {
            _bpeVa001Bll.AddOrUpdateRecord(entity);
            return Success("操作成功");
        }
    }
}