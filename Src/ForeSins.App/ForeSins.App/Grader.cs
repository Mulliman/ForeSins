using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App
{
    public class Grader
    {
        public Grades Grade(Round round)
        {
            return Grade(round.Sins);
        }

        public Grades Grade(uint sins)
        {
            if(sins > 20)
            {
                return Grades.S;
            } 
            
            if(sins > 12)
            {
                return Grades.D;
            }

            if (sins >= 7)
            {
                return Grades.C;
            }

            if (sins >= 4)
            {
                return Grades.B;
            }

            if (sins >= 2)
            {
                return Grades.A;
            }

            return Grades.G;
        }
    }
}