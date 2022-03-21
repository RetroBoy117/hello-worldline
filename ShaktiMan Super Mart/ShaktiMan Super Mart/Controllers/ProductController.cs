using Microsoft.AspNetCore.Mvc;
using ShaktiMan_Super_Mart.Services.SuperMart_Info;
using ShaktiMan_Super_Mart.Models;
namespace ShaktiMan_Super_Mart.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISuperMartService _superMartService;
        public ProductController(ISuperMartService supermartservice) 
        {
            _superMartService = supermartservice;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _superMartService.GetAllProductsAsync();

            return View(product);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product) 
        {

            if (!ModelState.IsValid) 
                return View(); 

           await _superMartService.InsertAsync(product);

            TempData["success-msg"] = "Product inserted successfully";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id) 
        {
            var products = await _superMartService.Find(id);

            if (products == null)
                return NotFound();

            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
           
            if (!ModelState.IsValid)
                return View();

            await _superMartService.UpdateAsync(product);

            TempData["success-msg"] = "Student has been successfully updated!!";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _superMartService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string name) 
        {
            if (!ModelState.IsValid)
                return View();

            var products = await _superMartService.FindByName(name);

            TempData["success-msg"] = $"Product Id: {products.Id} Name: {products.Name} Price:{products.Price}";

            return RedirectToAction("Search");
        }
    }
}
