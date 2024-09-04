using CashFlow.Domain.Extensions;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
    {
        private const string CURRENCY_SYMBOL = "R$";
        private readonly IExpensesReadOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;

        public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository, ILoggedUser loggedUser)
        {
            _repository = repository;
            _loggedUser = loggedUser;
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var loggedUser = await _loggedUser.Get();

            var expenses = await _repository.FilterByMonth(loggedUser, month);
            if (expenses.Count == 0)
            {
                return [];
            }

            var workBook = new XLWorkbook();

            workBook.Author = loggedUser.Name;
            workBook.Style.Font.FontSize = 12;

            var workSheet = workBook.Worksheets.Add(month.ToString("Y"));

            InsertHeader(workSheet);

            var row = 2;
            foreach (var expense in expenses)
            {
                workSheet.Cell($"A{row}").Value = expense.Title;
                workSheet.Cell($"B{row}").Value = expense.Date;
                workSheet.Cell($"C{row}").Value = expense.PaymentType.PaymentTypeToString();

                workSheet.Cell($"D{row}").Value = expense.Amount;
                workSheet.Cell($"D{row}").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";

                workSheet.Cell($"E{row}").Value = expense.Description;
                row++;
            }

            workSheet.Columns().AdjustToContents();

            var file = new MemoryStream();
            workBook.SaveAs(file);

            return file.ToArray();
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
