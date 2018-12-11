using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class DoctorsController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Doctor> allDoctors = Doctor.GetAll();
            return View(allDoctors);
        }

        [HttpGet("/doctors/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/doctors")]
        public ActionResult Create(string doctorName)
        {
            Doctor newDoctor = new Doctor(doctorName);
            newDoctor.Save();
            RedirectToAction("Index");
        }

        [HttpGet ("/doctors/{id}")]
        public ActionResult Show(int doctorId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Doctor selectedDoctor = Doctor.Find(doctorId);
            List<Patient> doctorPatients = selectedDoctor.GetPatients();
            List<Specialty> doctorSpecialties = selectedDoctor.GetSpecialties();
            model.Add("doctor", selectedDoctor);
            model.Add("doctorPatients", doctorPatients);
            model.Add("doctorSpecialties", doctorSpecialties);
            return View(model);
        }
    }
}