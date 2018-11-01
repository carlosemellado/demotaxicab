using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiCab_WebHooksApi.Controllers;

namespace TaxiCab_WebHooksApi.Tests
{
    [TestClass]
    public class AutenticationControlleTest
    {
        [TestMethod]
        public void SigninTest()
        {
            AutenticationController autenticationController = new AutenticationController();
            var result = autenticationController.Signin(new User() { name = "carlos.mellado@outlook.com" });
        }


        [TestMethod]
        public void SignOutTest()
        {
            AutenticationController autenticationController = new AutenticationController();
            var result = autenticationController.SignOut(new User() { name = "carlos.mellado@outlook.com" });
        }


    }
}
