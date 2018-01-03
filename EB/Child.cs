using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        
        public int Id { get; set; }

        public int MotherId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
     
        bool IsSpcialNeed { get; set; }

        string SpicialNeed { get; set; }

        public override string ToString()//?????????
        {
            return base.ToString();
        }

        public Child clone()
        {
            return (Child)MemberwiseClone();
        }
    }
}
