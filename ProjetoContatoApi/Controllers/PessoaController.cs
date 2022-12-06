using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoContato_API.Data;
using ProjetoContato_API.Models;

namespace ProjetoContato_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pessoaController : Controller
    {
        public IRepository _repo { get; }
        public pessoaController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetTodasPessoasAsync();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Conexão com Banco de Dados Falhou");
            }
        }

        [HttpGet("{pessoaId}")]
        public async Task<IActionResult> GetByPessoaId(int pessoaId)
        {
            try
            {
                var result = await _repo.GetPessoaAsyncById(pessoaId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Conexão com Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Pessoa model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/pessoa/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Conexão com Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{pessoaId}")]
        public async Task<IActionResult> put(int pessoaId, Pessoa model)
        {
            try
            {
                var pessoa = await _repo.GetPessoaAsyncById(pessoaId);
                if (pessoa == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    pessoa = await _repo.GetPessoaAsyncById(pessoaId);
                    return Created($"/api/pessoa/{model.Id}", pessoa);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Conexão com Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{pessoaId}")]
        public async Task<IActionResult> delete(int pessoaId)
        {
            try
            {
                var pessoa = await _repo.GetPessoaAsyncById(pessoaId);
                if (pessoa == null) return NotFound();
                
                _repo.Delete(pessoa);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Conexão com Banco de Dados Falhou");
            }
            return BadRequest();
        }
    }
}