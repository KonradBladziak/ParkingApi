using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MiastaController : Controller
    {
        private IUnitOfWork unitOfWork;

        public MiastaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WszystkieMiasta()
        {
            var miasta = unitOfWork.MiastoRepository.GetAllAsync().Result.ToList();
            ViewBag.Miasta = miasta;
            return View(miasta);
        }
    }
}
