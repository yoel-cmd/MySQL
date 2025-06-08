using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Models
{
    internal class Agent
    {
       
        public string code_name { get; set; }
        public string real_name { get; set; }
        public string current_location { get; set; }
        public string status { get; set; }
        public int missions_competd { get; set; }
        //-------------------------------------------------------------------------------------------------------------------------------
        public Agent(string code_name ,string real_name, string current_location, string status, int missions_competd)
        {
            this.code_name = code_name;
            this.real_name = real_name;
            this.current_location = current_location;
            this.status = status;
            this.missions_competd = missions_competd;
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        public void printAllAgents()
        {
            Console.WriteLine($"Code Name: {code_name}");
            Console.WriteLine($"Real Name: {real_name}");
            Console.WriteLine($"Location: {current_location}");
            Console.WriteLine($"Status: {status}");
            Console.WriteLine($"Missions Completed: {missions_competd}");
            Console.WriteLine("---------------");
        }
        //-------------------------------------------------------------------------------------------------------------------------------
    }
}
