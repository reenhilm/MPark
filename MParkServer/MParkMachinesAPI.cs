using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using MPark.Shared;
using System;
using System.Linq;

namespace MParkServer
{
    public static class MParkMachinesAPI
    {
        [FunctionName("GetMachines")]
        public static IActionResult Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "machines")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            var machines = GetMParkMachines();
            return new OkObjectResult(machines);
        }

        [FunctionName("GetById")]
        public static IActionResult GetById(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "machines/{id}")] HttpRequest req,
        ILogger log, Guid id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //TODO Implement GetById
            return new OkObjectResult(GetMParkMachines().FirstOrDefault(m => m.Id == id));
        }        

        [FunctionName("DeleteMachine")]
        public static IActionResult Delete(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "machines/{id}")] HttpRequest req,
        ILogger log, Guid id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //TODO Implement Delete
            return new OkResult();
        }

        [FunctionName("UpdateMachine")]
        public static IActionResult Put(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "machines/{id}")] HttpRequest req,
        ILogger log, UpdateMParkMachine updateMParkMachine)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //TODO Implement Update
            return new OkResult();
        }

        [FunctionName("CreateMachines")]
        public static async Task<IActionResult> Post(
                [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "machines")] HttpRequest req,
                ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createMParkMachine = JsonConvert.DeserializeObject<CreateMParkMachine>(requestBody);

            //TODO Validate
            if (createMParkMachine == null || string.IsNullOrWhiteSpace(createMParkMachine.Data)) return new BadRequestResult();

            //TODO store in database
            //TODO addAutomapper
            var machine = new MParkMachine {
                Id= Guid.NewGuid(),
                LastUpdated= DateTime.Now,
                Data = createMParkMachine.Data,
                City = createMParkMachine.City,
                Country = CountryList.GetCountries().First(c => c.Id == createMParkMachine.CountryId),
                Type = createMParkMachine.Type
            };

            return new OkObjectResult(machine);
        }



        private static IEnumerable<MParkMachine> GetMParkMachines()
        {
            Country cSweden = CountryList.GetCountries().ToList().FirstOrDefault(c => c.Id == 1);

            return new List<MParkMachine>()
            {
                new MParkMachine()
                {
                    Id = Guid.Parse("35f70e59-cce4-4144-a668-fdb90a28ea3f"),
                    City = "Eskilstuna",
                    Country = cSweden,
                    LastUpdated = DateTime.Now.AddDays(-4).AddHours(22).AddMinutes(15),
                    IsOnline = true,
                    Type = MachineType.Humidity,
                    Data = "Banan"
                },
                new MParkMachine()
                {
                    Id = Guid.Parse("7795223a-901a-41d9-841c-f36968eb253d"),
                    City = "Västerås",
                    Country = cSweden,
                    LastUpdated = DateTime.Now.AddDays(-10).AddHours(11).AddMinutes(55),
                    Type = MachineType.Temperature,
                    Data = "Melon"
                },
                new MParkMachine()
                {
                    Id = Guid.Parse("37db4e8c-6beb-4226-b8ae-6594eb941ed6"),
                    City = "Stockholm",
                    Country = cSweden,
                    LastUpdated = DateTime.Now.AddDays(-105).AddHours(2).AddMinutes(45),
                    Type = MachineType.Temperature,
                    Data = "Kiwi",
                    IsOnline = true
                },
                new MParkMachine()
                {
                    Id = Guid.Parse("e2bd702f-8e42-4b6e-a671-06db0162efb7"),
                    City = "Sundsvall",
                    Country = cSweden,
                    LastUpdated = DateTime.Now.AddDays(-305).AddHours(10).AddMinutes(1),
                    Type = MachineType.Temperature,
                    Data = "Citron"
                }
            };
        }
    }
}
