using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiCab_WebHooksApi.Controllers;
using TaxiCab_WebHooksApi.Models;
using TaxiCab_WebHooksApi.Repository;

namespace TaxiCab_WebHooksApi.Tests
{
    

    [TestClass]
    public class VehicleControllerTets
    {

        ITaxiCabVehicleRepository repository;


        [TestInitialize]
        public void TestInitialize()
        {
            // We can change the repository to MONGO DB REPOSITORY, because VahicleController accept 
            // ITaxiCabVehicleRepository objects
            repository = new TaxiCabVehicleRepository();
        }

        [TestMethod]
        public void UpdateLocationTest()
        {
            decimal latitud = 87.1000982m;
            decimal longitud = 88.1000982m;
            var updateLocationModel = new UpdateLocationModel{
                vehicle = new  Vehicle{ vehicleId = "AAA-AAA" },
                locations = new List<Location>() {
                    new Location { datetime = DateTime.Now, latitud = $"{latitud}", longitud = $"{longitud}" },
                    new Location { datetime = DateTime.Now, latitud = $"{latitud}", longitud = $"{longitud}" }
                }
            };
            VahicleController vehicleController = new VahicleController(repository);
            vehicleController.Request = new HttpRequestMessage();
            vehicleController.Request.SetConfiguration(new HttpConfiguration());
            var result = vehicleController.UpdateLocation(updateLocationModel);
            
        }


        [TestMethod]
        public void GetLocationsTest()
        {
            var updateLocationModel = new GetLocationModel
            {
                vehicle = new Vehicle { vehicleId = "AAA-AAA" }
            };
            VahicleController vehicleController = new VahicleController(repository);
            vehicleController.Request = new HttpRequestMessage();
            vehicleController.Request.SetConfiguration(new HttpConfiguration());
            var result = vehicleController.GetLocations(updateLocationModel);

        }
    }
}
