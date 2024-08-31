using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaseApi.Controllers.DTO;
using BaseApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
                id: dto.Id,
                status: dto.Status
            );

            return Ok(
                response
            );
        }
    }
}