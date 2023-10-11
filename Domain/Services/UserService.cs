using Domain.Contract;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        public List<User> Users;

        public UserService() { 
            Users = new List<User>();
        }

        public UserService(List<User> users)
        {
            Users = users;
        }

        private int GetLastId()
        {
            return (Users.LastOrDefault()?.Id ?? 0) + 1;
        }

        public int Create(User entity)
        {
            if (entity == null ||
                string.IsNullOrWhiteSpace(entity.Email)) return 0;
            if(!Users.Any(x =>  x.Email == entity.Email))
            {
                entity.Id = GetLastId();
                entity.Create();
                Users.Add(entity);
                return entity.Id;
            }
            return 0;
        }

        public bool Delete(int id)
        {
           if (id == 0 || Users.Count == 0) return false;
           var user = Users.FirstOrDefault(x => x.Id == id);
           if (user == null) return false;
           return Users.Remove(user);
            
            var index = Users.FindIndex(x => x.Id == id);
            if (index == -1) return false;
            Users.RemoveAt(index);
            return true;

            var usr = Get(id);
            if (usr == null) return false;
            return Users.Remove(usr);
        }

        public User? Get(int id)
        {
            if (id == 0 || Users.Count == 0) return null;
            var user = Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public List<User> GetAll(string key = "", string opera = "=", string value = "")
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, User entity)
        {
            if(id  == 0||entity == null) return false;
            if(entity.Email == null) return false;
            var index = Users.FindIndex(x => x.Id == id);
            if(index == -1) return false;
            Users[index].UserName = entity.UserName;
            Users[index].UserName = entity.UserName;
            Users[index].Password = entity.Password;
            Users[index].Active = entity.Active;
            Users[index].Update();
            return true;
        }
    }
}
