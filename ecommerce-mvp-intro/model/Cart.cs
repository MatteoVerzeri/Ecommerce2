using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_oop_ecommerce_basic.model
{
    //base version by Marco Borelli Nov 2022
    //extended and modified by olprofesur Nov-Dic 2022
    public class Cart
    {
        //attributes
        private float totale = 0;
        private float totale_S = 0;
        private const int MAXCARR = 999;
        private string _id;
        private int currentLenght;
        List<Product> oggetti = new List<Product>();

        //properties
        public List<Product> Oggetti
        {
            get
            {
                return oggetti;
            }
            private set
            {
                oggetti = value;
            }

        }
        public string Id
        {
            get
            {
                return _id;
            }
            private set
            {
                if (value != null)
                    _id = value;
                else
                    throw new Exception("Invalid Id");
            }
        }
        public float getTotale()
        {
            return totale;
        }
        public float getTotale_S()
        {
            return totale_S;
        }

        //constructors
        public Cart(string id)
        {
            this.Id = id;
            oggetti.Clear();
        }


        protected Cart(Cart c) : this(c.Id)
        {
            foreach (Product p in c.Oggetti)
            {
                this.Oggetti.Add(p.Clone());
            }


        }

        public Cart Clone()
        {
            return new Cart(this);

        }
        //metodi specifici
        public void Clear()
        {
            oggetti.Clear();
        }
        public void Add(Product p)
        {
            if (currentLenght == MAXCARR)
            {
                throw new Exception("Unable to add, MAX dimension of internal array reached");
            }

            if (p != null)
            {
                oggetti.Add(p);
                totale = totale + p.Price;
                totale_S = totale_S + p.getScontato();
            }
            else
            {
                throw new Exception("Invalid product");

            }


        }

        private int Lenght()
        {
            if (currentLenght < 100)
                return currentLenght;
            else
                throw new Exception("Cart full");
        }

        public int IndexOf(Product q)
        {
            return oggetti.IndexOf(q);
        }

        public void Modify(Product p)
        {
            int i = IndexOf(p);
            if (i >= 0)
            {
                oggetti[i] = p;
            }
            else
                throw new Exception("Product not found");
        }

        public Product Remove(Product p)
        {
            if (IndexOf(p) != -1)
            {
                oggetti.Remove(p);

                return p;
            }
            else
                throw new Exception("Product not found");
        }




    }
}
