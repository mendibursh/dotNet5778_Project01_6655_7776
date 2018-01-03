using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        int contractNumber;//?????????????

        int nannyId;

        int childId;

        bool isAcquaintance;

        bool isContract;

        double rateOfHour;

        double rateOfMonth;

        bool isHourlyRate;

        DateTime stertEmployment;

        DateTime endEmployment;

        public override string ToString()//????
        {
            return base.ToString();
        }
    }
}
