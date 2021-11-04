using LeaRun.Application.Busines.CollectionAnalysis;
using LeaRun.Application.Busines.DataAnalysis;
using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Busines.PerfGoal;
using LeaRun.Application.Busines.PerfReport;
using LeaRun.Application.Busines.PerfScheme;
using LeaRun.Application.Busines.SettingManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestController : Controller
    {
        /// <summary>
        /// Test
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //KpiSettingBLL bll = new KpiSettingBLL();
            //var values = bll.GetStandardDataKeyValueList("{\"typeid\":\"B\",\"sectypeid\":\"\",\"keyword\":\"国\"}");

            //AnalyzerBLL bll = new AnalyzerBLL();
            //var values = bll.GetAnalyzerList(new Util.WebControl.Pagination
            //{
            //    page = 1,
            //    rows = 30,
            //    sidx = "FXQBM",
            //    sord = "asc"
            //}, "{\"jxbm\":\"3fec7059f77842d39641def748509a84\",\"set\":\"0\",\"keyword\":\"\"}");

            //SystemBLL bll = new SystemBLL();
            //var values = bll.GetDeprtmentsByJXBM("3fec7059f77842d39641def748509a84");

            //YearSettingBLL bll = new YearSettingBLL();
            //var values = bll.GetYearBms();
            //var values = bll.GetYearSettings(new Util.WebControl.Pagination
            //{
            //    page = 1,
            //    rows = 10000,
            //    sidx = "JXBM",
            //    sord = "asc"
            //}, null);
            //var values = bll.GetDepartments("3fec7059f77842d39641def748509a84");

            //DictionaryBLL bll = new DictionaryBLL();
            ////var values = bll.GetStandardCodes("CV0218.01");
            //var values = bll.GetDimensionalities(new Util.WebControl.Pagination
            //{
            //    page = 1,
            //    rows = 10000,
            //    sidx = "BSCBH",
            //    sord = "asc"
            //}, null);

            //KpiSettingBLL bll = new KpiSettingBLL();
            //var values = bll.GetQuantitativeIndicatorsEntity("TEST-01", "3fec7059f77842d39641def748509a84");

            //KpiSettingBLL bll = new KpiSettingBLL();
            //var levers = bll.GetQualitativeIndicatorsLevels("{\"jxbm\":\"3fec7059f77842d39641def748509a84\",\"level\":\"1\"}");

            //KpiSettingBLL bll = new KpiSettingBLL();
            //bll.ModifyQuantitativeIndicatorsForm("TEST-01", "3fec7059f77842d39641def748509a84", "132144654654",
            //    new Entity.PerfConfig.ViewModel.QuantitativeIndicatorsModel
            //    {
            //        FJZB = "2",
            //        EXPLAIN = "some",
            //        JXBM = "3fec7059f77842d39641def748509a84",
            //        JXND = "2020",
            //        KPIBH = "132144654654",
            //        STATUS = "1",
            //        ZBBH = "TEST-01",
            //        ZBJB = "2",
            //        ZBMC = "定量指标23"
            //    });

            //AnalyzerBLL bll = new AnalyzerBLL();
            //bll.MetadataBindAnalyzer("3fec7059f77842d39641def748509a84", "S42VPXB", "TEST-01");

            //PerfGoalBLL bll = new PerfGoalBLL();
            //var values = bll.GetQuantitativeGoalAuditList(new Util.WebControl.Pagination
            //{
            //    page = 1,
            //    rows = 100,
            //    sidx = "JGFABH",
            //    sord = "asc"
            //}, "{\"jgfabh\":\"1\",\"jxbm\":\"3fec7059f77842d39641def748509a84\",\"orgcode\":\"31011400101\",\"firstZBBH\":\"Z01\",\"secZBBH\":\"Z01001\",\"zbmc\":\"手术\",\"auditStatus\":\"1\"}");
            //var value = bll.GetQuantitativeGoalEntity("1");

            //DataAnalysisBLL bll = new DataAnalysisBLL();
            //var values = bll.GetMomList(new Util.WebControl.Pagination
            //{
            //    page = 1,
            //    rows = 30,
            //    sidx = "XH",
            //    sord = "asc"
            //}, "{\"jxbm\":\"3fec7059f77842d39641def748509a84\",\"deptcode\":\"\",\"yd\":2,\"metcode\":\"VM7E6GF\"}");

            //DeptPerfReportBLL bll = new DeptPerfReportBLL();
            //var values = bll.GetNextYearReportList(new Util.WebControl.Pagination
            //{
            //    page = 1,
            //    rows = 30,
            //    sidx = "XH",
            //    sord = "asc"
            //}, "{\"jxbm\":\"3fec7059f77842d39641def748509a84\",\"deptcode\":\"31011400201\"}");

            //CollectionDataAnalysisBLL bll = new CollectionDataAnalysisBLL();
            //var values = bll.GetStandardDataMonthAnalysisList(new Util.WebControl.Pagination
            //{
            //    page = 1,
            //    rows = 30,
            //    sidx = "XH",
            //    sord = "asc"
            //}, "{\"jxbm\":\"3fec7059f77842d39641def748509a84\",\"yd\":null,\"jcsjbm\":\"SC05009\"}");

            PerfSchemeSettingBLL bll = new PerfSchemeSettingBLL();
            var values = bll.GetPerfDeptSchemeAppraisedataList(new Util.WebControl.Pagination
            {
                page = 1,
                rows = 30,
                sidx = "JGFABH",
                sord = "asc"
            }, "{\"jxbm\":\"3fec7059f77842d39641def748509a84\",\"yd\":null,\"jcsjbm\":\"SC05009\"}");
            //bll.ModifyPerfSchemeWeightList(values.ToList());

            //AppraiseSeetingBLL bll = new AppraiseSeetingBLL();
            //var values = bll.GetAppraisedataBmList("");

            return View();
        }

    }
}