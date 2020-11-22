using CoreAPI;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class EmpresaController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new EmpresaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new EmpresaManager();
                var empresa = new Empresa
                {
                    cedulaJuridica = id
                };

                empresa = mng.RetrieveById(empresa);
                apiResp = new ApiResponse();
                apiResp.Data = empresa;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Empresa empresa)
        {

            try
            {
                var mng = new EmpresaManager();
                apiResp = new ApiResponse();
                var temp = mng.RetrieveById(empresa);
                if (temp == null)
                {
                    mng.Create(empresa);
                    apiResp.Message = "Empresa ha sido creada.";
                    return Ok(apiResp);
                }
                else
                {
                    apiResp.Message = "Empresa ya existe.";
                    return Ok(apiResp);
                }


            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Empresa empresa)
        {
            try
            {
                var mng = new EmpresaManager();
                mng.Update(empresa);

                apiResp = new ApiResponse();
                apiResp.Message = "Empresa ha sido modificada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Empresa empresa)
        {
            try
            {
                var mng = new EmpresaManager();
                mng.Delete(empresa);

                apiResp = new ApiResponse();
                apiResp.Message = "Empresa ha sido eliminada.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}