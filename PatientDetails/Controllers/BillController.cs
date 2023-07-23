using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interfaces;
using ViewModels.ViewModel;

namespace PatientDetails.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillService _iBillService;
        private readonly IPatientService _iPatientService;
        public BillController(IBillService billService, IPatientService patientService)
        {
            _iBillService = billService;
            _iPatientService = patientService;
        }
        public IActionResult Index()
        {
            var billViewModel = _iBillService.AllBills();
            return View(billViewModel);
        }

        [HttpGet]
        public IActionResult CreateBill()
        {
            ViewData["PatientNamedropdownvalues"] = new SelectList(_iPatientService.AllPatients(), "PatientId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateBill(BillViewModel billViewModel)
        {
             _iBillService.CreateBill(billViewModel);
              return RedirectToAction("Index");  
        }

       [HttpGet]
       public IActionResult GetBillById(int id)
        {
            ViewData["PatientNamedropdownvalues"] = new SelectList(_iPatientService.AllPatients(), "PatientId", "Name");
            var billViewModel = _iBillService.GetBillById(id);
            return View(billViewModel);
        }

        [HttpPost]
        public IActionResult UpdateBillById(BillViewModel billViewModel)
        {
            _iBillService.UpdateBill(billViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateReport()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateReport([FromBody] CreateReportViewModel createReportViewModel)
        {
            var billViewModel = _iBillService.AllBills();

            return Json(billViewModel);
        }


    }
}
