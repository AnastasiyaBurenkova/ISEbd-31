using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBudget.Models;

namespace WeBudget.Service.Interface
{
   public interface IUslugi
    {
        void Delete(int id);

        void Edit(Uslugi Uslugi);

        void Create(Uslugi Uslugi);

        Uslugi findUslugiById(int? id);

        List<Uslugi> getList();

        void Dispose();

    }
}
