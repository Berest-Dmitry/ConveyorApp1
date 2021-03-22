using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConveyorApp1
{
    public class Functions
    {
        enum Events
        {
            YO, 
            nYO
        }

        public static int MDO()
        {
            int typeOfProcess;
            double mdo = 0.3;
            var random = new Random();

            if (random.NextDouble() < mdo)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static int YO()
        {
            int typeOfProcess;
            double yo = 0.15;
            var random = new Random();

            if (random.NextDouble() < yo)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static int MSO()
        {
            int typeOfProcess;
            double mso = 0.25;
            var random = new Random();

            if (random.NextDouble() < mso)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static int DVP()
        {
            int typeOfProcess;
            double dvp = 0.3;
            var random = new Random();

            if (random.NextDouble() < dvp)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static int InCache ()
        {
            double inCache = 0.75;
            var random = new Random();
            
            if (random.NextDouble() < inCache)
            {
                return 0; 
            }
            else
            {
                return 1;
            }
        }


        double probability = 0.5; // 50%
        var random = new Random();
 
        if (random.NextDouble() < probability)
            // Отображаем
    }
}
