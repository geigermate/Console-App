using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IOwnerLogic
    {
        void Create(Owner person);
        void Delete(int id);
        Owner Read(int id);
        IQueryable<Owner> ReadAll();
        void Update(Owner person);
    }
}
