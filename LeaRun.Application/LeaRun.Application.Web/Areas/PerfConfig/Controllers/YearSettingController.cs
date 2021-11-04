using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfConfig.Controllers
{
    /// <summary>
    /// 绩效配置-年度设置
    /// </summary>
    public class YearSettingController : MvcControllerBase
    {
        YearSettingBLL bll;
        DictionaryBLL dicBll;

        /// <summary>
        /// 
        /// </summary>
        public YearSettingController()
        {
            bll = new YearSettingBLL();
            dicBll = new DictionaryBLL();
        }

        #region 绩效年度配置

        #region 视图功能
        /// <summary>
        /// 绩效年度配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增/编辑绩效年度
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditYear(string keyValue)
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取考核年度字符串
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetYearStrJson(bool forSearch = true)
        {
            var years = bll.GetYears();
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限年度");
            foreach (var item in years)
            {
                items.Add(item, item);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }
        /// <summary>
        /// 获取考核年度下拉框
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetYearsJson(bool forSearch = true)
        {
            var years = bll.GetYearSettings(GetDefaultPagination("JXND"), null);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限年度");
            foreach (var item in years)
            {
                items.Add(item.JXBM, item.JXND);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }
        /// <summary>
        /// 获取绩效年度列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">请求参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetYearListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var years = bll.GetYearSettings(pagination, queryJson);
            var JsonData = new
            {
                rows = years,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        [HttpGet]
        public ActionResult GetYearBmsJson(bool forSearch = true)
        {
            var years = bll.GetYearBms();
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限年度");
            foreach (var item in years)
            {
                items.Add(item.JXBM, item.JXND);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取绩效年度
        /// </summary>
        /// <param name="keyValue">年度序号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetYearJson(string keyValue)
        {
            var year = bll.GetYearSettingEntity(keyValue);
            return ToJsonResult(year);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除绩效年度
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelYear(string keyValue)
        {
            var year = bll.GetYearSettingEntity(keyValue);
            year.STATUS = "0";
            bll.ModifyYearSettingForm(keyValue, year);
            return Success("删除成功");
        }

        /// <summary>
        /// 启/停用绩效年度
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult YearEnabled(string keyValue)
        {
            var year = bll.GetYearSettingEntity(keyValue);
            if (year.YXZT == "0")
                year.YXZT = "1";
            else
                year.YXZT = "0";
            bll.ModifyYearSettingForm(keyValue, year);
            return Success("操作成功");
        }

        /// <summary>
        /// 保存绩效年度
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveYear(BpeSC001Entity entity)
        {
            if (entity.JZSJ.HasValue)
                entity.JZSJ = entity.JZSJ.Value.AddDays(1).AddSeconds(-1);
            if (string.IsNullOrEmpty(entity.JXBM))
                bll.CreateYearSettingForm(entity);
            else
                bll.ModifyYearSettingForm(entity.JXBM, entity);
            return Success("操作成功");
        }
        #endregion

        #endregion

        #region 考核对象管理

        #region 视图功能
        /// <summary>
        /// 考核对象管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ObjManager()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取绩效对象配置列表
        /// </summary>
        /// <param name="jxbm"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public ActionResult GetDepartmentTree(string jxbm, string root)
        {
            if (string.IsNullOrEmpty(root))
            {
                root = "ROOT";
            }
            else
            {
                root = HttpUtility.UrlDecode(root);
            }
            //TODO: 优化建议：添加缓存，减少重复获取数据转化Dictionary的操作
            var departmentList = bll.GetDepartments(jxbm).ToList();
            for (int i = 0; i < departmentList.Count; i++)
            {
                if (!string.IsNullOrEmpty(departmentList[i].DEPTID))
                {
                    departmentList[i].PARENTORG = departmentList[i].ORGCODE;
                    departmentList[i].ORGCODE = departmentList[i].DEPTID;
                    departmentList[i].MANAGERORGNAME = departmentList[i].DEPTNAME;
                }
            }
            var temp = departmentList.ToDictionary(data => data.ORGCODE, data => data.PARENTORG);

            return Content(GenerateTree(departmentList, temp, root));
        }

        /// <summary>
        /// 嵌套生成树
        /// </summary>
        /// <param name="assessments"></param>
        /// <param name="assessDic"></param>
        /// <param name="Orgcode"></param>
        /// <returns></returns>
        private string GenerateTree(List<AssessmentObjectModel> assessments, Dictionary<string, string> assessDic, string Orgcode)
        {
            var temp = (from a in assessments
                        where a.PARENTORG == Orgcode
                        select a).OrderBy(a => a.DEPTID).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (temp.Count > 0)
            {
                foreach (var item in temp)
                {
                    bool hasChildren = assessDic.ContainsValue(item.ORGCODE);
                    sb.Append("{");
                    sb.Append("\"id\":\"" + (item.DEPTID ?? ("orgCode" + item.ORGCODE)) + "\",");
                    sb.Append("\"text\":\"" + item.MANAGERORGNAME + "\",");
                    sb.Append("\"value\":\"" + item.XH + "\",");
                    if (hasChildren)
                    {
                        string childrenString = GenerateTree(assessments, assessDic, item.ORGCODE);
                        sb.Append("\"showcheck\":true,");
                        sb.Append("\"ChildNodes\":" + childrenString + ",");
                        sb.Append("\"checkstate\":" + (childrenString.IndexOf("\"checkstate\":1") > -1 ? "1" : "0") + ",");
                    }
                    else
                    {
                        sb.Append("\"showcheck\":" + (string.IsNullOrWhiteSpace(item.DEPTID) ? "false" : "true") + ",");
                        sb.Append("\"checkstate\":" + (string.IsNullOrEmpty(item.XH) ? "0" : "1") + ",");
                    }
                    sb.Append("\"isexpand\":true,");
                    sb.Append("\"complete\":true,");
                    sb.Append("\"hasChildren\":" + hasChildren.ToString().ToLower() + "");
                    sb.Append("},");
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// 嵌套生成树（2）
        /// </summary>
        /// <param name="assessments"></param>
        /// <param name="Orgcode"></param>
        /// <returns></returns>
        private string GenerateTree(List<AssessmentObjectModel> assessments, string Orgcode)
        {
            var orgCodes = (from a in assessments
                            where a.PARENTORG == Orgcode
                            select a.ORGCODE).Distinct().ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (orgCodes.Count > 0)
            {
                foreach (var orgCode in orgCodes)
                {
                    var org = assessments.First(i => i.ORGCODE == orgCode);

                    bool hasOrgs = assessments.Exists(i => i.PARENTORG == orgCode);

                    var depts = assessments.Where(i => i.ORGCODE == orgCode && !string.IsNullOrWhiteSpace(i.DEPTID)).ToList();
                    bool hasDepts = depts.Count > 0;
                    string deptsString = "";
                    if (hasDepts)
                    {
                        StringBuilder deptSb = new StringBuilder();

                        foreach (var dept in depts)
                        {
                            deptSb.Append("{");
                            deptSb.Append("\"id\":\"" + dept.DEPTID + "\",");
                            deptSb.Append("\"text\":\"" + dept.DEPTNAME + "\",");
                            deptSb.Append("\"value\":\"" + dept.DEPTID + "\",");
                            deptSb.Append("\"showcheck\":true,");
                            deptSb.Append("\"isexpand\":false,");
                            deptSb.Append("\"complete\":true,");
                            deptSb.Append("\"hasChildren\":false,");
                            deptSb.Append("\"checkstate\":" + (string.IsNullOrEmpty(dept.XH) ? "0" : "1"));
                            deptSb.Append("},");
                        }
                        deptSb = deptSb.Remove(deptSb.Length - 1, 1);
                        deptsString = deptSb.ToString();
                    }

                    sb.Append("{");
                    sb.Append("\"id\":\"" + org.ORGCODE + "\",");
                    sb.Append("\"text\":\"" + org.MANAGERORGNAME + "\",");
                    sb.Append("\"value\":\"\",");

                    string childrenString = "";
                    if (hasOrgs)
                    {
                        childrenString = GenerateTree(assessments.Where(i => i.PARENTORG == orgCode).ToList(), orgCode);

                        if (hasDepts)
                        {
                            childrenString = childrenString.Remove(childrenString.Length - 1, 1) + "," + deptsString + "]";
                        }
                    }
                    else
                    {
                        if (hasDepts)
                        {
                            childrenString = "[" + deptsString + "]";
                        }
                    }
                    sb.Append("\"ChildNodes\":" + (string.IsNullOrWhiteSpace(childrenString) ? "[]" : childrenString) + ",");
                    sb.Append("\"checkstate\":" + (childrenString.IndexOf("\"checkstate\":1") > -1 ? "1" : "0") + ",");
                    sb.Append("\"showcheck\":" + (hasOrgs || hasDepts || !string.IsNullOrWhiteSpace(org.DEPTID)).ToString().ToLower() + ",");
                    sb.Append("\"isexpand\":false,");
                    sb.Append("\"complete\":true,");
                    sb.Append("\"hasChildren\":" + (hasOrgs || hasDepts).ToString().ToLower() + "");
                    sb.Append("},");
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return sb.ToString();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存考核对象管理
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public ActionResult SaveAssessmentObjectsForm(List<BpcSP007Entity> entities, string[] keyValues)
        {
            if (entities != null)
                bll.CreateAssessmentObjectsForm(entities);
            if (keyValues != null)
            {
                keyValues = keyValues[0].Split(',');
                bll.RemoveAssessmentObjectForm(keyValues);
            }
            return Success("操作成功。");
        }
        #endregion
        #endregion

        #region 绩效维度设置

        #region 视图功能
        /// <summary>
        /// 绩效维度设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Dimension()
        {
            return View();
        }

        /// <summary>
        /// 新增/编辑绩效维度
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditDimension(string keyValue)
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取绩效维度列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDimensionalities(Pagination pagination, string queryJson)
        {

            var watch = CommonHelper.TimerStart();
            var data = dicBll.GetDimensionalities(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取绩效维度实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDimensionEntity(string keyValue)
        {
            var data = dicBll.GetDimensionalityEntity(keyValue);
            return Content(data.ToJson());
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存绩效维度
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveDimension(BpeVA002Entity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
                dicBll.CreateDimensionalityForm(entity);
            else
                dicBll.ModifyDimensionalityForm(keyValue, entity);
            return Success("操作成功");
        }

        /// <summary>
        /// 删除绩效维度
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveDimensionalityForm(string keyValue)
        {
            dicBll.RemoveDimensionalityForm(keyValue);
            return Success("操作成功");
        }

        #endregion

        #endregion

    }
}
