﻿using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Dtos.User.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Abstractions.User;
using GlobalMeet.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        public CompanyController(ICompanyService companyService, IUserService userService)
        {
            _companyService = companyService;
            _userService = userService;
        }

        //[CustomAuthorize("SuperAdmin", "Owner")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddCompany([FromForm] AddCompanyDto companyDto)
        {
            var user = _userService.GetLoggedUser();
            var response = await _companyService.AddCompany(companyDto, (int)user.Data);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddWorker(int workerId)
        {
            var user = _userService.GetLoggedUser();
            var response = await _companyService.AddWorker((int)user.Data, workerId);
            if (response.Success)
            {
                await _userService.AddClaim(new AddClaimDto() { UserId = workerId.ToString(), ClaimName = "Moderator", ClaimType = "Moderator" });
                return Ok(response);
            }
            return new BadRequestResult();
        }




        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCompany(int id)
        {
            var response = await _companyService.GetCompany(id);
            return Ok(response);
        }


        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCompanies()
        {
            var response = await _companyService.GetCompanies();
            return Ok(response);
        }


        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> ApproveCompany(int id)
        {
            var response = await _companyService.ApproveRequest(id);
            if (response.Success)
            {
                var user = await _userService.GetUserByCompany(id);
                await _userService.AddClaim(new AddClaimDto() { UserId = user.Data.ToString(), ClaimName = "Owner", ClaimType = "Owner" });
            }
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> RejectCompany(int id)
        {
            var response = await _companyService.RejectRequest(id);
            return Ok(response);
        }
    }
}
