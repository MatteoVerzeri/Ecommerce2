using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_ecommerce_basic.model
{
    public class Alimentare : Product
    {
        private string[] ingredieni = new string[10];
        int lung = 0;
        DateTime scadenza;
        DateTime data;
        public string[] ingredienti 
        {
            get 
            {
                return ingredienti;
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] != null)
                    {
                        ingredienti[lung] = value[i];
                        lung++;
                    }
                }
            }
        }
        public string code { get; set; }
        public Alimentare(string id, string name, string prod, string descr, float price, DateTime scadenza, string[] ingredienti) : base(id, name, prod, descr, price)
        {
            this.scadenza = scadenza;
            this.ingredienti = ingredienti;
        }
        public Alimentare(string id, string name, string prod, string descr, DateTime scadenza, string[] ingredienti) : base(id, name, prod, descr)
        {
            this.scadenza= scadenza;
            this.ingredienti = ingredienti;
        }
        public Alimentare(Alimentare prodotto) : base(prodotto)
        {
            ingredienti = null;
            DateTime scadenza = DateTime.Now;
            scadenza.AddDays(14);
        }
        override public Product Clone()
        {
            return new Alimentare(this);
        }
        public override float getPrice()
        {
            if(DateTime.Compare(DateTime.Now, scadenza) < 0)
            {
                throw new Exception("prodotto scaduto, rimuovere questo prodotto dalla lista");
            }
            if(DateTime.Compare(DateTime.Now,scadenza.AddDays(-7))>0|| DateTime.Compare(DateTime.Now, scadenza.AddDays(-7)) == 0)
            {
                return base.getPrice()*50/100;
            }
            else 
            return base.getPrice();
        }

    }
}
