using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SebraeWebApi.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static SebraeWebApi.AspnetCore_EFCoreInMemory;

namespace SebraeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContaController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var conta = await _context.Contas
                                 .ToArrayAsync();

            var resposta = conta.Select(u => new Conta
            {
                ContaId = u.ContaId,
                Nome = u.Nome,
                Descricao = u.Descricao

            });

            return Ok(resposta);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int contaId)
        {
            try
            {
                var retorno = await _context.Contas.FindAsync(contaId);

                if (retorno == null)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Conta Indisponível.");
                }

                _context.Remove(retorno);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPost("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Conta conta)
        {
            try
            {
                var retorno = await _context.Contas.Where(s => s.ContaId == conta.ContaId).ToListAsync();

                if (retorno.Count() > 0)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Conta Indisponível.");
                }


                _context.Add(conta);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("Updates")]
        public async Task<IActionResult> Update([FromBody] Conta conta)
        {
            try
            {
                var retorno = await _context.Contas.FindAsync(conta.ContaId);


                if (retorno == null)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Conta Indisponível.");
                }
                _context.Update(retorno);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }
    }
}
