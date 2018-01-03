using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
 
        public int Id { get; set; }
      
        string LastName { get; set; }

        string FirstName { get; set; }
 
        DateTime BirthDate { get; set; }
  
        string Adress { get; set; }
 
        bool Elevator { get; set; }

        int Floor { get; set; }

        int Experience { get; set; }

        int CapacityChildren { get; set; }

        int MaxAge_month_Children { get; set; }

        int MinAge_month_Children { get; set; }

        bool IsHourlyRate { get; set; }

        double RateOfHour { get; set; }

        double RateOfMonth { get; set; }

        bool[] workDay = new bool[30];

        DateTime[,] timeOfWork = new DateTime[2, 6];//???

        bool MinistryEducation { get; set; }

        string Recommendations { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public Nanny clone()
        {
            return (Nanny)MemberwiseClone();
        }

        
    }
}
