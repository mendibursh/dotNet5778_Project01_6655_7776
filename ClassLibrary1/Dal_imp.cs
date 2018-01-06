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
        static int Range = 1000;
        public static IDAL Instance { get {return instance;} }

        Dal_imp () { }
        static Dal_imp () { }


        /// <summary>
        /// adds a Nanny object to the list
        /// throw Exception if there a Nanny with the same id.
        /// </summary>
        /// <param name="nen">a Nanny object to add</param>
        public void addNanny(BE.Nanny nen)
        {
            if (source.NannyList.Any(x => x.Id == nen.Id)) throw new Exception();///.........
            source.NannyList.Add(nen);//????colne???   
        }

        /// <summary>
        /// Deletes a certain Nanny from the list.
        /// Sending an exception if it does not exist.
        /// </summary>
        /// <param name="nan">id number</param>
        public void removeNanny(int id)
        {
            if (!source.NannyList.Any(X => X.Id == id)) throw new Exception();//.......
            source.NannyList = source.NannyList.Where(c => c.Id != id).ToList();
            
            //not need to check if there are a contract?????
        }

        //-------
        public void updateNannyDetails(BE.Nanny nan)//???????????
        {
            if (source.NannyList.All(X => X.Id != nan.Id)) throw new Exception();//.......
            source.NannyList = (from item in source.NannyList
                                 where item.Id != nan.Id
                                 select item).ToList();
            source.NannyList.Add(nan);
        }

       
        /// <summary>
        /// adds a Mother object to the list
        /// throw Exception if there a mother with the same id.
        /// </summary>
        /// <param name="mam">mother object to add</param>
        public void addMother(BE.Mother mam)
        {
            if (source.MotherList.Any(x => x.Id == mam.Id)) throw new Exception();//.........
            source.MotherList.Add(mam.clone());
            //not need to chrch if is exsis a contract?????????
        }

        //--------
        /// <summary>
        /// Deletes a certain Mother from the list.
        /// Sending an exception if it does not exist.
        /// </summary>
        /// <param name="id">id number</param>
        public void removeMother(int id)
        {
            if (source.MotherList.All(X => X.Id != id)) throw new Exception();//.......
            source.MotherList = source.MotherList.Where(c => c.Id == id).ToList();
        }

        /// <summary>
        /// replace the 
        /// </summary>
        /// <param name="mam"></param>
        public void updateMotherDetalse(BE.Mother mam)
        {
            if (source.MotherList.All(X => X.Id != mam.Id)) throw new Exception();//.......
            source.MotherList = (from item in source.MotherList
                                 where item.Id != mam.Id
                                 select item).ToList();
            source.MotherList.Add(mam);
        }


        /// <summary>
        /// adds a Child object to the list
        /// throw Exception if there a Child with the same id.
        /// </summary>
        /// <param name="child">a Child object to add</param>
        public void addChild(BE.Child child)
        {
            if (source.ChildrenList.Any(x => x.Id == child.Id)) throw new Exception();//.....
            source.ChildrenList.Add(child.clone());
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
            //we need to cherch if there are a cntraect to the child??????????
        }

        public void updateChildDetails(BE.Child child)
        {
            if (source.ChildrenList.All(X => X.Id != child.Id)) throw new Exception();//.......
            source.ChildrenList = (from item in source.ChildrenList
                                   where item.Id != child.Id
                                 select item).ToList();
            source.ChildrenList.Add(child);
        }

        /// <summary>
        /// adds to the contract a range number
        /// adds a Contract to the collction of Contracts
        /// 
        /// Exseption:
        /// if there are a contract to this child
        /// or if the mother or the nanny is not there
        /// </summary>
        /// <param name="con">a contract to add</param>
        public void addContract(BE.Contract con)
        {
            if (source.ContractList.Any(x => x.ChildId == con.ChildId)) throw new Exception();
            if (source.NannyList.All(x => x.Id != con.NannyId)) throw new Exception();
            if (source.MotherList.All(x => x.Id != con.MotherId)) throw new Exception();
            con.ContractNumber = ++Range;
            source.ContractList.Add(con);
        }


        public void updateContract(BE.Contract con)
        {
            if (source.ContractList.All(X => X.ChildId != con.ChildId)) throw new Exception();//.......
            //var tempInt = (from item in source.ContractList
            //               where item.ChildId == con.ChildId
            //               select item.ContractNumber);
            //con.ContractNumber = Cast<int>(tempInt);
            source.ContractList = (from item in source.ContractList
                                   where item.ChildId != con.ChildId
                                   select item).ToList();
            source.ContractList.Add(con);
        }

        /// <summary>
        /// delete one contract from the colection
        /// 
        /// Exception:
        /// if there not exsist the certin contract.
        /// </summary>
        /// <param name="con">the contract number to delete</param>
        public void removeContract(int numberContract)
        {
            if (source.ContractList.Any(x => x.ContractNumber == numberContract)) throw new Exception();
            source.ContractList = source.ContractList.Where(x => x.ContractNumber != numberContract).ToList();
        }

        /// <summary>
        /// return the clone list
        /// </summary>
        /// <returns></returns>
        public List<Nanny> getNannis()
        {
            if (source.NannyList == null) throw new Exception();
            var temp = source.NannyList.Select(item => item= (Nanny)MemberwiseClone()).ToList();
            return temp;
        }
         
        public List<Mother> getMothers()
        {
            if (source.MotherList == null) throw new Exception();
            var temp = source.MotherList.Select(item=>item = (Mother)MemberwiseClone()).ToList();
            return temp;
        }

        public List<Child> getChildren()
        {
            if (source.ChildrenList == null) throw new Exception();
            var temp = source.ChildrenList.Select(item => item = (Child)MemberwiseClone()).ToList();
            return temp;
        }

        public List<Contract> GetContracts()
        {
            if (source.ContractList == null) throw new Exception();
            var temp = source.ContractList.Select(item => item = (Contract)MemberwiseClone()).ToList();
            return temp;
        }

        public BE.Child GetChild(int idNumber)
        {
            if (source.ChildrenList.All(x => x.Id != idNumber)) throw new Exception();
            var child = from item in source.ChildrenList
                        where item.Id == idNumber
                        select (Child)MemberwiseClone();
            return child.ToList()[0];
        }

        public BE.Nanny GetNanny(int idNumber)
        {
            if (source.NannyList.All(x => x.Id != idNumber)) throw new Exception();
            var nanny = from item in source.NannyList
                        where item.Id == idNumber
                        select (Nanny)MemberwiseClone();
            return nanny.ToList()[0];
        }

        public BE.Mother GetMother(int idNumber)
        {
            if (source.MotherList.All(x => x.Id != idNumber)) throw new Exception();
            var mother = from item in source.MotherList
                        where item.Id == idNumber
                        select (Mother)MemberwiseClone();
            return mother.ToList()[0];
        }

        public BE.Contract GetContract(int idNumber)
        {
            if (source.ContractList.All(x => x.ChildId != idNumber)) throw new Exception();
            var con = from item in source.ContractList
                        where item.ChildId == idNumber
                        select (Contract)MemberwiseClone();
            return con.ToList()[0];
        }
    }
}
