using WebApCalc.Interface;
using WebApCalc.Models;
using WebApCalc.Services;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace WebApCalc.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "http://localhost:9646", headers: "*", methods: "*")]
   
    public class CalculoController : ApiController
    {
        private readonly ICalcular _calcular;
        public CalculoController(ICalcular calcular)
        {
           this._calcular = calcular;
        }

        [DisableCors]
        public IHttpActionResult Post([FromBody] ParamtrosCalculo paramtrosCalculo)
        {
            try
            {
                var calculado = this._calcular.CalcularValores(paramtrosCalculo.ValorInicial, paramtrosCalculo.Prazo);
                return Ok(calculado);

            }
            catch(Exception ex)
            {
                return BadRequest();

            }
           
        }
         
    }

    
}
