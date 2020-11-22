using CoreAPI;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class UsuarioController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/usuario
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
       
        // GET api/usuario/5
        // Retrieve by Cedula
        public IHttpActionResult Get(string correo)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    correoUsuario = correo
                };

                usuario = mng.RetrieveById(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Usuario usuario)
        {

            try
            {
                var mng = new UsuarioManager();
                mng.Create(usuario);
                apiResp = new ApiResponse();                               
                apiResp.Message = "Accion ejecutada con éxito.";
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Update(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "Usuario ha sido modificado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Delete(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "Usuario ha sido eliminado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
