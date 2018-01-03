using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    sealed class Dal_imp : IDAL
    {
        static DS.DataSource source;
        static readonly IDAL instance = new Dal_imp();
        public static IDAL Instance { get {return instance;} }

        Dal_imp () { }
        static Dal_imp () { }

        public void addNanny(BE.Nanny nen)
        {
            if (source.NannyList.Any(x => x.Id == nen.Id)) throw new Exception();///.........
            source.NannyList.Add(nen.clone());//????colne???   
        }

        /// <summary>
        /// Deletes a certain Nanny from the list.
        /// Sending an exception if it does not exist.
        /// </summary>
        /// <param name="nan">id number</param>
        public void removeNanny(int id)
        {
            if (!source.NannyList.Any(X => X.Id == id)) throw new Exception();//.......
            List<Nanny> list = source.NannyList.Where(c => c.Id == id).ToList();
            //not need to check if there are a contract?????
        }

        public void updateNannyDetails()
        {
            throw new NotImplementedException();
        }

        public void addMother(BE.Mother mam)
        {
            if (source.MotherList.Any(x => x.Id == mam.Id)) throw new Exception();//.........
            source.MotherList.Add(mam.clone());
            //not need to chrch if is exsis a contract?????????
        }

        /// <summary>
        /// Deletes a certain Mother from the list.
        /// Sending an exception if it does not exist.
        /// </summary>
        /// <param name="id">id number</param>
        public void removeMother(int id)
        {
            if (!source.MotherList.Any(X => X.Id == id)) throw new Exception();//.......
            source.MotherList = source.MotherList.Where(c => c.Id == id).ToList();
        }

        public void updateMotherDetalse()
        {
            throw new NotImplementedException();
        }

        public void addChild(BE.Child child)
        {
            if (source.ChildrenList.Any(x => x.Id == child.Id)) throw new Exception();//.....
            source.ChildrenList.Add(child.clone());
            //we need to cherch if there are a cntraect to the child??????????
        }

        /// <summary>
        /// Deletes a certain Child from the list.
        /// Sending an exception if it does not exist
        /// </summary>
        /// <param name="id">id number</param>
        public void removeChild(int id)
        {
            if (source.ChildrenList.All(x => x.Id != id)) throw new Exception();//.........
            source.ChildrenList = source.ChildrenList.Where(x => x.Id == id).ToList();
        }

        public void updateChildDetails()
        {
            throw new NotImplementedException();
        }

        public void addContract()
        {
            throw new NotImplementedException();
        }

        public void updateContract()
        {
            throw new NotImplementedException();
        }


        public void removeContract()
        {
            throw new NotImplementedException();
        }

        public List<Nanny> getNannis()
        {
            throw new NotImplementedException();
        }

        public List<Mother> getMoters()
        {
            throw new NotImplementedException();
        }

        public List<Child> getChildren()
        {
            throw new NotImplementedException();
        }

        public List<Contract> getContracts()
        {
            throw new NotImplementedException();
        }
    }
}
