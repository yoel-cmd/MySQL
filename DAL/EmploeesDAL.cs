using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySQL.Models;


namespace MySQL.DAL
{
    internal class AgentDAL
    {
        MySqlCommand cmd = null;
        MySqlDataReader reader = null;
        MySqlConnection conn;
        public AgentDAL(string connection)
        {
            string connStr = connection;
            conn = new MySqlConnection(connStr);
            conn.Open();

        }
        //------------------------------------------------------------------------------------------------------------------------------------
        public void AddAgent(Agent agent)
        {
            try
            {   
                string AddAgent = "INSERT INTO agents (name_code, real_name," +
             " current_location,status,missions_competd) VALUES (@name_code, @real_name,@current_location,@status,@missions_competd)";
                using (cmd = new MySqlCommand(AddAgent, conn))
                {
                    cmd.Parameters.AddWithValue("@code_name", agent.code_name);
                    cmd.Parameters.AddWithValue("@real_name", agent.real_name);
                    cmd.Parameters.AddWithValue("@current_location", agent.current_location);
                    cmd.Parameters.AddWithValue("@status", agent.status);
                    cmd.Parameters.AddWithValue("@missions_competd", agent.missions_competd);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("the Agent addiing to DB");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"err : {e.Message}");
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        public void DeleteAgent(int agentId)
        {
            try
            {
                string DeleteAgent = "DELETE FROM agents WHERE id = @id";
                using (cmd = new MySqlCommand(DeleteAgent, conn))
                {
                    cmd.Parameters.AddWithValue("@id", agentId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine($"הסוכן עם מזהה {agentId} נמחק בהצלחה.");
                    else
                        Console.WriteLine($"לא נמצא סוכן עם מזהה {agentId}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"err : {e.Message}");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            try
            {
                string query = "UPDATE agents SET current_location = @location WHERE id = @id";
                using (cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@location", newLocation);
                    cmd.Parameters.AddWithValue("@id", agentId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e){
                Console.WriteLine($"err : {e.Message}");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------

        public List<Agent> GetAllAgents()
        {
            List<Agent> agents = new List<Agent>();
           
            try
            {
                string GetAllAgents = "SELECT * FROM agents ";
                using (cmd = new MySqlCommand(GetAllAgents, conn))
                {
                    conn.Open();
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string code_name = reader.GetString("code_name");
                            string real_name = reader.GetString("real_name");
                            string current_location = reader.GetString("current_location");
                            string status = reader.GetString("status");
                            int missions_competd = reader.GetInt32("missions_competd");

                            Agent agent = new Agent(code_name, real_name, current_location, status, missions_competd);
                            agents.Add(agent);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"err:{e.Message}");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return agents;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public void CloseDB()
        {
            conn.Close();
            Console.WriteLine(" DB is closing");
        }
    }
}
