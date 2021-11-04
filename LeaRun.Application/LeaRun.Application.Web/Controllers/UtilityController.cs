using LeaRun.Util;
using LeaRun.Util.Offices;
using LeaRun.Util.WebControl;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Controllers
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2016.2.03 10:58
    /// 描 述：公共控制器
    /// </summary>
    public class UtilityController : Controller
    {
        #region 验证对象值不能重复
        #endregion

        #region 导出Excel
        /// <summary>
        /// 请选择要导出的字段页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelExportForm()
        {
            return View();
        }
        /// <summary>
        /// 执行导出Excel
        /// </summary>
        /// <param name="JsonColumn">表头</param>
        /// <param name="JsonData">数据</param>
        /// <param name="exportField">导出字段</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public void ExecuteExportExcel(string columnJson, string rowJson, string exportField, string filename)
        {
            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.Title = Server.UrlDecode(filename);
            excelconfig.TitleFont = "微软雅黑";
            excelconfig.TitlePoint = 15;
            excelconfig.FileName = Server.UrlDecode(filename) + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnEntity>();
            //表头
            List<GridColumnModel> columnData = columnJson.ToList<GridColumnModel>();
            bool needSpaceRow = false;
            if (rowJson == "[]" || string.IsNullOrEmpty(rowJson))
            {//无行数据时(导出模板时)，表格不会打印表头，故需要添加一行空白数据
                needSpaceRow = true;
                rowJson = "[{";
            }
            //写入Excel表头
            string[] fieldInfo = exportField.Split(',');
            foreach (string item in fieldInfo)
            {
                var list = columnData.FindAll(t => t.name == item);
                foreach (GridColumnModel gridcolumnmodel in list)
                {
                    if (gridcolumnmodel.hidden.ToLower() == "false" && gridcolumnmodel.label != null)
                    {
                        if (needSpaceRow) rowJson += "\"" + gridcolumnmodel.name + "\":\"\",";
                        string align = gridcolumnmodel.align;
                        excelconfig.ColumnEntity.Add(new ColumnEntity()
                        {
                            Column = gridcolumnmodel.name,
                            ExcelColumn = gridcolumnmodel.label,
                            Width = gridcolumnmodel.label.Length * 4,
                            Alignment = gridcolumnmodel.align,
                        });
                    }
                }
            }
            if (needSpaceRow) rowJson += "}]";
            //行数据
            DataTable rowData = rowJson.ToTable();
            ExcelHelper.ExcelDownload(rowData, excelconfig);
        }
        #endregion

        #region 导入Excel
        /// <summary>
        /// 执行导出Excel
        /// </summary>
        /// <param name="imFile">文件</param>
        /// <returns></returns>
        public ActionResult ExecuteImportExcel(HttpPostedFileBase imFile)
        {
            List<List<string>> rows = new List<List<string>>();
            var workbook = new HSSFWorkbook(imFile.InputStream);
            var sheet = workbook.GetSheetAt(0);
            for (int i = 2; i < sheet.PhysicalNumberOfRows; i++)
            {
                var row = sheet.GetRow(i);
                rows.Add(row.Cells.AsEnumerable().Select(c=>c.ToString()).ToList());
            }
            return Json(new { rows = rows, flag = true });
        }

        #endregion
    }
}
