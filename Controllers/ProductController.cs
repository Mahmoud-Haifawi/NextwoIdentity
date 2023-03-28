using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NextwoIdentity.Data;
using NextwoIdentity.Models;
using NextwoIdentity.Models.ViewModel;
using System.Linq;

namespace NextwoIdentity.Controllers
{
    [Authorize]

    public class ProductController : Controller
    {

     
        private NextwoDbContext db;
        private RoleManager<IdentityRole> roleManager;



        public ProductController( NextwoDbContext _db, RoleManager<IdentityRole> _roleManager)
        {
            this.db = _db;
            this.roleManager = _roleManager;
        }
        public IActionResult AllProduct()
        {
            return View(db.Products.Include(x => x.Category));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct() {
            ViewBag.allCateg = new SelectList(db.Categorys, "CategoryId", "CategoryName");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("AllProduct");
            }
            return View(product);
        }


        public ActionResult TopProducts()
        {
           // var topProducts = db.Products.OrderByDescending(p => p.ProductId).Take(10).ToList();
            return View(db.Products.Include(x => x.Category));
        }
        public ActionResult ALLCategory() {

                return View(db.Categorys);

        }
        [Authorize(Roles = "Admin")]

        public ActionResult CreateCategory() {

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task <ActionResult> CreateCategory(Category category)
        {
            

            if (ModelState.IsValid && !db.Categorys.Any(d=>d.CategoryName == category.CategoryName))
            {
                db.Categorys.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("ALLCategory");
                 return View(category);

            }
            else
            {
                TempData["exists"] = "this category already exsits";
                return View(category);

                // @ViewBag.msg;


            }
            
            
        }
        private bool IsCatygoryExsists(string name)
        {
            return db.Categorys.Any(d=>d.CategoryName == name);
        }

        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ALLCategory");
            }
            var data = db.Categorys.Find(id);
            if (data == null)
            {
                return RedirectToAction("ALLCategory");
            }
            return View(data);

        }
        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            var data = db.Categorys.Find(category.CategoryId);
            if (data == null)
            {
                return RedirectToAction("ALLCategory");
            }
            db.Categorys.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ALLCategory");

        }


        public IActionResult DetailsCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ALLCategory");
            }
            var data = db.Categorys.Find(id);
            if (data == null)
            {
                return RedirectToAction("ALLCategory");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ALLCategory");
            }
            var data = db.Categorys.Find(id);
            if (data == null)
            {
                return RedirectToAction("ALLCategory");
            }


            return View(data);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categorys.Update(category);
                db.SaveChanges();
                return RedirectToAction("ALLCategory");
            }
            return View(category);
        }
    }
}



    

