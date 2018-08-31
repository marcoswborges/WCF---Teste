using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Passagens
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cpf { get; set; }
    }
}
