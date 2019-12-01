using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoControleComprasWEB.Utils
{
    public class TempPedido
    {
        private static List<ItemPedido> tempItensPedido = new List<ItemPedido>();
        private static Pedido tempPedido = null;

        public static bool AddItem(ItemPedido item)
        {
            foreach (var i in tempItensPedido.ToList())
            {
                if (i.Produtos.NomeProduto.Equals(item.Produtos.NomeProduto))
                {
                    return false;
                }
            }
            tempItensPedido.Add(item);
            tempPedido = new Pedido();
            tempPedido.ItensPedido = tempItensPedido;
            return true;
        }

        public static void RemoveItem(string nomeProduto)
        {
            foreach (var item in tempItensPedido.ToList())
            {
                if (item.Produtos.NomeProduto.Equals(nomeProduto))
                {
                    tempItensPedido.Remove(item);
                }
            }
        }

        public static void MaisQuantidade(string nomeProduto)
        {
            foreach (var i in tempItensPedido.ToList())
            {
                if (i.Produtos.NomeProduto.Equals(nomeProduto))
                {
                    i.Quantidade += 1;
                }
            }
        }

        public static void MenosQuantidade(string nomeProduto)
        {
            foreach (var i in tempItensPedido.ToList())
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

        public static List<ItemPedido> GetListaItens()
        {
            return tempItensPedido;
        }

        public static Pedido GetPedido()
        {
            return tempPedido;
        }
    }
}
