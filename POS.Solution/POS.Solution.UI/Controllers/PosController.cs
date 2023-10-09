using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Solution.Core.Entities;
using POS.Solution.UI.Models;
using System.Diagnostics;

namespace POS.Solution.UI.Controllers
{
    public class PosController : Controller
    {
        private readonly ILogger<PosController> _logger;

        private readonly IHttpClientFactory _httpClientFactory;
        protected readonly HttpClient _client;

        public PosController(IHttpClientFactory httpClientFactory, ILogger<PosController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient("Pos");
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            var response = await _client.GetAsync("Pos/GetAll/");

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var model = JsonConvert.DeserializeObject<List<Invoice>>(data);

                return View(model);
            }

            return View();
        }

        public async Task<IActionResult> Details(Guid Id)
        {

            var response = await _client.GetAsync("Pos/GetInvoice/" + Id.ToString());

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var model = JsonConvert.DeserializeObject<Invoice>(data);

                return View(model);
            }

            return View();
        }

        public IActionResult Create()
        {

            //var response = await _client.GetAsync("Pos/GetProducts/");

            //if (response.IsSuccessStatusCode)
            //{
            //    var data = response.Content.ReadAsStringAsync().Result;

            //    var products = JsonConvert.DeserializeObject<Product>(data);

            //    ViewBag.Products = products;
            //}


           

            ViewBag.Products = productList;

            var model = new Invoice
            {
                InvoiceDetails = new List<InvoiceDetails>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Invoice model, string InvoiceDetailsJson)
        {
            try
            {

                model.InvoiceDetails = JsonConvert.DeserializeObject<List<InvoiceDetails>>(InvoiceDetailsJson);


                var response = await _client.PostAsJsonAsync("Pos/Create", model);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Create");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var response = _client.GetAsync("Pos/GetGetInvoice/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    var modelJson = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<Invoice>(modelJson);
                    return View(model);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Invoice model)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Pos/Update", model);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var response = await _client.DeleteAsync("Department/" + Id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("Error");
            }
        }

        [HttpGet("GetPrice")]
        public async Task<IActionResult> GetPrice(string productName)
        {
            var product = productList.Where(x => x.ProductName == productName).FirstOrDefault();

            return Json(product.Price);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        List<Product> productList = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Product1",
                Price = 200
            },
            new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Product2",
                Price = 300
            },
            new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Product3",
                Price = 400
            }
        };
    }
}