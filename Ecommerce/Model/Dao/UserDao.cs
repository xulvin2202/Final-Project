﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        EcommerceDbContext db = null;
        public UserDao()
        {
            db = new EcommerceDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Image = entity.Image;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        
        public IEnumerable<User> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString) || x.Phone.Contains(searchString) || x.Address.Contains(searchString) || x.Email.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page,pageSize);
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(a => a.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName,string passWord)
        {
            var result = db.Users.SingleOrDefault(a => a.UserName == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password != null && result.Password.Equals( passWord,StringComparison.CurrentCultureIgnoreCase) )

                        return 1;
                    else
                        return -2;
                
                }
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckUserEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
