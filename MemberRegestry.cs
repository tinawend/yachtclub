using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _1dv607_a2
{
    class MemberRegestry
    {

        private string _name;
        private string _personalnumber;
        private string _id;
        Random r = new Random();
        // private static List<Member> list = new List<Member>();


        public string Name {get{ return _name; } set{_name = value;}}
        public string Personalnumber {get{ return _personalnumber; } set{_personalnumber = value;}}
        public string Id {get{ return r.Next(1, 4).ToString(); } set{_id = value;}}

        public MemberRegestry(string name, string personalnumber, string id)
        {
            Name = name;
            Personalnumber = personalnumber;
            Id = id;

        }


        public void addMember()
        {
            string initialJson = File.ReadAllText(@"Members.json");

            var list = JsonConvert.DeserializeObject<List<Member>>(initialJson);
            list.Add(new Member(Name, Personalnumber, Id));
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

            File.WriteAllText(@"Members.json", convertedJson);

        }

            public void ChangeInfo(string oldName, string newName) 
            {
                string text = File.ReadAllText(@"Members.json");
                text = text.Replace(oldName, newName);
                File.WriteAllText(@"Members.json", text);
            }

    }
}
