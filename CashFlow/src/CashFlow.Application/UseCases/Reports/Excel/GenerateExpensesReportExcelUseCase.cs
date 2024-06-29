using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Reports.Excel
{
    public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
    {
        public async Task<byte[]> Execute(DateOnly month)
        {
            var workBook = new XLWorkbook();

            workBook.Author = "Everton Oliveira";
            workBook.Style.Font.FontSize = 12;

            var workSheet = workBook.Worksheets.Add(month.ToString("y"));
        }
    }
}
