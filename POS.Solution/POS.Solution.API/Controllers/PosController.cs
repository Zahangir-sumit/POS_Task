using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Solution.Application.IService;
using POS.Solution.Core.Entities;

namespace POS.Solution.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PosController : ControllerBase
    {
        private readonly IPosService _posService;
        private readonly ILogger<PosController> _logger;

        public PosController(IPosService posService, ILogger<PosController> logger)
        {
            _posService = posService;
            _logger = logger;
        }

        [Route("GetInvoice/{Id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetInvoice(Guid Id)
        {
            var Invoice = await _posService.GetInvoice(Id);

            return Ok(Invoice);
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Invoices = await _posService.GetAll();

            return Ok(Invoices);
        }

        [Route("GetProducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _posService.GetProducts();

            return Ok(products);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _posService.Add(invoice);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            return Ok(invoice);
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _posService.Update(invoice);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            return Ok(invoice);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            try
            {
               await _posService.Delete(id);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, ex.Message);
            }

            return Ok();
        }
    }
}
