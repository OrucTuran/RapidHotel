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
   public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategoryDal;

        public MessageCategoryManager(IMessageCategoryDal MessageCategoryDal)
        {
            _messageCategoryDal = MessageCategoryDal;
        }

        public void TDelete(MessageCategory t)
        {
            _messageCategoryDal.Delete(t);
        }

        public MessageCategory TGetByID(int id)
        {
            return _messageCategoryDal.GetByID(id);
        }

        public List<MessageCategory> TGetList()
        {
            return _messageCategoryDal.GetList();
        }

        public void TInsert(MessageCategory t)
        {
            _messageCategoryDal.Insert(t);
        }

        public void TUpdate(MessageCategory t)
        {
            _messageCategoryDal.Update(t);
        }
    }
}
