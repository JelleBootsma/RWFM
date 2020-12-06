using JsonFlatFileDataStore;
using RWFM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RWFM.Repositories{

    public class UserRepository{
        #region Constuction
        private static UserRepository instance;
        private string jsonstring;
        private string path;
        private List<User> collection;
        private UserRepository(){
            path = AppDomain.CurrentDomain.BaseDirectory + "accounts.json";
            jsonstring = File.ReadAllText(path);
            collection = JsonConvert.DeserializeObject<List<User>>(jsonstring);
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
            var user = collection.AsQueryable().FirstOrDefault( e => e.Username == username);
            return user;
        }

        public async Task<bool> AddUser(User user){
            if (GetUserByUsername(user.Username) == null){
                collection.Add(user);
                await SaveToFile();
                return true;
            }
            return false;
        }

        private async Task<bool> SaveToFile()
        {
            jsonstring = JsonConvert.SerializeObject(collection, Formatting.Indented);
            await File.WriteAllTextAsync(path, jsonstring);
            return true;
        }
        
        

    }
}