using BaseApi.Controllers.DTO;
using BaseApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("reportdisaster")]
    public class ReportDisasterController : Controller
    {
        private readonly IReportDisasterService _reportDisasterService;
        public ReportDisasterController(
            IReportDisasterService reportDisasterService
        )
        {
            _reportDisasterService = reportDisasterService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var response = _reportDisasterService.GetAll();

            return Ok(
                response
            );
        }

        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateReportDisasterDTO dto
        )
        {
            var response = _reportDisasterService.Create(
                dto
            );

            return Ok(
                response
            );
        }

        [HttpPut]
        public IActionResult Update(
            [FromBody] UpdateStatusReportDisasterDTO dto
        )
        {
            var response = _reportDisasterService.Update(
                dto
            );

            return Ok(
                response
            );
        }
    }
}