using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Util;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TableLogicManageController : MvcControllerBase
    {
        private readonly BpcSc006BLL _bpcSc006Bll = new BpcSc006BLL();
        private readonly BpcSp001Bll _bpcSp001Bll = new BpcSp001Bll();

        /// <summary>
        /// 采集表逻辑配置
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
        public ActionResult EditLogic(string keyValue)
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
            _bpcSc006Bll.DeleteRecord(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="enabled"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ModifyStatus(string keyValue, bool enabled)
        {
            _bpcSc006Bll.ModifyStatus(keyValue, enabled);
            return Success("操作成功");
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
            var data = _bpcSc006Bll.GetPageList(pagination, queryJson);
            var entities = data as BpcSc006Entity[] ?? data.ToArray();
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
            var entity = _bpcSc006Bll.GetEntity(keyValue);
            var table = _bpcSp001Bll.GetEntity(entity.CJBBM);
            if (table != null)
            {
                entity.CJBMC = table.CJBMC;
            }

            return ToJsonResult(entity);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(BpcSc006Entity entity)
        {
            if (entity.XH.IsEmpty() &&_bpcSc006Bll.ExistsRecord(entity.CJBBM))
            {
                return Error("该采集表已配置");
            }
            _bpcSc006Bll.AddOrUpdateRecord(entity);
            return Success("操作成功");
        }
    }
}