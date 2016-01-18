using System;

namespace CashRegister
{
    [Serializable]
    public class UnknownProductException : Exception
    {
        public UnknownProductException(string message) : base(message)
        {
        }
    }
}