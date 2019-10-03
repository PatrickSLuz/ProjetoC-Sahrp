using ProjetoControleCompras.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Utils
{
    class AbrirTelaVisualizacao
    {
        public static void AbrirTelaVerItens(dynamic d)
        {
            if (d != null)
            {
                frmVerItensPedido telaVerItensPedido = new frmVerItensPedido(d);
                telaVerItensPedido.ShowDialog();
            }
        }

        public static void AbrirTelaVerOrcamentos(dynamic d)
        {
            if (d != null)
            {
                
            }
        }
    }
}
