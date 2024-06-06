using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CarModelLogic : ICarModelLogic
    {
        IRepository<CarModel> repository;
        public CarModelLogic(IRepository<CarModel> repository)
        {
                this.repository = repository;
        }

        public void Create(CarModel item)
        {
            if (item.Name == null || item.Name.Length <= 2 || item.Name == "")
            {
                throw new ArgumentException("Szar a név!!!!!!!");
            }
            else
            {
                this.repository.Create(item);
            }
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public CarModel Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CarModel> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(CarModel item)
        {
            throw new NotImplementedException();
        }
    }
}
