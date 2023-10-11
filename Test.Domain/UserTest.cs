using Domain.Contract;
using Domain.Entity;
using Domain.Services;
using NUnit.Framework;

namespace Test.Domain
{
    [TestFixture]
    public class UserTest
    {
        private IUserService _userService;

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void CreateUserFail()
        {
            _userService = new UserService();
            int result = _userService.Create(null);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CreateUserFail2()
        {
            _userService = new UserService();
            int result = _userService.Create(new User { });
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CreateUserSuccess()
        {
            _userService = new UserService();
            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password",
                UserName = "name",
            };
            var result = _userService.Create(user);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void UpdateUserFail()
        {
            
            _userService = new UserService();
            var result = _userService.Update(1, null);
            Assert.IsFalse(result);   
        }

        [Test]
        public void UpdateUserFail2()
        {

            _userService = new UserService();
            var result = _userService.Update(1, new User { });
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateUserFail3()
        {

            _userService = new UserService();
            var result = _userService.Update(0, new User { });
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateUserFail4()
        {

            _userService = new UserService();
            var result = _userService.Update(0, null);
            Assert.IsFalse(result);
        }


        [Test]
        public void UpdateUserFail5() {
            _userService = new UserService();

            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password",
                UserName = "name",
            };

            var result = _userService.Update(1, user);
            Assert.IsFalse(result);
        }


        public void UpdateUserSuccess()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password1",
                UserName = "name1",
            };
            var result = _userService.Update(1, user);
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateUserSuccess2()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password1",
                UserName = "name1",
            };
            var result = _userService.Update(1, user);
            Assert.IsTrue(result);
            var resultUser = _userService.Get(1);
            Assert.IsNotNull(resultUser);
            Assert.AreEqual("name1", resultUser.UserName);
            Assert.AreEqual("password1", resultUser.Password);
        }

        [Test]
        public void UpdateUserSuccess3()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password1",
                UserName = "name1",
            };
            var result = _userService.Update(1, user);
            Assert.IsTrue(result);
            var resultUser = _userService.Get(1);
            Assert.IsNotNull (resultUser);
            Assert.IsNull(resultUser?.CreatedAt);
            Assert.IsNotNull(resultUser?.UpdatedAt);

        }

        [Test]
        public void GetUserVoidFail()
        {
            _userService = new UserService();
            var result = _userService.Get(1);
            Assert.IsNull(result);
        }

        [Test]
        public void GetUserVoidFail2()
        {
            _userService = new UserService();
            var result = _userService.Get(0); 
            Assert.IsNull(result);
        }
        [Test]
        public void GetUserVoidFailWithZero() 
        {
            _userService = new UserService();
            var result = _userService.Get(0);
            Assert.IsNull(result);

        }
        public void GetUserVoidFailWithZeroWithData()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",

                }
            };
            _userService = new UserService(users);
            var result = _userService.Get(0);
            Assert.IsNull(result);
        }

        [Test]
        public void GetUserVoidFailWithData()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",

                }
            };
            _userService = new UserService(users);
            var result = _userService.Get(2);
            Assert.IsNull(result);
        }



        /*
         Funcionalidad:
        Realizar el borrado de un usuario cuando este exista.
        Caso 1: Si el usuario existe, eliminarlo
        Caso 2: Si el usuario tiene relacionado 
        una persona no deberia
        poder eliminarse
        Caso 3: Si existe una configuracion global
        donde permita la eliminacion
        en cascada, realizar el borrado del usuario
        sin validar si tiene relaciones
        Exepciones:
        Caso 1: Si no existe el usuario, arroja falso
        Caso 2: Si el valor esta amarrado a relacion 
        con persona, arrojar falso
        caso 3:
         */


        [Test]

        public void DeleteSuccessWithData()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var result = _userService.Delete(1);
            var resultUser = _userService.Get(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            Assert.IsNull(resultUser);
        }
        [Test]

        public void DeleteFailWithNotData()
        {
            _userService = new UserService();
            var result = _userService.Delete(1);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFailWithData()
        {
            var users = new List<User>
            {
                 new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var result = _userService.Delete(2);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
    }
}