﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Estoque_V2_2
{
    class Program
    {
        static Fila Fila_Pedidos;
        static Fila[] Fila_Produtos;
        static Arvore Arvore_de_Produtos;
        static void Main(string[] args)
        {
            Fila_Pedidos = new Fila();
            Fila_Produtos = new Fila[4]; // [0] Bebida, [1] Comida, [2] Escritorio, [3] Utensilios]
            Arvore_de_Produtos = new Arvore();
        }
        static void Ler_Dados_ARQ1()
        {
            string nome_Arquivo = "abc1.txt";
            IDado novo = null;
            bool erro = false;

            if (!File.Exists(nome_Arquivo))
                Console.WriteLine("Arquivo {0} não existe!", nome_Arquivo);
            else
            {
                using (StreamReader entrada = new StreamReader(nome_Arquivo))
                { // codigo_Produto, nome_Produto, categoria, margem_Lucro, preco_Custo, estoque_Incial, minimo_Estoque
                    string[] info = entrada.ReadLine().Split(';');

                    while (!entrada.EndOfStream)
                    {
                        switch (info[2])
                        {
                            case "1":
                                novo = new Bebida(Convert.ToInt32(info[0]), info[1], Convert.ToDouble(info[3]), 
                                    Convert.ToDouble(info[4]), Convert.ToInt32(info[5]), Convert.ToInt32(info[6]));
                                Fila_Produtos[0].Inserir(novo);
                                break;
                            case "2":
                                novo = new Comida(Convert.ToInt32(info[0]), info[1], Convert.ToDouble(info[3]),
                                    Convert.ToDouble(info[4]), Convert.ToInt32(info[5]), Convert.ToInt32(info[6]));
                                Fila_Produtos[1].Inserir(novo);
                                break;
                            case "3":
                                novo = new Material_Escritorio(Convert.ToInt32(info[0]), info[1], Convert.ToDouble(info[3]),
                                    Convert.ToDouble(info[4]), Convert.ToInt32(info[5]), Convert.ToInt32(info[6]));
                                Fila_Produtos[2].Inserir(novo);
                                break;
                            case "4":
                                novo = new Utensilio(Convert.ToInt32(info[0]), info[1], Convert.ToDouble(info[3]),
                                    Convert.ToDouble(info[4]), Convert.ToInt32(info[5]), Convert.ToInt32(info[6]));
                                Fila_Produtos[3].Inserir(novo);
                                break;
                            default: erro = true;
                                break;
                        }

                        if (!erro)
                            Arvore_de_Produtos.Inserir(novo);

                        erro = false;
                    }
                }
            }
        }
        static void Ler_Dados_ARQ2()
        {
            string nome_Arquivo = "abc2.txt";
            IDado novo;

            if (!File.Exists(nome_Arquivo))
                Console.WriteLine("Arquivo {0} não existe!", nome_Arquivo);
            else
            {
                using (StreamReader entrada = new StreamReader(nome_Arquivo))
                { // cod_Pedido; Qtd_Produtos
                    string[] info = entrada.ReadLine().Split(';');

                    while (!entrada.EndOfStream)
                    {
                        novo = new Pedido(Convert.ToInt32(info[0]), Convert.ToInt32(info[1]));
                        Fila_Pedidos.Inserir(novo);
                    }
                }
            }
        }
        static void Ler_Dados_ARQ3()
        {
            string nome_Arquivo = "abc2.txt";
            IDado novo;
            string pedido;

            if (!File.Exists(nome_Arquivo))
                Console.WriteLine("Arquivo {0} não existe!", nome_Arquivo);
            else
            {
                using (StreamReader entrada = new StreamReader(nome_Arquivo))
                { // cod_Pedido; cod_Produto; Qtd_Vendida
                    string[] info = entrada.ReadLine().Split(';');

                    while (!entrada.EndOfStream)
                    {
                        pedido = info[0];

                        while(info[0] == pedido)
                        {
                            novo = new Vendas(Convert.ToInt32(info[0]), Convert.ToInt32(info[1]), Convert.ToInt32(info[2]));
                            Arvore_de_Produtos.Buscar(novo);
                        }
                    }
                }
            }
        }
    }
}