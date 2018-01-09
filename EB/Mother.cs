using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        public int Id { set; get; }

		public string LastName { set; get; }

		public string FirstName { set; get; }

		public int cellPhone { set; get; }

        public  string Address { get; set; }

       
		public string AreaCerch { get; set; }

        public bool[] weekWork = new bool[6];
       
        public TimeSpan[,] TimeWork = new TimeSpan[2, 6];

        public string Remarks { get; set; }
       
        public override string ToString()
        {
            return base.ToString();//??????
        }

        public Mother(){ }

        //public Mother(int id, string lastName, string firstame, string selNumber, string adress, string cerchArea, DateTime[,] timeWork, string remarks)
        //{
        //    Id = id;
        //    LastName = lastName;
        //    this.FirstName = firstame;
        //    SelNumber = selNumber;
        //    Adress = adress;
        //    CerchArea = cerchArea;
        //    TimeWork = timeWork;
        //    Remarks = remarks;
        //}
    }
}
