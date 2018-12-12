using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Clinic.Models;

// namespace Clinic.Controllers
// {
//     public class PatientsController : Controller
//     {
//         [HttpGet("/patients")]
//         public ActionResult Index()
//         {
//             List<Doctor> allDoctors = Doctor.GetAll();
//             return View(allDoctors);
//         }

//         [HttpPost ("/patients")]
//         public ActionResult Create(int doctorId, string patientName, string birthday)
//         {
//             Patient newPatient = new Patient(patientName, birthday);
//             newPatient.Save();
//             newPatient.AddToJoinTable(doctorId);
//             return RedirectToAction("Index");
//         }
//     }
// }