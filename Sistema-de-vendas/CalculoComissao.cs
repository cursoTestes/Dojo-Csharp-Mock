using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.Vendas
{
    public class CalculoComissao
    {
        public virtual Double calculaComissao(Double p)
        {
            var comissao = 0.0;
            if (p >= 0 && p < 10000)
            {
                comissao = p * 0.05;
            }
            else
            {
                comissao = p * 0.06;
            }

            return Math.Floor(comissao * 100)/ 100;
        }
    }
}
