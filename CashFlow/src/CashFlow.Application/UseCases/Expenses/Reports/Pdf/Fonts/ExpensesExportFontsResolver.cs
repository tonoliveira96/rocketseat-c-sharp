using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts
{
    public class ExpensesExportFontsResolver : IFontResolver
    {
        byte[]? IFontResolver.GetFont(string faceName)
        {

            var stream = ReadFontFile(faceName);

            if (faceName == null)
            {
                stream = ReadFontFile(FontHelper.DEFAULT_FONT);
            }

            var length = stream!.Length;

            var data = new byte[length];

            stream.Read(buffer: data, offset: 0, count: (int)length);

            return data;
        }

        FontResolverInfo? IFontResolver.ResolveTypeface(string familyName, bool bold, bool italic)
        {
            return new FontResolverInfo(familyName);
        }

        private Stream? ReadFontFile(string faceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return assembly.GetManifestResourceStream($"CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts.{faceName}.ttf");
        }
    }
}
