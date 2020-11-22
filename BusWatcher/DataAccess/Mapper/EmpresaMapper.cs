using DataAcess.Dao;
using Entities_POJOS;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class EmpresaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CEDULAJURIDICA = "CedulaJuridica";
        private const string DB_COL_NOMBRECOMERCIAL = "NombreComercial";
        private const string DB_COL_NOMBRELEGAL = "NombreLegal";
        private const string DB_COL_PAGINAWEB = "PaginaWeb";
        private const string DB_COL_TELEFONO = "Telefono";
        private const string DB_COL_ESTADOEMPRESA = "EstadoEmpresa";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_EMPRESA_PR" };

            var e = (Empresa)entity;
            operation.AddVarcharParam(DB_COL_CEDULAJURIDICA, e.cedulaJuridica);
            operation.AddVarcharParam(DB_COL_NOMBRECOMERCIAL, e.nombreComercial);
            operation.AddVarcharParam(DB_COL_NOMBRELEGAL, e.nombreLegal);
            operation.AddVarcharParam(DB_COL_PAGINAWEB, e.paginaWeb);
            operation.AddIntParam(DB_COL_TELEFONO, e.telefono);
            operation.AddVarcharParam(DB_COL_ESTADOEMPRESA, e.estadoEmpresa);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_EMPRESA_PR" };

            var e = (Empresa)entity;
            operation.AddVarcharParam(DB_COL_CEDULAJURIDICA, e.cedulaJuridica);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_EMPRESAS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_EMPRESA_PR" };

            var e = (Empresa)entity;
            operation.AddVarcharParam(DB_COL_CEDULAJURIDICA, e.cedulaJuridica);
            operation.AddVarcharParam(DB_COL_NOMBRECOMERCIAL, e.nombreComercial);
            operation.AddVarcharParam(DB_COL_NOMBRELEGAL, e.nombreLegal);
            operation.AddVarcharParam(DB_COL_PAGINAWEB, e.paginaWeb);
            operation.AddIntParam(DB_COL_TELEFONO, e.telefono);
            operation.AddVarcharParam(DB_COL_ESTADOEMPRESA, e.estadoEmpresa);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_EMPRESA_PR" };

            var e = (Empresa)entity;
            operation.AddVarcharParam(DB_COL_CEDULAJURIDICA, e.cedulaJuridica);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var empresa = BuildObject(row);
                lstResults.Add(empresa);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var empresa = new Empresa
            {
                cedulaJuridica = GetStringValue(row, DB_COL_CEDULAJURIDICA),
                nombreComercial = GetStringValue(row, DB_COL_NOMBRECOMERCIAL),
                nombreLegal = GetStringValue(row, DB_COL_NOMBRELEGAL),
                paginaWeb= GetStringValue(row, DB_COL_PAGINAWEB),
                telefono = GetIntValue(row, DB_COL_TELEFONO),
                estadoEmpresa = GetStringValue(row, DB_COL_ESTADOEMPRESA)
            };

            return empresa;
        }

    }
}

