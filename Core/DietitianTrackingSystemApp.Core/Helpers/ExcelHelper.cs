using ClosedXML.Excel;
using DietitianTrackingSystemApp.Core.Extensions;

namespace DietitianTrackingSystemApp.Core.Helpers
{
    public static class ExcelHelper
    {
        public static string ExportExcelToBase64<T>(List<T> list) where T : class
        {
            byte[] byteData = ExportExcelToByte(list);

            string stringData = Convert.ToBase64String(byteData);

            return stringData;
        }

        public static byte[] ExportExcelToByte<T>(List<T> list, string sheetName = "Sheet1") where T : class
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(sheetName);

                if (list != null && list.Count > 0)
                {
                    worksheet.AddColumns(list);

                    worksheet.AddRows(list);
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return content;
                }
            }
        }

        /// <summary>
        /// Converts excel file to model.
        /// If the column name exists in file and the name of the model's property or the columnname in the ExcelAttribute is the same as the columnname in the file,it sets the values of that column to that property.
        /// If there is a unmatched column name, it is checked whether the model has the Dictionary<string, string> property.If so, it sets the values to this property.
        /// If there is no column name, It sets the values in the file sequentially to the properties in the model .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="skipFirstRow"></param>
        /// <returns></returns>
        public static List<T> ImportExcelToModel<T>(Stream file, bool skipFirstRow = true) where T : new()
        {
            List<T> excelDataList = new List<T>();

            using (XLWorkbook workbook = new XLWorkbook(file))
            {
                foreach (IXLWorksheet worksheet in workbook.Worksheets)
                {
                    excelDataList.AddRange(worksheet.ToModel<T>(skipFirstRow));
                }
            }

            return excelDataList;
        }
    }
}