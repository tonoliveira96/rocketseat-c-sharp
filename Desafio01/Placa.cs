namespace Desafio01
{
    public class Placa
    {
        public string ValorPlaca { get; set; }

        public Placa(string valorPlaca)
        {
            ValorPlaca = valorPlaca;
        }

        public bool PlacaValida()
        {
            if (ValorPlaca.Length != 7)
                return false;

            for (int i = 0; i < 3; i++)
            {
                if (!Char.IsLetter(ValorPlaca[i]))
                {
                    return false;
                }
            }

            for (int i = 3; i < 6; i++)
            {
                if (!Char.IsNumber(ValorPlaca[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
