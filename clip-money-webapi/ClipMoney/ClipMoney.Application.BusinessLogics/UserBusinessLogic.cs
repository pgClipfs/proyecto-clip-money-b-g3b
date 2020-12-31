using ClipMoney.Domain.Models;
using ClipMoney.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClipMoney.Application.BusinessLogics
{
    public class UserBusinessLogic
    {
        //Creo una variable de solo lectura, esta variable me permitira acceder al la base de datos y recuperar los datos necesarios
        readonly UserRepository _userRepository;

        private readonly IConfiguration _config;

        //Realizo la inyeccion de dependencias a el ambito de la clase
        public UserBusinessLogic(UserRepository usersRepository, IConfiguration config)
        {
            _userRepository = usersRepository;
            _config = config;
        }

        //Este metodo recibe como parametros el nombre y la contraseña enviada desde el front, aqui el metodo
        //con esos dos campos generara una clave encriptada la cual serivira de acceso para el usuario
        public async Task<UserInLoggedModel> GetByUserNamePass(string name, string pass)
        {
            //Creo una variable del tipo UserInLoggedModel
            var userInLogged = new UserInLoggedModel();
            //Bloque try catch para manejar excepciones y errores
            try
            {
                //Se fija si alguno de los parametros es nulo o es solo espacios en blanco
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pass))
                    throw new ArgumentException("No se especificó nombre de usuario o contreña.");
                //Si pasa la validacion llama a la funcion de la capa que se conecta con la base de datos haciendo uso de la inyeccion de dependencias
                //alli recupera el usuario de la base de datos mediante su nombre de usuario y la
                //guarda en la variable User, este usuario contiene el salt el cual se usa para generar el codigo hash de la contraseña
                var User = await _userRepository.GetByUserSaltName(name);


                //Se genera el codigo hash convinando el usuario es decir el nombre y el salt genreado al registrase, se la guarda
                //en la variable hashedPass
                string hashedPass = HashPassword(User.Password, User.Salt);

                //Se compara si el codigo de encriptacion coincide con el recuperado de la base de datos
                if (hashedPass == User.HashedPassword)
                {
                    //Si coincide recupera el nombre de usuario de la base de datos
                    var userOk = _userRepository.GetByUserName(name);
                    //Genera el token con el nombre de usuario el cual le servira en el front end, este token sirve para no exponer en
                    //los medios de almacenamiento del navegador ni la contraseña del usuario ni el hash
                    var token = GenerarJWT(userOk);

                    //Setea los datos a la variable creada anteriormente
                    userInLogged.NombreUsuario = userOk.NombreUsuario;
                    userInLogged.Token = token;

                    //Devuelve el usuario y el token
                    return userInLogged;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Este metodo genera el token con el nombre de usuario como semilla, mediante el metodo SymmetricSecurityKey
        //guarda el token y le setea una duracion de 24 horas, hace que el token se corresponda con el nombre de usuario y devuelve el token
        private string GenerarJWT(UserInLoggedModel usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(24);

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.NombreUsuario),
                new Claim("user", usuario.NombreUsuario)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: Claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Este metodo genera el Salt es la semilla que se convinara con la contraseña y nos dara el codigo hash
        private static string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[16];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        //Este metodo mediante la semilla salt y el password en este caso o cualquier otro parametro deseado genera el codigo hash, recibe como
        //parametro el password y el salt
        public string HashPassword(string password, string salt)
        {
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();

            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(salt + password);
            byte[] bytHash = hashAlg.ComputeHash(bytValue);

            return Convert.ToBase64String(bytHash);
        }

        //Metodo que registra el usuario recibe como parametros un objeto de tipo UserModel
        public string RegisterUser(UserModel user)
        {
            try
            {
                //llama mediante la inyeccion de dependencias al repositorio y busca en la base de datos si el usuario ya esta registrado
                var userExists = _userRepository.ExistUserAccount(user.Nombre);
                if (userExists != null)
                    return "El usuario ya se encuentra registrado";

                if (!string.IsNullOrWhiteSpace(user.Contraseña))
                {
                    user.Salt = CreateSalt();
                    var hashedPassword = HashPassword(user.Contraseña, user.Salt);
                    user.HashedContraseña = hashedPassword;
                }

                //llama al metodo registrar usuario luego de que paso las validaciones y lo guarda en la base de datos, pasandole como parametro
                //el objeto user del tipo UserModel que contiene los datos
                _userRepository.RegisterUser(user);

                var userInLogged = new UserInLoggedModel();
                userInLogged.NombreUsuario = user.Nombre;
                var result = GenerarJWT(userInLogged);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "Creacion exitosa";
            
        }
    }

}
