using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace biosl5
{
    class bChar
    {
        public string _name = "charName";
        // Chars start at a-z, then A-Z, then 0-9
        public char _val = Convert.ToChar('a');
        public string _type = "char";

        public void parse(string returnStatement)
        {
            returnStatement.TrimStart().TrimEnd();
            string[] input = returnStatement.Split(' ');

            if (returnStatement.Contains("'"))
            {
                input = returnStatement.Split('\'');
            }
            else if (returnStatement.Contains('"'))
            {
                input = returnStatement.Split('"');
            }
            
            try {
                _val = Convert.ToChar(input[1]);
            } catch(Exception ex) {
                
            }
        }
    }
}