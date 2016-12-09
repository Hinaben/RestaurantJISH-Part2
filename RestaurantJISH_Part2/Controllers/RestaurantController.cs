using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using RestaurantJISH_Part2.Models;
using PagedList;
using PagedList.Mvc;

namespace RestaurantJISH_Part2.Controllers
{
    public class RestaurantController : Controller
    {
        RestaurantEntities db = new RestaurantEntities();

        public ActionResult Details()
        {
            var foodItem = new menus { foodName = "Rice ", price = 5.0, briefDescription = "rice", foodId = 1 };
            return View(foodItem);
        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult List(string searchby)
        {

            if (searchby == null || searchby == string.Empty)
            {
                return View(db.Restaurants.ToList());
            }

            else
            {

                return View(db.Restaurants.Where(x => x.Name.Contains(searchby.ToLower()) || x.Type.Contains(searchby.ToLower()) || x.Area.Contains(searchby.ToLower()) || x.Description.Contains(searchby.ToLower()) || x.City.Contains(searchby.ToLower())).ToList());
            }
        }
        public ActionResult Menu(int id, int? page)
        {
            //create object of menulist
            menuDetailmodel mymodel = new menuDetailmodel();

            //add property of restaurant name to object
            string restaurantName = (db.Restaurants.Where(x => x.RestaurantId.Equals(id)).FirstOrDefault().Name);
            mymodel.restuarantName = restaurantName;
            //add property of 2 joined table list to object

            var list = db.Categories.Join(db.FoodItems, c => c.CategoryId, m => m.CategoryId, (c, m) => new joinModel { foodCategory = c, foodItem = m }).Where(c => c.foodCategory.RestaurantId.Equals(id));

            mymodel.detailMenu = list.ToList().ToPagedList(page ?? 1, 12);
            //add category list to navbar property of this object
            var categoryList = db.Categories.Where(x => x.RestaurantId.Equals(id)).ToList();
            mymodel.navBarList = categoryList;
            Restaurants restaurantsInfo = db.Restaurants.Where(x => x.RestaurantId.Equals(id)).FirstOrDefault();
            mymodel.restuarantInformation = restaurantsInfo;
            //pass this object to the model    
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PagedMenuList", mymodel);
            }
            else
            {
                return View(mymodel);
            }


        }


        public PartialViewResult detailOfeachCategory(int restaurantId, int categoryId, int? page)
        {
            //create object of menulist
            menuDetailmodel mymodel = new menuDetailmodel();

            //add property of restaurant name to object
            string restaurantName = (db.Restaurants.Where(x => x.RestaurantId.Equals(restaurantId)).FirstOrDefault().Name);
            mymodel.restuarantName = restaurantName;
            //add property of 2 joined table list to object
            var list = db.Categories.Join(db.FoodItems, c => c.CategoryId, m => m.CategoryId, (c, m) => new joinModel { foodCategory = c, foodItem = m }).Where(c => c.foodCategory.RestaurantId.Equals(restaurantId) && c.foodCategory.CategoryId.Equals(categoryId));
            mymodel.detailMenu = list.ToList().ToPagedList(page ?? 1, 12);
            return PartialView("_productsForeachcategory", mymodel);
        }
    }
}
