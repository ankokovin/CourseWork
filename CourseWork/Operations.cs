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
                cont.UserSet.Remove(u);
                cont.SaveChanges();
                Res = "Пользователь " + u.Login + " успешно удалён";
                return true;
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
                        Message += "Вход";
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
                cont.CitySet.Remove(c);
                cont.SaveChanges();
                Res = "Город " + c.Name +" c id "+id+ " был успешно удалён";
                return true;
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
                cont.StreetSet.Remove(s);
                cont.SaveChanges();
                Res = "Удаление успешно";
                return false;
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
                if ((from h in cont.HouseSet where h.Street == street && h.Number == Number).FirstOrDefault() != null)
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
                if ((from h in cont.HouseSet where h.Id != id && h.Street == street && h.Number == Number select h).FirstOrDefault() != null)
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
                cont.HouseSet.Remove(a);
                cont.SaveChanges();
                Res = "Успешное удаления дома номер " + a.Number +
                " улицы " + a.Street + " города " + a.Street.City;
                return true;
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
                if ((from a in cont.AddressSet where a.House == house && a.Flat == Flat select a).FirstOrDefault() != null)
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
                if ((from h in cont.AddressSet where h.Id != id && h.House == house && h.Flat == Flat select h).FirstOrDefault() != null)
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
                cont.AddressSet.Remove(a);
                cont.SaveChanges();
                Res = "Успешное удаления квартиры номер"+a.Flat + "дома номер " + a.House.Number +
                " улицы " + a.House.Street + " города " + a.House.Street.City;
                return true;
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
    }
}
