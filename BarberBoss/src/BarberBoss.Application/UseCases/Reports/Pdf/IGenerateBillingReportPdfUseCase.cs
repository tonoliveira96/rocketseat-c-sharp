namespace BarberBoss.Application.UseCases.Reports.Pdf;
public interface IGenerateBillingReportPdfUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
