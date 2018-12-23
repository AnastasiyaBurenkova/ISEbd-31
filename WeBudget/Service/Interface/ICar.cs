using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBudget.Models;

namespace WeBudget.Service.Interface
{
    interface ICar
    {
        void Delete(int id);

        void Edit(Car Car);

        void Create(Car Car);

        Car findCarById(int? id);

        List<Car> getList();

        void Dispose();
    }
}
