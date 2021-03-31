using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConveyorApp1
{
    public class Functions
    {    
        public static Random  random = new Random();
        public static int Events()
        {
            int typeOfEvent = 0; 
            double value = random.NextDouble();

            if (value < 0.3)
            {
                typeOfEvent = 1;
            }
            else if(value > 0.3 && value < 0.55)
            {
                typeOfEvent = 2;
            }
            else if (value > 0.55 && value < 0.70)
            {
                typeOfEvent = 3;
            }
            else if (value > 0.70 && value < 1)
            {
                typeOfEvent = 4;
            }

            return typeOfEvent;
        }
    
        public static int Duration(int typeOfCommands)
        {
            int tact = 0;
            double value = random.NextDouble();

            switch (typeOfCommands)
            {
                case 1:
                    if (value < 0.7)
                    {
                        tact = 5;
                    }
                    else if (value > 0.7 && value < 0.85)
                    {
                        tact = 2;
                    }
                    else if (value > 0.85 && value < 1)
                    {
                        tact = 1;
                    }
                    break;

                case 2:
                    if (value < 0.7)
                    {
                        tact = 2;
                    }
                    else if (value > 0.7 && value < 0.9)
                    {
                        tact = 5;
                    }
                    else if (value > 0.9 && value < 1)
                    {
                        tact = 1;
                    }
                    break;

                case 3:
                    if (value < 0.8)
                    {
                        tact = 2;
                    }
                    else if (value > 0.8 && value < 1)
                    {
                        tact = 1;
                    }                   
                    break;

                case 4:
                    if (value < 0.6)
                    {
                        tact = 2;
                    }
                    else if (value > 0.6 && value < 1)
                    {
                        tact = 1;
                    }
                    break;
            }

            return tact;
        }
        public static int InCache ()
        {
            double inCache = 0.75;
            
            if (random.NextDouble() < inCache)
            {
                return 1; 
            }
            else
            {
                return 0;
            }
        }

        public static string Commands(int duration, int typeOfEvent, int inCache)
        {
            string result = Convert.ToString(duration) + "Т(";

            if (inCache == 1)
            {
                result += "Кэш,";
            }
            else if (inCache == 0)
            {
                result += "Н.К.,";
            }
            
            if (typeOfEvent == 3)
            {
                result += "УО)";
            }
            else
            {
                result += "-)";
            }

            return result;
        }

        public static ProcessModel ConvertStringToProcessModel(string input)
        {           
            char d = input[0];
            int duration = Convert.ToInt32(new string(d, 1));
            int cache = 0;
            int typeOfEvent = 1;
            if (input.Contains("Н.К."))
            {
                cache = 0;
            }
            else if (input.Contains("КЭШ"))
            {
                cache = 1;
            }
            if (input.Contains("УО"))
            {
                typeOfEvent = 3;
            }
            else if (input.Contains("-"))
            {
                typeOfEvent = 1;
            }
                return new ProcessModel() {
                TypeOfEvent = typeOfEvent,
                Duration = duration,
                InCache = cache
                };
        }
    }
}
