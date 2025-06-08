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

            //    AgentDAL agent1 = new AgentDAL("server=localhost;username=root;password=;database=classicmodels");
            //    agent1.AddAgent(agent);
            //}

            AgentDAL dal = new AgentDAL("server=localhost;username=root;password=;database=agents;");
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1 - Add an agent");
                Console.WriteLine("2 - Delete an agent");
                Console.WriteLine("3 - Update agent location");
                Console.WriteLine("4 - Show all agents");
                Console.WriteLine("5 - Exit the program");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // Add an agent
                        Console.Write("Enter code name: ");
                        string codeName = Console.ReadLine();

                        Console.Write("Enter real name: ");
                        string realName = Console.ReadLine();

                        Console.Write("Enter current location: ");
                        string location = Console.ReadLine();

                        Console.Write("Enter status: ");
                        string status = Console.ReadLine();

                        Console.Write("Enter number of completed missions: ");
                        int missionsCompleted = int.Parse(Console.ReadLine());


                        Agent newAgent = new Agent(codeName, realName, location, status, missionsCompleted);
                        dal.AddAgent(newAgent);
                        break;

                    case "2":
                        // מחיקת סוכן
                        Console.Write("Enter agent ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            dal.DeleteAgent(idToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "3":
                        // Update location
                        Console.Write("Enter agent ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                        {
                            Console.Write("Enter new location: ");
                            string newLoc = Console.ReadLine();
                            dal.UpdateAgentLocation(idToUpdate, newLoc);
                            Console.WriteLine("Location updated.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;


                    case "4":
                        Console.WriteLine("\n--- All Agents ---\n");
                        var agents = dal.GetAllAgents();
                        foreach (var agent in agents)
                        {
                            agent.printAllAgents();
                        }
                        break;

                    case "5":
                        running = false;
                        dal.CloseDB();
                        Console.WriteLine("The program is closing.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine();
            }


        }
    }
}
