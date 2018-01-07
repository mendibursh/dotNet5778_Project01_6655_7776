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
			try
			{
				dl.addChild(child);
			}
			catch
			{

			}
            
        }

        public void addContract(Contract con)
        {
            BE.Child toCheckChild = dl.GetChild(con.ChildId);
            TimeSpan minAge = new TimeSpan(90);
            if ((toCheckChild.BirthDate - DateTime.Now) < minAge) throw new Exception();

            BE.Nanny nanny = dl.GetNanny(con.NannyId);
            List<Contract> countContract = dl.getContracts();
            
            //check how much brothers the child have by the Nanny
            int k = 0;
            for (int i=0; i < countContract.Count(); ++i)
                if (countContract[i].MotherId == con.MotherId && countContract[i].NannyId == con.NannyId )
                    k++;

            con.Salary = SalaryPerMonth(nanny, con.IsHourlyRate,k);
            //update the salary to all contract

            //check if the contract is full
            int l = 0;
            for (int i = 0; i < countContract.Count(); ++i)
                if (countContract[i].NannyId == con.NannyId)
                    l++;
            if (l <= nanny.CapacityChildren) throw new Exception();

            dl.addContract(con);
        }

        /// <summary>
        /// Calculates the wages for child care
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
                salary = nan.RateOfMonth;
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
                salary = (timeWeekWork * 4) * nan.RateOfHour;
                //calculation of discount
                double PercentDiscount = (salary * (someBrothers) * 2) / 100;
                salary -= PercentDiscount;
            }
            return salary;
        }

        public void addMother(Mother mam)
        {
            dl.addMother(mam);
        }

        public void addNanny(Nanny nan)
        {
            TimeSpan minAge = new TimeSpan(365 * 18);
            if ( DateTime.Now - nan.BirthDate < minAge) throw new Exception();
            dl.addNanny(nan);
        }

        public List<Child> getChildren()
        {
            return dl.getChildren(); //clone???
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
        }

        public void removeNanny(int id)
        {
            dl.removeNanny(id);
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
								 group n by n.MinAge_month_Children;
				}
				else
				{

					group = from n in nannyListTemp
							group n by n.MaxAge_month_Children;

				}
			
			}
			else
			{
				if (maxAge)
				{
					group = from n in nannyListTemp
							orderby n.MinAge_month_Children
							group n by n.MinAge_month_Children;
				}
				else
				{

					group = from n in nannyListTemp
							orderby n.MaxAge_month_Children
							group n by n.MaxAge_month_Children;

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

		/// <summary>
		/// To caculte the distance between them (the 
		/// </summary>
		/// <param name="nan"> the nanny</param>
		/// <param name="mom"> the mom </param>
		/// <returns></returns>
		public int nannyAndMomDis ( Nanny nan , Mother mom )
		{

			// calculte the distance between the mom address to the nanny 
			int dis = CalculateDistance(nan.Adress, mom.Adress);
			return dis;
		}

	

    }
	

}
