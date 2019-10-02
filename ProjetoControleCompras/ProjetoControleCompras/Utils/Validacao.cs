using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Utils
{
    class Validacao
    {
        public static bool ValidarCPF_CNPJ(string cpf_cnpj)
        {
            cpf_cnpj.Replace(".", "").Replace("-","");

            if (cpf_cnpj.Length == 11)
            {
                if (ValidarCPF(cpf_cnpj))
                    return true;
            }
            else if (cpf_cnpj.Length == 14)
            {
                if (ValidarCNPJ(cpf_cnpj))
                    return true;
            }
            return false;
        }

        private static bool ValidarCPF(string cpf)
        {
            int Soma, Resto;

            if (cpf.Length == 11 && !(cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333"
                || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888"
                || cpf == "99999999999"))
            {

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
                        return true;
                    }
                }
            }
            return false;
        }
    
        private static bool ValidarCNPJ(string cnpj)
        {
            int Soma, Resto;

            if (!(cnpj == "00000000000000" || cnpj == "11111111111111" || cnpj == "22222222222222" || cnpj == "33333333333333"
                || cnpj == "44444444444444" || cnpj == "55555555555555" || cnpj == "66666666666666" || cnpj == "77777777777777"
                || cnpj == "88888888888888" || cnpj == "99999999999999"))
            {

                Soma = 0;
                Resto = 0;

                // ROUND 1
                Soma = CalculoSoma(cnpj, 5, 12);

                Resto = CalculoResto(Soma);

                if (Resto == Convert.ToInt32(cnpj[12].ToString())) // Verificacao do Primeiro Digito Verificador do CPF.
                {
                    Soma = 0;
                    Resto = 0;

                    // ROUND 2
                    Soma = CalculoSoma(cnpj, 6, 13);

                    Resto = CalculoResto(Soma);

                    if (Resto == Convert.ToInt32(cnpj[13].ToString())) // Verificacao do Segundo Digito Verificador do CPF.
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int CalculoResto(int soma)
        {
            int Resto = soma % 11;
            Resto = 11 - Resto;

            if (Resto >= 10)
            {
                Resto = 0;
            }
            return Resto;
        }

        public static int CalculoSoma(string cpf, int peso, int cont)
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
