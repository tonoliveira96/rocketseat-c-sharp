using Desafio01;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
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
            Console.Write("Soma: " + calc.Soma() + "\n");
            Console.Write("Subtração: " + calc.Subtracao() + "\n");
            Console.Write("Multiplicação: " + calc.Multiplicacao() + "\n");
            Console.Write("Divisão: " + calc.Divisao() + "\n");
            Console.Write("Média: " + calc.Media() + "\n");
            Console.WriteLine("**********************************************");
        }
    }
}

