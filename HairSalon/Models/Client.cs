using System;
using System.Collections.Generic;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Client
    {
        private string _name;
        private int _stylistId;
        private int _id;

        public Client(string name, int stylistId, int id = 0)
        {
            _name = name;
            _stylistId = stylistId;
            _id = id;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                return this.GetId().Equals(newClient.GetId());
            }
        }

        public override int GetHashCode()
        {
          return this.GetId().GetHashCode();
        }

        public string GetName()
        {
            return _name;
        }

        public int GetStylistId()
        {
            return _stylistId;
        }

        public int GetId()
        {
            return _id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@name, @stylist_id);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@stylist_id";
            stylistId.Value = this._stylistId;
            cmd.Parameters.Add(stylistId);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id=@id;";

            MySqlParameter myClientId = new MySqlParameter("@id", id);
            cmd.Parameters.Add(myClientId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string clientName = "";
            int clientStylistId = 0;

            while (rdr.Read())
            {
                clientName = rdr.GetString(1);
                clientStylistId = rdr.GetInt32(2);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            Client myClient = new Client(clientName, clientStylistId);
            return myClient;
        }

        public static List<Client> GetAll()
        {
             List<Client> allClients = new List<Client> {};
             MySqlConnection conn = DB.Connection();

             conn.Open();
             var cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText = @"SELECT * FROM clients;";
             var rdr = cmd.ExecuteReader() as MySqlDataReader;
             while(rdr.Read())
             {
               int clientId = rdr.GetInt32(0);
               string clientName = rdr.GetString(1);
               int clientStylistId = rdr.GetInt32(2);
               Client newClient = new Client(clientName, clientStylistId, clientId);
               allClients.Add(newClient);
             }
             conn.Close();
             if (conn != null)
             {
               conn.Dispose();
             }
             return allClients;
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE id = @thisId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@thisId";
            searchId.Value = _id;
            cmd.Parameters.Add(searchId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
        {
            //warn user first?
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";
            cmd.ExecuteNonQuery();

            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
