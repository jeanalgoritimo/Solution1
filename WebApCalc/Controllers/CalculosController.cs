using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using WebApi.Calculo.Aplication.Interfaces;
using WebApi.Calculo.Aplication.Requests;

namespace WebApi.Calculo.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "http://localhost:9646", headers: "*", methods: "*")]
   
    public class CalculosController : ApiController
    {
        private readonly ICalcularService _calcular;
        public CalculosController(ICalcularService calcular)
        {
           this._calcular = calcular;
        }

        [DisableCors]
        public IHttpActionResult Post([FromBody] Parametros paramtrosCalculo)
        {
            try
            {
                var calculado = this._calcular.CalcularValores(paramtrosCalculo.ValorInicial, paramtrosCalculo.Prazo);
                return Ok(calculado);

            }
            catch(Exception ex)
            {
                return BadRequest("Error in Request");

            }
           
        }
         
    }

    
}
