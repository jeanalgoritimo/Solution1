using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApCalc.Aplication.Responses;

namespace WebApCalc.Aplication.Interfaces
{
    public interface ICalcularService
    {
        Calculo CalcularValores(string valorInicial, string prazo);
    }
}
