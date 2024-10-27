using Fornecedores.Domain.DTOs;
using Fornecedores.Domain.Interfaces.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Fornecedores.API.Controllers
{
    [ApiController]
    [Route("api/fornecedores")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplication _fornecedorApplication;

        public FornecedorController(IFornecedorApplication fornecedorApplication)
        {
            _fornecedorApplication = fornecedorApplication;
        }

        /// <summary>
        /// Busca por todos os fornecedores cadastrados.
        /// </summary>
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

        /// <summary>
        /// Busca pelo fornecedor com o id informado.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor.</param>
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

        /// <summary>
        /// Atualiza os dados do fornecedor que possui o id informado.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor.</param>
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

        /// <summary>
        /// Insere um novo fornecedor com os dados informados.
        /// </summary>
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

        /// <summary>
        /// Deleta o fornecedor com o id informado.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor.</param>
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
