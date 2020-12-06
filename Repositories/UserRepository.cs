using JsonFlatFileDataStore;
using RWFM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RWFM.Repositories{

    public class UserRepository{
        #region Constuction
        private static UserRepository instance;
        private DataStore data;
        private IDocumentCollection<User> collection;
        private UserRepository(){
            data = new DataStore("accounts.json");
        }

        public static UserRepository GetInstance(){
            if (instance != null){
                return instance;
            }
            else{
                instance = new UserRepository();
                return instance;
            }
        }
        #endregion Constuction


        public User GetUserByUsername(string username){
            collection = data.GetCollection<User>();
            var user = collection.AsQueryable().First( e => e.Username == username);
            return user;
        }

        public async Task<bool> AddUser(User user){
            collection = data.GetCollection<User>();
            if (GetUserByUsername(user.Username) == null){
                await collection.InsertOneAsync(user);
                return true;
            }
            return false;
        }





    }
}