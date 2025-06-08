using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySQL.DAL;
using MySQL.Models;

namespace MySQL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //    Agent agent = new Agent("saso","moshe","12.13.14", "Active",4);

            //    AgentDAL agent1 = new AgentDAL("server=localhost;username=root;password=;dadtabase=classicmodels");
            //    agent1.AddAgent(agent);
            //}

            AgentDAL dal = new AgentDAL("server=localhost;username=root;password=;dadtabase=classicmodels");
            bool running = true;
            while (running)
            {
                Console.WriteLine("בחר פעולה:");
                Console.WriteLine("1 - הוסף סוכן");
                Console.WriteLine("2 - מחק סוכן");
                Console.WriteLine("3 - עדכן מיקום סוכן");
                Console.WriteLine("4 - הצג את כל הסוכנים");
                Console.WriteLine("5 - סגור את התוכנית");
                Console.Write("הקש בחירה: ");
                string choice = Console.ReadLine();
                switch (choice)
            {
                case "1":
                    // הוספת סוכן
                    Console.Write("הכנס שם קוד: ");
                    string codeName = Console.ReadLine();

                    Console.Write("הכנס שם אמיתי: ");
                    string realName = Console.ReadLine();

                    Console.Write("הכנס מיקום נוכחי: ");
                    string location = Console.ReadLine();

                    Console.Write("הכנס סטטוס: ");
                    string status = Console.ReadLine();

                    Console.Write("הכנס מספר משימות שהושלמו: ");
                    int missionsCompleted = int.Parse(Console.ReadLine());

                    Agent newAgent = new Agent(codeName, realName, location, status, missionsCompleted);
                    dal.AddAgent(newAgent);
                    break;

                case "2":
                    // מחיקת סוכן
                    Console.Write("הכנס מזהה סוכן למחיקה: ");
                    if (int.TryParse(Console.ReadLine(), out int idToDelete))
                    {
                        dal.DeleteAgent(idToDelete);
                    }
                    else
                    {
                        Console.WriteLine("מזהה לא חוקי.");
                    }
                    break;

                case "3":
                    // עדכון מיקום
                    Console.Write("הכנס מזהה סוכן לעדכון: ");
                    if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                    {
                        Console.Write("הכנס מיקום חדש: ");
                        string newLoc = Console.ReadLine();
                        dal.UpdateAgentLocation(idToUpdate, newLoc);
                        Console.WriteLine("המיקום עודכן.");
                    }
                    else
                    {
                        Console.WriteLine("מזהה לא חוקי.");
                    }
                    break;

                case "4":
                    // הצגת כל הסוכנים
                    var agents = dal.GetAllAgents();
                    foreach (var agent in agents)
                    {
                        agent.printAllAgents();
                    }
                    break;

                case "5":
                    running = false;
                    dal.CloseDB();
                    Console.WriteLine("התוכנית נסגרת.");
                    break;

                default:
                    Console.WriteLine("בחירה לא חוקית, נסה שוב.");
                    break;
            }

            Console.WriteLine();
        }


    }
    }
}
