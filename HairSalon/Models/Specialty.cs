using System;
using System.Collections.Generic;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Specialty
    {
        private string _name;
        private int _id;

        public Specialty(string name, int id = 0)
        {
            _id = id;
            _name = name;
        }

        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty) otherSpecialty;
                return this.GetId().Equals(newSpecialty.GetId());
            }
        }

        public override int GetHashCode()
        {
          return this.GetId().GetHashCode();
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@name);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            //delete from database
        }

        public static void DeleteAll()
        {
            //warn user first?
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";
            cmd.ExecuteNonQuery();

            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            int specialtyId = 0;
            string specialtyName = "";

            while (rdr.Read())
            {
                specialtyId = rdr.GetInt32(0);
                specialtyName = rdr.GetString(1);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            Specialty mySpecialty = new Specialty(specialtyName, specialtyId);
            return mySpecialty;
        }

        public static List<Specialty> GetAll()
        {
             List<Specialty> allSpecialties = new List<Specialty> {};
             MySqlConnection conn = DB.Connection();

             conn.Open();
             var cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText = @"SELECT * FROM specialties;";
             var rdr = cmd.ExecuteReader() as MySqlDataReader;
             while(rdr.Read())
             {
               int specialtyId = rdr.GetInt32(0);
               string specialtyName = rdr.GetString(1);
               Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
               allSpecialties.Add(newSpecialty);
             }
             conn.Close();
             if (conn != null)
             {
               conn.Dispose();
             }
             return allSpecialties;
        }

        public void AddStylist(Stylist newStylist)
        {
            //insert stylist_id and specialty_id pair into join table
        }

        public static List<Stylist> GetStylists()
        {
            //return all stylists paired with this specialty's id in join table
            List<Stylist> myStylists = new List<Stylist>{};
            return myStylists;
        }
    }
}
