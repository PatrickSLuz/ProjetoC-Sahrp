using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    class Status
    {
        public static string GetStatus(int index)
        {
            string status = null;
            switch (index)
            {
                case 0:
                    status = "Aguardando Validação do Gestor";
                    break;
                case 1:
                    status = "Aguardando Cadastro de Orçamentos";
                    break;
                case 2:
                    status = "Aguardando Compra do Pedido";
                    break;
                case 3:
                    status = "Pedido Cancelado";
                    break;
                case 4:
                    status = "Pedido Finalizado";
                    break;
            }
            return status;
        }
    }
}
