using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Busines.PerfStrategy;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Entity.PerfStrategy;
using LeaRun.Application.Entity.PerfStrategy.ViewModel;
using LeaRun.Util;
using Newtonsoft.Json;

namespace LeaRun.Application.Web.Areas.PerfStrategy.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class StrategicThemesController : MvcControllerBase
    {
        private readonly BpeVa003BLL _bpeVa003Bll = new BpeVa003BLL();
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
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditTheme(string keyValue)
        {
            var yearObject = new BpcSp003BLL().GetActiveYearSetting();
            ViewBag.ActionYear = yearObject.JXBM;
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
            _bpeVa003Bll.DeleteRecord(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 获取维度
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDimensionList()
        {
           var dimensions= _dictionaryBll.GetDimensionalities(GetDefaultPagination("BSCBH"),"");
           return Content(dimensions.ToJson());

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        public ActionResult GetListByYear(string jxbm)
        {
            var themes = _bpeVa003Bll.GetPageList(GetDefaultPagination("CREATEAT"), JsonConvert.SerializeObject(new { jxbm }));
            return Content(themes.ToJson());
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
            var data = _bpeVa003Bll.GetPageList(pagination, queryJson);
            var entities = data as BpeVa003Model[] ?? data.ToArray();
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
            var entity = _bpeVa003Bll.GetRecord(keyValue);
            return ToJsonResult(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetRecordModelJson(string keyValue)
        {
            var entity = _bpeVa003Bll.GetRecordModel(keyValue);
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
        public ActionResult SaveForm(BpeVa003Entity entity)
        {
            _bpeVa003Bll.AddOrUpdateRecord(entity);
            return Success("操作成功");
        }
    }
}