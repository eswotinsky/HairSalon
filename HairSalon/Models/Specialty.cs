using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Specialty
    {
        private int _name;
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
    }
}
