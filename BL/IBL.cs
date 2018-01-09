using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        void addNanny(BE.Nanny nan);
        void removeNanny(int id);
        void updateNannyDetails(BE.Nanny nan);

        void addMother(BE.Mother mam);
        void removeMother(int id);
        void updateMotherDetalse(BE.Mother mam);

        void addChild(BE.Child child);
        void removeChild(int id);
        void updateChildDetails(BE.Child child);

        void addContract(BE.Contract con);
        void updateContract(BE.Contract con);
        void removeContract(int ContractNumber);

        List<BE.Nanny> getNannis();
        List<BE.Mother> getMothers();
        List<BE.Child> getChildren();
        List<BE.Contract> getContracts();

		List<BE.Nanny> getNannisOrderToMotherNeeds(int motherId);
        List<BE.Nanny> getOrderCompatibilityNannies(int idNumber);
        bool checkCompatibilityMotherNanny(BE.Nanny nan, BE.Mother mam);

    }
}
