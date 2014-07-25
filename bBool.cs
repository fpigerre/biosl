using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace biosl5
{
    class bBool
    {

        public string _name = "default";
        public bool _val = false;

        public string _type = "bool";

        public void parse(string returnStatement)
        {

            returnStatement = returnStatement.TrimStart().TrimEnd().ToLower();

            string[] sRet = returnStatement.Split(' ');

            switch (sRet[0].ToLower())
            {

                case "return":
                    parse(sRet[1]);
                    break;

                case "true":
                    _val = true;
                    break;

                case "false":
                    _val = false;
                    break;

                default:
                    Console.WriteLine("Invalid boolean value!");
                    break;

            }

        }


    }
}
