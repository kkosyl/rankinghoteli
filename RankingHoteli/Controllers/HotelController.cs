using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RankingHoteli.Models;
using RankingHoteli.ViewModels;
using System.Data.Entity;

namespace RankingHoteli.Controllers
{
    public class HotelController : Controller
    {
        private HotelsDbContext _dbContext = new HotelsDbContext();

        public ActionResult Index()
        {
            return View(_dbContext.Hotels.ToList());
        }

        [HttpGet]
        public ActionResult AddHotel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHotel(HotelViewModel.AddHotelViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _dbContext.Pictures.LastOrDefault().PictureID + 1;
                string path = @"\Content\Photos\" + model.Photo.FileName + id;
                model.Photo.SaveAs(path);
                _dbContext.Pictures.Add(new Picture { Source = path });
                _dbContext.SaveChanges();
                int picId = _dbContext.Pictures.First(p => p.Source == path).PictureID;
                _dbContext.Hotels.Add(new Hotel { Address = model.Address, Name = model.Name, 
                    Price = model.Price, Descritpion = model.Description, PictureID = picId});
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}