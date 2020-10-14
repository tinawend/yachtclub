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
        public string Id {get;}
        public string Name {get;}
        public string Personalnumber {get;}
        public View()
        {
            Console.WriteLine("1-Add a new member");
            Console.WriteLine("2-List all members");
            Console.WriteLine("3-Change a members info");
            Console.WriteLine("Please write a number and press enter");
        
            switch (Console.ReadLine())
            {
                case "1" :
                Console.WriteLine("What is your full name?");
                Name = Console.ReadLine();
                Console.WriteLine("What is your personal number?");
                Personalnumber = Console.ReadLine();
                MemberRegestry memberRegestry = new MemberRegestry(Name, Personalnumber, Id);
                memberRegestry.addMember();
                    break;
                case "2":
                 listMembers();

                    break;
                case "3":
                 memberRegestry = new MemberRegestry(Name, Personalnumber, Id);
                 changeMemberInfo(memberRegestry);

                    break;
            }
        }

        
        public void changeMemberInfo(MemberRegestry memberRegestry)
        {
            
            Console.WriteLine("1-Change Member name");
            Console.WriteLine("Please write a number and press enter");
             switch (Console.ReadLine())
            {
                case "1":
                Console.WriteLine("Please write a name to change");
                string oldName = Console.ReadLine();
                Console.WriteLine("Please write a new name");
                string newName = Console.ReadLine();
                memberRegestry.ChangeInfo(oldName, newName);
                break;

            }
        }



        public void listMembers()
        {
            // using (var reader = new StreamReader(@"Members.json"))
            // {
            //     // string line;
            //     // while ((line = reader.ReadLine()) != null)
            //     // {
            //     //     Console.WriteLine(line, "{0}");
            //     // //    foreach(string name in line){
            //     //     //    Console.WriteLine();
            //     // //    }
            //     // }
            //                var json = reader.ReadToEnd();
            //     // var items = JsonConvert.DeserializeObject<List<SchemaInfo>>(json);
            //      var items = JObject.Parse(json);
            //     foreach (var item in items[0].Properties())
            //     {
            //        Console.WriteLine("{0} {1}", item);
            //     }
            // }
           string initialJson = File.ReadAllText(@"Members.json");

            var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
            // Console.WriteLine(list);
            foreach (var item in list) Console.WriteLine(item.Id);
        }
        

    }
}
