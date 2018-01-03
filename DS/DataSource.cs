using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class DataSource
    {
        public List<BE.Nanny> NannyList=new List<BE.Nanny>();
        public List<BE.Mother> MotherList;
        public List<BE.Child> ChildrenList;
        public List<BE.Contract> ContractList;

        DataSource() { }
    }
}
