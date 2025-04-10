using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
namespace Common.Utilities.Extensions
{
    public static class Files
    {
      
        /// <summary>
        /// return json excel (for ravil jobs)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ConvertExcelToJson(this IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "No file uploaded";
            }

            try
            {
                var data = new List<Dictionary<string, object>>();

                // استفاده از MemoryStream برای ذخیره فایل
                using (var stream = new MemoryStream())
                {
                    // کپی فایل به MemoryStream
                    file.CopyTo(stream);

                    // با استفاده از ClosedXML فایل Excel را باز می‌کنیم
                    using (var workbook = new XLWorkbook(stream))
                    {
                        var worksheet = workbook.Worksheet(1); // اولین شیت
                        var rowCount = worksheet.RowsUsed();  // تعداد ردیف‌های استفاده شده
                        var columnCount = worksheet.ColumnsUsed(); // تعداد ستون‌های استفاده شده

                        // خواندن هدرها از ردیف اول
                        var headers = new List<string>();
                        foreach (var cell in worksheet.Row(1).Cells())
                        {
                            headers.Add(cell.Value.ToString());
                        }

                        // خواندن سطرها و تبدیل به دیکشنری
                        foreach (var row in worksheet.RowsUsed().Skip(1)) // شروع از ردیف 2
                        {
                            var rowData = new Dictionary<string, object>();

                            for (int i = 0; i < headers.Count; i++)
                            {
                                var cell = row.Cell(i + 1); // دریافت سلول
                                var cellValue = cell == null ? "" : cell.Value.ToString(); // بررسی اگر سلول خالی باشد

                                rowData[headers[i]] = cellValue;
                            }

                            data.Add(rowData);
                        }
                    }
                }

                // تبدیل لیست داده‌ها به فرمت JSON
                string jsonResult = JsonConvert.SerializeObject(data, Formatting.Indented);
                return jsonResult;
            }
            catch
            {
                return "No file uploaded";
            }
        }
    }
}