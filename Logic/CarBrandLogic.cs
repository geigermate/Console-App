using Models;
using Repository;

namespace Logic
{
    public class CarBrandLogic : ICarBrandLogic
    {
        IRepository<CarBrand> repository;

        public CarBrandLogic(IRepository<CarBrand> repository)
        {
            this.repository = repository;
        }

        public void Create(CarBrand item)
        {
            if (item.Name == null)
            {
                throw new ArgumentException("Brand name too short!");
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

        public CarBrand Read(int id)
        {
            return this.repository.Read(id) ?? throw new ArgumentException("Brand with the specified id doesn't exist");
        }

        public IQueryable<CarBrand> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(CarBrand item)
        {
            this.repository.Update(item);
        }

        //NON-CRUD

        public IEnumerable<KeyValuePair<string, int>> BrandWithTheMostModels()
        {
            //CarBrand brand = this.repository.ReadAll().Count(b => b.CarModels.Count());
            var q = from x in this.repository.ReadAll()
                             orderby x.CarModels.Count() descending
                             select new KeyValuePair<string, int>(x.Name, x.CarModels.Count());
            return q.Take(1);
            //return brand.Name;
        }

        public IEnumerable<KeyValuePair<string, int>> BrandWithTheLeastModels()
        {
            var q = from x in this.repository.ReadAll()
                    orderby x.CarModels.Count() ascending //növekvő sorrend
                    select new KeyValuePair<string, int>(x.Name, x.CarModels.Count());
            return q.Take(1);
        }
    }
}
