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
        public static bool AddUser(UserType userType, string Login, string Password)
        {
            try
            { 
                if ((from u in cont.UserSet where u.Login==Login select u).Count() > 0)
                {
                    //TODO: сообщение
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
                return true;
            }
            catch (Exception e)
            {
                // TODO: добавить обработку
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
            if ((from u in cont.UserSet where u.Login == Login select u).FirstOrDefault() != null)
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
            if ((from c in cont.CitySet where c.Name == Name select c).FirstOrDefault() != null){
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
        }

        public static bool AddStreet(string Name, City city)
        {
            return false;
        }
    }
}
