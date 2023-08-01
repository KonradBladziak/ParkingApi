using BLL.IWorkServices;
using BLL.WorkServices;
using DAL.DataContext;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;

namespace MVC.Controllers
{
    public class ParkingiController : Controller
    {
        private IParkingService parkingService;
        private IMiastoService miastoService;
        private IOpiekunService opiekunService;

        public ParkingiController(IParkingService parkingService, IMiastoService miastoService, IOpiekunService opiekunService)
        {
            this.parkingService = parkingService;
            this.miastoService = miastoService;
            this.opiekunService = opiekunService;
        }


        public async Task<IActionResult> Index()
        {
            var parkingi = await parkingService.GetParkingi();
            //ViewData["Opiekunowie"] = await parkingService.get
            return View(parkingi);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await parkingService.GetParkingiByIdDetails(id);

            if (parking == null)
            {

                return NotFound();

            }

            TempData["ID"] = id;
            return View(parking);
        }


        //public async Task<IActionResult> Create(string Imie, [Bind("Adres,Nazwa,IdMiasta")] Parking parking, Opiekun opiekun)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //parking.Miasto = await miastoService.GetMiastoById(parking.IdMiasta);
        //        opiekun = parking.Opiekunowie.FirstOrDefault(x => x.Imie == Imie); 
        //        parking.Opiekunowie.Add(opiekun);
        //        await parkingService.AddParking(parking);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdMiasta"] = new SelectList(await miastoService.GetMiasta(), "Id", "Nazwa", parking.IdMiasta);
        //    ViewData["Opiekun"] = new SelectList(await opiekunService.GetOpiekunowie(), "Imie", "Nazwisko", opiekun.Id);
        //    return View(parking);
        //}
        public async Task<IActionResult> Create([Bind("Adres,Nazwa,IdMiasta")] Parking parking) //int opiekunId)
        {
            if (ModelState.IsValid)
            {
                //Opiekun opiekun = await opiekunService.GetOpiekunById(opiekunId);
                //ICollection<Opiekun> opiekunowie = new List<Opiekun>();
                // parking.Opiekunowie = opiekunowie;
                //if (opiekun != null)
                // {
                //  parking.Opiekunowie.Add(opiekun);
                await parkingService.AddParking(parking);
                //await parkingService.AddOpiekun(parking.Id, opiekunId);
                return RedirectToAction(nameof(Index));
                //}
            }

            ViewData["IdMiasta"] = new SelectList(await miastoService.GetMiasta(), "Id", "Nazwa", parking.IdMiasta);
            //ViewData["Opiekun"] = new SelectList(await opiekunService.GetOpiekunowie(), "Id", "Nazwisko");
            return View(parking);
        }

        public async Task<IActionResult> DodajOpiekuna(int opiekunId)
        {
            int id = Convert.ToInt32(TempData["ID"]);

            TempData.Keep("ID");

            Parking parking = await parkingService.GetParkingiByIdDetails(id);

            if (ModelState.IsValid && opiekunId > 0)
            {
                await parkingService.AddOpiekun(parking.Id, opiekunId);
                return RedirectToAction(nameof(Details));
            }

            ViewData["Opiekun"] = new SelectList(await opiekunService.GetOpiekunowie(), "Id", "Nazwisko");
            
            return View(parking);
        }

        public async Task<IActionResult> DodajMiejsca(int ilosc)
        {
            int id = Convert.ToInt32(TempData["ID"]);

            TempData.Keep("ID");

            Parking parking = await parkingService.GetParkingiByIdDetails(id);
            ICollection<Miejsce> miejsca = new List<Miejsce>();

            if (ModelState.IsValid && ilosc > 0)
            {
                for (int i = 0; i < ilosc; i++)
                {
                    var miejsce = new Miejsce
                    {
                        ParkingId = id,
                    };

                    miejsca.Add(miejsce);
                }

                parking.Miejsca = miejsca;
                await parkingService.UpdateParking(parking);
                return RedirectToAction(nameof(Index));
            }

            return View(parking);
        }

        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Adres,IdMiasta")] Parking parking)
        {
            if (id != parking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await parkingService.UpdateParking(parking);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMiasta"] = new SelectList(await miastoService.GetMiasta(), "Id", "Nazwa", parking.IdMiasta);
            return View(await parkingService.GetParkingiByIdDetails(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var parking = await parkingService.GetParkingiById(id);

            if (parking != null)
            {
                await parkingService.DeleteParking(parking);
                return RedirectToAction(nameof(Index));
            }

            return View(parking);
        }
    }
}
