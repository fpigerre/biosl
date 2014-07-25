using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace biosl5
{
    class bVars
    {

        List<bBool> boolList = new List<bBool>();
        List<bDouble> doubleList = new List<bDouble>();
        List<bFloat> floatList = new List<bFloat>();
        List<bInteger> intList = new List<bInteger>();
        List<bShort> shortList = new List<bShort>();


        public string listVars()
        {
            string lst = "";
            for (int i = 0; i < boolList.Count - 1; i++)
            {
                lst += "BOOL:" + boolList[i]._name + " VAL:" + boolList[i]._val.ToString();
            }
            return lst;
        }


        public void addVar(string _name, string _val, string _type)
        {

            _name = _name.TrimStart().TrimEnd().ToLower(); ///REMEMBER!!!   TOLOWER    IS IMPORTANT!

            if (_name != "" && _type != "")
            {


                switch (_type.ToLower())
                {

                    case "bool":
                        bBool _tempB = new bBool();
                        _tempB._name = _name; //set LOWER name
                        try { _tempB._val = bool.Parse(_val); } catch (Exception ex) { }
                        break;

                    case "char":
                        bChar _tempC = new bChar();
                        _tempC._name = _name; //set LOWER name
                        try { _tempC._val = char.Parse(_val); }
                        catch (Exception ex) { }
                        break;

                    case "double":
                        bDouble _tempD = new bDouble();
                        _tempD._name = _name; //set LOWER name
                        try { _tempD._val = double.Parse(_val); }
                        catch (Exception x) { }
                        break;

                    case "float":
                        bFloat _tempF = new bFloat();
                        _tempF._name = _name; //set LOWER name
                        try { _tempF._val = float.Parse(_val); }
                        catch (Exception x) { }
                        break;


                    case "int":
                        bInteger _tempI = new bInteger();
                        _tempI._name = _name; //set LOWER name
                        try { _tempI._val = int.Parse(_val); }
                        catch (Exception x) { }
                        break;

                    case "short":
                        bShort _tempS = new bShort();
                        _tempS._name = _name; //set LOWER name
                        try { _tempS._val = short.Parse(_val); }
                        catch (Exception x) { }
                        break;

                    default:
                        Console.WriteLine("The data type is not valid!");
                        break;

                }


            }
            else
            {
                Console.WriteLine("Error! Variable must have a valid name!");
            }
        }



    }
}
