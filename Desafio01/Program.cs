﻿using Desafio01;
using System.Globalization;

namespace Program
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Task 1 - Digite seu nome para receber uma mensagem de boas vindas: ");
            var valor = Console.ReadLine();
            Console.WriteLine($"Olá, {valor}! Seja muito bem-vindo!");
            Console.WriteLine("\n");
            Console.WriteLine("**********************************************");

            Console.WriteLine("Task 2 - Formar o nome conpleto com nome e sobrenome: ");
            Console.WriteLine("Digite seu nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Digite seu sobrenome: ");
            var sobrenome = Console.ReadLine();
            Console.WriteLine(nome + " " + sobrenome);
            Console.WriteLine("\n");
            Console.WriteLine("**********************************************");

            Console.WriteLine("Task 2 - Operações matemáticas com 2 números: ");
            Console.Write("Primeiro número: ");
            var numero1 = Double.Parse(Console.ReadLine());
            Console.Write("Segundo número: ");
            var numero2 = Double.Parse(Console.ReadLine());
            var calc = new Calculator(numero1, numero2);
            Console.WriteLine("\n");
            Console.Write("Soma: " + calc.Soma() + "\n");
            Console.Write("Subtração: " + calc.Subtracao() + "\n");
            Console.Write("Multiplicação: " + calc.Multiplicacao() + "\n");
            Console.Write("Divisão: " + calc.Divisao() + "\n");
            Console.Write("Média: " + calc.Media() + "\n");
            Console.WriteLine("**********************************************");

            Console.WriteLine("Task 4 - Contagem de caracteres: ");
            Console.WriteLine("Digite qualquer palavra: ");
            var palavra = Console.ReadLine();
            var palavraFormatada = palavra.ToString().Trim().Replace(" ", "").Length;
            Console.WriteLine("Quantidade de caracteres: " + palavraFormatada);
            Console.WriteLine("\n");
            Console.WriteLine("**********************************************");

            Console.WriteLine("Task 5 - Verifica placa do carro: ");
            Console.WriteLine("Digite a placa do carro: ");
            var placa = Console.ReadLine();
            var validaPlaca = new Placa(placa);
            var placaResultado = validaPlaca.PlacaValida() ? "Placa válida!" : "Placa Inválida!";
            Console.WriteLine(placaResultado);
            Console.WriteLine("\n");
            Console.WriteLine("**********************************************");

            Console.WriteLine("Task 6 - Exibe a data atual em vários formatos: ");
            var data = DateTime.Now;
            CultureInfo idioma = new CultureInfo("pt-BR");
            Console.WriteLine("Formato completo: " + data.ToString("G", idioma));
            Console.WriteLine("Apenas a data no formato 'dd/MM/yyy': " + data.ToString("dd/MM/yyyy", idioma));
            Console.WriteLine("Apenas hora no formato 24h: " + data.ToString("HH:mm", idioma));
            Console.WriteLine("A data com o mês por extenso: " + data.ToString("dd MMMM yyyy", idioma));
            Console.WriteLine("\n");
            Console.WriteLine("**********************************************");
        }
    }
}

