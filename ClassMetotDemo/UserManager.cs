using System;
using System.Collections.Generic;
using System.Text;

namespace ClassMetotDemo
{
    class UserManager
    {
        private List<User> _users;
        public UserManager()
        {
            _users = new List<User>()
            {
                new User(){ Id=Helpers.CreateNewId() ,Username="admin", Password="123", CreatedDateTime = DateTime.Now },
                new User(){ Id=Helpers.CreateNewId() ,Username="ozan", Password="123", CreatedDateTime = DateTime.Now }
            };
        }

        public void GetUsers()
        {
            if (_users.Count == 0)
            {
                Console.WriteLine("Sistemde Kayıtlı Kullanıcı Bulunamadı!");
            }
            else
            {
                foreach (var item in _users)
                {
                    Console.WriteLine($"Id: {item.Id}\nKullanıcı Adı: {item.Username}\nŞifre: *\nKayıt Tarihi: {item.CreatedDateTime.ToShortDateString()}");
                    Console.WriteLine("------------------------------");
                }
            }
        }
        public User CheckLogin(CustomerLoginModel customerLoginModel)
        {
            return _users.Find(p => p.Username.Equals(customerLoginModel.UserName) && p.Password.Equals(customerLoginModel.Password));
        }

        public void LoginUser(User user)
        {
            user.IsConnected = true;
            this.UpdateUser(user);
        }
        public void LogoutUser(User user)
        {
            user.IsConnected = false;
            this.UpdateUser(user);
        }


        public void AddUser(UserCreateModel userCreateModel)
        {
            User user = new User()
            {
                Id = Helpers.CreateNewId(),
                Username = userCreateModel.Username,
                Password = userCreateModel.Password
            };

            _users.Add(user);

            Console.WriteLine("Yeni Kullanıcı Başarıyla Kayıt Edildi!");
        }

        public void UpdateUser(User user)
        {
            User findedUser = _users.Find(p => p.Id.Equals(user.Id));

            findedUser.Username = user.Username;
            findedUser.Password = user.Password;
            findedUser.IsConnected = user.IsConnected;
            Console.WriteLine("Kullanıcı Başarıyla Düzenlendi!");
        }

        public void DeleteUser(User user)
        {
            if (user.IsConnected == true)
            {
                Console.WriteLine("Kullanıcı Sistemde Aktifken Silinemez!");
            }
            else
            {
                _users.Remove(user);

                Console.WriteLine("Kullanıcı Başarıyla Silindi Edildi!");
            }
        }
        public void DeleteUserById(int id)
        {
            User findedUser = _users.Find(p => p.Id.Equals(id));

            if (findedUser != null)
                DeleteUser(findedUser);
            else
                Console.WriteLine("Verdiğiniz Id'ye Göre Bir Kullanıcı Bulunamadı!");
        }
    }
}
