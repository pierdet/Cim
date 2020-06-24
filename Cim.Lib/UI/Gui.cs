using System;

namespace Cim.Lib.UI
{
    public class Gui : IGui
    {
        public void Write(string msg)
        {
            Console.Write(msg);
        }
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
        public void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public void WriteSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        //Todo - Implement WriteList
    }
}
