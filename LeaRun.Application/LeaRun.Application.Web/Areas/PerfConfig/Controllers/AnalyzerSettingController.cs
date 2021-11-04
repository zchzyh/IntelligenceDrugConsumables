using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfConfig.Controllers
{
    /// <summary>
    /// 绩效设置-分析器设置
    /// </summary>
    public class AnalyzerSettingController : MvcControllerBase
    {
        readonly AnalyzerBLL bll;

        /// <summary>
        /// 
        /// </summary>
        public AnalyzerSettingController()
        {
            bll = new AnalyzerBLL();
        }

        #region 视图功能
        /// <summary>
        /// 数据项分析器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DataItem()
        {
            return View();
        }

        /// <summary>
        /// 元数据分析器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult MetaData()
        {
            return View();
        }

        /// <summary>
        /// 编辑分析器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Analyzer()
        {
            return View();
        }
        #endregion

        #region 数据项分析器

        #region 获取数据
        /// <summary>
        /// 数据项列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetDataItemListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetStandardDataList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }

        /// <summary>
        /// 分析器列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataItemAnalyzerListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetAnalyzerList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }

        /// <summary>
        /// 获取分析器
        /// </summary>
        /// <param name="fxqbm"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataItemAnalyzerJson(string fxqbm)
        {
            var analyzer = bll.GetAnalyzerEntity(fxqbm);
            return ToJsonResult(analyzer);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除分析器
        /// </summary>
        /// <param name="fxqbm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelDataItemAnalyzer(string fxqbm)
        {
            bll.ModifyAnalyzerForm(fxqbm, new BpcSM006Entity { STATUS = "0" });
            return Success("删除成功");
        }


        /// <summary>
        /// 保存分析器
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fxqbm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveDataItemAnalyzer(BpcSM006Entity entity, string fxqbm)
        {
            if (string.IsNullOrEmpty(entity.CREATOR))
                bll.CreateAnalyzerForm(entity);
            else
                bll.ModifyAnalyzerForm(fxqbm, entity);
            return Success("操作成功");
        }

        /// <summary>
        /// 关联数据项和分析器
        /// </summary>
        /// <param name="jcsjbm"></param>
        /// <param name="fxqbm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RelateDataItem(string jcsjbm, string fxqbm)
        {
            bll.StandardDataBindAnalyzer(jcsjbm, fxqbm);
            return Success("操作成功");
        }
        #endregion

        #endregion

        #region 元数据分析器

        #region 获取数据
        /// <summary>
        /// 数据项列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GeMetaDataListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetMetadataList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }

        /// <summary>
        /// 分析器列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public ActionResult GetMetaDataAnalyzerListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetAnalyzerList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }

        /// <summary>
        /// 获取分析器
        /// </summary>
        /// <param name="fxqbm"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMetaDataAnalyzerJson(string fxqbm)
        {
            var analyzer = bll.GetAnalyzerEntity(fxqbm);
            return ToJsonResult(analyzer);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除分析器
        /// </summary>
        /// <param name="fxqbm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelMetaDataAnalyzer(string fxqbm)
        {
            bll.ModifyAnalyzerForm(fxqbm, new BpcSM006Entity
            {
                STATUS = "0"
            });
            return Success("删除成功");
        }

        /// <summary>
        /// 保存分析器
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fxqbm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveMetaDataAnalyzer(BpcSM006Entity entity, string fxqbm)
        {
            if (string.IsNullOrEmpty(entity.CREATOR))
                bll.CreateAnalyzerForm(entity);
            else
                bll.ModifyAnalyzerForm(fxqbm, entity);
            return Success("操作成功");
        }

        /// <summary>
        /// 关联数据项和分析器
        /// </summary>
        /// <param name="jxbm"></param>
        /// <param name="metaCode"></param>
        /// <param name="fxqbm">重置时为空</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RelateMetaData(string jxbm, string metaCode, string fxqbm)
        {
            bll.MetadataBindAnalyzer(jxbm, metaCode, fxqbm);
            return Success("操作成功");
        }
        #endregion

        #endregion
    }
}
