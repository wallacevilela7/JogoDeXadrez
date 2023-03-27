using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }


        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {

            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca PecaCapturada = tab.RetirarPeca(destino);
            tab.ColorcarPeca(p, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(JogadorAtual != tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if (!tab.Peca(pos).ExistemMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }

        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        private void MudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        private void ColocarPecas()
        {
            tab.ColorcarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 1).ToPosicao());
            tab.ColorcarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('d', 2).ToPosicao());
            tab.ColorcarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 2).ToPosicao());
            tab.ColorcarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 1).ToPosicao());
            tab.ColorcarPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('d', 1).ToPosicao());

            tab.ColorcarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 7).ToPosicao());
            tab.ColorcarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 8).ToPosicao());
            tab.ColorcarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('d', 7).ToPosicao());
            tab.ColorcarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 7).ToPosicao());
            tab.ColorcarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 8).ToPosicao());
            tab.ColorcarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('a', 7).ToPosicao());
        }
    }
}
