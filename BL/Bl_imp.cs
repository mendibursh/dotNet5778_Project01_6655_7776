using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Response;
using System.Threading;

namespace BL
{
    public class Bl_imp : IBL
    {
        DAL.IDAL dl;

        public Bl_imp()
        {
            dl = DAL.FactoryDAL.GetIdal(); 
        }

        public void addChild(Child child)
        {
            dl.addChild(child);//clone????
        }

        /// <summary>
        ///adds a new contract to the list of contracts
        /// 
        /// Exception:
        /// 1.if there not are a mother or nanny
        /// 2.if there are another contract for this child
        /// 3.if the age of the child iz not ligal
        /// 4.if the capacity of children by the nanny is full
        /// 
        /// </summary>
        /// <param name="con">Contract item</param>
        public void addContract(Contract con)
        {
            //check the age of the child
            Child toCheckChild = dl.GetChild(con.ChildId);
            TimeSpan minAge = new TimeSpan(90);
            if ((toCheckChild.BirthDate - DateTime.Now) < minAge) throw new Exception();

            Nanny nanny = dl.GetNanny(con.NannyId);
            List<Contract> countContract = dl.getContracts();
            
            //check how much brothers the child have by the Nanny
            int k = 0;
            for (int i=0; i < countContract.Count(); ++i)
                if (countContract[i].MotherId == con.MotherId && countContract[i].NannyId == con.NannyId )
                    k++;

            //update the salary to all contract
            con.Salary = SalaryPerMonth(nanny, con.IsHourlyRate,k);

            //check if the contract of this nanny is full
            int l = 0;
            for (int i = 0; i < countContract.Count(); ++i)
                if (countContract[i].NannyId == con.NannyId)
                    l++;
            if (l <= nanny.CapacityChildren) throw new Exception();

            dl.addContract(con);
        }

        /// <summary>
        /// Calculates the salary for child care
        /// 
        /// Exception:
        /// if the nother asks to calculate according to hour, and the nanny does not allow
        /// </summary>
        /// <param name="nan">object of nanny</param>
        /// <param name="isDalyRate">bool variable if the mother wants order to hourly rate or not</param>
        /// <param name="someBrothers">int variable if there more children by the same nanny</param>
        /// <returns></returns>
        double SalaryPerMonth(BE.Nanny nan ,bool isDalyRate, int someBrothers)
        {
            double salary = 0;
            if (!isDalyRate)
            {
                salary = nan.SallaryPerMonths;
            }
            else
            {
                //if the nanny opposes hourly payment
                if (!nan.IsHourlyRate) throw new Exception();
                //Calculation of monthly work hours
                double timeWeekWork = 0;
                for (int i=0; i < 6 ; ++i)
                {
                    if (nan.workDay[i])
                    {
                        timeWeekWork += (nan.timeOfWork[1, i] - nan.timeOfWork[0, i]).TotalHours;
                    }
                }
                //calculation of the full monthly salary
                salary = (timeWeekWork * 4) * nan.SallaryPerHour;
                //calculation of discount
                double PercentDiscount = (salary * (someBrothers) * 2) / 100;
                salary -= PercentDiscount;
            }
            return salary;
        }

        /// <summary>
        /// adds a new mother to the list of mothers
        /// </summary>
        /// <param name="mam">a Mother item</param>
        public void addMother(Mother mam)
        {
            dl.addMother(mam);
        }

        /// <summary>
        /// adds a new nanny to the list of nannis
        /// </summary>
        /// <param name="nan">a Nenny item</param>
        public void addNanny(Nanny nan)
        {
            TimeSpan minAge = new TimeSpan(365 * 18);
            if ( DateTime.Now - nan.BirthDate < minAge) throw new Exception();
            dl.addNanny(nan);
        }

        
        public List<Child> getChildren()
        {
            return dl.getChildren();
        }

        public List<Contract> getContracts()
        {
            return dl.getContracts();
        }

        public List<Mother> getMothers()
        {
            return dl.getMothers();
        }

        public List<Nanny> getNannis()
        {
            return dl.getNannis();
        }

        public void removeChild(int id)
        {
            dl.removeChild(id);
        }

        public void removeContract(int ContractNumber)
        {
            dl.removeContract(ContractNumber);
          
        }

        public void removeMother(int id)
        {
            dl.removeMother(id);
            //we need to remove all hir contracts and children.
        }

        public void removeNanny(int id)
        {
            dl.removeNanny(id);
            //we need to remove all hir contracts
        }

        public void updateChildDetails(Child child)
        {
            dl.updateChildDetails(child);
        }

        public void updateContract(Contract con)
        {
            dl.updateContract(con);
        }

        public void updateMotherDetalse(Mother mam)
        {
            dl.updateMotherDetalse(mam);
        }

        public void updateNannyDetails(Nanny nan)
        {
			TimeSpan minAge = new TimeSpan(365 * 18);
            if (nan.BirthDate - DateTime.Now < minAge) throw new Exception();
            dl.updateNannyDetails(nan);
        }

        /// <summary>
        /// returns enumeretor of the collection of the nannies are compatible with the mother's needs 
        /// </summary>
        /// <param name="motherId">the mothers id to comper</param>
        /// <returns></returns>
        public List<Nanny> getNannisOrderToMotherNeeds(int motherId)
        {
            Mother corentMother = dl.GetMother(motherId);
            List <Nanny> nannyList = dl.getNannis();
            var compatibilityNannis = from item in nannyList
                                      where checkCompatibilityMotherNanny(item, corentMother)
                                      select item;
            return compatibilityNannis.ToList();
        }

        /// <summary>
        /// Checks the compatibility between the nanny and the mother needs
        /// 
        /// return true if the nnany compatiabil in the time of work
        /// return false if thay not compatiabil in the time of work
        /// </summary>
        /// <param name="nan">Nanny object to comper</param>
        /// <param name="mam">Mother object to comper</param>
        /// <returns></returns>
        public bool checkCompatibilityMotherNanny(Nanny nan, Mother mam)
        {
            
            for (int i = 0; i < 6; ++i)
            {   //Full day no compatibility
                if (mam.weekWork[i] == true && nan.workDay[i] == false)
                {
                    return false;
                }
                else if (mam.weekWork[i] && nan.workDay[i])
                {//There is no compatibility during work hours
                    if (mam.TimeWork[0, i] < nan.timeOfWork[0, i] || mam.TimeWork[1,i]> nan.timeOfWork[1,i] )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// get the closest nanny by compatibility or by matches the hour and the days to the mother needs 
        /// </summary>
        /// <param name="idNumber">Id's mom</param>
        /// <returns>return the list of the nannies there are much to the mom's need or the 5 closest nannies</returns>
        public List<Nanny> getOrderCompatibilityNannies(int idNumber)
        {
            List<Nanny> nannies = getNannisOrderToMotherNeeds(idNumber);
            if (nannies.Count == 0)
            {
                return getFiveClosestNannis(idNumber);
            }
            else
            {
                return nannies;
            }
  
        }

        /// <summary>
        /// get the five closest nannies by the one prameter is the expiriance of the nanny and the salary and the floor
        /// </summary>
        /// <param name="idNumber">id's mom</param>
        /// <returns>the 5 closest nannies</returns>
        public List<Nanny> getFiveClosestNannis(int idNumber)
        {
            Mother tempMom = dl.GetMother(idNumber);
            List<Nanny> tempNannies = getNannis();
            var nannies = from item in tempNannies
                          orderby item.Experience descending, item.SallaryPerHour, item.Floor
                          select item;
            return nannies.Take(5).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MotherId"></param>
        /// <param name="distance"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public List<Nanny> nannisByDistance(int MotherId, int distance, string address = null)
        {
            Mother TempMother = dl.GetMother(MotherId);
            List<Nanny> tempNanniesList = getNannisOrderToMotherNeeds(MotherId);
            List<Nanny> temp =null;
            if (tempNanniesList.Count > 0)
            {
                if (address != null)
                {
                    temp = (from item in tempNanniesList
                            let dis = CalculateDistance(item.Address, address)
                            orderby dis
                            select item).ToList();
                }
                else
                {
                    temp = (from item in tempNanniesList
                            let dis = CalculateDistance(item.Address, TempMother.Address)
                            where dis <= distance
                            orderby dis
                            select item).ToList();
                }
                if (temp.Count == 0) throw new Exception();
                return temp;
            }
            else throw new Exception();
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Child> getCehildrenWhitoutNanny()
        {
            List<Child> tempChildList = getChildren();
            List<Contract> tempContractList = getContracts();

            var temp = from item1 in tempChildList
                       from item2 in tempContractList
                       where item1.Id != item2.ChildId
                       select item1;
            return temp.ToList();
        }


        /// <summary>
        /// gets the nannies by the vaction of the nannies
        /// </summary>
        /// <returns>List of this nannies</returns>
        public List<Nanny> getNanniesByTHMATVaction()
        {
            List<Nanny> tempNannyList = getNannis();

            var temp = from item in tempNannyList
                       where item.MinistryEducationVaction == false
                       select item;
            return temp.ToList();
        }

        
        /// <summary>
        /// get list from a delegte with condition, and return the list of them if its null return the all list of contract
        /// </summary>
        /// <param name="predicat"> Delegate that get contract and return bool </param>
        /// <returns></returns>
        public List<Contract> getContractByDelegate(Func<Contract,bool>predicat = null)
        {
            List<Contract> tempContractList = getContracts();
            if (predicat != null)
            {
                var temp = from item in tempContractList
                           where predicat(item)
                           select item;

                return temp.ToList();
            }
            else return tempContractList;
        }

        /// <summary>
        /// Get the number of the contract that fit to the condtion in the delegate
        /// </summary>
        /// <param name="predicat">Delegate that get contract and return bool</param>
        /// <returns>Return int - the number of the items</returns>
        public int getNumOfContractByDelegate(Func<Contract, bool> predicat = null)
        {
            List<Contract> tempContractList = getContracts();
            if (predicat != null)
            {
                var temp = from item in tempContractList
                           where predicat(item)
                           select item;

                return temp.ToList().Count;
            }
            else return tempContractList.Count;
        }


        public static int CalculateDistance(string source, string dest)
        {
			var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };

            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxAge"></param>
        /// <param name="byOrder"></param>
        /// <returns></returns>
		public IEnumerable<IGrouping<int, Nanny>> nanniesByChildAge(bool maxAge ,bool byOrder = false)
		{
			TimeSpan minAge = new TimeSpan(1);
			IEnumerable<IGrouping<int, Nanny>> group = null;
			List<Nanny> nannyListTemp = getNannis();
            
			// check if the do the grouping with order or not 
			if (byOrder)
			{

				// check if to sort by max age or not 
				if (maxAge)
				{
					group = from n in nannyListTemp
								 group n by n.MinAge_monthe;
				}
				else
				{

					group = from n in nannyListTemp
							group n by n.MaxAge_monthe;

				}
			
			}
			else
			{
				if (maxAge)
				{
					group = from n in nannyListTemp
							orderby n.MinAge_monthe
							group n by n.MinAge_monthe;
				}
				else
				{

					group = from n in nannyListTemp
							orderby n.MaxAge_monthe
							group n by n.MaxAge_monthe;

				}
			}

			// return the group 
			return group;
		}

		public IEnumerable <IGrouping<int,Contract>> contractBydistance(bool orderBy = false)
		{
			IEnumerable <IGrouping<int,Contract >> group = null;
			List <Contract>tempContractList = getContracts();

			if (orderBy)
			{
				// order the contract by the distance from the nanny to the mom, and the distance is in the 5,10 etc km 
				group = from n in tempContractList
						group n by nannyAndMomDis(dl.GetNanny(n.NannyId), dl.GetMother(n.MotherId)) / 5;
			}
			else
			{
				group = from d in tempContractList
						let dis = nannyAndMomDis(dl.GetNanny(d.NannyId), dl.GetMother(d.MotherId))
						orderby dis
						group d by dis / 5;
			}
			return group;
		}


		public int nannyAndMomDis ( Nanny nan , Mother mom )
		{

			// calculte the distance between the mom address to the nanny 
			int dis = CalculateDistance(nan.Address, mom.Address);
			return dis;
		}


	}
	

}
