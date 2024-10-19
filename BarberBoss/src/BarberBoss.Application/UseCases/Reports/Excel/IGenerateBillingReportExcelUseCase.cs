namespace BarberBoss.Application.UseCases.Reports.Excel;
public interface IGenerateBillingReportExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}

