using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using WebApCalc.Controllers;
using WebApCalc.Interface;
using WebApCalc.Models;
using WebApCalc.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ICalcular _calcular = new Calcular();
        [TestMethod]
        public void PostSimplesNotNull()
        { 
            var testCalulo = GetValores();
            var controller = new CalculoController(_calcular); 
            var result = controller.Post(testCalulo);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostChecks()
        { 
            var testCalulo = GetValores();
            var controller = new CalculoController(_calcular);

            var result = controller.Post(testCalulo);
            var responseString = result as OkNegotiatedContentResult<Calculo>;

            Assert.AreEqual(responseString.Content.ValorBruto, 9388.8);
            Assert.AreEqual(responseString.Content.ValorLiquido, 9188.8);
        }

        [TestMethod]
        public void PostChecksBadRequest()
        {
            var controller = new CalculoController(_calcular);
            var result = controller.Post(null);
            var responseString = result as OkNegotiatedContentResult<Calculo>;
            Assert.IsNull(responseString);
        }
        private ParamtrosCalculo GetValores()
        {
            var testCalulo = new ParamtrosCalculo();

            testCalulo.ValorInicial = "200";
            testCalulo.Prazo = "2";

            return testCalulo;
        }
    }
}
