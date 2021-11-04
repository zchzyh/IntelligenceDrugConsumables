using LeaRun.Application.Busines.PerfGoal;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfGoal.Controllers
{
    /// <summary>
    /// 绩效目标-目标值设置
    /// </summary>
    public class GoalSettingController : MvcControllerBase
    {
        PerfGoalBLL bll;
        /// <summary>
        /// 
        /// </summary>
        public GoalSettingController()
        {
            bll = new PerfGoalBLL();
        }

        #region 单位目标值设置

        #region 视图功能
        /// <summary>
        /// 单位目标值设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 修改目标值
        /// </summary>
        /// <param name="keyValue">目标值序号</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditGoal(string keyValue)
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 目标值设置
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGoalJson(string keyValue)
        {
            var entity = bll.GetQuantitativeGoalEntity(keyValue);
            return ToJsonResult(entity);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 目标值申请
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(string keyValue)
        {
            var entity = bll.GetQuantitativeGoalEntity(keyValue);
            if (entity.SQZT == 1)
            {
                entity.SQZT = 0;
            }
            else if (entity.SQZT == 0)
            {
                entity.SQZT = 1;
            }
            bll.ApplyQuantitativeGoal(entity.JGFABH, entity.SQZT);
            return Success("操作成功");
        }

        /// <summary>
        /// 保存目标值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveGoal(BpeTA004Entity entity)
        {
            if (string.IsNullOrEmpty(entity.XH))
                bll.CreateQuantitativeGoalForm(entity);
            else
            {
                var newData = bll.GetQuantitativeGoalEntity(entity.XH);

                if (entity.HGMBZ == null)
                {
                    entity.HGMBZ = 0;
                }
                if (entity.YXMBZ == null)
                {
                    entity.YXMBZ = 0;
                }
                newData.HGMBZ = entity.HGMBZ;
                newData.YXMBZ = entity.YXMBZ;
                newData.YLMBZ = (entity.HGMBZ + entity.YXMBZ) / 2;
                newData.BGMBZ = entity.BGMBZ;

                bll.ModifyQuantitativeGoalForm(entity.XH, newData);
            }
            return Success("操作成功");
        }
        #endregion

        #endregion

        #region 单位目标值审核

        #region 视图功能
        /// <summary>
        /// 单位目标值审核
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ForAuditList()
        {
            return View();
        }

        /// <summary>
        /// 审核目标值
        /// </summary>
        /// <param name="keyValues">单位方案编号</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AuditForm(string keyValues)
        {
            return View();
        }

        /// <summary>
        /// 审核目标值详情
        /// </summary>
        /// <param name="jgfabh">单位方案编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="orgname">部门名称</param>
        /// <param name="orgcode">部门编码</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DetailForm(string jgfabh, string jxbm, string orgname, string orgcode)
        {
            ViewData["orgname"] = orgname;
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 目标值审核列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetAuditListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var lst = bll.GetQuantitativeGoalAuditList(pagination, queryJson);
            var JsonData = new
            {
                rows = lst,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 目标值审核
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAuditJson(string keyValues)
        {
            var vals = keyValues.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (vals.Length == 1)
                return ToJsonResult(bll.GetQuantitativeGoalAuditEntity(vals[0]));
            else return ToJsonResult(null);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 审核目标值
        /// </summary>
        /// <param name="keyValues"></param>
        /// <param name="REMARK"></param>
        /// <param name="STATUS"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult AuditGoal(string keyValues, string REMARK, string STATUS)
        {
            foreach (var item in keyValues.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                var old = bll.GetQuantitativeGoalAuditEntity(item);
                old.STATUS = STATUS;
                old.REMARK = REMARK;
                bll.ModifyQuantitativeGoalForm(item, old);
            }
            return Success("操作成功");
        }

        #endregion

        #endregion

    }
}
