using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSimulator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private bool SearchRecordDB(string login, string password)
        {
            using (var vueJSTestDB = new KeyboardSimulatorContext())
            {
                if (vueJSTestDB.Users.SingleOrDefault(user => user.Name == login && user.Password == password) != null)
                {
                    return true;
                }
            }
            return false;

        }

        public static string GetHash(string password)
        {
            
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        [HttpPost("Registration")]

        public string Registration([FromBody] UserRegistration userRegistration)
        {


            if (SearchRecordDB(userRegistration.Name, userRegistration.Password) == true)
            {
                return "Пользователь уже заригистрирован";
            }

            if (userRegistration.Password != userRegistration.PasswordTwo)
            {
                return "Введеные пароли не совпадают";
            }

            userRegistration.Password = GetHash(userRegistration.Password);

            var newUser = new User
            {
                Name = userRegistration.Name,
                Surname=userRegistration.Surname,
                Email = userRegistration.Email,
                Password = userRegistration.Password,
                Gender=userRegistration.Gender,
                DateOfBirth=userRegistration.DateOfBirth
                //undone  исправить что бы сохранялась дата т.к. сейчас записывает строку
            };

            using (var KeyboardSimulatorDB = new KeyboardSimulatorContext())
            {
                KeyboardSimulatorDB.Users.Add(newUser);
                KeyboardSimulatorDB.SaveChanges();
            }

            return "Пользователь " + newUser.Name + " добавлен в базу";
        }


    }
    // TODO добавить методы для обратотки post запросов от компонентов autorization и registration
}
