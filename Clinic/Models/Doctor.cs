using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Clinic;

namespace Clinic.Models
{
    public class Doctor
    {
        private int _id;
        private string _name;

        public Doctor(string name, int id=0)
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
            _id = id;
        }

        public static List<Specialty> GetSpecialties(int id)
        {
            List<Specialty> doctorsSpecialties = new List<Specialty>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialties.* FROM doctors
                JOIN doctors_specialties on (doctors.id = doctors_specialties.doctor_id)
                JOIN specialties ON (doctors_specialties.specialty_id = specialties.id)
                WHERE doctors.id = @DoctorId;";
            cmd.Parameters.AddWithValue("@DoctorId", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
                doctorsSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return doctorsSpecialties;
        }

        public static List<Patient> GetPatients(int id)
        {
            List<Patient> doctorsPatients = new List<Patient>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT patients.* FROM doctors
                JOIN doctors_patients on (doctors.id = doctors_patients.doctor_id)
                JOIN patients ON (doctors_patients.patient_id = patients.id)
                WHERE doctors.id = @DoctorId;";
            cmd.Parameters.AddWithValue("@DoctorId", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int patientId = rdr.GetInt32(0);
                string patientName = rdr.GetString(1);
                string patientBirthday = rdr.GetDateTime(2).ToString("MM/dd/yyyy");
                Patient newPatient = new Patient(patientName, patientBirthday, patientId);
                doctorsPatients.Add(newPatient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return doctorsPatients;
        }




        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO doctors (name) VALUES (@name);";
            cmd.Parameters.AddWithValue("@name", this._name);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Doctor> GetAll()
        {
            List<Doctor> allDoctors = new List<Doctor>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM doctors;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int doctorId = rdr.GetInt32(0);
                string doctorName = rdr.GetString(1);
                Doctor newDoctor = new Doctor(doctorName);
                newDoctor.SetId(doctorId);
                allDoctors.Add(newDoctor);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allDoctors;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM doctors;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }            
        }

        public override bool Equals(System.Object otherDoctor)
        {
            if (!(otherDoctor is Doctor))
            {
                return false;
            }
            else
            {
                Doctor newDoctor = (Doctor) otherDoctor;
                bool areIdsEqual = (this.GetId() == newDoctor.GetId());
                bool areDescriptionsEqual = (this.GetName() == newDoctor.GetName());
                return (areIdsEqual && areDescriptionsEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

    }
}
