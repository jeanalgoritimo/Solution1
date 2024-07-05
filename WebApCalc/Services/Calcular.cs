using WebApCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using WebApCalc.Interface;

namespace WebApCalc.Services
{
    public class Calcular  : ICalcular
    {
        public Calculo CalcularValores(string valorInicial, string meses)
        {
             
            Calculo calculo = new Calculo();

            if ((!string.IsNullOrEmpty(valorInicial) && !string.IsNullOrEmpty(meses)))
            {
                calculo.ValorBruto = CalculoValorFinal(valorInicial, meses);
                calculo.ValorLiquido = CalculoValorLiquido(valorInicial, calculo.ValorBruto);
                 
            }
            else
            {
                calculo = new Calculo();
            }
         
            return calculo;
        }
        private double CalculoValorFinal(string valorInicial, string meses)
        {
            double meuValor = 0;
            meuValor = Math.Round(Convert.ToDouble(valorInicial), 2);
            var porcentagem = impostoTable(meses);
            var TBI_CDI = 1.08 * 0.009;
            var TBI_CDI_Imposto = porcentagem + TBI_CDI;
            var ImpostoFinal = meuValor * TBI_CDI_Imposto;
            var ValorFinal = meuValor * ImpostoFinal;

            return Math.Round(Convert.ToDouble(ValorFinal), 2);
        }
        private double CalculoValorLiquido(string valorbruto, double valorInvestido)
        {
            double meuValor = 0;
            meuValor = Math.Round(Convert.ToDouble(valorbruto), 2);
            var ValorFinal = valorInvestido - meuValor;

            return Math.Round(Convert.ToDouble(ValorFinal), 2);
        }
        private double impostoTable(string faixaImposto)
        {
            double imposto = 0;

            int faixaImpostoInt = Convert.ToInt32(faixaImposto);
            if (faixaImpostoInt <= 6)
            {
                imposto = 0.225;
            }
            else if (faixaImpostoInt <= 12)
            {
                imposto = 0.2;
            }
            else if (faixaImpostoInt <= 24)
            {
                imposto = 0.175;
            }
            else if (faixaImpostoInt > 24)
            {
                imposto = 0.15;
            } 

            return imposto;
        }
    }
}