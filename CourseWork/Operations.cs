using System;
using System.Linq;

namespace CourseWork
{
    /// <summary>
    /// Операции, выполняемые над базой данных
    /// </summary>
    static class Operations
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        public static Model1Container cont = new Model1Container();
        public delegate bool AttentionMessageHandler(string s);
        public static event AttentionMessageHandler AttentionMessage;
        #region Users
        /// <summary>
        /// Функция добавления нового пользователя
        /// </summary>
        /// <param name="userType">Тип нового пользователя</param>
        /// <param name="Login">Логин пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        /// <returns>Результат добавления</returns>
        public static bool AddUser(UserType userType, string Login, string Password,out string Res)
        {
            try
            { 
                if ((from u in cont.UserSet where u.Login==Login select u).Count() > 0)
                {
                    Res = "Пользователь с данным именем уже существует";
                    return false;
                }

                User user = new User
                {
                    Login = Login,
                    Password = Password,
                    UserType = userType
                };
                cont.UserSet.Add(user);
                cont.SaveChanges();
                Res = "Пользователь " + Login + " успешно добавлен";
                return true;
            }
            catch (Exception e)
            {
                // TODO: добавить обработку
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция изменения пользователя
        /// </summary>
        /// <param name="Id">Идентификационный номер пользователя</param>
        /// <param name="userType">Тип пользователя</param>
        /// <param name="Login">Имя пользователя</param>
        /// <param name="Password">Пароль</param>
        /// <param name="Res">Сообщение результата изменения</param>
        /// <returns>Результат изменения</returns>
        public static bool ChangeUser(int Id, UserType userType, string Login, string Password, out string Res)
        {
            if ((from u in cont.UserSet where u.Login == Login select u).Count() > 1)
            {
                Res = "Пользователь с данным именем уже существует";
                return false;
            }
            var a = (from u in cont.UserSet where u.Id==Id select u).FirstOrDefault();
            if (a == null)
            {
                Res = "Нет пользователя с таким идентификационным номером";
                return false;
            }
            a.Login = Login;
            a.Password = Password;
            a.UserType = userType;
            cont.SaveChanges();
            Res = "Изменение успешно";
            return true;
        }
        /// <summary>
        /// Функция удаления пользователя
        /// </summary>
        /// <param name="id">Идентификационный номер пользователя</param>
        /// <param name="Res">Сообщение результата удаления</param>
        /// <returns>Результат удаления</returns>
        public static bool RemoveUser(int id, out string Res)
        {
            try
            {
                var u = cont.UserSet.Find(id);
                if (u == null)
                {
                    Res = "Нет пользователя с данным идентификационным номером";
                    return false;
                }
                if (u.Order.Count == 0 || AttentionMessage("Вы действительно хотите удалить пользователя" +
                    u+ "?\n"+u.Order.Count+" заказов а также связанные с ними объекты будут удалены."))
                {
                    cont.UserSet.Remove(u);
                    cont.SaveChanges();
                    Res = "Пользователь " + u.Login + " успешно удалён";
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch(Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Поиск пользователя по идентификационному номеру
        /// </summary>
        /// <param name="Id">Идентификационный номер</param>
        /// <returns>Пользователь</returns>
        public static User FindUser(int Id) => (from u in cont.UserSet where u.Id == Id select u).FirstOrDefault();
        /// <summary>
        /// Функция входа в систему
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <param name="Message">Получаемое сообщение</param>
        /// <returns>Пользователь, под которым происходит вход, null при ошибке входа</returns>
        public static User TryEntry(string Login, string Password,out string Message)
        {
            Message = string.Empty;
            var user = (from u in cont.UserSet
                        where u.Login == Login
                        select u).ToList();
            if (user.Count == 0)
            {
                Message += "Такого пользователя не существует";
                return null;
            }
            else
            {
                if (user.Count > 1)
                    Message += "Несколько пользователей имеют одинаковый логин!";
                 
                foreach (User u in user)
                    if (u.Password == Password)
                    {
                        //Login complete
                        Message += "Успешный вход :"+u;
                        return u;
                    }
                Message += "Неверный пароль";
                return null;
            }
        }
        #endregion Users
        #region Адреса
        #region City
        /// <summary>
        /// Добавить город
        /// </summary>
        /// <param name="Name">Название города</param>
        /// <param name="Res">Сообщение о результате</param>
        /// <returns>Результат добавления</returns>
        public static bool AddCity(string Name, out string Res)
        {
            try
            {
                if ((from c in cont.CitySet where c.Name==Name select c).Count()>0)
                {
                    Res = "Данный город уже добавлен";
                    return false;
                }
                City city = new City
                {
                    Name = Name
                };
                cont.CitySet.Add(city);
                cont.SaveChanges();
                Res = "Город " + Name + " был добавлен успешно";
                return true;
            }
            catch(Exception e)
            {
                //TODO: обработка
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Удалить город
        /// </summary>
        /// <param name="id">Идентификатор города</param>
        /// <param name="Res">Сообщение о результате</param>
        /// <returns>Результат удаления</returns>
        public static bool RemoveCity(int id, out string Res)
        {
            try
            {
                var c = cont.CitySet.Find(id);
                if (c == null)
                {
                    Res = "Город не обнаружен";
                    return false;
                }
                if (c.Street.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить город " + c.Name + "?\n" +
                    c.Street.Count + " улиц и связанные с ними объекты также будут удалены."))
                {
                    cont.CitySet.Remove(c);
                    cont.SaveChanges();
                    Res = "Город " + c.Name + " c id " + id + " был успешно удалён";
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }catch(Exception e)
            {
                //TODO: обработка
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Изменить город
        /// </summary>
        /// <param name="id">Идентификационный номер города</param>
        /// <param name="Name">Новое имя города</param>
        /// <param name="Res">Сообщение о результате</param>
        /// <returns>Результат изменения</returns>
        public static bool ChangeCity(int id, string Name, out string Res)
        {
            try
            {
                if ((from c in cont.CitySet where c.Name == Name select c).FirstOrDefault() != null)
                {
                    Res = "Уже есть город с именем " + Name;
                    return false;
                }
                var a = (from c in cont.CitySet where c.Id == id select c).FirstOrDefault();
                if (a == null)
                {
                    Res = "Нет города с идентификационным номером " + id;
                    return false;
                }
                a.Name = Name;
                cont.SaveChanges();
                Res = "Изменение успешно";
                return true;
            }catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция поиска города по идентификационному номеру
        /// </summary>
        /// <param name="Id">Идентификационный номер</param>
        /// <returns>Город</returns>
        public static City FindCity(int Id) => (from c in cont.CitySet where c.Id == Id select c).FirstOrDefault();
        #endregion City
        #region Street
        /// <summary>
        /// Функция добавления улицы
        /// </summary>
        /// <param name="Name">Название улицы</param>
        /// <param name="city">Город</param>
        /// <param name="Res">Сообщение результата добавления</param>
        /// <returns>Результат добавления</returns>
        public static bool AddStreet(string Name, City city, out string Res)
        {
            try
            {
                if ((from s in cont.StreetSet where s.City.Id == city.Id && s.Name == Name select s).FirstOrDefault() != null)
                {
                    Res = "В городе " + city.Name + " уже есть улица " + Name;
                    return false;
                }
                Street street = new Street();
                street.Name = Name;
                street.City = city;
                cont.StreetSet.Add(street);
                cont.SaveChanges();
                Res = "Улица была добавлена успешно";
                return true;
            }
            catch(Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция изменения улицы
        /// </summary>
        /// <param name="id">Идентификационный номер улицы</param>
        /// <param name="Name">Название улицы</param>
        /// <param name="city">Город</param>
        /// <param name="Res">Сообщение результата изменения</param>
        /// <returns>Результат изменения</returns>
        public static bool ChangeStreet(int id, string Name, City city, out string Res)
        {
            if ((from s in cont.StreetSet where s.City.Id == city.Id && s.Name == Name select s).FirstOrDefault() != null)
            {
                Res = "В городе " + city.Name + " уже есть улица " + Name;
                return false;
            }
            var a = FindStreet(id);
            if (a == null)
            {
                Res = "Нет улицы с заданным идентификационным номером";
                return false;
            }
            a.Name = Name;
            a.City = city;
            cont.SaveChanges();
            Res = "Изменение успешно";
            return true;
        }
        /// <summary>
        /// Функция удаления улицы по идентификационному номеру
        /// </summary>
        /// <param name="id">Идентификационный номер</param>
        /// <param name="Res">Сообщение результата удаления</param>
        /// <returns>Результат удаления</returns>
        public static bool RemoveStreet(int id, out string Res)
        {
            try
            {
                var s = FindStreet(id);
                if (s == null)
                {
                    Res = "Нет улицы с заданным идентификационным номером";
                    return false;
                }
                if (s.House.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить улицу " + s + " ?\n" +
                    s.House.Count + " домов и связанные с ними объекты также будут удалены."))
                {
                    cont.StreetSet.Remove(s);
                    cont.SaveChanges();
                    Res = "Удаление успешно";
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }catch(Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция поиска улицы по идентификационному номеру
        /// </summary>
        /// <param name="id">Идентификационный номер</param>
        /// <returns>Улица</returns>
        public static Street FindStreet(int id) => (from s in cont.StreetSet where s.Id == id select s).FirstOrDefault();
        #endregion Street
        #region House
        /// <summary>
        /// Функция добавления дома
        /// </summary>
        /// <param name="Number">Номер дома</param>
        /// <param name="FlatsCount">Количество квартир</param>
        /// <param name="street">Улица</param>
        /// <param name="Res">Сообщение результата добавления</param>
        /// <returns>Результат добавления</returns>
        public static bool AddHouse(string Number,int FlatsCount, Street street, out string Res)
        {
            try
            {
                if ((from h in cont.HouseSet where h.Street.Id == street.Id && h.Number == Number select h).FirstOrDefault() != null)
                {
                    Res = "Уже есть дом номер " + Number + " на улице " + street;
                    return false;
                }
                House house = new House();
                house.Street = street;
                house.Number = Number;
                house.FlatsCount = FlatsCount;
                cont.HouseSet.Add(house);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch(Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция изменения дома
        /// </summary>
        /// <param name="id">Идентификационный номер дома</param>
        /// <param name="Number">Номер дома</param>
        /// <param name="FlatsCount">Количество квартир</param>
        /// <param name="street">Улица</param>
        /// <param name="Res">Сообщение результата изменения</param>
        /// <returns>Результат изменения</returns>
        public static bool ChangeHouse(int id, string Number, int FlatsCount, Street street, out string Res)
        {
            try
            {
                if ((from h in cont.HouseSet where h.Id != id && h.Street.Id == street.Id && h.Number == Number select h).FirstOrDefault() != null)
                {
                    Res = "В городе " + street.City + " на улице " + street + " уже есть дом номер " + Number;
                    return false;
                }
                var a = FindHouse(id);
                if (a == null)
                {
                    Res = "Нет дома с данным идентификационным номером";
                    return false;
                }
                a.Street = street;
                a.Number = Number;
                a.FlatsCount = FlatsCount;
                cont.SaveChanges();
                Res = "Изменение дома успешно";
                return true;
            }catch(Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция удаления дома
        /// </summary>
        /// <param name="id">Идентификационный номер дома</param>
        /// <param name="Res">Сообщение результата удаления</param>
        /// <returns>Результат удаления</returns>
        public static bool RemoveHouse(int id, out string Res)
        {
            try
            {
                var a = FindHouse(id);
                if (a == null)
                {
                    Res = "Нет дома с таким идентификационным номером";
                    return false;
                }
                if (a.Address.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить дом " + a + " ?\n" +
                   a.Address.Count + " адресов и связанные с ними объекты также будут удалены."))
                {
                    cont.HouseSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаления дома номер " + a.Number +
                    " улицы " + a.Street + " города " + a.Street.City;
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция поиска дома по идентификационному номеру
        /// </summary>
        /// <param name="id">Идентификационный номер</param>
        /// <returns>Дом</returns>
        public static House FindHouse(int id) => (from s in cont.HouseSet where s.Id == id select s).FirstOrDefault();
        #endregion House
        #region Address
        /// <summary>
        /// Функция добавления адреса
        /// </summary>
        /// <param name="Flat">Номер квартиры</param>
        /// <param name="house">Дом</param>
        /// <param name="Res">Сообщение результата добавления</param>
        /// <returns>Результат добавления</returns>
        public static bool AddAddress(int Flat, House house, out string Res)
        {
            try
            {
                if ((from a in cont.AddressSet where a.House.Id == house.Id && a.Flat == Flat select a).FirstOrDefault() != null)
                {
                    Res = "Уже есть данный адрес";
                    return false;
                }
                Address address = new Address();
                address.Flat = Flat;
                address.House = house;
                cont.AddressSet.Add(address);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }catch(Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция изменения адреса
        /// </summary>
        /// <param name="id">Идентификационный номер адреса</param>
        /// <param name="Flat">Номер квартиры</param>
        /// <param name="house">Дом</param>
        /// <param name="Res">Сообщение результата изменения</param>
        /// <returns>Результат изменения</returns>
        public static bool ChangeAddress(int id, int Flat, House house, out string Res)
        {
            try
            {
                if ((from h in cont.AddressSet where h.Id != id && h.House.Id == house.Id && h.Flat == Flat select h).FirstOrDefault() != null)
                {
                    Res = "В городе " + house.Street.City + " на улице " + house.Street + 
                        " в доме номер " + house.Number+" уже есть квартира номер "+Flat;
                    return false;
                }
                var a = FindAddress(id);
                if (a == null)
                {
                    Res = "Нет адреса с данным идентификационным номером";
                    return false;
                }
                a.Flat = Flat;
                a.House = house;
                cont.SaveChanges();
                Res = "Изменение дома успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция удаления адреса по идентификационному номеру
        /// </summary>
        /// <param name="id">Идентификационный номер адреса</param>
        /// <param name="Res">Сообщение результата удаления</param>
        /// <returns>Результат удаления</returns>
        public static bool RemoveAddress(int id, out string Res)
        {
            try
            {
                var a = FindAddress(id);
                if (a == null)
                {
                    Res = "Нет адреса с таким идентификационным номером";
                    return false;
                }
                if (a.Order.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить адрес " + a + " ?\n" +
                    a.Order.Count + " заказов и связанные с ними объекты также будут удалены."))
                {
                    cont.AddressSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаления квартиры номер" + a.Flat + "дома номер " + a.House.Number +
                    " улицы " + a.House.Street + " города " + a.House.Street.City;
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }
        /// <summary>
        /// Функция поиска адреса по идентификационному ключу
        /// </summary>
        /// <param name="id">Идентификационный ключ</param>
        /// <returns>Адрес</returns>
        public static Address FindAddress(int id) => (from a in cont.AddressSet where a.Id == id select a).FirstOrDefault();
        #endregion Address
        #endregion Адреса
        #region Order
        
        public static bool AddOrder(User user,Customer customer,Address address, out string Res)
        {
            try
            {
                Order order = new Order();
                order.Customer = customer;
                order.Address = address;
                order.User = user;
                cont.OrderSet.Add(order);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangeOrder(int Id,Customer customer, Address address, out string Res)
        {
            try
            {
                var a = FindOrder(Id);
                if (a == null)
                {
                    Res = "Нет заказа с данным идентификационный номером";
                    return false;
                }
                a.Address = address;
                a.Customer = customer;
                cont.SaveChanges();
                Res = "Изменение заказа успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool RemoveOrder(int id,out string Res)
        {
            try
            {
                var a = FindOrder(id);
                if (a == null)
                {
                    Res = "Нет заказа с таким идентификационным номером";
                    return false;
                }
                if (a.OrderEntry.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить заказ " + a + " ?\n" +
                    a.OrderEntry.Count + " заказных позиций и связанные с ними объекты также будут удалены."))
                {
                    cont.OrderSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаление заказа";
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static Order FindOrder(int id) => (from o in cont.OrderSet where o.Id == id select o).FirstOrDefault();
        #endregion Order
        #region OrderEntry
        public static bool AddOrderEntry(Order order,DateTime startTime, DateTime endTime
            ,string RegNumber,Meter meter,Status status, out string Res)
        {
            try
            {
                OrderEntry orderEntry = new OrderEntry();
                orderEntry.Order = order;
                orderEntry.StartTime = startTime;
                orderEntry.EndTime = endTime;
                orderEntry.Meter = meter;
                orderEntry.RegNumer = RegNumber;
                orderEntry.Status = status;
                cont.OrderEntrySet.Add(orderEntry);
                cont.SaveChanges();
                Res = "Успешное добавление заказа";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangeOrderEntry(int Id, Order order, DateTime startTime, DateTime endTime, 
             string RegNumber,Meter meter, Status status, out string Res)
        {
            try
            {
                var a = FindOrderEntry(Id);
                if (a == null)
                {
                    Res = "Нет заказной позиции с данным идентификационным номером";
                    return false;
                }
                a.Meter = meter;
                a.Order = order;
                a.RegNumer = RegNumber;
                a.StartTime = startTime;
                a.EndTime = endTime;
                a.Status = status;
                cont.SaveChanges();
                Res = "Изменение заказной позиции успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool RemoveOrderEntry(int id, out string Res)
        {
            try
            {
                var a = FindOrderEntry(id);
                if (a == null)
                {
                    Res = "Нет заказной позиции с таким идентификационным номером";
                    return false;
                }
                cont.OrderEntrySet.Remove(a);
                cont.SaveChanges();
                Res = "Успешное удаление заказной позиции";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static OrderEntry FindOrderEntry(int id) => (from o in cont.OrderEntrySet where o.Id == id select o).FirstOrDefault();
        #endregion OrderEntry
        #region Meter

        public static bool AddMeter(string Name,MeterType meterType, out string Res)
        {
            try
            {
                if ((from a in cont.MeterSet where a.Name==Name select a).FirstOrDefault() != null)
                {
                    Res = "Уже есть прибор учёта с данным названием";
                    return false;
                }
                Meter meter = new Meter();
                meter.Name = Name;
                meter.MeterType = meterType;
                cont.MeterSet.Add(meter);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangeMeter(int Id, string Name,MeterType meterType, out string Res)
        {
            try
            {
                if ((from h in cont.MeterSet where h.Id != Id && h.Name == Name select h).FirstOrDefault() != null)
                {
                    Res = "Уже есть прибор учёта с данным названием";
                    return false;
                }
                var a = FindMeter(Id);
                if (a == null)
                {
                    Res = "Нет прибора учёта с данным идентификационным номером";
                    return false;
                }
                a.Name = Name;
                a.MeterType = meterType;
                cont.SaveChanges();
                Res = "Изменение дома успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool RemoveMeter(int id, out string Res)
        {
            try
            {
                var a = FindMeter(id);
                if (a == null)
                {
                    Res = "Нет прибора учёта с таким идентификационным номером";
                    return false;
                }
                if (a.OrderEntry.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить прибор учёта " + a + " ?\n" +
                    a.OrderEntry.Count + " заказных позиций и связанные с ними объекты также будут удалены."))
                {
                    cont.MeterSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаление прибора учёта";
                    return true;
                }
                else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static Meter FindMeter(int id) => (from o in cont.MeterSet where o.Id == id select o).FirstOrDefault();
        #endregion Meter
        #region Status

        public static bool AddStatus(string Name, out string Res)
        {
            try
            {
                if ((from a in cont.StatusSet where a.Name == Name select a).FirstOrDefault() != null)
                {
                    Res = "Уже есть данный статус";
                    return false;
                }
                Status status = new Status();
                status.Name = Name;
                cont.StatusSet.Add(status);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangeStatus(int Id, string Name, out string Res)
        {
            try
            {
                if ((from h in cont.StatusSet where h.Id != Id && h.Name == Name select h).FirstOrDefault() != null)
                {
                    Res = "Уже есть данный статус";
                    return false;
                }
                var a = FindStatus(Id);
                if (a == null)
                {
                    Res = "Нет статуса с данным идентификационным номером";
                    return false;
                }
                a.Name = Name;
                cont.SaveChanges();
                Res = "Изменение статуса успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool RemoveStatus(int id, out string Res)
        {
            try
            {
                var a = FindStatus(id);
                if (a == null)
                {
                    Res = "Нет статуса с таким идентификационным номером";
                    return false;
                }
                if (a.OrderEntry.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить статус заказа " + a + " ?\n" +
                    a.OrderEntry.Count + " заказных позиций и связанные с ними объекты также будут удалены."))
                {
                    cont.StatusSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаление статуса";
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static Status FindStatus(int id) => (from o in cont.StatusSet where o.Id == id select o).FirstOrDefault();
        #endregion Status
        #region MeterType

        public static bool AddMeterType(string Name, out string Res)
        {
            try
            {
                if ((from a in cont.MeterTypeSet where a.Name == Name select a).FirstOrDefault() != null)
                {
                    Res = "Уже есть данный тип приборов учёта";
                    return false;
                }
                MeterType meterType = new MeterType();
                meterType.Name = Name;
                cont.MeterTypeSet.Add(meterType);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangeMeterType(int Id, string Name, out string Res)
        {
            try
            {
                if ((from h in cont.MeterTypeSet where h.Id != Id && h.Name == Name select h).FirstOrDefault() != null)
                {
                    Res = "Уже есть тип приборов учёта с данным названием";
                    return false;
                }
                var a = FindMeterType(Id);
                if (a == null)
                {
                    Res = "Нет типа приборов учёта с данным идентификационным номером";
                    return false;
                }
                a.Name = Name;
                cont.SaveChanges();
                Res = "Изменение прибора учёта успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool RemoveMeterType(int id, out string Res)
        {
            try
            {
                var a = FindMeterType(id);
                if (a == null)
                {
                    Res = "Нет типа приборов учёта с таким идентификационным номером";
                    return false;
                }
                if ((a.Meter.Count == 0) && (a.Stavka.Count == 0) ||
                    AttentionMessage("Вы уверены, что хотите удалить тип приборов учёта " + a + " ?\n" +
                    a.Meter.Count + " приборов учёта и " + a.Stavka.Count + " ставок, а так же связанные с ними объекты также будут удалены."))
                {
                    cont.MeterTypeSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаление типа приборов учёта";
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static MeterType FindMeterType(int id) => (from o in cont.MeterTypeSet where o.Id == id select o).FirstOrDefault();
        #endregion MeterType
        #region Stavka

        public static bool AddStavka(MeterType meterType,Person person, out string Res)
        {
            try
            {
                if ((from a in cont.StavkaSet where a.MeterType.Id == meterType.Id && a.Person.Id == person.Id select a).FirstOrDefault() != null)
                {
                    Res = "Уже есть данная ставка";
                    return false;
                }
                Stavka stavka = new Stavka();
                stavka.MeterType = meterType;
                stavka.Person = person;
                cont.StavkaSet.Add(stavka);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangeStavka(int Id,MeterType meterType,Person person, out string Res)
        {
            try
            {
                if ((from h in cont.StavkaSet where h.Id != Id && h.MeterType.Id == meterType.Id && h.Person.Id == person.Id select h).FirstOrDefault() != null)
                {
                    Res = "Уже есть данная ставка у данного человека";
                    return false;
                }
                var a = FindStavka(Id);
                if (a == null)
                {
                    Res = "Нет ставки с данным идентификационным номером";
                    return false;
                }
                a.MeterType = meterType;
                a.Person = person;
                cont.SaveChanges();
                Res = "Изменение ставки успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool RemoveStavka(int id, out string Res)
        {
            try
            {
                var a = FindStavka(id);
                if (a == null)
                {
                    Res = "Нет ставки с таким идентификационным номером";
                    return false;
                }
                cont.StavkaSet.Remove(a);
                cont.SaveChanges();
                Res = "Успешное удаление ставки";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static Stavka FindStavka(int id) => (from o in cont.StavkaSet where o.Id == id select o).FirstOrDefault();

        #endregion Stavka
        #region Person

        public static bool AddPerson(string FIO, out string Res)
        {
            try
            {
                if ((from a in cont.PersonSet where a.FIO==FIO select a).FirstOrDefault() != null)
                {
                    Res = "Уже есть данный человек";
                    return false;
                }
                Person person = new Person();
                person.FIO = FIO;
                cont.PersonSet.Add(person);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangePerson(int Id, string FIO, out string Res)
        {
            try
            {
                if ((from h in cont.PersonSet where h.Id != Id && h.FIO == FIO select h).FirstOrDefault() != null)
                {
                    Res = "Уже есть человек с данным ФИО";
                    return false;
                }
                var a = FindPerson(Id);
                if (a == null)
                {
                    Res = "Нет адреса с данным идентификационным номером";
                    return false;
                }
                a.FIO = FIO;
                cont.SaveChanges();
                Res = "Изменение ФИО успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool RemovePerson(int id, out string Res)
        {
            try
            {
                var a = FindPerson(id);
                if (a == null)
                {
                    Res = "Нет ФИО с таким идентификационным номером";
                    return false;
                }
                if (a.Worker.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить работника " + a + " ?\n" +
                    a.Worker.Count + " ставок и связанные с ними объекты также будут удалены."))
                {
                    cont.PersonSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаление ФИО";
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static Person FindPerson(int id) => (from o in cont.PersonSet where o.Id == id select o).FirstOrDefault();
        #endregion Person
        #region Customer

        public static bool AddCustomer(string Name, string Passport, out string Res)
        {
            try
            {
                if ((from a in cont.CustomerSet where a.Passport==Passport&&!(a is Company) select a).FirstOrDefault() != null)
                {
                    Res = "Уже есть данный частный заказчик";
                    return false;
                }
                Customer customer = new Customer();
                customer.Name = Name;
                customer.Passport = Passport;
                cont.CustomerSet.Add(customer);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangeCustomer(int Id, string Name, string Passport, out string Res)
        {
            try
            {
                if ((from h in cont.CustomerSet where h.Id != Id && !(h is Company) && h.Passport == h.Passport select h).FirstOrDefault() != null)
                {
                    Res = "Уже есть частный клиент с данным номером паспорта";
                    return false;
                }
                var a = FindCustomer(Id);
                if (a == null)
                {
                    Res = "Нет частного клиента с данным идентификационным номером";
                    return false;
                }
                a.Passport = Passport;
                a.Name = Name;
                cont.SaveChanges();
                Res = "Изменение дома успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool RemoveCustomer(int id, out string Res)
        {
            try
            {
                var a = FindCustomer(id);
                if (a == null)
                {
                    Res = "Нет заказчика с таким идентификационным номером";
                    return false;
                }
                if (a is Company)
                {
                    Res = "Данный заказчик является компанией, а не частным лицом";
                    return false;
                }
                if (a.Order.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить заказчика " + a + " ?\n" +
                    a.Order.Count + " заказов будут удалены."))
                {
                    cont.CustomerSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаление";
                    return true;
                }else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static Customer FindCustomer(int id) => (from o in cont.CustomerSet where o.Id == id select o).FirstOrDefault();
        #endregion Customer
        #region Company

        public static bool AddCompany(string Name, string Passport,string CompanyName,string INN,  out string Res)
        {
            try
            {
                if ((from a in cont.CustomerSet where (a is Company)&&((a as Company).INN==INN) select a)
                    .FirstOrDefault() != null)
                {
                    Res = "Уже есть данная компания";
                    return false;
                }
                Company company = new Company();
                company.Name = Name;
                company.Passport = Passport;
                company.INN = INN;
                company.CompanyName = CompanyName;
                cont.CustomerSet.Add(company);
                cont.SaveChanges();
                Res = "Успешное добавление";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static bool ChangeCompany(int Id, string Name, string Passport, string CompanyName, string INN, out string Res)
        {

            try
            {
                if ((from h in cont.CustomerSet where h.Id != Id && (h is Company) && (h as Company).INN == INN select h).FirstOrDefault() != null)
                {
                    Res = "Уже есть компания с данным ИНН";
                    return false;
                }
                var a = FindCompany(Id);
                if (a == null)
                {
                    Res = "Нет компании с данным идентификационным номером";
                    return false;
                }
                a.Passport = Passport;
                a.Name = Name;
                cont.SaveChanges();
                Res = "Изменение компании успешно";
                return true;
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }

        }

        public static bool RemoveCompany(int id, out string Res)
        {

            try
            {
                var a = FindCustomer(id);
                if (a == null)
                {
                    Res = "Нет заказчика с таким идентификационным номером";
                    return false;
                }
                if (!(a is Company))
                {
                    Res = "Данный заказчик является  не компанией, а частным лицом";
                    return false;
                }
                if (a.Order.Count == 0 || AttentionMessage("Вы уверены, что хотите удалить заказчика " + a + " ?\n" +
     a.Order.Count + " заказов будут удалены."))
                {
                    cont.CustomerSet.Remove(a);
                    cont.SaveChanges();
                    Res = "Успешное удаление";
                    return true;
                }
                else
                {
                    Res = "Удаление отменено";
                    return false;
                }
            }
            catch (Exception e)
            {
                Res = e.Message;
                return false;
            }
        }

        public static Company FindCompany(int id) => (from o in cont.CustomerSet where o.Id == id select o).FirstOrDefault() as Company;
        #endregion Company
    }
}
