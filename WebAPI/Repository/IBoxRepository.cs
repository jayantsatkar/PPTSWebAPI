using System.Data;

namespace WebAPI.Repository
{
    public interface IBoxRepository
    {
        DataTable GetReportData();

        DataTable GetAllPartNumbers();
    }
}
