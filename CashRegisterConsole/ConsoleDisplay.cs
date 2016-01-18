using System;
using CashRegister;

namespace CashRegisterConsole
{
    public class ConsoleDisplay : IDisplay
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}