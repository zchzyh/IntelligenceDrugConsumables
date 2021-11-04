using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Busines.PerfScheme;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.Entity.PerfScheme.ViewModel;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfScheme.Controllers
{

    /// <summary>
    /// 方案设置
    /// </summary>
    public class PerfSchemeSettingController : MvcControllerBase
    {
        PerfSchemeSettingBLL bll;
        AppraiseSeetingBLL appraisebll;
        DictionaryBLL dicbll;
        SystemBLL sysbll;
        YearSettingBLL yearBll;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PerfSchemeSettingController()
        {
            bll = new PerfSchemeSettingBLL();
            appraisebll = new AppraiseSeetingBLL();
            dicbll = new DictionaryBLL();
            sysbll = new SystemBLL();
            yearBll = new YearSettingBLL();
        }

        #region 基础绩效方案设置

        #region 视图功能

        /// <summary>
        /// 绩效方案基本设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 新增/修改基础方案
        /// </summary>
        /// <param name="keyValue">方案编号</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditBasePerfScheme(string keyValue)
        {
            return View();
        }
        /// <summary>
        /// 指标配置
        /// </summary>
        /// <param name="keyValue">方案编号</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult PerfSchemeKPISetting(string keyValue)
        {
            return View();
        }
        /// <summary>
        /// 打印基础方案
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult PrintPerfScheme(string keyValue)
        {
            return View();
        }
        #endregion 视图功能

        #region 获取数据
        /// <summary>
        /// 获取绩效方案名称下拉框
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPerfSchemeNameJson(bool forSearch = true)
        {
            var famcs = bll.GetPerfSchemeNameList(GetDefaultPagination("FABH"), null);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限科室");
            foreach (var item in famcs)
            {
                items.Add(item.FABH, item.FAMC);
                ;
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取考核对象下拉框
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDeptListJson(bool forSearch = true)
        {
            var deptnames = yearBll.GetDepartmentBms("");
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限科室");
            foreach (var item in deptnames)
            {
                if (!items.ContainsKey(item.DEPTID))
                    items.Add(item.DEPTID, item.DEPTNAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }
        /// <summary>
        /// 基础方案列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetPerfSchemeListJson(Pagination pagination, string queryJson)
        {
            var metas = bll.GetPerfSchemedataList(pagination, queryJson);
            return ToJsonResult(metas);
        }
        /// <summary>
        /// 获取所有定量定性指标列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetKPIListJson(Pagination pagination, string queryJson)
        {
            var metas = bll.GetKPIListJson(pagination, queryJson);
            var queryParam = queryJson.ToJObject();
            if (!queryParam["print"].IsEmpty() && queryParam["print"].ToString().ToLower() == "true")
            {
                metas = metas.Where(n => !string.IsNullOrEmpty(n.XH));
            }
            metas = metas.Where(n => !string.IsNullOrEmpty(n.ZBGS));
            return ToJsonResult(metas);
        }
        /// <summary>
        /// 获取基础绩效方案的数据列表，给到编辑页面
        /// </summary>
        /// <param name="keyValue">评价方法编号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetBasePerfSchemeData(string keyValue)
        {
            var meta = bll.GetBasePerfSchemeEntity(keyValue);
            return ToJsonResult(new
            {
                FABH = meta.FABH,
                FAMC = meta.FAMC,
                JXBM = meta.JXBM,
                SYND = meta.SYND,
                STATUS = meta.STATUS,
                SYDX = meta.SYDX,
                CREATOR = meta.CREATOR,
                REMARK = meta.REMARK
            });
        }
        #endregion 获取数据

        #region 提交数据
        /// <summary>
        /// 保存基础方案信息
        /// </summary>
        /// <param name="bpepa001"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveBasePerfScheme(BpePA001Entity bpepa001)
        {
            if (string.IsNullOrEmpty(bpepa001.FABH) || bpepa001.FABH.Contains("&nbsp;"))
            {
                //bpepa001.FABH = VerifyCode.GetRandomCode();
            }
            if (string.IsNullOrEmpty(bpepa001.CREATOR))
            {
                bll.AddBasePerfScheme(bpepa001);
            }
            else
            {
                bll.ModifyBasePerfScheme(bpepa001.FABH, bpepa001);
            }
            return Success("操作成功");
        }
        /// <summary>
        /// 删除基础绩效方案+方案对应的指标明细数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelBasePerfScheme(string keyValue)
        {
            bll.DelBasePerfScheme(keyValue);
            bll.DelBasePerfSchemeKPI(keyValue);
            return Success("删除成功");
        }
        /// <summary>
        /// 删除基础绩效方案对应的指标明细数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelBasePerfSchemeKPI(string keyValue)
        {
            bll.DelBasePerfSchemeKPI(keyValue);
            return Success("删除成功");
        }
        /// <summary>
        /// 保存指标配置
        /// </summary>
        /// <param name="KPI"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult SavePerfSchemeKPI(string KPI, string keyValue)
        {
            List<Dictionary<string, string>> KPIIDS = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(KPI);
            List<BpePA002Entity> meta = new List<BpePA002Entity>();
            foreach (var item in KPIIDS)
            {
                meta.Add(new BpePA002Entity
                {
                    XH = VerifyCode.GetRandomCode(),
                    FABH = keyValue,
                    KPIBH = item["id"],
                    ZBLX = item["zblx"],
                    //CREATOR="",
                    //CREATEAT="",
                    //MODIFOR="",
                    //MODIFYAT="",
                    STATUS = "1"
                });
            }
            bll.DelBasePerfSchemeKPI(keyValue);
            bll.SaveSchemeKpiList(meta);
            return Success("指标配置成功");
        }
        #endregion 提交数据

        #endregion 基础绩效方案设置


        #region 科室绩效方案设置
        #region 视图功能

        /// <summary>
        /// 部门方案设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DepSchemeSetting()
        {
            return View();
        }

        /// <summary>
        /// 部门方案指标查看
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DepSchemeZB(string jgfabh, string jxbm, string jgbm)
        {
            return View();
        }

        /// <summary>
        /// 新增-科室绩效方案配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditDepSchemeSettingTable(string keyValue)
        {
            return View();
        }
        #endregion 视图功能

        #region 获取数据
        /// <summary>
        /// 对象方案指标列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetDepSchemeZBListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetDepZBList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = 1,//pagination.total,
                page = pagination.page,
                records = data.Count(),// pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }
        /// <summary>
        /// 获取科室绩效方案的数据列表，给到编辑页面
        /// </summary>
        /// <param name="keyValue">评价方法编号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDepPerfSchemeData(string keyValue)
        {
            var meta = bll.GetDepSchemeEntity(keyValue);
            return ToJsonResult(new
            {
                JGFABH = meta.JGFABH,
                JGFAMC = meta.JGFAMC,
                JGBM = meta.JGBM,
                FABH = meta.FABH,
                JXBM = meta.JXBM,
                STATUS = meta.STATUS,
                CREATOR = meta.CREATOR,
                MODIFOR = meta.MODIFOR
            });
        }
        /// <summary>
        /// 科室绩效方案明细列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetDepSchemeListJson(Pagination pagination, string queryJson)
        {
            var metas = bll.GetDepSchemeDataList(pagination, queryJson);
            return ToJsonResult(metas);
        }

        #endregion 获取数据


        #region 提交数据

        /// <summary>
        /// 保存方案的科室列表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="fabh"></param>
        /// <param name="tableIds"></param>
        /// <param name="jgfamc"></param>
        /// <param name="KPI"></param>
        /// <param name="jgfabh"></param>
        /// <returns></returns>
        public ActionResult SaveSchemeDep(string fabh, string jxbm,string jgfabh,string jgfamc,string jgbm,string status)
        {
            if (fabh.IsEmpty())
            {
                return Error("请选择一个方案");
            }

            bll.SaveSchemeDepList( fabh,jxbm,jgfabh,jgfamc,jgbm,status);

            return Success("科室绑定成功");
        }
        /// <summary>
        /// 保存科室绩效方案信息
        /// </summary>
        /// <param name="bpepa003"></param>
        /// <returns></returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[AjaxOnly]
        //public ActionResult SaveDepPerfScheme(BpePA003Entity bpepa003)
        //{
        //    if (string.IsNullOrEmpty(bpepa003.JGFABH) || bpepa003.FABH.Contains("&nbsp;"))
        //    {
        //        bpepa001.FABH = VerifyCode.GetRandomCode();
        //    }
        //    if (string.IsNullOrEmpty(bpepa003.CREATOR))
        //    {
        //        bll.AddDepPerfScheme(bpepa003);
        //    }
        //    else
        //    {
        //        bll.ModifyDepPerfScheme(bpepa003.JGFABH, bpepa003);
        //    }
        //    return Success("操作成功");
        //}


        /// <summary>
        /// 删除科室绩效方案+方案对应的指标明细数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelDepPerfScheme(string keyValue)
        {
            bll.DelDepPerfScheme(keyValue);
            bll.DelDepPerfSchemeKPI(keyValue);
            return Success("删除成功");
        }
        /// <summary>
        /// 删除基础绩效方案对应的指标明细数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelDepPerfSchemeKPI(string keyValue)
        {
            bll.DelDepPerfSchemeKPI(keyValue);
            return Success("删除成功");
        }

        #endregion 提交数据

        #endregion 科室绩效方案设置


        #region 绩效方案权重设置

        #region 视图功能
        /// <summary>
        /// 绩效方案权重设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult PerfSchemeWeightSetting()
        {
            return View();
        }
        #endregion 视图功能

        #region 获取数据
        /// <summary>
        /// 获取绩效基础方案编码列表
        /// </summary>
        /// <param name="queryJson">请求参数</param>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPerfSchemedataBmsJson(string queryJson, bool forSearch = false)
        {
            var perfSchemedatas = bll.GetPerfSchemedataBms(queryJson);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "全部方案");
            foreach (var item in perfSchemedatas)
            {
                items.Add(item.FABH, item.FAMC);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取绩效权重设置列表
        /// </summary>
        /// <param name="fabh">方案编号</param>
        /// <param name="level">指标等级</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPerfSchemeWeightList(string fabh, string level)
        {
            var watch = CommonHelper.TimerStart();
            var perfSchemeWeightListdatas = bll.GetPerfSchemeWeightList(fabh, level);
            var totalCount = perfSchemeWeightListdatas.Count();
            var JsonData = new
            {
                rows = perfSchemeWeightListdatas,
                total = totalCount,
                page = 1,
                records = totalCount,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存基本方案绩效权重设置列表
        /// </summary>
        /// <param name="perfSchemeWeightdataList">基本方案绩效权重设置列表</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SavePerfSchemeWeightdata(string perfSchemeWeightdataList)
        {
            if (!string.IsNullOrEmpty(perfSchemeWeightdataList))
            {
                var list = perfSchemeWeightdataList.ToList<PerfSchemeWeightModel>();
                bll.ModifyPerfSchemeWeightList(list);
                return Success("保存成功。");
            }
            return Error("没有需要保存的记录。");
        }

        #endregion 提交数据

        #endregion 绩效方案权重设置


        #region 绩效方案评价设置

        #region 视图功能
        /// <summary>
        /// 绩效方案评价设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DepSchemeAppraiseSetting()
        {
            return View();
        }
        #endregion 视图功能

        #region 获取数据
        /// <summary>
        /// 获取部门绩效方案编码列表
        /// </summary>
        /// <param name="queryJson">请求参数</param>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDeptSchemedataBmsJson(string queryJson, bool forSearch = true)
        {
            var deptSchemedatas = bll.GetPerfDeptSchemedataBms(queryJson);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "全部方案");
            foreach (var item in deptSchemedatas)
            {
                items.Add(item.JGFABH, item.JGFAMC);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取部门绩效评价设置列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPerfDeptSchemeAppraisedataList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var perfDeptSchemeAppraisedatas = bll.GetPerfDeptSchemeAppraisedataList(pagination, queryJson);
            var JsonData = new
            {
                rows = perfDeptSchemeAppraisedatas,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取评价方法编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAppraisedataBmList(string queryJson)
        {
            var appraisedataBmList = appraisebll.GetAppraisedataBmList(queryJson);
            return ToJsonResult(appraisedataBmList);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存部门方案评价设置列表
        /// </summary>
        /// <param name="appraisedataList">部门方案评价设置列表</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveDeptSchemeAppraisedata(string appraisedataList)
        {
            if (!string.IsNullOrEmpty(appraisedataList))
            {
                var list = appraisedataList.ToList<SavePerfDeptSchemeAppraiseModel>();
                foreach (var item in list)
                {
                    bll.ModifyPerfDeptSchemeAppraisedataForm(item.JGFABH, item.PJFFBH);
                }
                return Success("保存成功。");
            }
            return Error("没有需要保存的记录。");
        }

        #endregion 提交数据

        #endregion 绩效方案评价设置
    }
}
