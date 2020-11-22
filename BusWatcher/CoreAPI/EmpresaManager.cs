
using DataAcess.Crud;
using Entities_POJOS;
using Exceptions;
using System;
using System.Collections.Generic;


namespace CoreAPI
{
    public class EmpresaManager : BaseManager
    {
        private EmpresaCrudFactory crudEmpresa;

        public EmpresaManager()
        {
            crudEmpresa = new EmpresaCrudFactory();
        }

        public void Create(Empresa empresa)
        {
            try
            {
                var e = crudEmpresa.Retrieve<Empresa>(empresa);

                if (e != null)
                {
                    throw new BussinessException(3);
                }
                crudEmpresa.Create(empresa);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Empresa> RetrieveAll()
        {
            return crudEmpresa.RetrieveAll<Empresa>();
        }

        public Empresa RetrieveById(Empresa empresa)
        {
            Empresa e = null;
            try
            {
                e = crudEmpresa.Retrieve<Empresa>(empresa);
                if (e == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return e;
        }

        public void Update(Empresa empresa)
        {
            crudEmpresa.Update(empresa);
        }

        public void Delete(Empresa empresa)
        {
            crudEmpresa.Delete(empresa);
        }
    }
}

