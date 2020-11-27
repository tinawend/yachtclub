using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

namespace _1dv607_a2
{
    class View
    {

      /*
      View function that gives the user different options and actions depending on whats picked.
      */
        public View()
        {
            Console.WriteLine("1-Add a new member");
            Console.WriteLine("2-List all members");
            Console.WriteLine("3-Change a members info");
            Console.WriteLine("4-Delete a member");
            Console.WriteLine("5-Show one members info");
            Console.WriteLine("6-Addboat");
            Console.WriteLine("7-Delete Boat");
            Console.WriteLine("8-Change Boat");
            Console.WriteLine("Please write a number and press enter");
        
            MemberRegistry memberRegistry = new MemberRegistry();
            switch (Console.ReadLine())
            {
                case "1" :
               addingAMember(memberRegistry);
                    break;
                case "2":
                 listMembers(memberRegistry);
                    break;
                case "3":
                 changeMemberInfo(memberRegistry);
                    break;
                case "4":
                deleteMember(memberRegistry);
                    break;
                case "5":
                showSpecificMember(memberRegistry);
                    break;
                case "6":
                addBoatToMember(memberRegistry);
                    break;
                case "7":
                deleteBoat(memberRegistry);
                    break;
                case "8":
                changeBoat(memberRegistry);
                    break;
            }
        }

    /*
         Function that lets you change members information.
    */
        public void changeMemberInfo(MemberRegistry memberRegistry)
        {
            
            Console.WriteLine("Please write a Memberid for the member to be changed");
            string MemberId = Console.ReadLine();
            Console.WriteLine("1-Change a Members name");
            Console.WriteLine("2-Change a Members Personalnumber");
            Console.WriteLine("Please write a number and press enter");
             switch (Console.ReadLine())
            {
                case "1":
                Console.WriteLine("Please write a new name");
                string newName = Console.ReadLine();
                memberRegistry.ChangeName(newName, MemberId);
                break;
                case "2":
                Console.WriteLine("Please write a new personalnumber");
                string newPnum = Console.ReadLine();
                memberRegistry.ChangePNum(newPnum, MemberId);
                break;

            }
        }

     /*
         Function that lets you add a member.
    */
        public void addingAMember(MemberRegistry memberRegistry)
        {
                Console.WriteLine("What is your full name?");
                string Name = Console.ReadLine();

                Console.WriteLine("What is your personal number?");
                string Personalnumber = Console.ReadLine();
                    while(Personalnumber.Length < 6)
                    {
                        Console.WriteLine("Personalnumber should contain at least 6 characters");
                        Personalnumber = Console.ReadLine();
                    }
                string MemberId = memberRegistry.setMemberId();

                int AmountOfBoats = 0;
                string Type = "";
                string Lenght = "";
          
                memberRegistry.addMember(Name, Personalnumber, MemberId, Type, Lenght, AmountOfBoats);
                
        }
        public void addBoatToMember(MemberRegistry memberRegistry) 
        {       
                Console.WriteLine("Memberid?");
                string MemberId = Console.ReadLine();
                Console.WriteLine("how many boats?");
                int AmountOfBoats = int.Parse(Console.ReadLine());
                string Type = "";
                string Lenght = "";
                int i = 0;

                while (i < AmountOfBoats)
                {   
                Console.WriteLine("Type the number of the boatType?");
                Console.WriteLine("1-Sailboat");
                Console.WriteLine("2-Motorsailer");
                Console.WriteLine("3-kayak/Canoe");
                Console.WriteLine("4-Other");
                switch(Console.ReadLine())
                {
                    case "1":
                    Type = "Sailboat";
                        break;
                    case "2":
                    Type = "Motorsailer";
                        break;
                    case "3":
                    Type = "kayak/Canoe";
                        break;
                    case "4":
                    Type = "Other";
                        break;
                }
                Console.WriteLine("lenght of boat?");
                Lenght = Console.ReadLine();
                memberRegistry.AddBoat(Type, Lenght, AmountOfBoats, MemberId);
                 i++;
                }

        }

    /*
         Function that lets you delete a member
    */
        public void deleteMember(MemberRegistry memberRegistry)
        {
            Console.WriteLine("Please write an id of the member to be deleted");
            string idToDelete = Console.ReadLine();
            memberRegistry.deleteMember(idToDelete);
        }
        public void deleteBoat(MemberRegistry memberRegistry)
        {
            Console.WriteLine("Please write an id of a member");
            string MemberId = Console.ReadLine();
            Console.WriteLine("Write Type off boat");
            string Type = Console.ReadLine();
            Console.WriteLine("Write the lenght of the boat");
            string Lenght = Console.ReadLine();
            memberRegistry.deleteBoat(MemberId, Type, Lenght);

        }

        public void changeBoat(MemberRegistry memberRegistry) 
        {
            Console.WriteLine("Please write an id of a member");
            string MemberId = Console.ReadLine();
            Console.WriteLine("Write the Type of the boat you want to change");
            string Type = Console.ReadLine();
            Console.WriteLine("Write the lenght of the boat you want to change");
            string Lenght = Console.ReadLine();
            Console.WriteLine("Write the new Type of boat");
            string newType = Console.ReadLine();
            Console.WriteLine("Write the new lenght of the boat");
            string newLength = Console.ReadLine();
            memberRegistry.changeBoat(Type, Lenght, newLength, newType, MemberId);
        }

        public void showSpecificMember(MemberRegistry memberRegistry)
        {
            Console.WriteLine("Please write an id of a member");
            string MemberId = Console.ReadLine();
            Console.WriteLine(memberRegistry.showMemberInfo(MemberId));
        }

    /*
         Function that lets you list all members
    */
        public void listMembers(MemberRegistry memberRegistry)
        {
            Console.WriteLine("1-Compact List");
            Console.WriteLine("2-Verbose List");
            switch (Console.ReadLine())
            {
                case "1" :
                Console.WriteLine(memberRegistry.showCompactList());
                    break;
                case "2" :
                Console.WriteLine(memberRegistry.showVerboseList());
                    break;
            }
        }
        

    }
}
