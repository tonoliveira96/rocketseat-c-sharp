using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CashFlow.Application.UseCases.Reports.Excel
{
    public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
    {
        public readonly IExpensesReadOnlyRepository _repository;

        public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if(expenses.Count == 0)
            {
                return [];
            }

            var workBook = new XLWorkbook();

            workBook.Author = "Everton Oliveira";
            workBook.Style.Font.FontSize = 12;

            var workSheet = workBook.Worksheets.Add(month.ToString("Y"));

            InsertHeader(workSheet);

            var row = 2;
            foreach( var expense in expenses)
            {
                workSheet.Cell($"A{row}").Value = expense.Title;
                workSheet.Cell($"B{row}").Value = expense.Date;
                workSheet.Cell($"C{row}").Value = ConvertPaymentType(expense.PaymentType);
                workSheet.Cell($"D{row}").Value = expense.Amount;
                workSheet.Cell($"E{row}").Value = expense.Description;
                row++;
            }

            var file = new MemoryStream();
            workBook.SaveAs(file);

            return file.ToArray();
        }

        private string ConvertPaymentType(PaymentType payment)
        {
            return payment switch
            {
                PaymentType.Cash => "Dinheiro",
                PaymentType.CreditCard => "Cartão de Crédito",
                PaymentType.DebitCard => "Cartão de Débito",
                PaymentType.EletronicTransfer => "Pix",
                _ => string.Empty,
            };
        }

        private void InsertHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
            worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
            worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
            worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
            worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;

            worksheet.Cells("A1:E1").Style.Font.Bold = true;

            worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#f5c2b6");

            worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        }
    }
}
