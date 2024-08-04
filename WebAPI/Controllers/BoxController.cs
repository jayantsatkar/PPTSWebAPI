using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebAPI.Repository;
using Newtonsoft.Json;
using NLog;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly IBoxRepository boxRepository;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public BoxController(IBoxRepository boxRepository)
        {
            this.boxRepository = boxRepository;
        }

        [HttpGet]
        public ActionResult GetReportData()
        {
            logger.Info("Application Started");
            DataTable dt = new DataTable();
            try
            {
             dt = boxRepository.GetReportData();
            }
            catch (Exception ex)
            {
            }
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(dt));

        }
    }
}
