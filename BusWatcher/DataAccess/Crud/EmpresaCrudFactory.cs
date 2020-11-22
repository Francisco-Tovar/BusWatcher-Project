using System;
using System.Collections.Generic;
using Entities_POJOS;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class EmpresaCrudFactory : CrudFactory
    {
        EmpresaMapper mapper;

        public EmpresaCrudFactory() : base()
        {
            mapper = new EmpresaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var empresa = (Empresa)entity;
            var sqlOperation = mapper.GetCreateStatement(empresa);
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
            var lstEmpresas = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var e in objs)
                {
                    lstEmpresas.Add((T)Convert.ChangeType(e, typeof(T)));
                }
            }

            return lstEmpresas;
        }

        public override void Update(BaseEntity entity)
        {
            var empresa = (Empresa)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(empresa));
        }

        public override void Delete(BaseEntity entity)
        {
            var empresa = (Empresa)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(empresa));
        }
    }
}


