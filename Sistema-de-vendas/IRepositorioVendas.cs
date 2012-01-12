using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema_de_vendas
{
    public interface IRepositorioVendas
    {
        List<double> GetVendas(int mes, int ano);
    }
}
