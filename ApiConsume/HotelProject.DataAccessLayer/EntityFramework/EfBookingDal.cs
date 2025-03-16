using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        Context context = new Context();
        public EfBookingDal(Context context) : base(context)
        {

        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            var values = context.Bookings.Where(x => x.ID.Equals(booking.ID)).FirstOrDefault();
            values.Status = "Onaylandı.";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved2(int id)
        {
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı.";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved3(int id)
        {
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            var value = context.Bookings.Count();
            return value;
        }

        public List<Booking> LastSixBookings()
        {
            var values = context.Bookings.OrderByDescending(x => x.ID).Take(6).ToList();
            return values;
        }
    }
}
