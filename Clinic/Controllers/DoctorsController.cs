using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class DoctorsController : Controller
    {
        [HttpGet("/doctors")]
        public ActionResult Index()
        {
            List<Doctor> allDoctors = Doctor.GetAll();
            return View(allDoctors);
        }



        [HttpPost("/doctors")]
        public ActionResult Create(string doctorName, int specialtyId)
        {
            Doctor newDoctor = new Doctor(doctorName);
            newDoctor.Save();
            newDoctor.AddToJoinTable(specialtyId);
            return RedirectToAction("Index");
        }

        [HttpGet ("/doctors/{doctorId}")]
        public ActionResult Show(int doctorId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Doctor selectedDoctor = Doctor.Find(doctorId);
            List<Patient> doctorPatients = Doctor.GetPatients(doctorId);
            List<Specialty> doctorSpecialties = Doctor.GetSpecialties(doctorId);
            model.Add("doctor", selectedDoctor);
            model.Add("doctorPatients", doctorPatients);
            model.Add("doctorSpecialties", doctorSpecialties);
            return View(model);
        }

        [HttpPost ("/doctors/{doctorId}")]
        public ActionResult ShowPatients(int doctorId, string patientName, string birthday)
        {
            Patient newPatient = new Patient(patientName, birthday);
            newPatient.Save();
            return RedirectToAction("Show");
        }

        [HttpGet("/doctors/{doctorId}/patients/new")]
        public ActionResult NewPatient(int doctorId)
        {
            Doctor thisDoctor = Doctor.Find(doctorId);
            return View(thisDoctor);
        }

        

    }
}