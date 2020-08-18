using System;

namespace BarDg.Core.Domain.Model
{
    public class Log
    {
        public int IdLog { get; set; }
        public string Descricao { get; set; }
        public string Mensagem { get; set; }
        public string StackTrace { get; set; }
        public string Level { get; set; }
        public DateTime DataLog { get; set; }
        public object Objeto { get; set; }

    }
}
