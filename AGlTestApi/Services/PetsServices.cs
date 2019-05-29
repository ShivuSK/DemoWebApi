using AGLTest.Models;
using AGLTestApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AGLTestApi.Services
{
    public class PetsServices : IPetsServices
    {
        /// <summary>
        /// This method is used to get the Cat pet owners and grouped by Gender
        /// </summary>
        /// <param name="configuration">Variable to use to fetch the appsenting values</param>
        /// <returns></returns>
        public Result GetPetsOwner(IConfiguration configuration)
        {
            Result result = new Result();

            //initiate the httpclient 
            using (var client = new HttpClient())
            {
                try
                {
                    //Get the JSON data url from the appsettings
                    var jsonDataUrl = configuration.GetValue<string>("DataUrl");
                    client.BaseAddress = new Uri(jsonDataUrl);

                    //Call the http request to get the JSON response
                    HttpResponseMessage response = client.GetAsync(jsonDataUrl).Result;

                    //List to collect the Male Owners
                    List<string> listMaleOwners = new List<string>();

                    //List to collect the Female Owners
                    List<string> listFemaleOwners = new List<string>();

                    //Checck the response code is eqaul to 200 OK
                    if (response.IsSuccessStatusCode)
                    {
                        //Get the JSON responase
                        var responsRresult = response.Content.ReadAsStringAsync().Result;

                        //Deserilize the JSON response and map it to List<Person> model
                        var deserilizedResults = JsonConvert.DeserializeObject<List<Person>>(responsRresult)
                                                .Where(x => x.Pets != null).OrderByDescending(y => y.Gender).ToList();

                        //Checkc the list item count 
                        if (deserilizedResults.Count != 0)
                        {

                            foreach (var deserilizedResult in deserilizedResults)
                            {
                                //Get the Gender of the Pet Owner
                                string gender = deserilizedResult.Gender;

                                //filter the JSON response by the pet type "Cat" and select the Pet owner name
                                var petsOwner = deserilizedResult.Pets.Where(x => x.Type == "Cat").Select(n => n.Name).ToList();

                                //Collecct the male and female owners in a separate list
                                foreach (var ownerName in petsOwner)
                                {
                                    if (string.Equals(gender, "Male"))
                                        listMaleOwners.Add(ownerName);
                                    else
                                        listFemaleOwners.Add(ownerName);
                                }
                            }

                            //sort the male and female owners list in assending order
                            listMaleOwners.Sort();
                            listFemaleOwners.Sort();

                            List<CatOwners> listCatOwners = new List<CatOwners>()
                             {
                                    new CatOwners
                                    {
                                        Gender = "Male",
                                        Owners = listMaleOwners
                                    },
                                    new CatOwners
                                    {
                                        Gender = "Female",
                                        Owners = listFemaleOwners
                                    }
                             };

                            result.CatTypeOwners = listCatOwners;
                        }
                        else
                            return null;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return result;
        }
    }
}
