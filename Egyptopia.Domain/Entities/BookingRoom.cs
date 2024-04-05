//using Egyptopia.Domain.Common;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Egyptopia.Domain.Entities
//{
//    public class BookingRoom:EntityBase
//    {
//        public DateTime CheckInDate { get; set; }
//        public DateTime CheckOutDate { get; set; }
//        public int RoomNumber { get; set; }
//        public double TotalAmount { get; set; }
//        public Guid? RoomId { get; set; }
//        [ForeignKey("RoomId")]
//        public virtual Room Room { get; set; }
//    }
//}
