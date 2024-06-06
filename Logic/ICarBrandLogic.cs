using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICarBrandLogic
    {
        void Create(CarBrand item);
        void Delete(int id);
        CarBrand Read(int id);
        IQueryable<CarBrand> ReadAll();
        void Update(CarBrand item);
    }
}
