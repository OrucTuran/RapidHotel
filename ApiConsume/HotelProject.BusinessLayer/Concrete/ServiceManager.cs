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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TDelete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public Service TGetByID(int id)
        {
            return _serviceDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _serviceDal.GetList();
        }

        public void TInsert(Service t)
        {
            _serviceDal.Insert(t);
        }

        public void TUpdate(Service t)
        {
            _serviceDal.Update(t);
        }
    }
}
