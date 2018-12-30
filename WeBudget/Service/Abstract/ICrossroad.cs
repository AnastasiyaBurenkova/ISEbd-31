using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCrossroad.Service.Abstract
{
     public interface ICrossroad
    {
        void Delete(int id);
        void Edit(BaseEntity baseEntity);
        void Create(BaseEntity baseEntity);
        BaseEntity findById(int? id);
        List<BaseEntity> getList();
    }
}
