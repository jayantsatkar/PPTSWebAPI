using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebAPI.Repository;
using Newtonsoft.Json;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly IBoxRepository boxRepository;

        public BoxController(IBoxRepository boxRepository)
        {
            this.boxRepository = boxRepository;
        }

        [HttpGet]
        public ActionResult GetReportData()
        {
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
