using DataAcess.Dao;
using Entities_POJOS;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class UsuarioMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CEDULA = "Cedula";
        private const string DB_COL_NOMBRE = "Nombre";
        private const string DB_COL_PRIMERAPELLIDO = "PrimerApellido";
        private const string DB_COL_SEGUNDOAPELLIDO = "SegundoApellido";
        private const string DB_COL_FECHANACIMIENTO = "FechaNacimiento";
        private const string DB_COL_CORREOUSUARIO = "CorreoUsuario";
        private const string DB_COL_CONTRASENA = "Contrasena";
        private const string DB_COL_TELEFONO = "Telefono";
        private const string DB_COL_ESTADOUSUARIO = "EstadoUsuario";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, u.cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, u.nombre);
            operation.AddVarcharParam(DB_COL_PRIMERAPELLIDO, u.apellido1);
            operation.AddVarcharParam(DB_COL_SEGUNDOAPELLIDO, u.apellido2);
            operation.AddDatetimeParam(DB_COL_FECHANACIMIENTO, u.dob);
            operation.AddVarcharParam(DB_COL_CORREOUSUARIO, u.correoUsuario);
            operation.AddVarcharParam(DB_COL_CONTRASENA, u.contrasena);
            operation.AddIntParam(DB_COL_TELEFONO, u.telefono);
            operation.AddVarcharParam(DB_COL_ESTADOUSUARIO, u.estadoUsuario);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_CORREOUSUARIO, u.correoUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIOS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_PR" };

            var u = (Usuario)entity;            
            operation.AddVarcharParam(DB_COL_CEDULA, u.cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, u.nombre);
            operation.AddVarcharParam(DB_COL_PRIMERAPELLIDO, u.apellido1);
            operation.AddVarcharParam(DB_COL_SEGUNDOAPELLIDO, u.apellido2);
            operation.AddDatetimeParam(DB_COL_FECHANACIMIENTO, u.dob);
            operation.AddVarcharParam(DB_COL_CORREOUSUARIO, u.correoUsuario);
            operation.AddVarcharParam(DB_COL_CONTRASENA, u.contrasena);
            operation.AddIntParam(DB_COL_TELEFONO, u.telefono);
            operation.AddVarcharParam(DB_COL_ESTADOUSUARIO, u.estadoUsuario);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USUARIO_PR" };

            var c = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_CORREOUSUARIO, c.correoUsuario);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var usuario = BuildObject(row);
                lstResults.Add(usuario);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                cedula= GetStringValue(row, DB_COL_CEDULA),
                nombre = GetStringValue(row, DB_COL_NOMBRE),
                apellido1 = GetStringValue(row, DB_COL_PRIMERAPELLIDO),
                apellido2 = GetStringValue(row, DB_COL_SEGUNDOAPELLIDO),
                dob = GetDateValue(row, DB_COL_FECHANACIMIENTO),
                correoUsuario = GetStringValue(row, DB_COL_CORREOUSUARIO),
                contrasena = GetStringValue(row, DB_COL_CONTRASENA),
                telefono = GetIntValue(row, DB_COL_TELEFONO),
                estadoUsuario = GetStringValue(row, DB_COL_ESTADOUSUARIO)
            };

            return usuario;
        }
                
    }
}

