using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpGet("/specialties/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/specialties")]
        public ActionResult Create(string specialtyName)
        {
            Specialty newSpecialty = new Specialty(specialtyName);
            newSpecialty.Save();
            return RedirectToAction("Index");
        }

        [HttpGet ("/specialties/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty selectedSpecialty = Specialty.Find(id);
            List<Doctor> specialtyDoctors = Specialty.GetDoctors(id);
            model.Add("specialty", selectedSpecialty);
            model.Add("specialtyDoctors", specialtyDoctors);
            return View(model);
        }

        //create a new doctor within a certain specialty
        [HttpGet("/specialties/{specialtyId}/doctors/new")]
        public ActionResult NewDoctorInSpecialty(int specialtyId)
        {
            Specialty thisSpecialty = Specialty.Find(specialtyId);
            return View(thisSpecialty);
        }
    }
}