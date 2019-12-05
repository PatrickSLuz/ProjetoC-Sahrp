using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/Empresa")]
    [ApiController]
    public class EmpresaAPIController : ControllerBase
    {
        private readonly OrcamentoDAO _orcamentoDAO;

        public EmpresaAPIController(OrcamentoDAO orcamentoDAO)
        {
            _orcamentoDAO = orcamentoDAO;
        }

        // GET: api/Empresa/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<dynamic> listaEmpresas = new List<dynamic>();
            dynamic empresa;
            foreach (var item in _orcamentoDAO.ListarTodos().ToList())
            {
                if (listaEmpresas.Count > 0)
                {
                    if (!VerificaCNPJnaLista(item.Cnpj, listaEmpresas))
                    {
                        empresa = new
                        {
                            Nome = item.Nome,
                            Cnpj = item.Cnpj,
                            Email = item.Email,
                            Cep = item.Cep
                        };
                        listaEmpresas.Add(empresa);
                    }
                }
                else
                {
                    empresa = new
                    {
                        Nome = item.Nome,
                        Cnpj = item.Cnpj,
                        Email = item.Email,
                        Cep = item.Cep
                    };
                    listaEmpresas.Add(empresa);
                }
            }

            return Ok(listaEmpresas);
        }

        private bool VerificaCNPJnaLista(string cnpj, List<dynamic> lista)
        {
            foreach (var item in lista)
            {
                if (cnpj.Equals(item.Cnpj))
                {
                    return true; // ja existe o CNPJ nesta Lista
                }
            }

            return false; // NAO existe o CNPJ nesta Lista
        }
    }
}