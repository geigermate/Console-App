using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICarModelLogic
    {
        void Create(CarModel item);
        void Delete(int id);
        CarModel Read(int id);
        IQueryable<CarModel> ReadAll();
        void Update(CarModel item);
    }
}
