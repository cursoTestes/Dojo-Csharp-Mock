using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.Vendas
{
    public class CalculoRoyalties
    {
        private Sistema_de_vendas.IRepositorioVendas iRepositorioVendas;
        private CalculoComissao calculoComissao ;
        public CalculoRoyalties(Sistema_de_vendas.IRepositorioVendas iRepositorioVendas, CalculoComissao calculoComissao)
        {
            this.calculoComissao = calculoComissao;
            this.iRepositorioVendas = iRepositorioVendas;
        }
        public Double CalculaRoyalties(int mes, int ano)
        {
            Double royalty = 0.0;
            
            List<double> vendas = iRepositorioVendas.GetVendas(mes, ano);
            
            foreach (var venda in vendas)
            { 
                var valorLiquido = venda - calculoComissao.calculaComissao(venda);
                royalty += valorLiquido * 0.2;
            }
            
            return royalty;
        }
    }
}
