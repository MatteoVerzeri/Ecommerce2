using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_ecommerce_basic.model
{
    public class Elettronico : Product
    {
        public string code { get; set; }
        public Elettronico(string id, string name, string prod, string descr, float price, string code) : base(id, name, prod, descr, price)
        {
            this.code = code;
        }
        public Elettronico(string id, string name, string prod, string descr, string code) : base(id, name, prod, descr)
        {
            this.code=code;
        }
        public Elettronico(Elettronico prodotto) : base(prodotto)
        {
            code = "";
        }

        public Elettronico(string id) : base(id)
        {
        }

        override public Product Clone()
        {
            return new Elettronico(this);
        }
    }
}
