﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EFBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            var context = new Context();
            var value = context.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            value.Status = "Onaylandı";
            context.SaveChanges();

        }

        public void BookingStatusChangeApproved2(int id)
        {
            var context = new Context();
            var value = context.Bookings.Find(id);
            value.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved3(int id)
        {
            var context = new Context();
            var value = context.Bookings.Find(id);
            value.Status = "Onaylandı";
            context.SaveChanges();

        }

        public void BookingStatusChangeCancel(int id)
        {
            var context = new Context();
            var value = context.Bookings.Find(id);
            value.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeWaitl(int id)
        {
            var context = new Context();
            var value = context.Bookings.Find(id);
            value.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            var context = new Context();
            var value = context.Bookings.Count();
            return value;
        }

        public List<Booking> Last6Bookings()
        {
            var context = new Context();
            var value = context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return value;
        }
    }
}
