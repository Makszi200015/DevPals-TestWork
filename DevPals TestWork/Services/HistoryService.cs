using DevPals_TestWork.Context;
using DevPals_TestWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPals_TestWork.Services
{
    public class HistoryService
    {
        private ApplicationContext db;

        public HistoryService(ApplicationContext db) 
        {
            this.db = db;
        }
        public void Add(HistoryModel history) 
        {
            db.History.Add(history);
            db.SaveChanges();
        }
        public IEnumerable<HistoryModel> GetHistory(string userName)  
        {
            IEnumerable<HistoryModel> histories =  db.History.Where(name => name.UsedUserName == userName).ToList();
            return histories;
        } 
    }
}
