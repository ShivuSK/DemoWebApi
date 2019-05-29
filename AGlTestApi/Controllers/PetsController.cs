using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGLTest.Models;
using AGLTestApi.Models;
using AGLTestApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AGlTestApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IPetsServices  petsServices;
        /// <summary>
        /// Constructor call to intiate the configurarion and  service class objects
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="petsServices"></param>
        public ValuesController(IConfiguration configuration, IPetsServices petsServices)
        {
            this.configuration = configuration;           
            this.petsServices = petsServices;
        }
       
        /// <summary>
        /// Get request /api/GetPetsOwners to fetch the Cat pet owner collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPetsOwners")]
        public ActionResult<Result> GetPetsOwners()
        {
            //service method call to get the Cat pet owner collection
            Result petsOwnersResult = petsServices.GetPetsOwner(configuration);
            return petsOwnersResult;

        }

    }
}
