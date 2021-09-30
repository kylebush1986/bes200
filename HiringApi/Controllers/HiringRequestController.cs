using HiringApi.Models;
using HiringApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringApi.Controllers
{
    public class HiringRequestController : ControllerBase
    {
        private readonly IHireEmployees _employeeHiringService;

        public HiringRequestController(IHireEmployees employeeHiringService)
        {
            _employeeHiringService = employeeHiringService;
        }

        [HttpPost("hiring-requests")]
        public async Task<ActionResult> AddHiringRequest([FromBody] PostHiringRequest request)
        {
           // Validate - if bad, return a 400.
           if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

     

            GetHiringResponse response = await _employeeHiringService.HireAsync(request);
           

          //  await Task.Delay(3000);
            return Ok(response);
        }

       
    }
}
