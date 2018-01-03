using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        void addNanny(BE.Nanny nan);
        void removeNanny(int id);
        void updateNannyDetails();

        void addMother(BE.Mother mam);
        void removeMother(int id);
        void updateMotherDetalse();

        void addChild(BE.Child child);
        void removeChild(int id);
        void updateChildDetails();

        void addContract();
        void updateContract();
        void removeContract();

        List<BE.Nanny> getNannis();
        List<BE.Mother> getMoters();
        List<BE.Child> getChildren();
        List<BE.Contract> getContracts();
    }
}
