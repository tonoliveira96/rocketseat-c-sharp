using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Colors;
using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf
{
    public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
    {
        private const string CURRENCY_SYMBOL = "R$";
        private readonly IExpensesReadOnlyRepository _repository;

        public GenerateExpensesReportPdfUseCase(IExpensesReadOnlyRepository repository)
        {
            _repository = repository;

            GlobalFontSettings.FontResolver = new ExpensesExportFontsResolver();
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if (expenses.Count == 0)
            {
                return [];
            }

            var document = CreateDocument(month);
            var page = CreatePage(document);

            CreateHeaderWithProfilePhotoAndName(page);
            var totalExpenses = expenses.Sum(expenses => expenses.Amount);
            CreateTotalExpenseSection(page, month, totalExpenses);

            foreach (var expense in expenses)
            {
                var table = CreateExpensesTable(page);
                var row = table.AddRow();
                row.Height = 25;

                row.Cells[0].AddParagraph(expense.Title);
                row.Cells[0].Format.Font = new Font { Name = FontHelper.RELEWAY_BLACK, Size = 14, Color = ColorsHelper.BLACK };
                row.Cells[0].Shading.Color = ColorsHelper.RED_LIGHT;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[0].MergeRight = 2;
                row.Cells[0].Format.LeftIndent = 20;

                row.Cells[3].AddParagraph(ResourceReportGenerationMessages.AMOUNT);
                row.Cells[3].Format.Font = new Font { Name = FontHelper.RELEWAY_BLACK, Size = 14, Color = ColorsHelper.WHITE };
                row.Cells[3].Shading.Color = ColorsHelper.RED_DARK;
                row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

                row = table.AddRow();
                row.Height = 30;
                row.Borders.Visible = false;
            }

            return RenderDocument(document);
        }

        private Document CreateDocument(DateOnly month)
        {
            var document = new Document();

            document.Info.Title = $"{ResourceReportGenerationMessages.EXPENSE_FOR} {month:Y}";
            document.Info.Author = "Everton Oliveira";

            var style = document.Styles["Normal"];
            style.Font.Name = FontHelper.RELEWAY_REGULAR;

            return document;
        }

        private Section CreatePage(Document document)
        {
            var section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();

            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.LeftMargin = 40;
            section.PageSetup.RightMargin = 40;
            section.PageSetup.TopMargin = 80;
            section.PageSetup.BottomMargin = 80;

            return section;
        }

        private void CreateHeaderWithProfilePhotoAndName(Section page)
        {
            var table = page.AddTable();
            table.AddColumn();
            table.AddColumn("300");

            var row = table.AddRow();
            var assemby = Assembly.GetExecutingAssembly();
            var directoryName = Path.GetDirectoryName(assemby.Location);

            row.Cells[0].AddImage(Path.Combine(directoryName!, "UseCases", "Expenses", "Reports", "Pdf", "Logo", "logo.png"));
            row.Cells[1].AddParagraph("Olá, Everton");
            row.Cells[1].Format.Font = new Font { Name = FontHelper.RELEWAY_BLACK, Size = 16 };
            row.Cells[1].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
        }

        private void CreateTotalExpenseSection(Section page, DateOnly month, decimal totalExpenses)
        {
            var paragraph = page.AddParagraph();
            paragraph.Format.SpaceBefore = "40";
            paragraph.Format.SpaceAfter = "40";

            var title = string.Format(ResourceReportGenerationMessages.TOTAL_SPENT_IN, month.ToString("Y"));

            paragraph.AddFormattedText(title, new Font { Name = FontHelper.RELEWAY_REGULAR, Size = 15 });

            paragraph.AddLineBreak();
            paragraph.AddFormattedText($"{totalExpenses} {CURRENCY_SYMBOL}", new Font { Name = FontHelper.WORLSANS_BLACK, Size = 50 });
        }

        private Table CreateExpensesTable(Section page)
        {
            var table = page.AddTable();
            table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("195").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("195").Format.Alignment = ParagraphAlignment.Right;

            return table;
        }

        private byte[] RenderDocument(Document document)
        {
            var renderer = new PdfDocumentRenderer
            {
                Document = document,
            };

            renderer.RenderDocument();

            using var file = new MemoryStream();
            renderer.PdfDocument.Save(file);

            return file.ToArray();
        }
    }
}
