using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RhApi.Context;
using RhApi.Models;
using RhApi.Services;

namespace rh_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase  
    {

        const string dataObrigatoria = "Data de admissão não foi informada.";
        const string dataInvalida = "Data Inválida. Data anterior a fundação da empresa.";
        private readonly RhContext _context;

        public FuncionarioController(RhContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Obter(int id)
        {
            var funcionario = _context.Funcionario.Find(id);

            if (funcionario == null)
                return NotFound();

            return Ok(funcionario);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Funcionario funcionario)
        {
            if (ValidacoesData.DataNaoInformada(funcionario.DataAdmissao))
                return BadRequest(new { Erro = dataObrigatoria } );

            if (ValidacoesData.DataAnteriorFundacaoDaEmpresa(funcionario.DataAdmissao))
                return BadRequest(new { Erro = dataInvalida } );    

            var funcionarioBanco = _context.Funcionario.Find(id);

            if (funcionarioBanco == null)
                return NotFound();

            funcionarioBanco.Nome = funcionario.Nome;
            funcionarioBanco.Endereco = funcionario.Endereco;
            funcionarioBanco.EmailProfissional = funcionario.EmailProfissional;
            funcionarioBanco.Departamento = funcionario.Departamento;
            funcionarioBanco.DataAdmissao = funcionario.DataAdmissao;
            funcionarioBanco.Salario = funcionario.Salario;
            funcionarioBanco.Ranal = funcionario.Ranal;
            funcionarioBanco.Status = funcionario.Status;

            _context.Funcionario.Update(funcionarioBanco);
            _context.SaveChanges();

            return Ok(funcionarioBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var funcionarioBanco = _context.Funcionario.Find(id);

            if (funcionarioBanco == null)
                return NotFound();

            _context.Funcionario.Remove(funcionarioBanco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Criar(Funcionario funcionario)
        {
            if (ValidacoesData.DataNaoInformada(funcionario.DataAdmissao))
                 return BadRequest(new { Error = dataObrigatoria });

            if (ValidacoesData.DataAnteriorFundacaoDaEmpresa(funcionario.DataAdmissao))
                return BadRequest(new { Erro = dataInvalida } );         

            _context.Funcionario.Add(funcionario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Obter), new { Id = funcionario.Id }, funcionario);
        }
    }
}