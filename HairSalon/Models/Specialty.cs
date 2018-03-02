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
            //save to database
        }

        public void Delete()
        {
            //delete from database
        }

        public static void DeleteAll()
        {
            //delete all specialties from database
        }

        public static Specialty Find(int id)
        {
            //find from database
            Specialty mySpecialty = new Specialty("test");
            return mySpecialty;
        }

        public static List<Specialty> GetAll()
        {
            //get from database
            List<Specialty> allSpecialties = new List<Specialty>{};
            return allSpecialties;
        }

        public void AddStylist(Stylist newStylist)
        {
            //insert stylist_id and specialty_id pair into join table
        }

        public static List<Stylist> GetStylists()
        {
            //get all stylists with this specialty from database
            List<Stylist> myStylists = new List<Stylist>{};
            return myStylists;
        }
    }
}
