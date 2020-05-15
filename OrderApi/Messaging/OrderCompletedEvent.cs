using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace should be same in both order and cart ie Common.Messaging, so that namespace between publisher and subscriber can remain same
namespace Common.Messaging
{
    public class OrderCompletedEvent
    {
        public string BuyerId { get; set; }
        public OrderCompletedEvent(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}