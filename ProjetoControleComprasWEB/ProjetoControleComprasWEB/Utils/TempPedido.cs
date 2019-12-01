using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoControleComprasWEB.Utils
{
    public class Pedido_temp
    {
        private static List<ItemPedido> listaItensPedido_temp = new List<ItemPedido>();
        private static Pedido pedido_temp = null;

        public static bool AddItem(ItemPedido item)
        {
            foreach (var i in listaItensPedido_temp.ToList())
            {
                if (i.Produtos.NomeProduto.Equals(item.Produtos.NomeProduto))
                {
                    return false;
                }
            }
            listaItensPedido_temp.Add(item);
            pedido_temp = new Pedido();
            pedido_temp.ItensPedido = listaItensPedido_temp;
            return true;
        }

        public static void RemoveItem(string nomeProduto)
        {
            foreach (var item in listaItensPedido_temp.ToList())
            {
                if (item.Produtos.NomeProduto.Equals(nomeProduto))
                {
                    listaItensPedido_temp.Remove(item);
                }
            }
        }

        public static void MaisQuantidade(string nomeProduto)
        {
            foreach (var i in listaItensPedido_temp.ToList())
            {
                if (i.Produtos.NomeProduto.Equals(nomeProduto))
                {
                    i.Quantidade += 1;
                }
            }
        }

        public static void MenosQuantidade(string nomeProduto)
        {
            foreach (var i in listaItensPedido_temp.ToList())
            {
                if (i.Produtos.NomeProduto.Equals(nomeProduto))
                {
                    if (i.Quantidade > 1)
                    {
                        i.Quantidade -= 1;
                    }
                }
            }
        }

        public static void ClearData()
        {
            listaItensPedido_temp = new List<ItemPedido>();
            pedido_temp = null;
        }

        public static List<ItemPedido> GetListaItens()
        {
            return listaItensPedido_temp;
        }

        public static Pedido GetPedido()
        {
            return pedido_temp;
        }
    }
}
