using DevPals_TestWork.Context;
using DevPals_TestWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DevPals_TestWork.Services
{
    public class CustomerService
    {
        private ApplicationContext db;
        public CustomerService(ApplicationContext db)
        {
            this.db = db;
        }
        public static string MD5Hash(string Pin)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Pin));
            byte[] result = md5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            return stringBuilder.ToString(); ;
        }

        public bool Login(string UserName, string Pin)
        {
            return db.Customer.Any(prop => prop.UserName == UserName && prop.Pin == CustomerService.MD5Hash(Pin));
        }

        public int GetBalance(string UserName)
        {
            CustomerModel customerModel = db.Customer.FirstOrDefault(name => name.UserName == UserName);
            return customerModel.Balance;
        }

        public void BalanceUpdate(int WithdrawnCash, string UserName)
        {
            CustomerModel customerModel = db.Customer.FirstOrDefault(name => name.UserName == UserName);
            customerModel.Balance = customerModel.Balance - WithdrawnCash;
            db.SaveChanges();
        }
    }
}
