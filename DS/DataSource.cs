using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class DataSource
    {
        public List<BE.Nanny> NannyList= new List<BE.Nanny>();
        public List<BE.Mother> MotherList = new List<BE.Mother> ();
        public List<BE.Child> ChildrenList = new List<BE.Child> ();
        public List<BE.Contract> ContractList = new List<BE.Contract>();

        DataSource() { }
    }
}
