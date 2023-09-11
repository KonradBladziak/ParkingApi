using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class InwalidzkieController : Controller
    {
        private IMiejscaInwalidzkieService miejscaInwalidzkieService;
        private IMiejsceService miejscaService;

        public InwalidzkieController(IMiejscaInwalidzkieService miejscaInwalidzkieService, IMiejsceService miejscaService)
        {
            this.miejscaInwalidzkieService = miejscaInwalidzkieService;
            this.miejscaService = miejscaService;
        }
        public async Task<IActionResult> Index()
        {
            var miejsca = await miejscaInwalidzkieService.GetMiejscaInwalidzkie();
            return View(miejsca);
        }
        //public async Task<IActionResult> Create([Bind("RozmiarMiejsca,IdMiejsca")] MiejsceInwalidzkie inwalidzkie)
        //{
        //    ViewBag.Message=null;

        //    if (inwalidzkie.IdMiejsca != null && inwalidzkie.RozmiarMiejsca > 0) 
        //    {
        //        var miejsce = await miejscaService.GetMiejsceById(inwalidzkie.IdMiejsca);
        //        if (miejsce.MiejsceInwalidzkie == null) 
        //        {
        //            miejsce.MiejsceInwalidzkieId = inwalidzkie.Id;
        //            miejsce.MiejsceInwalidzkie = inwalidzkie;
        //            await miejscaService.UpdateMiejsce(miejsce);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            ViewBag.Message = "To miejsce już jest inwalidzkie";
        //        }
        //    }

        //    return View(inwalidzkie);
        //}

        public async Task<IActionResult> Create([Bind("RozmiarMiejsca,IdMiejsca")] MiejsceInwalidzkie inwalidzkie)
        {
            ViewBag.Message = null;

            if (inwalidzkie.IdMiejsca != null && inwalidzkie.RozmiarMiejsca > 0)
            {
                if (await miejscaInwalidzkieService.CzyToMiejsceInwalidzkie(inwalidzkie.IdMiejsca) == false)
                {
                    await miejscaInwalidzkieService.AddMiejsceInwalidzkie(inwalidzkie);
                    var miejsce = await miejscaService.GetMiejsceByIdDetails(inwalidzkie.IdMiejsca);
                    miejsce.MiejsceInwalidzkie = inwalidzkie;
                    miejsce.MiejsceInwalidzkieId = inwalidzkie.Id;
                    await miejscaService.UpdateMiejsce(miejsce);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "To miejsce już jest inwalidzkie";
                }
            }

            return View(inwalidzkie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var inwalidzkie = await miejscaInwalidzkieService.GetMiejsceInwalidzkieById(id);

            if (inwalidzkie != null)
            {
                miejscaInwalidzkieService.DeleteMiejsceInwalidzkie(inwalidzkie);
                return RedirectToAction(nameof(Index));
            }

            return View(inwalidzkie);
        }
    }
}
