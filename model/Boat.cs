using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _1dv607_a2
{
    public class Boat 
    {
        private string _type;
        private string _lenght;
        

        public Boat(string type, string lenght)
        { 
            Type = type;
            Lenght = lenght;
        }

        public string Type 
        {
            get
            {
                return _type; 
            } 
            set
            {
                _type = value;
            }
        }
        public string Lenght 
        {
            get
            {
                return _lenght; 
            } 
            set
            {
                _lenght = value;
            }
        }
       
    }

}