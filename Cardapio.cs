using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Lanchonete
{
    class Cardapio
    {
        public string NomeProduto { get; set; }
        public double PrecoProduto { get; set; }

        public int ID { get; set; }

        public void SomandoItens(int quantidade)
        {
            PrecoProduto *= quantidade;
        }
    }
}