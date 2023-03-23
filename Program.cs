using System;
using tabuleiro;
using xadrez;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);


            tab.ColorcarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));
            tab.ColorcarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 3));
            tab.ColorcarPeca(new Rei(Cor.Preta, tab), new Posicao(2, 4));

            Tela.ImprimirTabuleiro(tab);
        }
    }
}