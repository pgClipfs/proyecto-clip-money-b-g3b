using ClipMoney.Application.BusinessLogics;
using ClipMoney.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClipMoney.API.Controllers
{
    [Route("api/login")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        //Se crea una variable de lectura para acceder a la logica del usuario donde se realiza validaciones y todo
        //procesamiento que tenga que ver con logica de programacion
        private readonly UserBusinessLogic _userBussinessLogic;

        //Constructor de la clase recibie como parametro un objeto de tipo UserBusinessLogic y lo setea en el ambito actual
        //a este objeto lo usaremos para invocar los metodos de la logica de negocio que implican el registro del usuario
        public AuthController(UserBusinessLogic userBussinessLogic)
        {
            _userBussinessLogic = userBussinessLogic;
        }



        [HttpPost("signon")]
        public IActionResult Post(UserCredentialsModel model)
        {
            //Se crea un objeto del tipo UserInLoggedModel model este sera el que devolveremos al front end con los datos de nombre
            //de usuario y un token, por el momento solo eso mas adelante veremos lo necesario y lo agregaremos al mapeo
            UserInLoggedModel userLogged = new UserInLoggedModel();

            //utlizando el objeto pasado por el contructor llamo a la funcion que recibe como parametro el nombre de usuario
            //y la contraseña, este metodo validara que los datos coincidan y generara el token para el inicio de sesion, este metodo
            //utilizara en su capa llamados al repositorio que se comunica con la base de datos directamente para la obtencion del usuario
            //registrado, ademas tambien se hara el hash a la password y se fijara que coincida con la almacenada
            var user = _userBussinessLogic.GetByUserNamePass(model.NombreUsuario, model.Password);

            //validacion si no matchea el usuario y contraseña, validacion simple que me dice si se recupero o no el usuario
            if (user == null)
                return BadRequest("Usuario no encontrado");

            //Seteo el token y el nombre de usuario que ser recupero previamente en nuestro objeto creado al principio, devuelvo un OK http y
            //los datos del usuario
            userLogged.NombreUsuario = user.NombreUsuario;
            userLogged.Token = user.Token;

            return Ok(userLogged);
        }

        [HttpPost("signin")]
        public IActionResult SignInUser(UserModel user)
        {
            //creo una variable userRegister en donde almacenara el usuario que se va a registrar nuevo, luego devolvere el objeto del usuario
            //registrado si el registro fue exitoso, este metodo llama a la logica de negocio del usuario y hace uso del metodo register user, el 
            //cual realiza la creacion del salt para convinarlo con la contraseña y generar el hash que se guardara en la base de datos, esto se
            //realiza de esta manera por seguridad, ya que si robaran tu contraseña para acceder directamente a la base no les seria utili, necesitarian
            //el salt y el metodo de encriptacion para obtener el hash
            var userRegister = _userBussinessLogic.RegisterUser(user);
            return Ok(userRegister);
        }
    }
}




