using System;
using System.Collections.Generic;
using Entities_POJOS;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class UsuarioCrudFactory : CrudFactory
    {
        UsuarioMapper mapper;

        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetCreateStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsuarios = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var u in objs)
                {
                    lstUsuarios.Add((T)Convert.ChangeType(u, typeof(T)));
                }
            }

            return lstUsuarios;
        }

        public override void Update(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(usuario));
        }

        public override void Delete(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(usuario));
        }
    }
}

