
using DataAcess.Crud;
using Entities_POJOS;
using Exceptions;
using System;
using System.Collections.Generic;


namespace CoreAPI
{
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;

        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
        }

        public void Create(Usuario usuario)
        {
            try
            {
                var c = crudUsuario.Retrieve<Usuario>(usuario);

                if (c != null)
                {
                    //Usuario already exist
                    throw new BussinessException(3);
                }

                crudUsuario.Create(usuario);
                                
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Usuario> RetrieveAll()
        {
            return crudUsuario.RetrieveAll<Usuario>();
        }

        public Usuario RetrieveById(Usuario usuario)
        {
            Usuario c = null;
            try
            {
                c = crudUsuario.Retrieve<Usuario>(usuario);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Usuario usuario)
        {
            crudUsuario.Update(usuario);
        }

        public void Delete(Usuario usuario)
        {
            crudUsuario.Delete(usuario);
        }
    }
}
