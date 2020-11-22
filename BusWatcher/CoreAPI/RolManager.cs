
using DataAcess.Crud;
using Entities_POJOS;
using Exceptions;
using System;
using System.Collections.Generic;


namespace CoreAPI
{
    public class RolManager : BaseManager
    {
        private RolCrudFactory crudRol;

        public RolManager()
        {
            crudRol = new RolCrudFactory();
        }

        public void Create(Rol rol)
        {
            try
            {
                var r = crudRol.Retrieve<Rol>(rol);

                if (r != null)
                {
                    throw new BussinessException(3);
                }
                crudRol.Create(rol);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Rol> RetrieveAll()
        {
            return crudRol.RetrieveAll<Rol>();
        }

        public Rol RetrieveById(Rol rol)
        {
            Rol r = null;
            try
            {
                r = crudRol.Retrieve<Rol>(rol);
                if (r == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return r;
        }

        public void Update(Rol rol)
        {
            crudRol.Update(rol);
        }

        public void Delete(Rol rol)
        {
            crudRol.Delete(rol);
        }
    }
}


