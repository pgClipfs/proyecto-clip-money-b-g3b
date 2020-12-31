using AutoMapper;
using ClipMoney.Domain.Models;
using ClipMoney.Persistence.EntityFramework.context;
using System.Linq;
using System;
using ClipMoney.Persistence.EntityFramework.entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClipMoney.Domain.Repositories
{
    public class UserRepository
    {
        //crea el objeto privado de tipo BilleteraClipMoneyContext, este tipo es el contexto generado por entity frameork, alli contiene
        //el mapeo con la base de datos, es decir genero clases a partir de las tablas de las base de datos
        //el mapper convierte los modelos para guardarlos en la base de datos dierctamente cuando poseen los mismos datos y no setearlo uno a uno
        private readonly BilleteraClipMoneyContext _context;
        private readonly IMapper _mapper;

        //ineyeccion de dependencias
        public UserRepository(BilleteraClipMoneyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //mediante el context se conecta a la base de datos busca la tabla usuarios y hace uso de Linq para recuperar los datos
        //mapea el tipo de dato
        public UserInLoggedModel GetByUserName(string name)
        {
            //Si hago la comparacion de pass en el bussiness no es necesario pasarla acá
            var user = _context.Usuarios.Where(us => us.nombre_usuario == name).FirstOrDefault();

            return _mapper.Map<UserInLoggedModel>(user);
        }

        //obtiene de la base de datos el usuario con su nombre y el salt
        public async Task<UserSaltModel> GetByUserSaltName(string name)
        {
            //Si hago la comparacion de pass en el bussiness no es necesario pasarla acá
            var user = await _context.Usuarios.Where(us => us.nombre_usuario == name).FirstAsync();
            return _mapper.Map<UserSaltModel>(user);
        }

        //Recupera de la base de datos el usuario por el nombre de usuario si es que existe
        public UserModel ExistUserAccount(string nombre)
        {
            try
            {
                var user = (from u in _context.Usuarios
                            where u.nombre_usuario == nombre
                            select new UserModel
                            {
                                Id = u.id,
                                Nombre = u.nombre_usuario
                            }).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Graba en la base de datos un nuevo usuario y devuelve un booleano si la grabacion fue exitosa
        public bool RegisterUser(UserModel newUser)
        {
            try
            {
                var userDb = new Usuarios();
                userDb.nombre_usuario = newUser.Nombre;
                userDb.hashed_password = newUser.HashedContraseña;
                userDb.salt = newUser.Salt;
                userDb.password = newUser.Contraseña;

                _context.Usuarios.Add(userDb);

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}