using OfficeOpenXml;
using PizzaShop.Models;
using System;
using System.IO;
using System.Linq;

namespace ShopLibrary.Until
{
    public class ExcelUtility
    {
        public string FilePath
        {
            get
            {
                string fileName = $"OrderReport_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                return Path.Combine(desktopPath, fileName);
            }
        }

        public void GenerateOrderExcel(OrderModel order)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            CreateFileOnDesktop();

            using (var package = new ExcelPackage())
            {
                // Set the LicenseContext to use EPPlus in a non-commercial way

                var worksheet = package.Workbook.Worksheets.Add("Order Details");

                // Write headers
                worksheet.Cells["B2:B6"].Style.Font.Bold = true;
                worksheet.Cells[2, 2].Value = "Заказчик";
                worksheet.Cells[3, 2].Value = "Дата оформления";
                worksheet.Cells[4, 2].Value = "Дата завершения";
                worksheet.Cells[5, 2].Value = "Адресс доставки";
                worksheet.Cells[6, 2].Value = "Комментарий";

                worksheet.Cells[2, 3].Value = $"{order.Customer?.FirstName} {order.Customer?.LastName} {order.Customer?.Phone}";

                worksheet.Cells[3, 3].Value = order.OrderPlaced;
                worksheet.Cells[3, 3].Style.Numberformat.Format = "dd.MM.yyyy HH:mm";

                worksheet.Cells[4, 3].Value = order.OrderFulfilled;
                worksheet.Cells[4, 3].Style.Numberformat.Format = "dd.MM.yyyy HH:mm";

                worksheet.Cells[5, 3].Value = "Адресс доставки";
                worksheet.Cells[6, 3].Value = "Комментарий";

                worksheet.Cells["B9:E9"].Style.Font.Bold = true;
                worksheet.Cells[9, 2].Value = "Продукт";
                worksheet.Cells[9, 3].Value = "Цена";
                worksheet.Cells[9, 4].Value = "Количество";
                worksheet.Cells[9, 5].Value = "Сумма";


                // Write order details for each item
                int row = 10;
                foreach (var orderDetail in order.OrderDetails)
                {
                    worksheet.Cells[row, 2].Value = orderDetail.Product?.Name;
                    worksheet.Cells[row, 3].Value = orderDetail.PriceAtCheckout;
                    worksheet.Cells[row, 4].Value = orderDetail.Quntity;
                    worksheet.Cells[row, 5].Value = orderDetail.PriceAtCheckout * orderDetail.Quntity;
                    row++;
                }

                worksheet.Cells[row + 1, 4].Value = "Сумма заказа";
                worksheet.Cells[row + 1, 4].Value = order.Price;

                // Auto-fit columns
                worksheet.Cells.AutoFitColumns();

                // Save the Excel file
                package.SaveAs(new FileInfo(FilePath));
            }
        }

        private void CreateFileOnDesktop()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"OrderReport_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            string filePath = Path.Combine(desktopPath, fileName);

            // Create an empty file
            File.Create(filePath).Dispose();
        }
    }
}
