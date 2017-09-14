using EntitieServices.EntitiProductShop;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductShop.Mapping
{
    public static class PaymentMapper
    {
        public static Payment To_Payment_Create_ViewModel(this PaymentViewModel payment)
        {
            Payment PaymentVM = new Payment()
            {
                PaymentID = payment.PaymentID,
                CustomerAddress = payment.CustomerAddress,
                City = payment.City,
                Country = payment.Country,
                CustomerState = payment.CustomerState,
                Email = payment.Email,
                FirstNAme = payment.FirstNAme,
                LastNAme = payment.LastNAme,
                OrderDate = payment.OrderDate,
                Phone = payment.Phone,
                PostalCode = payment.PostalCode,
                Total = payment.Total,
                UserName = payment.UserName,
            };
            return PaymentVM;
        }
    }
}