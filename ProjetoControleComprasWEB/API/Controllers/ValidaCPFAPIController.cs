using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/ValidaCPF")]
    [ApiController]
    public class ValidaCPFAPIController : ControllerBase
    {
        // GET: api/ValidaCPF/Validar/11122233344455
        [HttpGet]
        [Route("Validar/{cpf}")]
        public IActionResult Validar(string cpf)
        {
            if (cpf.Where(x => char.IsLetter(x)).Count() == 0) // Verifica se tem letra na string
            {
                if (cpf.Length == 11 && !(cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333"
                    || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888"
                    || cpf == "99999999999"))
                {
                    int Soma, Resto;

                    Soma = 0;
                    Resto = 0;

                    // ROUND 1
                    Soma = CalculoSoma(cpf, 10, 9);

                    Resto = CalculoResto(Soma);

                    if (Resto == Convert.ToInt32(cpf[9].ToString())) // Verificacao do Primeiro Digito Verificador do CPF.
                    {
                        Soma = 0;
                        Resto = 0;

                        // ROUND 2
                        Soma = CalculoSoma(cpf, 11, 10);

                        Resto = CalculoResto(Soma);

                        if (Resto == Convert.ToInt32(cpf[10].ToString())) // Verificacao do Segundo Digito Verificador do CPF.
                        {
                            return Ok(new { cpf_valido = "true" }); // CPF VALIDO
                        }
                    }
                }
            }
            return BadRequest(new { cpf_valido = "false" }); // CPF INVALIDO
        }

        private static int CalculoResto(int soma)
        {
            int Resto = soma % 11;
            Resto = 11 - Resto;

            if (Resto >= 10)
            {
                Resto = 0;
            }
            return Resto;
        }

        private static int CalculoSoma(string cpf, int peso, int cont)
        {
            int Soma = 0;
            for (int i = 0; i < cont; i++)
            {
                //Soma += (cpf[i] - '0') * peso; // - '0' para converte o valor da Tabela ASCII.
                Soma += Convert.ToInt32(cpf[i].ToString()) * peso; // Convertendo o cpf[] em String para poder converter em int.
                peso--;
                if (peso == 1)
                    peso = 9;
            }
            return Soma;
        }
    }
}