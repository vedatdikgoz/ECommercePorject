﻿using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Entities.Concrete
{
    public class Order:IEntity
    {
        
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumOrderState OrderState { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }


    public enum EnumPaymentType
    {
        CreditCard=0,
        Eft=1,
        PayDoor=2
    }

    public enum EnumOrderState
    {
        Waiting=0,
        Unpaid=1,
        Cargo=2,
        Complated=3
    }
}
