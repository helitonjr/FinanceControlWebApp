using System;

using HJR.FinanceControl.WebApp.Helpers.Enums;

namespace HJR.FinanceControl.WebApp.Models
{
    public abstract class Conta
    {
        public int      Id                 { get; set; }
        public int      Documento          { get; set; }
        public string   DescricaoDocumento { get; set; }
        public DateTime DataVencimento     { get; set; }
        public float    ValorTotal         { get; set; }
        public Situacao Situacao           { get; set; }
    }
}