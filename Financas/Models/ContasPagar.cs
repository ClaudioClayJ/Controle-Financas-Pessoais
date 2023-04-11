﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContasPagar
    {
        public int Id { get; set; }
        public double ValorPagar { get; set; }
        public string Descricao { get; set; }
        public string DataEmissao { get; set; }
        public string Contato { get; set; }
        public int IdContato { get; set; }
        public string Banco { get; set; }
        public int IdBanco { get; set; }
        public string FormaPagamento { get; set; }
        public int IdFormaPagamento { get; set; }
    }
}
