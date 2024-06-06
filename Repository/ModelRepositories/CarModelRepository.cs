using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelRepositories
{
    public class CarModelRepository : Repository<CarModel>, IRepository<CarModel>
    {
        public CarModelRepository(CarOwnerDbContext ctx) : base(ctx)
        {
        }

        public override CarModel Read(int id)
        {
            return ctx.CarModels.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(CarModel item)
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
