using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results; 
using WebApi.Calculo.Controllers;
using WebApi.Calculo.Aplication.Interfaces;
using WebApi.Calculo.Aplication.Services;
using WebApi.Calculo.Aplication.Responses;
using WebApi.Calculo.Aplication.Requests;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ICalcularService _calcular = new CalcularService();

        [TestMethod]
        public void PostSimplesNotNull()
        {
            var testCalulo = GetValores("200", "2");
            var controller = new CalculosController(_calcular);
            var result = controller.Post(testCalulo);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostChecks()
        {
            var testCalulo = GetValores("200", "2");
            var controller = new CalculosController(_calcular);

            var result = controller.Post(testCalulo);
            var responseString = (OkNegotiatedContentResult<CalculosResponses>)result;

            Assert.AreEqual(responseString.Content.ValorBruto, 9388.8);
            Assert.AreEqual(responseString.Content.ValorLiquido, 9188.8);
        }

        [TestMethod]
        public void PostupToSixMonths()
        {
            var testCalulo = GetValores("200", "6");
            var controller = new CalculosController(_calcular);

            var result = controller.Post(testCalulo);
            var responseString = (OkNegotiatedContentResult<CalculosResponses>)result;

            Assert.AreEqual(responseString.Content.ValorBruto, 9388.8);
            Assert.AreEqual(responseString.Content.ValorLiquido, 9188.8);
        }
        [TestMethod]
        public void PostupToTwelveMonths()
        {
            var testCalulo = GetValores("200", "12");
            var controller = new CalculosController(_calcular);

            var result = controller.Post(testCalulo);
            var responseString = (OkNegotiatedContentResult<CalculosResponses>)result;

            Assert.AreEqual(responseString.Content.ValorBruto, 8388.8);
            Assert.AreEqual(responseString.Content.ValorLiquido, 8188.8);
        }
        [TestMethod]
        public void PostupToTwentyFourMonths()
        {
            var testCalulo = GetValores("200", "24");
            var controller = new CalculosController(_calcular);

            var result = controller.Post(testCalulo);
            var responseString = (OkNegotiatedContentResult<CalculosResponses>)result;

            Assert.AreEqual(responseString.Content.ValorBruto, 7388.8);
            Assert.AreEqual(responseString.Content.ValorLiquido, 7188.8);
        }
        [TestMethod]
        public void PostOverTwentyFourMonths()
        {
            var testCalulo = GetValores("200", "30");
            var controller = new CalculosController(_calcular);

            var result = controller.Post(testCalulo);
            var responseString = (OkNegotiatedContentResult<CalculosResponses>)result;

            Assert.AreEqual(responseString.Content.ValorBruto, 6388.8);
            Assert.AreEqual(responseString.Content.ValorLiquido, 6188.8);
        }
        [TestMethod]
        public void PostChecksBadRequest()
        {
            var controller = new CalculosController(_calcular);
            var result = controller.Post(null);
            var responseString = ((BadRequestErrorMessageResult)result).Message;
            Assert.AreEqual(responseString, "Error in Request");
        }
        private Parametros GetValores(string _valorInicial, string _Prazo)
        {
            var testCalulo = new Parametros();

            testCalulo.ValorInicial = _valorInicial;
            testCalulo.Prazo = _Prazo;

            return testCalulo;
        }
    }
}
