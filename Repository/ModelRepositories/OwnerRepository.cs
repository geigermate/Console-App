using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelRepositories
{
    public class OwnerRepository : Repository<Owner>, IRepository<Owner>
    {
        public OwnerRepository(CarOwnerDbContext ctx) : base(ctx)
        {
        }

        public override Owner Read(int id)
        {
            return ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public override void Update(Owner item)
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
