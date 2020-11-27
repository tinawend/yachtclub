using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _1dv607_a2
{
    public class MemberRegistry
    {
            public List<Boat> boatList = new List<Boat>();

            public MemberRegistry()
            {

            }

    /*
        Adds a member to the file Members.json.
    */

            public void addMember(string Name, string Personalnumber, string MemberId, string Type, string Lenght, int amountOfBoats) 
            {
                string initialJson = File.ReadAllText(@"Members.json");

                var list = JsonConvert.DeserializeObject<List<object>>(initialJson);
                

                list.Add(new Member(Name, Personalnumber, MemberId, boatList));
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(@"Members.json", convertedJson);

            }

        


            public List<Boat> AddBoat(string Type, string Lenght, int amountOfBoats, string MemberId)
            {
                string initialJson = File.ReadAllText(@"Members.json");

                var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
                
                foreach (Member item in list.ToList()) 
                {
                    if(MemberId == item.MemberId) 
                    {
                        item.Boats.Add(new Boat(Type, Lenght));
                    }
                }


                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(@"Members.json", convertedJson);

                return boatList;
            } 

     /*
        Changes the info of a member.
    */
            public void ChangeName(string newInfo, string MemberId) 
            {
                string initialJson = File.ReadAllText(@"Members.json");
                var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
                foreach (Member item in list.ToList()) 
                {
                    if(MemberId == item.MemberId) 
                    {
                        item.Name = newInfo;
                    }
                }
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(@"Members.json", convertedJson);
            }

            public void ChangePNum(string newInfo, string MemberId) 
            {
                string initialJson = File.ReadAllText(@"Members.json");
                var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
                foreach (Member item in list.ToList()) 
                {
                    if(MemberId == item.MemberId) 
                    {
                        item.Personalnumber = newInfo;
                    }
                }
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(@"Members.json", convertedJson);
            }
     /*
        Delete a member from the file Members.json.
    */
            public void deleteMember(string memberToDelete)
            {
                string initialJson = File.ReadAllText(@"Members.json");

                var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
                foreach (Member item in list.ToList()) 
                {
                    if(memberToDelete == item.MemberId) 
                    {
                        list.Remove(item);                
                    }
                }
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(@"Members.json", convertedJson);

            }

            public string setMemberId() 
            {

                string MemberId = string.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000); // lånat exempel via forum

                string initialJson = File.ReadAllText(@"Members.json");

                List<Member> list = JsonConvert.DeserializeObject<List<Member>>(initialJson);

                foreach (Member item in list) 
                {
         
                        if(MemberId == item.MemberId)
                        {
                            Environment.Exit(-1);
                            return "Id's are full, contact secretary";
                        }

                }
                return MemberId;
            }

            public void deleteBoat(string MemberId, string Type, string Lenght) 
            {
                string initialJson = File.ReadAllText(@"Members.json");

                var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
               
                foreach (Member item in list.ToList()) 
                {
                    if(MemberId == item.MemberId) 
                    {
                 
                        for(int i = 0; i < item.Boats.Count; i++)
                        {
                            if(Type == item.Boats[i].Type && Lenght == item.Boats[i].Lenght)
                            {
                                item.Boats.Remove(item.Boats[i]);
                            }
                        }
                        
                    }
                }


                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(@"Members.json", convertedJson);
         

            }

            public void changeBoat(string Type, string Lenght, string newLength, string newType, string MemberId) 
            {
                string initialJson = File.ReadAllText(@"Members.json");

                var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
               
                foreach (Member item in list.ToList()) 
                {
                    if(MemberId == item.MemberId) 
                    {
                         for(int i = 0; i < item.Boats.Count; i++)
                        {
                            if(Type == item.Boats[i].Type && Lenght == item.Boats[i].Lenght)
                            {
                                item.Boats[i].Type = newType;
                                item.Boats[i].Lenght = newLength;
                          
                            }
                        }
                    }
                }
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(@"Members.json", convertedJson);

            }

            public string showMemberInfo(string MemberId)
            {
                string initialJson = File.ReadAllText(@"Members.json");

                var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
                foreach (Member item in list.ToList()) 
                {
                    for(int i = 0; i < item.Boats.Count; i++)
                    {
                        if(MemberId == item.MemberId) 
                        {
                            return "name: " + item.Name + "\nPersonalNumber: " + item.Personalnumber + "\nMember Id: " + item.MemberId + "\nBoat Type: " + item.Boats[i].Type + "\nBoat Length: " + item.Boats[i].Lenght;
                        }
                    }
                }
                

                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(@"Members.json", convertedJson);
                return "member do not exist";
            }

            public string showVerboseList()
            {
                string initialJson = File.ReadAllText(@"Members.json");

                List<Member> list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
                var str = "";
                foreach (Member item in list) 
                {
                    str += "\n\nName: " + item.Name + "\nId: " + item.MemberId + "\nPersonalNumber: " + item.Personalnumber;
                    for(int i = 0; i < item.Boats.Count; i++)
                    {
                    
                        str += "\nType: " + item.Boats[i].Type + ",\nLenght: " + item.Boats[i].Lenght;
                    }
                }
                return str;

            }

            public string showCompactList()
            {
                string initialJson = File.ReadAllText(@"Members.json");

                List<Member> list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
                var str = "";
                foreach (Member item in list) 
                {
                    str += "\nName: " + item.Name + "\nId: " + item.MemberId + "\nNumber of boats: " + item.Boats.Count + "\n";
                }
                return str;
            }



            public virtual string Name
            {
                get;
                set;
            }
            public virtual string Personalnumber
            {
                get;
                set;
            }
            public virtual string MemberId
            {
                get;
                set;
            }
            public virtual string Type
            {
                get;
                set;
            }
            public virtual string Lenght
            {
                get;
                set;
            }
    }
}
