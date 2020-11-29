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
        public List<Member> list;

        public MemberRegistry()
        {

        }

        public List<Member> getList()
        {
            string initialJson = File.ReadAllText(@"Members.json");
            list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
            return list;
        }

        public void writeToList()
        {
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(@"Members.json", convertedJson);
        }
    /*
        Adds a member to the file Members.json.
    */

        public void addMember(string Name, string Personalnumber, string MemberId, string Type, string Lenght, int amountOfBoats) 
        {
            list = getList();
            list.Add(new Member(Name, Personalnumber, MemberId, boatList));
            writeToList();
        }

        public List<Boat> AddBoat(string Type, string Lenght, int amountOfBoats, string MemberId)
        {
            list = getList();
                
            foreach (Member item in list.ToList()) 
            {
                if(MemberId == item.MemberId) 
                {
                    item.Boats.Add(new Boat(Type, Lenght));
                }
            }
            writeToList();

            return boatList;
        } 

     /*
        Changes the info of a member.
    */
        public void ChangeName(string newInfo, string MemberId) 
        {
            list = getList();
            foreach (Member item in list.ToList()) 
            {
                if(MemberId == item.MemberId) 
                {
                    item.Name = newInfo;
                }
            }
            writeToList();
        }

        public void ChangePNum(string newInfo, string MemberId) 
        {
        
            list = getList();
            foreach (Member item in list.ToList()) 
            {
                if(MemberId == item.MemberId) 
                {
                    item.Personalnumber = newInfo;
                }
            }
            writeToList();
        }
    /*
    Delete a member from the file Members.json.
*/
        public void deleteMember(string memberToDelete)
        {
            list = getList();
            foreach (Member item in list.ToList()) 
            {
                if(memberToDelete == item.MemberId) 
                {
                    list.Remove(item);                
                }
            }
            writeToList();

        }

        public string setMemberId() 
        {
            string MemberId = string.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000); // lånat exempel via forum

            list = getList();

            foreach (Member item in list) 
            {
        
                    if(MemberId == item.MemberId)
                    {
                        Environment.Exit(-1);
                    }

            }
            return MemberId;
        }

        public void deleteBoat(string MemberId, string Type, string Lenght) 
        {
            list = getList();
            
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
            writeToList();
        }

        public void changeBoat(string Type, string Lenght, string newLength, string newType, string MemberId) 
        {
            list = getList();
            
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
            writeToList();
        }
    }
}
