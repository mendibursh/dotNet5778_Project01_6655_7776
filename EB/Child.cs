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

        int MotherId { get; set; }
        
        string firstName;
        string P_firstName
        {
            set { firstName = value; }
            get { return firstName; }
        }

        string lastName;
        string P_LastName
        {
            set { firstName = value; }
            get { return firstName; }
        }

        bool isSpcialNeed;
        bool P_isSpicalNeed
        {
            set { isSpcialNeed = value; }
            get { return isSpcialNeed; }
        }

        string spicialNeed;
        string P_SpicialNeed
        {
            set { spicialNeed = value; }
            get { return spicialNeed; }
        }

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
