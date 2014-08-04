using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.IO;
using System.Windows.Forms;



namespace biosl5
{
    class main
    {
        // Declare variables

        private char q = '"';


        static void Main(string[] args)
        {
            LEX lexparser = new LEX();
            lexparser.init();
            lexparser.lexer("print \"this is a string\"");
            lexparser.lexer("print \"NEW STRING!\"");
            lexparser.showList();
            Console.ReadLine();
        }

        static void TestAllDataTypes()
        {
            bBool myBool = new bBool();
            myBool._name = "boolean";
            myBool.parse("false");
            Console.WriteLine("Boolean: " + myBool._val.ToString());

            bChar myChar = new bChar();
            myChar._name = "char";
            myChar.parse("\"\"");
            Console.WriteLine("Char: " + myChar._val.ToString());

            bDouble myDouble = new bDouble();
            myDouble._name = "double";
            myDouble.parse("2 * 3 + 4 - 1");
            Console.WriteLine("Double: " + myDouble._val.ToString());

            bFloat myFloat = new bFloat();
            myFloat._name = "float";
            myFloat.parse("1.5 + 2.2");
            Console.WriteLine("Float: " + myFloat._val.ToString());

            bInteger myInt = new bInteger();
            myInt._name = "integer";
            myInt.parse("5 + 2 + 3");
            Console.WriteLine("Integer: " + myInt._val.ToString());

            bShort myShort = new bShort();
            myShort._name = "short";
            myShort.parse("2 + 2 + 3");
            Console.WriteLine("Short: " + myShort._val.ToString());

            Console.ReadKey();
        }

        static string readFile(string location)
        {
            if (File.Exists(location))
            {
                string raw = File.ReadAllText(location);
                Console.WriteLine(raw);
            }
            else
            {
                Console.WriteLine("Invalid path name!");
            }

            return "";
        }
    }
}
