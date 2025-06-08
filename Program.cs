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

            Agent agent = new Agent("saso","moshe","12.13.14", "Active",4);

            AgentDAL agent1 = new AgentDAL("server=localhost;username=root;password=;dadtabase=classicmodels");
            agent1.AddAgent(agent);

            string connStr = "server=localhost;username=root;password=;dadtabase=classicmodels";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                Console.WriteLine("enter your query");
                string query = Console.ReadLine();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //string[] words = query.Split(' ');
                    //int index = Array.FindIndex(words, w => w.Equals("from", StringComparison.OrdinalIgnoreCase));
                    //string tableName = words[index + 1];
                    //Console.WriteLine();

                    string firstname = reader.GetString();
                }



            }
            catch(Exception e)
            {
                Console.WriteLine($"err:{e.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
