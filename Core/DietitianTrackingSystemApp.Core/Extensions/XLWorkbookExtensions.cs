using ClosedXML.Excel;
using DietitianTrackingSystemApp.Core.CustomAttributes;
using System.Reflection;

namespace DietitianTrackingSystemApp.Core.Extensions
{
    public static class XLWorkbookExtensions
    {
        public static void AddColumns<T>(this IXLWorksheet worksheet, List<T> list)
        {
            int currentColumn = 1;

            foreach (var property in list[0].GetType().GetProperties().ToList())
            {
                if (property.PropertyType == typeof(Dictionary<string, string>))
                {
                    var value = property.GetValue(list[0], null);

                    foreach (var keyValuePair in (Dictionary<string, string>)value)
                    {
                        worksheet.Cell(1, currentColumn).Value = keyValuePair.Key;

                        currentColumn++;
                    }
                }
                else
                {
                    ExcelAttribute excelAttribute = property.GetCustomAttribute<ExcelAttribute>() != null
                       ? property.GetCustomAttribute<ExcelAttribute>()
                       : new ExcelAttribute { ColumnName = property.Name };

                    if (!excelAttribute.Discard)
                    {
                        worksheet.Cell(1, currentColumn).Value = excelAttribute.ColumnName;

                        currentColumn++;
                    }
                }
            }
        }

        public static void AddRows<T>(this IXLWorksheet worksheet, List<T> list)
        {
            int currentRow = 1;

            foreach (var item in list)
            {
                int currentColumn = 1;

                currentRow++;

                foreach (var property in item.GetType().GetProperties())
                {
                    if (property.PropertyType == typeof(Dictionary<string, string>))
                    {
                        var value = property.GetValue(item, null);

                        if (value != null)
                        {
                            foreach (var keyValuePair in (Dictionary<string, string>)value)
                            {
                                worksheet.Cell(currentRow, currentColumn).Value = keyValuePair.Value;

                                currentColumn++;
                            }
                        }
                    }
                    else
                    {
                        ExcelAttribute excelAttribute = property.GetCustomAttribute<ExcelAttribute>();

                        if (!excelAttribute.HasValue() || !excelAttribute.Discard)
                        {
                            worksheet.Cell(currentRow, currentColumn).Value = property.GetValue(item);

                            currentColumn++;
                        }
                    }
                }
            }
        }

        public static List<T> ToModel<T>(this IXLWorksheet workSheet, bool skipFirstRow) where T : new()
        {
            List<T> dataList = new List<T>();

            List<PropertyInfo> propertyList = typeof(T).GetPropertyList();

            if (skipFirstRow)
            {
                foreach (IXLRow row in workSheet.RowsUsed().Skip(1).ToList())
                {
                    dataList.Add(row.GetModelData<T>(propertyList, workSheet));
                }
            }
            else
            {
                foreach (IXLRow row in workSheet.RowsUsed().ToList())
                {
                    dataList.Add(row.GetModelData<T>(propertyList));
                }
            }

            return dataList;
        }

        private static T GetModelData<T>(this IXLRow row, List<PropertyInfo> propertyList, IXLWorksheet workSheet) where T : new()
        {
            var data = new T();

            foreach (IXLCell cell in row.CellsUsed())
            {
                PropertyInfo property = propertyList.Where(x => x.GetCustomAttribute<ExcelAttribute>() != null
                                       ? x.GetCustomAttribute<ExcelAttribute>().ColumnName.ToLower() == Convert.ToString(workSheet.Cell(1, cell.Address.ColumnNumber).Value).ToLower() : x.Name.ToLower() == Convert.ToString(workSheet.Cell(1, cell.Address.ColumnNumber).Value).ToLower()).FirstOrDefault();

                if (property != null)
                {
                    if (property.PropertyType == cell.Value.GetType())
                        property.SetValue(data, cell.Value, null);
                    else
                        property.SetValue(data, cell.Value.ToConvert(property.PropertyType), null);
                }
                else
                {
                    PropertyInfo propertyDictionary = propertyList.Where(x => x.PropertyType == typeof(Dictionary<string, string>)).FirstOrDefault();

                    if (propertyDictionary != null)
                    {
                        if (propertyDictionary.GetValue(data, null) == null)
                            propertyDictionary.SetValue(data, new Dictionary<string, string>(), null);

                        propertyDictionary.PropertyType.GetProperty("Item").SetValue(propertyDictionary.GetValue(data, null), cell.Value.ToString(), new[] { workSheet.Cell(1, cell.Address.ColumnNumber).Value.ToString() });
                    }
                }
            }

            return data;
        }

        private static T GetModelData<T>(this IXLRow row, List<PropertyInfo> propertyList) where T : new()
        {
            var data = new T();

            int i = 0;

            foreach (IXLCell cell in row.CellsUsed())
            {
                PropertyInfo property = propertyList[i];

                if (property != null)
                {
                    if (property.PropertyType == cell.Value.GetType())
                        property.SetValue(data, cell.Value, null);
                    else
                        property.SetValue(data, cell.Value.ToConvert(property.PropertyType), null);
                }

                i++;
            }

            return data;
        }

        private static List<PropertyInfo> GetPropertyList(this Type genericType)
        {
            return genericType.GetProperties().ToList();
        }
    }
}