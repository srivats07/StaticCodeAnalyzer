using ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProductBusinessLayer<T>
    {
        List<T> getAll();
        bool Add(T Products);
        bool Delete(int id);
        bool Update(T updatedItem);

    }
    public class BusinessLayer : IProductBusinessLayer<Products>
    {
        public bool Add(Products Products)
        {
            
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Products> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Products updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
