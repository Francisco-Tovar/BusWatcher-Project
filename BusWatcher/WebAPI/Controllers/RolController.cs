using CoreAPI;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class RolController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new RolManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new RolManager();
                var rol = new Rol
                {
                    nombreRol = id
                };

                rol = mng.RetrieveById(rol);
                apiResp = new ApiResponse();
                apiResp.Data = rol;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Rol rol)
        {

            try
            {
                var mng = new RolManager();
                apiResp = new ApiResponse();
                var temp = mng.RetrieveById(rol);
                if (temp == null)
                {
                    mng.Create(rol);
                    apiResp.Message = "Rol ha sido creado.";
                    return Ok(apiResp);
                }
                else
                {
                    apiResp.Message = "Rol ya existe.";
                    return Ok(apiResp);
                }


            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Rol rol)
        {
            try
            {
                var mng = new RolManager();
                mng.Update(rol);

                apiResp = new ApiResponse();
                apiResp.Message = "Rol ha sido modificado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Rol rol)
        {
            try
            {
                var mng = new RolManager();
                mng.Delete(rol);

                apiResp = new ApiResponse();
                apiResp.Message = "Rol ha sido eliminado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}