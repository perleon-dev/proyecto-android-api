﻿using Customer.Application.Queries.Interfaces;
using Customer.Application.Queries.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFastServiceQueryHandler IFastServiceQueryHandler;


        public FastServiceController(IMediator mediator, IFastServiceQueryHandler iFastServiceQueryHandler)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            IFastServiceQueryHandler = iFastServiceQueryHandler ?? throw new ArgumentNullException(nameof(iFastServiceQueryHandler));
        }

        [HttpGet("get-search-by-id-cliente")]
        [ProducesResponseType(typeof(userLoginViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByBlobStorage([FromQuery] LoginRequest login)
        {
            var result =  IFastServiceQueryHandler.Login(login);
            return Ok(result);
        }

    }
}
