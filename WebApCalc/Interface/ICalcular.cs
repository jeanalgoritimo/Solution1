using WebApCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApCalc.Interface
{
    public interface ICalcular
    {
        Calculo CalcularValores(string valorInicial, string meses);
    }
}
