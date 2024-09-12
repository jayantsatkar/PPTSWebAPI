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

        public DataSet GetReportData(String PartNumber)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DBHelper.AddSqlParameter("@BoschPart_No", PartNumber, ref parameters);

            return DBHelper.ExecuteProcedureDataSet("usp_GetFloatReport", parameters);
        }

        public DataTable GetAllPartNumbers()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBHelper.ExecuteProcedure("usp_GetParts", parameters);
        }

        
    }
}
