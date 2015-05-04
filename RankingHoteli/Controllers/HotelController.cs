using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RankingHoteli.Models;
using RankingHoteli.ViewModels;
using System.Data.Entity;
using System.IO;

namespace RankingHoteli.Controllers
{
    public class HotelController : Controller
    {
        private HotelsDbContext _dbContext = new HotelsDbContext();

        public ActionResult Index()
        {
            IList<HotelListViewModel> model = new List<HotelListViewModel>();

            foreach (var item in _dbContext.Hotels)
            {
                string photoPath = _dbContext.Pictures.First(p =>p.HotelID == item.HotelID).Source;
                model.Add(new HotelListViewModel
                {
                    Name = item.Name,
                    Address = item.Address,
                    Price = item.Price,
                    Description = item.Descritpion,
                    Picture = photoPath
                });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddHotel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHotel(AddHotelViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Hotels.Add(new Hotel
                    {
                        Address = model.Address,
                        Name = model.Name,
                        Price = model.Price,
                        Descritpion = model.Description,
                    });
                    _dbContext.SaveChanges();

                    int id = 1;
                    if (_dbContext.Pictures.Max(s => (int?)s.PictureID) != null)
                        id = _dbContext.Pictures.Max(s => s.PictureID) + 1;

                    int hotelId = _dbContext.Hotels.First(h => h.Name == model.Name).HotelID;

                    string filePath = Path.GetFileNameWithoutExtension(model.Picture.FileName) +
                                               id + Path.GetExtension(model.Picture.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Photos/"), filePath);
                    model.Picture.SaveAs(path);

                    _dbContext.Pictures.Add(new Picture { Source = filePath, HotelID = hotelId });
                    _dbContext.SaveChanges();
                    int picId = _dbContext.Pictures.First(p => p.Source == filePath).PictureID;

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return View();
        }
    }
}