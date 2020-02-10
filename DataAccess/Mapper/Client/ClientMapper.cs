using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using POJOS;

namespace DataAccess.Mapper.Client
{
    public class ClientMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_LAST_NAME = "LAST_NAME";
        private const string DB_COL_OLD = "OLD";
        private const string DB_COL_EMAIL = "EMAIL";
        //dcordoba@coffebitcr.com

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var entity = BuildObject(row);
                lstResults.Add(entity);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var client = new ClientType()
            {
                Id = GetIntValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                LastName = GetStringValue(row, DB_COL_LAST_NAME),
                Old = GetIntValue(row, DB_COL_OLD),
                Email = GetStringValue(row, DB_COL_EMAIL)
            };

            return client;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CLIENT_PR" };

            var c = (ClientType)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddVarcharParam(DB_COL_LAST_NAME, c.LastName);
            operation.AddIntParam(DB_COL_OLD, c.Old);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CLIENT_PR" };

            var c = (ClientType)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CLIENT_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CLIENT_PR" };

            var c = (ClientType)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddVarcharParam(DB_COL_LAST_NAME, c.LastName);
            operation.AddIntParam(DB_COL_OLD, c.Old);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CLIENT_PR" };

            var c = (ClientType)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }
    }
}
