using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelRepositories
{
    public class CarBrandRepository : Repository<CarBrand>, IRepository<CarBrand>
    {
        public CarBrandRepository(CarOwnerDbContext ctx) : base(ctx)
        {
        }

        public override CarBrand Read(int id)
        {
            return ctx.CarBrands.FirstOrDefault(b => b.Id == id);
        }

        public override void Update(CarBrand item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
