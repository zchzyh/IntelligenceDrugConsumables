using LeaRun.Application.Cache;
using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Application.Busines.SettingManage;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TableFrequencyManageController : MvcControllerBase
    {
        private readonly BpcSm003BLL _bpcSm003Bll = new BpcSm003BLL();
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
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditPl(string keyValue)
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelRecord(string keyValue, string jxbm)
        {
            var yearObject = _yearSettingBll.GetYearSettingEntity(jxbm);
            if (yearObject == null)
            {
                return Error("当前年度不存在");
            }

            if (yearObject.YXZT == "1")
            {
                return Error("年度已启用,请勿删除");
            }
            _bpcSm003Bll.DelRecord(keyValue);
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
            _bpcSm003Bll.ModifyStatus(keyValue, enabled);
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
            var data = _bpcSm003Bll.GetPageList(pagination, queryJson);
            var bpcSm003Entities = data as BpcSm003Entity[] ?? data.ToArray();
            var queryParam = queryJson.ToJObject();
          
            FillEntities(bpcSm003Entities);
            if (!queryParam["CJPLName"].IsEmpty())
            {
                bpcSm003Entities = bpcSm003Entities.Where(m => m.PLMC.Contains(queryParam["CJPLName"].ToString())).ToArray();
            }
        
            var jsonData = new
            {
                rows = bpcSm003Entities,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(jsonData.ToJson());
        }

        private void FillEntities(IEnumerable<BpcSm003Entity> list)
        {
            var dataItemList = _dictionaryBll.GetStandardCodes("PMS.2001");
            foreach (var entity in list)
            {
                var item = dataItemList.FirstOrDefault(l => l.CODE == entity.PLBH);
                if (item != null)
                {
                    entity.PLMC = item.NAME;
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCjplJson(string keyValue)
        {
            var entity = _bpcSm003Bll.GetEntity(keyValue);
            return ToJsonResult(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IsActivateYear(string jxbm)
        {
            var yearObject = _yearSettingBll.GetYearSettingEntity(jxbm);
            if (yearObject.YXZT == "1")
            {
                return ToJsonResult(true);
            }

            return ToJsonResult(false);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(BpcSm003Entity entity)
        {
            if (entity.XH.IsEmpty())
            {
                if (_bpcSm003Bll.ExistsRecord(entity.ND, entity.PLBH))
                {
                    return Error("当前年度的频率已经存在！");
                }
            }
            else
            {
                var yearObject = _yearSettingBll.GetYearSettingEntity(entity.JXBM);
                if (yearObject.YXZT == "1")
                {
                    return Error("年度已启用,不允许修改");
                }
            }
            _bpcSm003Bll.AddOrUpdateRecord(entity);
            return Success("操作成功");
        }
    }
}