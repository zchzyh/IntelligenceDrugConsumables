using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfConfig.Controllers
{
    /// <summary>
    /// 绩效配置-KPI设置
    /// </summary>
    public class KpiSettingController : MvcControllerBase
    {
        KpiSettingBLL bll;
        DictionaryBLL dicBll;
        /// <summary>
        /// 
        /// </summary>
        public KpiSettingController()
        {
            bll = new KpiSettingBLL();
            dicBll = new DictionaryBLL();
        }

        #region 元数据设置

        #region 视图功能
        /// <summary>
        /// 元数据设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增/修改元数据
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="keyValue">元数据id</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditMetadata(string year, string keyValue)
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 元数据列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetMetaListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var metas = bll.GetMetadataList(pagination, queryJson);
            var JsonData = new
            {
                rows = metas,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取元数据所有一级分类
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <param name="dontGet">是否取数据</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFirstKindJson(bool forSearch = true, bool dontGet = false)
        {
            if (dontGet) return ToJsonResult(null);
            var firsts = dicBll.GetDataTypes(JsonConvert.SerializeObject(new { grade = 1 }));
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "所有一级分类");
            foreach (var item in firsts)
            {
                items.Add(item.TYPEID, item.NAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取元数据所有二级分类
        /// </summary>
        /// <param name="first">一级分类id</param>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSecondKindJson(string first, bool forSearch = true)
        {
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "所有二级分类");
            if (!string.IsNullOrEmpty(first))
            {
                var seconds = dicBll.GetDataTypes(JsonConvert.SerializeObject(new { grade = 2, parent = first }));
                foreach (var item in seconds)
                {
                    items.Add(item.TYPEID, item.NAME);
                }
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取元数据所有计量单位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUnitJson()
        {
            var items = new Dictionary<string, string>();
            var units = dicBll.GetStandardCodes(Config.GetValue("UnitType"));
            foreach (var item in units)
            {
                items.Add(item.CODE, item.NAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取元数据所有运行频率
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFrequencyJson()
        {
            var items = new Dictionary<string, string>();
            var units = dicBll.GetStandardCodes(Config.GetValue("FrequencyType"));
            foreach (var item in units)
            {
                items.Add(item.CODE, item.NAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取元数据
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="keyValue">元数据id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMetaJson(string year, string keyValue)
        {
            var meta = bll.GetMetadataEntity(year, keyValue);
            var seconds = dicBll.GetDataTypes(JsonConvert.SerializeObject(new { grade = 2 }));
            List<BpcSM002Entity> ss = JsonConvert.DeserializeObject<List<BpcSM002Entity>>(seconds.ToJson());
            var cur = ss.Find(delegate (BpcSM002Entity item) { return item.TYPEID == meta.TYPEID; });
            return ToJsonResult(new
            {
                JXND = meta.JXND,
                PARTYPEID = cur.PARENT,
                TYPEID = meta.TYPEID,
                METCODE = meta.METCODE,
                METNAME = meta.METNAME,
                UNIT = meta.UNIT,
                PX = (int)meta.PX.Value,
                RUNFRE = meta.RUNFRE,
                STATUS = meta.STATUS,
                REMARK = meta.REMARK,
                CREATOR = meta.CREATOR
            });
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除元数据
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="keyValue">元数据id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelMetadata(string year, string keyValue)
        {
            bll.RemoveMetadataForm(year, keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 启/停用元数据
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="keyValue">元数据id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult MetaEnabled(string year, string keyValue)
        {
            var meta = bll.GetMetadataEntity(year, keyValue);
            if (meta.STATUS == "0")
                meta.STATUS = "1";
            else
                meta.STATUS = "0";
            bll.ModifyMetadataForm(year, keyValue, meta);
            return Success("操作成功");
        }


        /// <summary>
        /// 保存元数据
        /// </summary>
        /// <param name="meta">元数据实例入参</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveMeta(BpeMA001Entity meta)
        {
            if (string.IsNullOrEmpty(meta.METCODE) || meta.METCODE.Contains("&nbsp;"))
                meta.METCODE = VerifyCode.GetRandomCode();
            if (string.IsNullOrEmpty(meta.CREATOR))
                bll.CreateMetadataForm(meta);
            else
                bll.ModifyMetadataForm(meta.JXND, meta.METCODE, meta);
            return Success("操作成功");
        }
        #endregion

        #endregion

        #region 数据项设置

        #region 视图功能
        /// <summary>
        /// 数据项设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DataItem()
        {
            return View();
        }

        /// <summary>
        /// 新增/修改数据项
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="keyValue">元数据id</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditDataItem(string year, string keyValue)
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 数据项列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetDataListJson(Pagination pagination, string queryJson)
        {
            var lst = bll.GetStandardDataList(pagination, queryJson);
            var JsonData = new
            {
                rows = lst,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取数据项
        /// </summary>
        /// <param name="keyValue">数据项编码</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataItemJson(string keyValue)
        {
            var item = bll.GetStandardDataEntity(keyValue);
            var seconds = dicBll.GetDataTypes(JsonConvert.SerializeObject(new { grade = 2 }));
            List<BpcSM002Entity> ss = JsonConvert.DeserializeObject<List<BpcSM002Entity>>(seconds.ToJson());
            var cur = ss.Find(delegate (BpcSM002Entity i) { return i.TYPEID == item.TYPEID; });
            return ToJsonResult(new
            {
                PARTYPEID = cur.PARENT,
                TYPEID = item.TYPEID,
                JCSJBM = item.JCSJBM,
                JCSJMC = item.JCSJMC,
                JLDW = item.JLDW,
                PX = (int)item.PX.Value,
                YXPL = item.YXPL,
                STATUS = item.STATUS,
                REMARK = item.REMARK,
                TJXS = item.TJXS,
                CREATOR = item.CREATOR
            });
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除数据项
        /// </summary>
        /// <param name="keyValue">元数据id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelDataItem(string keyValue)
        {
            bll.RemoveStandardDataForm(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 启/停用数据项
        /// </summary>
        /// <param name="keyValue">元数据id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DataItemEnabled(string keyValue)
        {
            var item = bll.GetStandardDataEntity(keyValue);
            if (item.STATUS == "0")
                item.STATUS = "1";
            else
                item.STATUS = "0";
            bll.ModifyStandardDataForm(keyValue, item);
            return Success("操作成功");
        }


        /// <summary>
        /// 保存元数据
        /// </summary>
        /// <param name="item">元数据实例入参</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveDataItem(BpcSM001Entity item)
        {
            if (string.IsNullOrEmpty(item.JCSJBM) || item.JCSJBM.Contains("&nbsp;"))
                item.JCSJBM = VerifyCode.GetRandomCode();
            if (string.IsNullOrEmpty(item.CREATOR))
                bll.CreateStandardDataForm(item);
            else
                bll.ModifyStandardDataForm(item.JCSJBM, item);
            return Success("操作成功");
        }

        #endregion

        #endregion

        #region 数据项类别管理

        #region 视图功能
        /// <summary>
        /// 数据项类别管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DataType()
        {
            return View();
        }

        /// <summary>
        /// 数据项类别编辑
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditDataType(string keyValue)
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 数据项分类列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetTypeList(Pagination pagination, string queryJson)
        {
            var types = JsonConvert.DeserializeObject<List<BpcSM002Entity>>(dicBll.GetDataTypes(pagination, queryJson).ToJson());
            var firsts = JsonConvert.DeserializeObject<List<BpcSM002Entity>>(dicBll.GetDataTypes(JsonConvert.SerializeObject(new { grade = 1 })).ToJson());
            types.ForEach(delegate (BpcSM002Entity item)
            {
                if (!string.IsNullOrEmpty(item.PARENT))
                    item.PARENT = firsts.Find(delegate (BpcSM002Entity i) { return i.TYPEID == item.PARENT; }).NAME;
            });
            var JsonData = new
            {
                rows = types,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGradeJson()
        {
            var items = new Dictionary<string, string>();
            items.Add("1", "一级");
            items.Add("2", "二级");
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTypeJson(string keyValue)
        {
            var data = JsonConvert.DeserializeObject<List<BpcSM002Entity>>(dicBll.GetDataTypes(GetDefaultPagination("TYPEID"),
                JsonConvert.SerializeObject(new { keyword = keyValue })).ToJson())[0];
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除数据项分类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelDataType(string keyValue)
        {
            return Success("删除成功");
        }

        /// <summary>
        /// 启/停用数据项分类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DataTypeEnabled(string keyValue)
        {
            return Success("操作成功");
        }


        /// <summary>
        /// 保存数据项分类
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveDataType(BpcSM002Entity item)
        {
            return Success("操作成功");
        }

        #endregion

        #endregion

        #region 定量指标设置

        #region 视图功能
        /// <summary>
        /// 定量指标设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Quantitative()
        {
            return View();
        }

        /// <summary>
        /// 新增/修改定量指标
        /// </summary>
        /// <param name="keyValue">定量指标id</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditQuantitative(string keyValue)
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 定量指标列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetQuanListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var quans = bll.GetQuantitativeIndicators(pagination, queryJson);
            var JsonData = new
            {
                rows = quans,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取指标级别
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetLevelJson(bool forSearch = true)
        {
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限指标级别");
            items.Add("1", "一级指标");
            items.Add("2", "二级指标");
            items.Add("3", "三级指标");
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 某级定量指标列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetLevelQuanListJson(string queryJson)
        {
            var items = new Dictionary<string, string>();
            var quans = bll.GetQuantitativeIndicatorLevels(queryJson);
            foreach (var item in quans)
            {
                items.Add(item.ZBBH, item.ZBMC);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取指定指标
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="level">指标级别</param>
        /// <param name="fjzb">父级指标</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDadQuanJson(string year, string level, string fjzb = null)
        {
            var items = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(level))
            {
                var quans = bll.GetQuantitativeIndicators(GetDefaultPagination("JXBM"),
                    JsonConvert.SerializeObject(new { level = level, jxbm = year, fjzb = fjzb }));
                foreach (var item in quans)
                {
                    items.Add(item.ZBBH, item.ZBMC);
                }
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取定量指标
        /// </summary>
        /// <param name="year">定量指标有效年度</param>
        /// <param name="keyValue">定量指标id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetQuanJson(string year, string keyValue)
        {
            var quan = bll.GetQuantitativeIndicatorsEntity(keyValue, year);
            return ToJsonResult(quan);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除定量指标
        /// </summary>
        /// <param name="keyValue">定量指标id</param>
        /// <param name="year">年度</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelQuantitative(string keyValue, string year)
        {
            bll.RemoveQuantitativeIndicatorsForm(keyValue, year);
            return Success("删除成功");
        }

        /// <summary>
        /// 启/停用定量指标
        /// </summary>
        /// <param name="keyValue">定量指标id</param>
        /// <param name="year">年度</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult QuanEnabled(string keyValue, string year)
        {
            var quan = bll.GetQuantitativeIndicatorsEntity(keyValue, year);
            if (quan.STATUS == "0")
                quan.STATUS = "1";
            else
                quan.STATUS = "0";
            bll.ModifyQuantitativeIndicatorsForm(keyValue, year, quan);
            return Success("操作成功");
        }

        /// <summary>
        /// 保存定量指标
        /// </summary>
        /// <param name="quan">定量指标</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveQuan(BpeTA001Entity quan)
        {
            if (string.IsNullOrEmpty(quan.CREATOR))
                bll.CreateQuantitativeIndicatorsForm(quan);
            else
                bll.ModifyQuantitativeIndicatorsForm(quan.ZBBH, quan.JXBM, quan);
            return Success("操作成功");
        }

        #endregion

        #endregion

        #region 定性指标设置

        #region 视图功能
        /// <summary>
        /// 定性指标设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Qualitative()
        {
            return View();
        }

        /// <summary>
        /// 新增/修改定性指标
        /// </summary>
        /// <param name="keyValue">定性指标id</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditQualitative(string keyValue)
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 定性指标列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetQualListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var quals = bll.GetQualitativeIndicators(pagination, queryJson);
            var JsonData = new
            {
                rows = quals,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取指定的指标
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="level">指标级别</param>
        /// <param name="fjzb">父级指标</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDadQualJson(string year, string level, string fjzb = null)
        {
            var items = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(level))
            {
                var quals = bll.GetQualitativeIndicators(GetDefaultPagination("JXBM"),
                    JsonConvert.SerializeObject(new { level = level, jxbm = year, fjzb = fjzb }));
                foreach (var item in quals)
                {
                    items.Add(item.ZBBH, item.ZBMC);
                }
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取定性指标
        /// </summary>
        /// <param name="zbbh">定性指标有效年度</param>
        /// <param name="jxbm">定性指标id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetQualJson(string zbbh, string jxbm)
        {
            var qual = bll.GetQualitativeIndicatorsEntity(zbbh, jxbm);
            return ToJsonResult(qual);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除定性指标
        /// </summary>
        /// <param name="keyValue">定性指标id</param>
        /// <param name="year">年度</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelQualitative(string keyValue, string year)
        {
            bll.RemoveQualitativeIndicatorsForm(keyValue, year);
            return Success("删除成功");
        }

        /// <summary>
        /// 启/停用定性指标
        /// </summary>
        /// <param name="keyValue">定性指标id</param>
        /// <param name="year">年度</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult QualEnabled(string keyValue, string year)
        {
            var qual = bll.GetQualitativeIndicatorsEntity(keyValue, year);
            if (qual.STATUS == "0")
                qual.STATUS = "1";
            else
                qual.STATUS = "0";
            bll.ModifyQualitativeIndicatorsForm(keyValue, year, qual);
            return Success("操作成功");
        }

        /// <summary>
        /// 保存定性指标
        /// </summary>
        /// <param name="qual">定性指标</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveQual(BpeTB001Entity qual)
        {
            if (string.IsNullOrEmpty(qual.CREATOR))
                bll.CreateQualitativeIndicatorsForm(qual);
            else
                bll.ModifyQualitativeIndicatorsForm(qual.ZBBH, qual.JXBM, qual);
            return Success("操作成功");
        }

        #endregion

        #endregion

        #region 关键绩效指标设置

        #region 视图功能
        /// <summary>
        /// 关键绩效指标设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult QuanPerf()
        {
            return View();
        }

        /// <summary>
        /// 新增/修改关键绩效指标
        /// </summary>
        /// <param name="keyValue">绩效指标id</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditQuanPerf(string keyValue)
        {
            return View();
        }

        /// <summary>
        /// 自定义公式
        /// </summary>
        /// <param name="zbgs"></param>
        /// <param name="zbgsms"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditFormula(string zbgs, string zbgsms)
        {
            ViewData["zbgs"] = zbgs;
            ViewData["zbgsms"] = zbgsms;
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取关键绩效指标列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPerfListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var lst = bll.GetJxQuantitativeIndicators(pagination, queryJson);
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
        /// 获取考核主体
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetOrgsJson(bool forSearch = true)
        {
            SystemBLL bll = new SystemBLL();
            var orgs = bll.GetOrgs(null);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "不限考核主体");
            foreach (var item in orgs)
            {
                items.Add(item.ORGID, item.ORGNAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取一级指标列表
        /// </summary>
        /// <param name="year">指标年度</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFirstQuanJson(string year)
        {
            //year = year ?? DateTime.Now.Year.ToString();
            return GetDadQuanJson(year, "1");
        }

        /// <summary>
        /// 获取二级指标列表
        /// </summary>
        /// <param name="first">一级指标id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSecondQuanJson(string first)
        {
            return GetDadQuanJson("", "2", first);
        }

        /// <summary>
        /// 获取三级指标列表
        /// </summary>
        /// <param name="second">二级指标id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetThirdQuanJson(string second)
        {
            return GetDadQuanJson("", "3", second);
        }

        /// <summary>
        /// 获取三级指标树状图
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllThirdQuanJson(string keyword)
        {
            var quans = bll.GetQuantitativeIndicators(GetDefaultPagination("JXBM"),
                JsonConvert.SerializeObject(new { }));

            var treeList = new List<TreeEntity>();
            for (int i = 1; ; i++)
            {
                var levelQuan = quans.Where(q => q.ZBJB == i.ToString());
                if (levelQuan.Count() == 0)
                {
                    break;
                }
                else
                {
                    foreach (var item in levelQuan)
                    {
                        bool hasChildren = quans.Count(t => t.FJZB == item.ZBBH) == 0 ? false : true;
                        TreeEntity tree = new TreeEntity
                        {
                            id = item.ZBBH,
                            text = item.ZBMC,
                            value = item.ZBBH,
                            parentId = i == 1 ? "0" : item.FJZB,
                            isexpand = true,
                            complete = true,
                            hasChildren = hasChildren,
                            Attribute = "Sort",
                            AttributeValue = "level_" + i.ToString()
                        };
                        treeList.Add(tree);
                    }
                }
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                treeList = treeList.TreeWhere(t => t.text.Contains(keyword), "id", "parentId");
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 根据三级指标获取所属的一级、二级指标
        /// </summary>
        /// <param name="zbbh"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetParentsQuanJson(string zbbh)
        {
            var result = new List<string>();
            if (!string.IsNullOrEmpty(zbbh))
            {
                var quanList = bll.GetQuantitativeIndicators(GetDefaultPagination("JXBM"),
                    JsonConvert.SerializeObject(new { }));
                var quan = quanList.Where(q => q.ZBBH == zbbh).FirstOrDefault();
                while (quan != null)
                {
                    zbbh = quan.FJZB;
                    result.Add(quan.ZBBH);
                    quan = quanList.Where(q => q.ZBBH == zbbh).FirstOrDefault();
                }
                result.Reverse();
            }
            return ToJsonResult(result);
        }

        /// <summary>
        /// 获取指标极性
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPolarityJson()
        {
            var items = new Dictionary<string, string>();
            items.Add("1", "正向");
            items.Add("0", "负向");
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取指标程度
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDegreeJson()
        {
            var items = new Dictionary<string, string>();
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取关键绩效指标
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPerfJson(string keyValue)
        {
            var entity = bll.GetJxQuantitativeIndicatorsEntity(keyValue);
            var models = bll.GetJxQuantitativeIndicators(GetDefaultPagination("KPIBH"),
                JsonConvert.SerializeObject(new { jxbm = entity.JXBM }));
            var model = JsonConvert.DeserializeObject<List<JxQuantitativeIndicatorsModel>>(models.ToJson())
                .Find(delegate (JxQuantitativeIndicatorsModel item) { return item.KPIBH == entity.KPIBH; });
            //字典字段使用编码
            model.ZBJX = entity.ZBJX;
            model.ZBCD = entity.ZBCD;
            model.JLDW = entity.JLDW;
            model.ZBGS = entity.ZBGS;
            model.ZBGSMS = entity.ZBGSMS;
            model.ZBSDMD = entity.ZBSDMD;
            model.REMARK = entity.REMARK;
            return ToJsonResult(model);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除关键绩效指标
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelQuanPerf(string keyValue)
        {
            bll.RemoveJxQuantitativeIndicatorsForm(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 启/停用关键绩效指标
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult QuanPerfEnabled(string keyValue)
        {
            var entity = bll.GetJxQuantitativeIndicatorsEntity(keyValue);
            if (entity.STATUS == "0")
                entity.STATUS = "1";
            else
                entity.STATUS = "0";
            bll.ModifyJxQuantitativeIndicatorsForm(entity.KPIBH, entity);
            return Success("操作成功");
        }

        /// <summary>
        /// 保存关键绩效指标
        /// </summary>
        /// <param name="model">关键绩效指标</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SavePerf(JxQuantitativeIndicatorsModel model)
        {
            var years = new YearSettingBLL().GetYearSettings(GetDefaultPagination("JXBM"), null);
            model.JXBM = model.JXBM ?? JsonConvert.DeserializeObject<List<YearSettingModel>>(years.ToJson())
                .Find(delegate (YearSettingModel item) { return item.JXND == DateTime.Now.Year.ToString(); }).JXBM;
            BpeTA002Entity perf = new BpeTA002Entity
            {
                KPIBH = model.KPIBH,
                JXBM = model.JXBM,
                ZBBH = model.ThirdZBBH,
                ZBJX = model.ZBJX,
                ZBCD = model.ZBCD,
                ZBGS = model.ZBGS,
                ZBGSMS = model.ZBGSMS,
                ZBSDMD = model.ZBSDMD,
                JLDW = model.JLDW,
                REMARK = model.REMARK,
                STATUS = model.STATUS
            };
            if (string.IsNullOrEmpty(perf.KPIBH))
                bll.CreateJxQuantitativeIndicatorsForm(perf);
            else
                bll.ModifyJxQuantitativeIndicatorsForm(perf.KPIBH, perf);
            return Success("操作成功");
        }
        #endregion

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jxbm"></param>
        /// <param name="needThd">是否需要第三级分类</param>
        /// <returns></returns>
        public ActionResult GetZBTreeJson(string jxbm, bool needThd = false)
        {
            var quans = JsonConvert.DeserializeObject<List<QuantitativeIndicatorsModel>>(
                bll.GetQuantitativeIndicators(GetDefaultPagination("JXBM"),
                JsonConvert.SerializeObject(new { jxbm = jxbm })).ToJson());
            var treeList = new List<TreeEntity>();
            treeList.Add(new TreeEntity
            {
                id = "00",
                text = "所有指标",
                value = "",
                isexpand = true,
                complete = true,
                hasChildren = true,
                img = "fa fa-align-justify",
                parentId = "0",
                Level = 0
            });
            quans.ForEach(delegate (QuantitativeIndicatorsModel item)
            {
                int level = int.Parse(item.ZBJB);
                if (!needThd && level == 3) return;
                TreeEntity tree = new TreeEntity();
                bool hasChildren = !needThd && level == 2 ? false : quans.Exists(delegate (QuantitativeIndicatorsModel i) { return i.FJZB == item.ZBBH; });
                tree.id = item.ZBBH;
                tree.text = item.ZBMC;
                tree.value = item.JXBM;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.FJZB ?? "00";
                tree.Level = level;
                tree.img = "fa fa-line-chart";
                treeList.Add(tree);
            });
            //必须TreeToJson
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 获取数据项一级分类树
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTypeTreeJson()
        {
            var treeList = new List<TreeEntity>();
            treeList.Add(new TreeEntity
            {
                id = "00",
                text = "所有分类",
                value = "",
                isexpand = true,
                complete = true,
                hasChildren = true,
                img = "fa fa-align-justify",
                parentId = "0",
                Level = 0
            });
            var firsts = dicBll.GetDataTypes(JsonConvert.SerializeObject(new { grade = 1 }));
            foreach (var item in firsts)
            {
                TreeEntity tree = new TreeEntity();
                tree.id = item.TYPEID;
                tree.text = item.NAME;
                tree.value = item.TYPEID;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = false;
                tree.parentId = "00";
                tree.Level = 1;
                tree.img = "fa fa-hand-o-right";
                treeList.Add(tree);
            }
            //必须TreeToJson
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 获取数据项基本信息键值列表
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetStandardDataKeyValueList(string queryJson)
        {
            var data = bll.GetStandardDataKeyValueList(queryJson);
            var items = new Dictionary<string, string>();
            foreach (var item in data)
            {
                items.Add(item.JCSJBM, item.JCSJMC);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }
    }
}
