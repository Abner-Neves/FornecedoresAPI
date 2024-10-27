using Fornecedores.Domain.DTOs;
using Fornecedores.Domain.Interfaces.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Fornecedores.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplication _fornecedorApplication;

        public FornecedorController(IFornecedorApplication fornecedorApplication)
        {
            _fornecedorApplication = fornecedorApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetFornecedores()
        {
            try
            {
                var fornecedores = await _fornecedorApplication.GetFornecedores();
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFornecedorById(int id)
        {
            try
            {
                var fornecedor = await _fornecedorApplication.GetFornecedorById(id);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFornecedor(int id, [FromBody] UpdateFornecedorDto fornecedor)
        {
            try
            {
                var result = await _fornecedorApplication.UpdateFornecedor(id, fornecedor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertFornecedor([FromBody] InsertFornecedorDto fornecedor)
        {
            try
            {
                var fornecedores = await _fornecedorApplication.InsertFornecedor(fornecedor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            try
            {
                await _fornecedorApplication.DeleteFornecedor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

}
