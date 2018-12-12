using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Clinic;

namespace Clinic.Models
{
    public class Patient
    {
        private int _id;
        private string _name;
        private string _birthday;

        public Patient(string name, string birthday, int id=0)
        {
            _id = id;
            _name = name;
            _birthday = birthday;
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
            cmd.CommandText = @"INSERT INTO patient (name, birthday) VALUES (@name, @birthday);";
            cmd.Parameters.AddWithValue("@name", this._name);
            cmd.Parameters.AddWithValue("@birthday", this._birthday);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Patient> GetAll()
        {
            List<Patient> allPatients = new List<Patient>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM patients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int patientId = rdr.GetInt32(0);
                string patientName = rdr.GetString(1);
                string patientBirthday = rdr.GetDateTime(2).ToString("MM/dd/yyyy");
                Patient newPatient = new Patient(patientName, patientBirthday);
                newPatient.SetId(patientId);
                allPatients.Add(newPatient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allPatients;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM patients;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }            
        }

        public void AddToJoinTable(int doctorId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO doctors_patients (doctor_id, patient_id) VALUES (@doctorId, @patientId);";
            cmd.Parameters.AddWithValue("@patientId", this._id);
            cmd.Parameters.AddWithValue("@doctorId", doctorId);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        
        
    }
}
