using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //OrderId is made primary key using [key] .it is same as using hilo in contextfile. 
        //and Table is automatically generated with [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //with cloumn name as Identity
        public int OrderId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public string BuyerId { get; set; } //uniqueid ie email

        public string UserName { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string Address { get; set; }//where order need to go
        public string PaymentAuthCode { get; set; }
        // public Guid RequestId { get;  set; }
        public decimal OrderTotal { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        protected Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
    public enum OrderStatus
    {
        Preparing = 1,
        Shipped = 2,
        Delivered = 3,
    }
}

