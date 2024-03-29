﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_V2_2
{
    class Pedido : IDado
    {
        public int Cod_Pedido { get; set; }
        public int Qtd_Produtos { get; set; }
        public Pedido(int Cod_Pedido, int Qtd_Produtos)
        {
            this.Cod_Pedido = Cod_Pedido;
            this.Qtd_Produtos = Qtd_Produtos;
        }
        public override string ToString()
        {
            return "Pedido: " + Cod_Pedido + " Qtd_Produtos: " + Qtd_Produtos;
        }
        public int CompareTo(object obj)
        {
            Pedido aux = (Pedido)(obj);

            if (Cod_Pedido < aux.Cod_Pedido)
                return -1;
            else if (Cod_Pedido > aux.Cod_Pedido)
                return 1;
            else
                return 0;
        }
        public void Inserir(IDado val) { }
    }
}
