namespace DesafioPaggCerto.Extensions
{
    public static class StringExt
    {
        public static string CardMask(this string cardNumber)
        {
            return cardNumber.Substring(0, 4) + "********" + cardNumber.Substring(cardNumber.Length - 4);
        }
    }
}
