using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interfaces;
using ViewModels.ViewModel;

namespace PatientDetails.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _iPatientService;
        private readonly IGenderService _iGenderService;
        public PatientController(IPatientService patientService, IGenderService genderService)
        {
            _iPatientService = patientService;
            _iGenderService = genderService;
        }
        public IActionResult Index()
        { 
            var patientViiewModel = _iPatientService.AllPatients();
            return View(patientViiewModel);
        }


        [HttpGet]
        public IActionResult AddNewPatient()
        {
            ViewData["Genderdropdownvalues"] = new SelectList(_iGenderService.Genders(), "Id","Genders");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPatient(PatientViiewModel patientViiewModel)
        {
          
            _iPatientService.AddNewPatient(patientViiewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Genderdropdownvalues"] = new SelectList(_iGenderService.Genders(), "Id", "Genders");
            var patientViewModel = _iPatientService.GetPatientById(id);
            return View(patientViewModel);
        }

        [HttpPost]
        public IActionResult Edit(PatientViiewModel patientViiewModel)
        {
            _iPatientService.UpdatePatient(patientViiewModel);
            return RedirectToAction("Index");
        }
    }
}
