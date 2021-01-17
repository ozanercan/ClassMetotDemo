using System;
using System.Threading;

namespace ClassMetotDemo
{
    class Program
    {
        static User _loggedUser;
        static UserManager _userManager = new UserManager();

        static void Main(string[] args)
        {
            CustomerManager _customerManager = new CustomerManager();

        applicationBase:

            Console.Write("Kullanıcı Adı: ");

            string userName = Console.ReadLine();

            Console.Write("\nŞifre: ");

            string password = Console.ReadLine();

            User findedUser = _userManager.CheckLogin(new CustomerLoginModel()
            {
                UserName = userName,
                Password = password
            });
            if (findedUser != null)
            {
                _loggedUser = findedUser;
                _userManager.LoginUser(_loggedUser);

                Console.WriteLine("Giriş Başarılı! Yönlendiriliyorsunuz.");

                Thread.Sleep(500);
            loggedPoint:
                Console.Clear();
                Console.WriteLine("-- Ana Menü --");
                Console.WriteLine("1- Müşteri İşlemleri");
                Console.WriteLine("2- Kullanıcı İşlemleri");
                Console.Write("Lütfen işlem türünü seçin. (1-2): ");

                int choosedOperation = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (choosedOperation == 1)
                {
                    #region Customer Operations
                    Console.WriteLine("-- Müşteri İşlemleri --");
                    Console.WriteLine("0- Geri");
                    Console.WriteLine("1- Müşterileri Listele");
                    Console.WriteLine("2- Yeni Müşteri Oluştur");
                    Console.WriteLine("3- Müşteri Düzenle");
                    Console.WriteLine("4- Müşteri Sil");

                    Console.Write("Lütfen yapmak istediğiniz işlemi seçin. (1-4): ");

                    int choosedCustomerOperation = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    if (choosedCustomerOperation == 1)
                    {
                        Console.WriteLine("-- Müşterileri Listele --");

                        _customerManager.GetCustomers();

                        Console.WriteLine("Yeni İşlem İçin Herhangi Bir Tuşa Basın!");

                        Console.ReadKey();

                        goto loggedPoint;
                    }
                    else if (choosedCustomerOperation == 2)
                    {
                        Console.WriteLine("-- Yeni Müşteri Oluştur --");

                        Console.Write("Müşteri Adı: ");
                        string customerFirstName = Console.ReadLine();

                        Console.Write("\nMüşteri Soyadı: ");
                        string customerLastName = Console.ReadLine();

                        CustomerCreateModel customerCreateModel = new CustomerCreateModel()
                        {
                            FirstName = customerFirstName,
                            LastName = customerLastName
                        };

                        _customerManager.AddNewCustomer(customerCreateModel);

                        Console.WriteLine("Yeni İşlem İçin Herhangi Bir Tuşa Basın!");

                        Console.ReadKey();

                        goto loggedPoint;
                    }
                    else if (choosedCustomerOperation == 3)
                    {
                        Console.WriteLine("-- Müşteri Düzenle --");

                        _customerManager.GetCustomers();

                        Console.WriteLine("Lütfen Düzenlemek İstediğiniz Müşterinin Id değerini yazınız.");

                        Console.Write("Id: ");

                        int choosedCustomerId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Müşteri Adı: ");
                        string customerFirstName = Console.ReadLine();

                        Console.Write("\nMüşteri Soyadı: ");
                        string customerLastName = Console.ReadLine();

                        Customer customer = new Customer()
                        {
                            Id = choosedCustomerId,
                            FirstName = customerFirstName,
                            LastName = customerLastName
                        };

                        _customerManager.UpdateCustomer(customer);

                        Console.WriteLine("Yeni İşlem İçin Herhangi Bir Tuşa Basın!");

                        Console.ReadKey();

                        goto loggedPoint;
                    }
                    else if (choosedCustomerOperation == 4)
                    {
                        Console.WriteLine("-- Müşteri Sil --");

                        _customerManager.GetCustomers();

                        Console.WriteLine("Lütfen Silmek İstediğiniz Müşterinin Id değerini yazınız.");

                        Console.Write("Id: ");

                        int choosedCustomerId = Convert.ToInt32(Console.ReadLine());

                        _customerManager.DeleteCustomerById(choosedCustomerId);

                        Console.WriteLine("Yeni İşlem İçin Herhangi Bir Tuşa Basın!");

                        Console.ReadKey();

                        goto loggedPoint;
                    }
                    else
                    {
                        goto loggedPoint;
                    }
                    #endregion
                }
                else
                {
                    #region User Operations
                    Console.WriteLine("-- Kullanıcı İşlemleri --");
                    Console.WriteLine("0- Geri");
                    Console.WriteLine("1- Kullanıcıları Listele");
                    Console.WriteLine("2- Yeni Kullanıcı Oluştur");
                    Console.WriteLine("3- Kullanıcı Düzenle");
                    Console.WriteLine("4- Kullanıcı Sil");

                    Console.Write("Lütfen yapmak istediğiniz işlemi seçin. (1-3): ");

                    int choosedUserOperation = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    if (choosedUserOperation == 1)
                    {
                        Console.WriteLine("-- Kullanıcıları Listele --");

                        _userManager.GetUsers();

                        Console.WriteLine("Yeni İşlem İçin Herhangi Bir Tuşa Basın!");

                        Console.ReadKey();

                        goto loggedPoint;
                    }
                    else if (choosedUserOperation == 2)
                    {
                        Console.WriteLine("-- Yeni Kullanıcı Oluştur --");

                        Console.Write("Kullanıcı Adı: ");
                        string customerUserName = Console.ReadLine();

                        Console.Write("\nŞifre: ");
                        string customerPassword = Console.ReadLine();

                        UserCreateModel userCreateModel = new UserCreateModel()
                        {
                            Username = customerUserName,
                            Password = customerPassword
                        };

                        _userManager.AddUser(userCreateModel);

                        Console.WriteLine("Yeni İşlem İçin Herhangi Bir Tuşa Basın!");

                        Console.ReadKey();

                        goto loggedPoint;
                    }
                    else if (choosedUserOperation == 3)
                    {
                        Console.WriteLine("-- Kullanıcı Düzenle --");

                        _userManager.GetUsers();

                        Console.WriteLine("Lütfen Düzenlemek İstediğiniz Kullanıcının Id değerini yazınız.");

                        Console.Write("Id: ");

                        int choosedUserId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Kullanıcı Adı: ");
                        string newUserName = Console.ReadLine();

                        Console.Write("\nŞifre: ");
                        string newPassword = Console.ReadLine();

                        User newUser = new User()
                        {
                            Id = choosedUserId,
                            Username = newUserName,
                            Password = newPassword
                        };

                        _userManager.UpdateUser(newUser);

                        Console.WriteLine("Yeni İşlem İçin Herhangi Bir Tuşa Basın!");

                        Console.ReadKey();

                        goto loggedPoint;
                    }
                    else if (choosedUserOperation == 4)
                    {
                        Console.WriteLine("-- Kullanıcı Sil --");

                        _userManager.GetUsers();

                        Console.WriteLine("Lütfen Silmek İstediğiniz Müşterinin Id değerini yazınız.");

                        Console.Write("Id: ");

                        int choosedUserId = Convert.ToInt32(Console.ReadLine());

                        _userManager.DeleteUserById(choosedUserId);

                        Console.WriteLine("Yeni İşlem İçin Herhangi Bir Tuşa Basın!");

                        Console.ReadKey();

                        goto loggedPoint;
                    }
                    else
                    {
                        goto loggedPoint;
                    }
                    #endregion
                }

            }
            else
            {
                Console.WriteLine("Kullanıcı Adı veya Şifre Yanlış!");
                goto applicationBase;
            }
        }
        ~Program()
        {
            if (_loggedUser != null)
            {
                _userManager.LogoutUser(_loggedUser);
            }
        }
    }
}
