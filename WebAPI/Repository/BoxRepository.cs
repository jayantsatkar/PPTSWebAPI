using System.Data;
using System.Data.SqlClient;

namespace WebAPI.Repository
{
    public class BoxRepository : IBoxRepository
    {
        public IConfiguration Configuration { get; }

        public BoxRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DataTable GetReportData()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBHelper.ExecuteProcedure("usp_GetFloatReport", parameters);
        }
    }
}
