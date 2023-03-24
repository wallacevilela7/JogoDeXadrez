using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        //SOU O REI 
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "R ";
        }
    }
}
