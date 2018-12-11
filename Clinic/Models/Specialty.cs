using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Clinic;

namespace Clinic.Models
{
    public class Specialty
    {
        private int _id;
        private string _name;

        public Specialty(string name, int id=0)
        {
            _id = id;
            _name = name;
        }

        public int GetId()
        {
            return _id;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetId(int id)
        {
            _id=id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@name);";
            cmd.Parameters.AddWithValue("@name", this._name);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(specialtyName);
                newSpecialty.SetId(specialtyId);
                allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }            
        }

        public static Specialty Find(int specialtyId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = @SpecialtyId;";
            cmd.Parameters.AddWithValue("@SpecialtyId", specialtyId);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string name = "";
            while(rdr.Read())
            {
                id = rdr.GetInt32(0);
                name = rdr.GetString(1);
            }
            Specialty newSpecialty = new Specialty(name, id);
            newSpecialty.SetId(id);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newSpecialty;
        }

        public static List<Doctor> GetDoctors(int id)
        {
            List<Doctor> specialtyDoctors = new List<Doctor>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT doctors.* FROM specialties
                JOIN doctors_specialties on (specialties.id = doctors_specialties.specialty_id)
                JOIN doctors ON (doctors_specialties.doctor_id = doctors.id)
                WHERE specialties.id = @SpecialtyId;";
            cmd.Parameters.AddWithValue("@SpecialtyId", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int doctorId = rdr.GetInt32(0);
                string doctorName = rdr.GetString(1);
                Doctor newDoctor = new Doctor(doctorName, doctorId);
                specialtyDoctors.Add(newDoctor);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return specialtyDoctors;
        }

        
    }
}
