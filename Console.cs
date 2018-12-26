using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public static class ExtensionMethods
        {
            public static int toInt(this string value)
            {
                return int.Parse(value);
            }
        }
    class Console
    {
        static public string Ask(string question)
        {
            System.Console.Write(question);
            return System.Console.ReadLine();
        }

        static public int AskInt(string question)
        {
            try
            {
                System.Console.Write(question);
                return (System.Console.ReadLine()).toInt();
            }
            catch (Exception) 
            {
                throw new FormatException("Input was not a number! Error Util #843-2");
            }
        }
    }
}
