using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace biosl5
{
    class LEX ///init this a new instance
    {

        public ArrayList cmdLst = new ArrayList();
        private ArrayList tokenLst = new ArrayList();

        private string _temp = "";

        bool inString = false;

        public void init()
        {
            //MATH OPERATORS
            tokenLst.Add("+"); //0
            tokenLst.Add("-"); //1
            tokenLst.Add("/"); //2
            tokenLst.Add("*"); //3

            //TEST
            tokenLst.Add("print"); //4
            tokenLst.Add("\""); //5
            tokenLst.Add("'"); //6
        }

        public void lexer(string _lne)
        {

            char[] currentToken;
            string token = "";
            bool canGo = true;

            currentToken = _lne.ToCharArray();

            for (int currIndex = 0; currIndex < currentToken.Length && canGo; currIndex++) //loop thru every char
            {

                token += currentToken[currIndex];
                //Console.WriteLine(token);

                if (inString)
                {
                    if (currentToken[currIndex] != '"' && currentToken[currIndex].ToString() != "'") ///this is for strings!
                    {
                        _temp += currentToken[currIndex];
                    }
                    else if (currentToken[currIndex] == '"' || currentToken[currIndex].ToString() == "'")
                    {
                        if (_temp != "") { cmdLst.Add(_temp); _temp = ""; }
                        inString = false;
                    }
                }
                else
                {
                    if (currentToken[currIndex])
                    {
                    }
                }


                string tok = token.ToLower();


                switch (tok)
                {
                    case "print":
                        cmdLst.Add("print");
                        token = "";
                        break;

                    case "if":
                        cmdLst.Add("if");
                        token = "";
                        break;

                    case "else":
                        cmdLst.Add("else");
                        token = "";
                        break;

                    case " ":
                        token = "";
                        break;

                    case "\"":
                    case "'":
                        if (!inString)
                        {
                            inString = true;
                        }
                        token = "";
                        break;

                    case "\r\n":
                        token = "";
                        break;

                }

            }//for_main


        }//function

        public void showList()
        {
            for (int i = 0; i < cmdLst.Count; i++)
            {
                Console.WriteLine("'" + cmdLst[i] + "'");
            }
        }

    }
}
