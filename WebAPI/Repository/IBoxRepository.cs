using System.Data;

namespace WebAPI.Repository
{
    public interface IBoxRepository
    {
        DataSet GetReportData(string PartNumber);

        DataTable GetAllPartNumbers();
    }
}
