using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    class ServiceManager : IServiceService
    {
        private readonly IServiceDal _roomDal;

        public void TDelete(Service t)
        {
            _roomDal.Delete(t);
        }

        public Service TGetByID(int id)
        {
            return _roomDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _roomDal.GetList();
        }

        public void TInsert(Service t)
        {
            _roomDal.Insert(t);
        }

        public void TUpdate(Service t)
        {
            _roomDal.Update(t);
        }
    }
}
