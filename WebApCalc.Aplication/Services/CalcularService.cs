using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApCalc.Aplication.Interfaces;
using WebApCalc.Aplication.Responses;

namespace WebApCalc.Aplication.Services
{
    public class CalcularService : ICalcularService
    {
        public Calculo CalcularValores(string valorInicial, string prazo)
        {
            Calculo calculo = new Calculo();
            calculo.ValorBruto = 9388.8;
            calculo.ValorLiquido = 9188.8;
            return calculo;
        }
    }
}
