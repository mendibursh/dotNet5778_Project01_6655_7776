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

		public string firstame { set; get; }

		public string SelNumber { set; get; }

        public  string Adress { get; set; }

		public string CerchArea { get; set; }
       
        DateTime[,] TimeWork = new DateTime[2, 6];//????

        string Remarks { get; set; }
       
        public override string ToString()
        {
            return base.ToString();//??????
        }

        public Mother clone()
        {
            return (Mother)MemberwiseClone();
        }

        public Mother(int id, string lastName, string firstame, string selNumber, string adress, string cerchArea, DateTime[,] timeWork, string remarks)
        {
            Id = id;
            LastName = lastName;
            this.firstame = firstame;
            SelNumber = selNumber;
            Adress = adress;
            CerchArea = cerchArea;
            TimeWork = timeWork;
            Remarks = remarks;
        }
    }
}
