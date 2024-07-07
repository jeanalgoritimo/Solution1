using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Calculo.Aplication.Responses;

namespace WebApi.Calculo.Aplication.Interfaces
{
    public interface ICalcularService
    {
        CalculosResponses CalcularValores(string valorInicial, string prazo);
    }
}
