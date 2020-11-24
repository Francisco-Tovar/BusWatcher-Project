﻿using DataAcess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class ListOptionMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_LIST_ID = "ListId";
        private const string DB_LIST_VALUE = "Value";
        private const string DB_LIST_DESC = "Description";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var option = BuildObject(row);
                lstResults.Add(option);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var listOption = new OptionList
            {
                ListId = GetStringValue(row, DB_LIST_ID),
                Value = GetStringValue(row, DB_LIST_VALUE),
                Description = GetStringValue(row, DB_LIST_DESC),
            };

            return listOption;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LIST_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
