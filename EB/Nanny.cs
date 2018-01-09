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
  
        public string Address { get; set; }
 
        public bool Elevetor { get; set; }

        public int Floor { get; set; }

        public int Experience { get; set; }

        public int CellPhone { get; set; }

        public int CapacityChildren { get; set; }

        public int MaxAge_monthe { get; set; }

        public int MinAge_monthe { get; set; }

        public bool IsHourlyRate { get; set; }

        public double SallaryPerHour { get; set; }

        public double SallaryPerMonths { get; set; }

        public bool[] workDay = new bool[6];

        public TimeSpan[,] timeOfWork = new TimeSpan[2, 6];

        public bool MinistryEducationVaction { get; set; }

        public string Recommendations { get; set; }

        public override string ToString()
        {
            return "ID: "  + Id.ToString() + "\n first name: " + FirstName + "last name: " + LastName
                + "\nAddress: " + Address;
        }

        //public Nanny(int id, string lastName, string firstName, DateTime birthDate, string adress, bool elevator, int floor, int experience, int capacityChildren, TimeSpan maxAge_month_Children, TimeSpan minAge_month_Children, bool isHourlyRate, double rateOfHour, double rateOfMonth, bool[] workDay, DateTime[,] timeOfWork, bool ministryEducation, string recommendations)
        //{
        //    Id = id;
        //    LastName = lastName;
        //    FirstName = firstName;
        //    BirthDate = birthDate;
        //    Adress = adress;
        //    Elevator = elevator;
        //    Floor = floor;
        //    Experience = experience;
        //    CapacityChildren = capacityChildren;
        //    MaxAge_month_Children = maxAge_month_Children;
        //    MinAge_month_Children = minAge_month_Children;
        //    IsHourlyRate = isHourlyRate;
        //    RateOfHour = rateOfHour;
        //    RateOfMonth = rateOfMonth;
        //    this.workDay = workDay;
        //    this.timeOfWork = timeOfWork;
        //    MinistryEducation = ministryEducation;
        //    Recommendations = recommendations;
        //}
    }
}
