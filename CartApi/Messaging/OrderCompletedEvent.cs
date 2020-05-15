using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace is common.Messaging so that it can be same in cartapi as well as orderapi
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