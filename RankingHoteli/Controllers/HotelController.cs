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
                string photoPath = _dbContext.Pictures.First(p => p.HotelID == item.HotelID).Source;
                model.Add(new HotelListViewModel
                {
                    HotelId = item.HotelID,
                    Name = item.Name,
                    Address = item.Address,
                    Price = item.Price,
                    Description = item.Descritpion,
                    Picture = photoPath
                });
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            Hotel hotel = _dbContext.Hotels.Find(id);
            AddOpinionAndShowDetailsViewModel model = new AddOpinionAndShowDetailsViewModel();
            model.Opinion = new AddOpinionViewModel();
            model.Hotel = new HotelDetailsViewModel
            {
                Address = hotel.Address,
                Description = hotel.Descritpion,
                Name = hotel.Name,
                Price = hotel.Price,
                HotelId = id
            };
            model.Hotel.Opinions = new List<KeyValuePair<string, Opinion>>();
            model.Hotel.Picture = new List<string>();

            var picturesPath = _dbContext.Pictures.Where(p => p.HotelID == id).Select(p => p.Source);
            foreach (var item in picturesPath)
                model.Hotel.Picture.Add(item);

            var opinions = _dbContext.Opinions.Where(o => o.HotelID == id).Select(o => o);
            foreach (var item in opinions)
            {
                string user = _dbContext.Users.First(u => u.UserID == item.UserID).Nick;
                model.Hotel.Opinions.Add(new KeyValuePair<string, Opinion>(user, item));
            }
            return View(model);
        }

        public ActionResult AddOpinion(AddOpinionAndShowDetailsViewModel model)
        {
            return View();
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

                    foreach (var item in model.Picture)
                    {
                        string filePath = Path.GetFileNameWithoutExtension(item.FileName) +
                                               id + Path.GetExtension(item.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/Photos/"), filePath);
                        item.SaveAs(path);

                        _dbContext.Pictures.Add(new Picture { Source = filePath, HotelID = hotelId });
                        _dbContext.SaveChanges();
                    }
                    
                    //int picId = _dbContext.Pictures.First(p => p.Source == filePath).PictureID;

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var pictures = _dbContext.Pictures.Where(p => p.HotelID == id).Select(p => p).AsEnumerable();
            foreach (var item in pictures)
            {
                string path = Request.MapPath(@"~/Content/Photos/" + item.Source);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }
            var opinions = _dbContext.Opinions.Where(p => p.HotelID == id).Select(p => p).AsEnumerable();
            _dbContext.Opinions.RemoveRange(opinions);
            _dbContext.Pictures.RemoveRange(pictures);
            _dbContext.Hotels.Remove(_dbContext.Hotels.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}