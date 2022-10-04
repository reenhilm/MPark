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

namespace MParkServer
{
    public static class MParkMachinesAPI
    {
        [FunctionName("GetMachines")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "machines")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            var machines = GetMParkMachines();
            return new OkObjectResult(machines);
        }

        [FunctionName("CreateMachines")]
        public static async Task<IActionResult> Create(
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
                LocationCity = createMParkMachine.LocationCity,
                LocationCountry = createMParkMachine.LocationCountry,
                Type = createMParkMachine.Type
            };

            return new OkObjectResult(machine);
        }

        private static IEnumerable<MParkMachine> GetMParkMachines()
        {
            return new List<MParkMachine>()
            {
                new MParkMachine()
                {
                    Id = Guid.NewGuid(),
                    LocationCity = "Eskilstuna",
                    LocationCountry = "Sweden",
                    LastUpdated = DateTime.Now.AddDays(-4).AddHours(22).AddMinutes(15),
                    IsOnline = true,
                    Type = MachineType.Humidity,
                    Data = "Banan"
                },
                new MParkMachine()
                {
                    Id = Guid.NewGuid(),
                    LocationCity = "Västerås",
                    LocationCountry = "Sweden",
                    LastUpdated = DateTime.Now.AddDays(-10).AddHours(11).AddMinutes(55),
                    Type = MachineType.Temperature,
                    Data = "Melon"
                },
                new MParkMachine()
                {
                    Id = Guid.NewGuid(),
                    LocationCity = "Stockholm",
                    LocationCountry = "Sweden",
                    LastUpdated = DateTime.Now.AddDays(-105).AddHours(2).AddMinutes(45),
                    Type = MachineType.Temperature,
                    Data = "Kiwi",
                    IsOnline = true
                },
                new MParkMachine()
                {
                    Id = Guid.NewGuid(),
                    LocationCity = "Sundsvall",
                    LocationCountry = "Sweden",
                    LastUpdated = DateTime.Now.AddDays(-305).AddHours(10).AddMinutes(1),
                    Type = MachineType.Temperature,
                    Data = "Citron"
                }
            };
        }
    }
}
