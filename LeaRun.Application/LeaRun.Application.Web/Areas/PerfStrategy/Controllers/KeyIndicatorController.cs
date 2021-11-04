using System.Collections.Generic;
using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Busines.PerfConfig;
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
    public class KeyIndicatorController : MvcControllerBase
    {
        private readonly BpeTa003BLL _bpeVa003Bll = new BpeTa003BLL();
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
        public ActionResult EditKeyIndicator(string keyValue)
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
            var entities = data as BpeTa003Model[] ?? data.ToArray();
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
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetQuantifyPageList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = _bpeVa003Bll.GetQuantifyPageList(pagination, queryJson);
            var entities = data as BpeTa002Model[] ?? data.ToArray();
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
        /// <param name="entitiesJson"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string entitiesJson)
        {
           var entities= JsonConvert.DeserializeObject<List<BpeTa003Entity>>(entitiesJson);
            _bpeVa003Bll.AddOrUpdateRecord(entities);
            return Success("操作成功");
        }
    }
}