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
      
        public string LastName { get; set; }

        public string FirstName { get; set; }
 
        public DateTime BirthDate { get; set; }
  
        public string Adress { get; set; }
 
        public bool Elevator { get; set; }

        public int Floor { get; set; }

        public int Experience { get; set; }

        public int CapacityChildren { get; set; }

        public int MaxAge_month_Children { get; set; }

        public int MinAge_month_Children { get; set; }

        public bool IsHourlyRate { get; set; }

        public double RateOfHour { get; set; }

        public double RateOfMonth { get; set; }

        public bool[] workDay = new bool[30];

        public DateTime[,] timeOfWork = new DateTime[2, 6];//???

        public bool MinistryEducation { get; set; }

        public string Recommendations { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public Nanny clone()
        {
            return (Nanny)MemberwiseClone();
        }

        public Nanny(int id, string lastName, string firstName, DateTime birthDate, string adress, bool elevator, int floor, int experience, int capacityChildren, TimeSpan maxAge_month_Children, TimeSpan minAge_month_Children, bool isHourlyRate, double rateOfHour, double rateOfMonth, bool[] workDay, DateTime[,] timeOfWork, bool ministryEducation, string recommendations)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            Adress = adress;
            Elevator = elevator;
            Floor = floor;
            Experience = experience;
            CapacityChildren = capacityChildren;
            MaxAge_month_Children = maxAge_month_Children;
            MinAge_month_Children = minAge_month_Children;
            IsHourlyRate = isHourlyRate;
            RateOfHour = rateOfHour;
            RateOfMonth = rateOfMonth;
            this.workDay = workDay;
            this.timeOfWork = timeOfWork;
            MinistryEducation = ministryEducation;
            Recommendations = recommendations;
        }
    }
}
