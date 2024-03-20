using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio01
{
    public class Calculator
    {
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }

        public Calculator(double valor1, double valor2)
        {
            Valor1 = valor1;
            Valor2 = valor2;
        }

        public double Soma()
        {
            return Valor1 + Valor2;
        }

        public double Subtracao()
        {
            return Valor1 - Valor2;
        }

        public double Multiplicacao()
        {
            return Valor1 * Valor2;
        }

        public double Divisao()
        {
            return Valor1 / Valor2;
        }

        public double Media()
        {
            return (Valor1 + Valor2) / 2;
        }
    }
}
