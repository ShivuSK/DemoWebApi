using AGLTest.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGLTestApi.Services
{
    public interface IPetsServices
    {
        /// <summary>
        /// Interface method to get the pets owner collecction
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        Result GetPetsOwner(IConfiguration configuration);
    }
}
