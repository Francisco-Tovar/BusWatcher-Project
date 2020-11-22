﻿using System;
using System.Collections.Generic;
using Entities_POJOS;
using DataAcess.Mapper;
using DataAcess.Dao;


namespace DataAcess.Crud
{
    public class RolCrudFactory : CrudFactory
    {
        RolMapper mapper;

        public RolCrudFactory() : base()
        {
            mapper = new RolMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var rol = (Rol)entity;
            var sqlOperation = mapper.GetCreateStatement(rol);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
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
            var lstRoles = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var r in objs)
                {
                    lstRoles.Add((T)Convert.ChangeType(r, typeof(T)));
                }
            }

            return lstRoles;
        }

        public override void Update(BaseEntity entity)
        {
            var rol = (Rol)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(rol));
        }

        public override void Delete(BaseEntity entity)
        {
            var rol = (Rol)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(rol));
        }
    }
}



