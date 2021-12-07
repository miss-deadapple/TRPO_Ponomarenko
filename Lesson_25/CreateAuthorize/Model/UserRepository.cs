using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CreateAuthorize.View;

namespace CreateAuthorize.Model
{
    public class UserRepository
    {
        private DBContainer _dbContainer = new DBContainer();

        public bool SignIn(string login, string password)
        {
                return _dbContainer.Entity1Set.Select(item => item.login).Contains(login) &&
                       _dbContainer.Entity1Set.Select(item => item.password).Contains(password);
        }

        public Task<bool> SignInTask(string login, string password)
        {
            return Task.Run(() => SignIn(login, password)); 
        }

        public bool SignUp(Dictionary<UserModel, string> credentials)
        {
            if (!_dbContainer.Entity1Set.Select(item => item.login).Contains(credentials[UserModel.LOGIN]))
                try
                {
                    Entity1 user = new Entity1();
                    user.first_name = credentials[UserModel.FIRST_NAME];
                    user.last_name = credentials[UserModel.LAST_NAME];
                    user.login = credentials[UserModel.LOGIN];
                    user.middle_name = credentials[UserModel.MIDDLE_NAME];
                    user.password = credentials[UserModel.PASSWORD];
                    _dbContainer.Entity1Set.Add(user);
                    _dbContainer.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            else return false;
        }

        public Task<bool> SignUpTask(Dictionary<UserModel, string> credentials)
        {
            return Task.Run(() => SignUp(credentials));
        }
    }
}