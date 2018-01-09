using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;


namespace BL
{
    
    public class DefaultInitilize
    {
        static Random r = new Random();
        public DefaultInitilize()
        {
            initilizeArray();
            NannyInitilize();
            MotherInitilize();
            ChildInitilize();
            ContractInitilize();
        }
        static int[] idMotherArray = new int[3];
        static int[] idNannyArray = new int[4];
        static int[] idChildArray = new int[3];

        /// <summary>
        /// initilize 3 araays of id 
        /// </summary>
        void initilizeArray()
        {
            for (int i = 0; i < 3; i++)
                idChildArray[i] = IDCreator("child");
            for (int i = 0; i < 4; i++)
                idNannyArray[i] = IDCreator("nanny");
            for (int i = 0; i < 3; i++)
                idMotherArray[i] = IDCreator("mother");
        }
        /// <summary>
        /// create id for objects ranomaly, 
        /// TypeObject options: nanny,mother,child
        /// </summary>
        int IDCreator(string t)
        {
            int id = 0;
            switch (t)
            {
                case "nanny":
                    do
                    {
                        id = r.Next(100000000, 299999999);
                    } while (instance.getNannis().Exists(x => x.Id == id));
                    break;
                case "mother":
                    do
                    {
                        id = r.Next(300000000, 599999999);
                    } while (instance.getMothers().Exists(x => x.Id == id));
                    break;
                case "child":
                    do
                    {
                        id = r.Next(600000000, 999999999);
                    } while (instance.getChildren().Exists(x => x.Id == id));
                    break;
            }
            return id;
        }

        static IBL instance = Factory_BL.GetIBL();//singelton

        /// <summary>
        /// Initilize & addtion to list 20 nannies
        /// </summary>
        void NannyInitilize()
        {
            Nanny Ayala_Zehavi = new Nanny
            {

                Id = idNannyArray[0],
                LastName = "Ayala",
                FirstName = "zehavi",
                BirthDate = new DateTime(1980, 5, 19),
                Address = "Beit Ha-Defus St 21, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 3,
                CellPhone = 0523433333,
                MaxAge_monthe = 14,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,
                workDay = new bool[6] { true, true, true, true, true, false },
                timeOfWork = new TimeSpan[6, 2]
                {
                    { new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)}
				},

                Recommendations = "",
            };
            Nanny Moria_schneider = new Nanny
            {
                Id = idNannyArray[1],
                FirstName = "Moria",
                LastName = "schneider",
                BirthDate = new DateTime(1980, 5, 19),
                Address = "Shakhal St 15, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 3,
                CellPhone = 0523433333,
                MaxAge_monthe = 14,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,
                workDay = new bool[6] { true, true, true, true, true, false },
                timeOfWork = new TimeSpan[6, 2]
                {
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)}
				},

                Recommendations = "",
            };
            Nanny malki_fishman = new Nanny
            {
                //v
                Id = idNannyArray[2],
                FirstName = "malki",
                LastName = "fishman",
                BirthDate = new DateTime(1992, 4, 9),
                Address = "Bar Ilan St 15, Jerusalem",
                Elevetor = false,
                Floor = 1,
                Experience = 5,
                CellPhone = 0525633333,
                MaxAge_monthe = 17,
                MinAge_monthe = 1,
                CapacityChildren = 7,
                IsHourlyRate = false,
                SallaryPerMonths = 1200,
                workDay = new bool[6] { true, true, true, true, true, true },
                timeOfWork = new TimeSpan[6, 2]
                {
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)}
				},

                Recommendations = "",
            };
            Nanny Elisheva_Shaked = new Nanny
            {
                Id = idNannyArray[3],
                FirstName = "Elisheva",
                LastName = "Shaked",
                BirthDate = new DateTime(1990, 5, 29),
                Address = "Amram Gaon St 15, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 3,
                CellPhone = 0523433333,
                MaxAge_monthe = 14,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,
                workDay = new bool[6] { true, true, true, true, true, true },
                timeOfWork = new TimeSpan[6, 2]
                {
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)}
				},
                Recommendations = "",
            };
           
            instance.addNanny(malki_fishman);
            instance.addNanny(Moria_schneider);
            instance.addNanny(Ayala_Zehavi);
            instance.addNanny(Elisheva_Shaked);
			
        }

        /// <summary>
        /// Initilize & addtion to list 21 Mothers
        /// </summary>
        void MotherInitilize()
        {

            Mother Bracha_Polak = new Mother
            {
                Id = idMotherArray[0],
                FirstName = "Bracha",
                LastName = "Polak",
                Address = "HaRav Herzog St 12, Jerusalem",
                cellPhone = 0526874352,
                AreaCerch = "Shakhal St 23,Jerusalem",

                TimeWork = new TimeSpan[6, 2]
                {
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)}
				},

            };
            Mother Oshrat_Levi = new Mother
            {
                Id = idMotherArray[1],
                FirstName = "Oshrat",
                LastName = "Levi",
                Address = "Ha-'va'ad haleumi St 21,Jerusalem",
                cellPhone = 0526943451,
                AreaCerch = "Shakhal St 23,Jerusalem",

                TimeWork = new TimeSpan[6, 2]
                {
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)}
				},
                Remarks = "",
            };
            Mother Ayelt_Shaked = new Mother
            {
                Id = idMotherArray[2],
                FirstName = "Ayelt",
                LastName = "Shaked",
                Address = "Shakhal St 23,Jerusalem",
                cellPhone = 0521234566,
                AreaCerch = "Shakhal St 23,Jerusalem",

                TimeWork = new TimeSpan[6, 2]
                {
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)},
					{ new TimeSpan(7,30,0),new TimeSpan(16,30,0)}
				},
                Remarks = "",

            };
           
            instance.addMother(Bracha_Polak);
			instance.addMother(Ayelt_Shaked);
			instance.addMother(Oshrat_Levi);
        }

        /// <summary>
        /// Initilize & addtion to list 30 Childs
        /// </summary>
        void ChildInitilize()
        {
            Child nadav = new Child
            {
                Id = idChildArray[0],
                MotherId = idMotherArray[0],
                FirstName = "nadav",
                BirthDate = new DateTime(2017, 8, 26),
                IsSpecalNeed = false,
            };
            Child moty = new Child
            {
                Id = idChildArray[1],
                MotherId = idMotherArray[1],
                FirstName = "moty",
                BirthDate = new DateTime(2017, 9, 8),
                IsSpecalNeed = false,
            };
            Child eti = new Child
            {
                Id = idChildArray[2],
                MotherId = idMotherArray[2],
                FirstName = "eti",
                BirthDate = new DateTime(2017, 5, 29),
                IsSpecalNeed = false,
            };
            
            instance.addChild(nadav);
            instance.addChild(moty);
			instance.addChild(eti);
            
        }

        /// <summary>
        /// find nanny that suitable with Current mom
        /// </summary>
        int FindNanny(Mother mom)
        {
            List<Nanny> temp = instance.getNannis();
            int i = 0;
            while (i < temp.Count) {
                if (instance.checkCompatibilityMotherNanny(temp[i], mom) == true)
                {
                    return temp[i].Id;
                }
                i++;
            }
            throw new Exception("sorry, no Nanny Exists to your needs");
        }

        /// <summary>
        /// Initilize & addtion to list of Contracts, Note! there are children that have no nanny
        /// </summary>
        void ContractInitilize()
        {
            Contract con;
            for (int i = 0; i < 3; i++)
            {

               // Mother m = instance.getMothers().Find(x => x.Id == instance.getChildren().Find(y => y.Id == idChildArray[i]).MotherId);
                try
                {
                     // int Nannyid = FindNanny(m);
                    con = new Contract
                    {
                        ChildId = idChildArray[i],
                        NannyId = idNannyArray[i],
                        //NameNanny = instance.getNanny().Find(x => x.ID == Nannyid).name,
                        IsAcquaintance = true,//if its not, addContract will change it
                        IsContract = true,
                        stertEmployment = DateTime.Today,
                        endEmployment = new DateTime(2108, 6, 25),
                    };
                    //if (instance.addContract(con))
                    ////throw the nanny that get a child to the end of list, to distribute evenly
                    //{
                    //    Nanny n = instance.getNanny().Find(x => x.ID == con.idNanny);
                    //    instance.removeNanny(con.idNanny);
                    //    instance.addNanny(n);
                    //}
                }
                catch (Exception)
                {
                    //Console.WriteLine(instance.getMother().Find(x => x.ID == instance.getChild().Find(y => y.ID == idChildArray[i]).idMother).name);
                    /* don't something*/
                }
            }
            //foreach (Nanny n in instance.getNannis())
            //if (n.myChildren != null)
           // {
              //  Console.WriteLine(n.ToString());
                //Console.WriteLine(n.myChildren.Count);
            // }
        }
		class test
		{
			public test ()
			{
				tryThis();
			}
			public void tryThis()
			{
				Child i = instance.GetChild(idChildArray[1]);
				i.ToString();
				//foreach (var i in tempNannyList)
				//{
					//i.ToString();
				//}
			}

		}

        class program
        {


			
			static void Main(string[] args)
            {
                try
                {
                    DefaultInitilize ul = new DefaultInitilize();
                }
                catch(Exception g)
                {
                    
                    Console.WriteLine("this is an Exception...{0}" ,g.Message);
                    Console.ReadKey();
                }
				test u = new test();
				

            }


			
		}


    }
}


