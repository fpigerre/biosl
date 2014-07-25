using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace biosl5
{
    class bShort
    {


        //declare vars...such as for prop's, etc...         //int _name = _val
        public string _name = null;
        public short _val = 0;

        public string _type = "short";



        public void parse(string returnStatement)
        {
            returnStatement = returnStatement.TrimStart().TrimEnd().ToLower();


            string[] cmd = returnStatement.Split(' ');  //0 = 5,                1 = +              , 2 = 3

            switch (cmd[0])
            {

                case "return":
                    returnStatement = returnStatement.Substring(7);
                    parse(returnStatement);
                    break;

                default:
                    //ok, so now check to see if it is a direct math expression
                    string[] mathOperators = { "+", "-", "*", "/" };
                    bool isDirect = true;




                    //this checks to see if it has a valid math operator...
                    for (int i = 0; i < mathOperators.Length; i++)
                    {
                        if (returnStatement.Contains(" " + mathOperators[i] + " "))
                        {
                            isDirect = false;
                        }
                    }





                    if (!isDirect)
                    {

                        string _temp = returnStatement;
                        bool isDone = false;


                        while (!isDone)
                        {
                            //Console.WriteLine("DHISAHDIUSAGDSAK");
                            //get first three characters
                            //string _currExpr = _temp.Substring(0, 4);

                            //_temp = _temp.Substring(0, 4); //consume first three characters so above always works...
                            string[] _terms = _temp.Split(' ');

                            //Console.WriteLine("'" + returnStatement + "'");
                            //Console.WriteLine("'"+_terms[2]+"'");

                            //Console.WriteLine("..");

                            short x = 0;
                            short y = 0;
                            string _operator = "+";

                            try //if the user did not enter an value, then its no good, return a random value.
                            {

                                x = short.Parse(_terms[0]);
                                _operator = _terms[1]; //*, /, +, -      (mathOperators)
                                y = short.Parse(_terms[2]);

                                //Console.WriteLine(x.ToString() + "," + y.ToString() + "," + _operator);

                            }
                            catch (Exception ex)
                            {
                                isDone = true;

                            }


                            //made it this far, without any errors, the user has done all they need to do, so now just evaluate the code
                            //Console.WriteLine(x.ToString() + " " + _operator + " " + y.ToString());
                            _val = doExpression(x.ToString() + " " + _operator + " " + y.ToString());


                            //check to see if the code should keep executing. (by checking to see if in the new array, char 1 ( + 3) is an operator;
                            string[] tempSplit = _temp.Split(' ');
                            bool matched = false;

                            for (int j = 0; j < mathOperators.Length - 1; j++)
                            {

                                try
                                {
                                    if (tempSplit[1] == mathOperators[j] && !matched) //!matched for speed
                                    { matched = true; }
                                }
                                catch (Exception e)
                                {
                                    isDone = true;
                                    matched = true;
                                }


                            }//for



                            try //if this fails, then we are done!
                            {
                                int xLen = x.ToString().Length;
                                int yLen = y.ToString().Length;

                                int newLen = 3 + xLen + yLen; //2 spaces (x_+_y)

                                _temp = _val.ToString() + _temp.Substring(newLen);
                                //MsgBox(_temp);

                            }
                            catch (Exception e)
                            {

                                for (int i = 0; i < mathOperators.Length - 1; i++)
                                {
                                    isDone = true;


                                    if (_temp.Contains(mathOperators[i]))
                                    {
                                        isDone = false;
                                    }
                                } //for

                                if (!isDone)
                                { //so it is a follow up


                                    _temp = _val.ToString() + _temp;


                                }

                            }//try


                            if (_temp.TrimEnd() == "") { isDone = true; }

                        }//while

                    }//if
                    else
                    {


                        _val = getValue(returnStatement);


                    }



                    break;
            }



        }


        static short doExpression(string operation) //example : "2 * 3"
        {

            string[] words = operation.Split(' ');

            try
            {
                short x = short.Parse(words[0]); //must be signed
                short y = short.Parse(words[2]); //must be signed
                string sign = words[1];      //this is so I can test which operator to use.

                switch (sign)
                {
                    case "+":
                        return (short)(x + y);
                        break;

                    case "-":
                        return (short)(x - y);
                        break;

                    case "*":
                        return (short)(x * y);
                        break;

                    case "/":
                        return (short)(x / y);
                        break;

                    default:
                        return getValue("a");
                        break;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        static short getValue(string newVal)
        {
            try
            {
                return short.Parse(newVal);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Specify a valid integer!");
                Random rndInt = new Random();
                return 0;//rndInt.Next(2124, 21240878);
            }
        }


        static void MsgBox(string text)
        {
            MessageBox.Show(text);
        }


    }
}