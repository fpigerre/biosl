using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace biosl5
{
    class LEX ///init this a a new instance
    {

        public ArrayList cmdLst = new ArrayList();
        private ArrayList tokenLst = new ArrayList();

        private string _temp = "";

        bool inStr = false;

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

            char[] currTok;
            string token = "";
            bool canGo = true;

            currTok = _lne.ToCharArray();

            for (int currIndex = 0; currIndex < currTok.Length && canGo; currIndex++) //loop thru every char
            {

                token += currTok[currIndex];
                //Console.WriteLine(token);



                if (inStr && currTok[currIndex] != '"') ///this is for strings!
                {
                    _temp += currTok[currIndex]; 
                }
                else if (currTok[currIndex] == '"') 
                {
                    if (_temp != "") { cmdLst.Add(_temp); _temp = ""; }
                    inStr = false;
                }


                string tok = token.ToLower();


                switch (tok)
                {
                    case "print":
                        cmdLst.Add("print");
                        token = "";
                        break;

                    case " ":
                        token = "";
                        break;

                    case "\"":
                        if (!inStr) {
                            inStr = true;
                        }
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
