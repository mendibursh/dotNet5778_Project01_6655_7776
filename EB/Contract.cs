using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public int ContractNumber { get; set; }

        public int NannyId { get; set; }

        public int MotherId { get; set; }

        public int ChildId { get; set; }

        public bool IsAcquaintance { get; set; }

        public bool IsContract { get; set; }

        public double RateOfHour { get; set; }

        public double RateOfMonth { get; set; }

        public bool IsHourlyRate { get; set; }

        public DateTime stertEmployment { get; set; }

        public DateTime endEmployment { get; set; }

        public override string ToString()//????
        {
            return base.ToString();
        }
    }
}
