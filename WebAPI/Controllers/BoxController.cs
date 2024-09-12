using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebAPI.Repository;
using Newtonsoft.Json;
using NLog;
using Newtonsoft.Json.Linq;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class BoxController : ControllerBase
    {
        private readonly IBoxRepository boxRepository;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public BoxController(IBoxRepository boxRepository)
        {
            this.boxRepository = boxRepository;
            logger.Info("Application Started");
        }

        [HttpPost("ReportData")]
        public ActionResult GetReportData(dynamic obj)
        {

            DataSet dt;//= new DataTable();
            try
            {
                JObject jsonObject = JObject.Parse(obj.ToString());
                string PartNumber = (string)jsonObject["partNumber"];
             dt = boxRepository.GetReportData(PartNumber);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500, "An error occurred. Please contact administrator");
            }
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(dt));

        }

        [HttpGet("GetAllPartNumbers")]
        public ActionResult GetAllPartNumbers()
        {

            DataTable dt;//= new DataTable();
            try
            {
                dt = boxRepository.GetAllPartNumbers();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500, "An error occurred. Please contact administrator");
            }
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(dt));

        }
    }
}
