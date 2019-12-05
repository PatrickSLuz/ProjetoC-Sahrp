using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/Agente")]
    [ApiController]
    public class AgenteAPIController : ControllerBase
    {
        private readonly AgenteDAO _agenteDAO;

        public AgenteAPIController(AgenteDAO agenteDAO)
        {
            _agenteDAO = agenteDAO;
        }

        // GET: api/Agente/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<dynamic> listaAgentes = new List<dynamic>();
            dynamic agente;
            foreach (var item in _agenteDAO.ListarTodos())
            {
                agente = new
                {
                    Nome = item.NomeAgente,
                    Cpf = item.Cpf,
                    Cargo = item.Cargo.NomeCargo,
                    Setor = item.Setor.NomeSetor,
                    Email = item.Email,
                    DataCadastro = item.DtCriacao
                };

                listaAgentes.Add(agente);
            }
            return Ok(listaAgentes);
        }
    }
}