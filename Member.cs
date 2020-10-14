using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _1dv607_a2
{
    class Member : MemberRegestry
    {

        public Member(string name, string personalnumber, string id) : base(name, personalnumber, id)
        { 
            Name = name;
            Personalnumber = personalnumber;
            Id = id;
        }
       
    }

}