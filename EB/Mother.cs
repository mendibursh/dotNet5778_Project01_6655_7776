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
 
        string LastName { set; get; }

        string firstame { set; get; }

        string SelNumber { set; get; }

        string Adress { get; set; }
       
        string CerchArea { get; set; }
       
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
    }
}
