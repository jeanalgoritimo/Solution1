using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Calculo.Aplication.Interfaces;
using WebApi.Calculo.Aplication.Responses;

namespace WebApi.Calculo.Aplication.Services
{
    public class CalcularService : ICalcularService
    {
        public CalculosResponses CalcularValores(string valorInicial, string prazo)
        {

            CalculosResponses calculo = new CalculosResponses();

            if ((!string.IsNullOrEmpty(valorInicial) && !string.IsNullOrEmpty(prazo)))
            {
                calculo.ValorBruto = CalculoValorFinal(valorInicial, prazo);
                calculo.ValorLiquido = CalculoValorLiquido(valorInicial, calculo.ValorBruto);

            }
            else
            {
                calculo = new CalculosResponses();
            }

            return calculo;
        }
        private double CalculoValorFinal(string valorInicial, string prazo)
        {
            double meuValor = 0;
            meuValor = Math.Round(Convert.ToDouble(valorInicial), 2);
            var porcentagem = impostoTable(prazo);
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
