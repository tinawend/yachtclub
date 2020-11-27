using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _1dv607_a2
{
    public class Member 
    {
        private string _name;
        private string _personalnumber;
        private string _memberId;

        private List<Boat> _boat;

    
        public Member(string name, string personalnumber, string id, List<Boat> boat)
        { 
            Name = name;
            Personalnumber = personalnumber;
            MemberId = id;
            Boats = boat;
     
        }

        public string Name 
        {
            get{ return _name; } set{_name = value;}
        }
        public string Personalnumber 
        {
            get{ return _personalnumber;} set{_personalnumber = value;}
        }
        public string MemberId 
        {
            get{ return _memberId;} set{_memberId = value;}
        }

        public List<Boat> Boats 
        {
            get{ return _boat;} set{_boat = value;}
        }
       
    }

}