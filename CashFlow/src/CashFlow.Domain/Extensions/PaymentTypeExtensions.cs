using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Extensions
{
    public static class PaymentTypeExtensions
    {
        public static string PaymentTypeToString(this PaymentType payment)
        {
            return payment switch
            {
                PaymentType.Cash => "Dinheiro",
                PaymentType.CreditCard => "Cart�o de Cr�dito",
                PaymentType.DebitCard => "Cart�o de D�bito",
                PaymentType.EletronicTransfer => "Pix",
                _ => string.Empty,
            };
        }
    }
}
