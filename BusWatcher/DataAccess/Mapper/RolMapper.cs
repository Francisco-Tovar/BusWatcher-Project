using DataAcess.Dao;
using Entities_POJOS;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class RolMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_NOMBREROL = "NombreRol";
        private const string DB_COL_ESTADOROL = "EstadoRol";
        private const string DB_COL_IDROL = "IdRol";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ROL_PR" };

            var r = (Rol)entity;
            operation.AddVarcharParam(DB_COL_NOMBREROL, r.nombreRol);
            operation.AddVarcharParam(DB_COL_ESTADOROL, r.estadoRol);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ROL_PR" };

            var r = (Rol)entity;
            operation.AddVarcharParam(DB_COL_NOMBREROL, r.nombreRol);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ROLES_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ROL_PR" };

            var r = (Rol)entity;
            operation.AddVarcharParam(DB_COL_NOMBREROL, r.nombreRol);
            operation.AddVarcharParam(DB_COL_ESTADOROL, r.estadoRol);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ROL_PR" };

            var r = (Rol)entity;
            operation.AddVarcharParam(DB_COL_NOMBREROL, r.nombreRol);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var rol = BuildObject(row);
                lstResults.Add(rol);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var rol = new Rol
            {
                idRol = GetIntValue(row,DB_COL_IDROL),
                nombreRol = GetStringValue(row, DB_COL_NOMBREROL),
                estadoRol = GetStringValue(row, DB_COL_ESTADOROL)
            };

            return rol;
        }

    }
}


