using Shop_Backend.lib.Database;
using Shop_Backend.lib.ValueObjects.Models;

namespace Shop_Backend.lib.Models
{
    public abstract class AbstractModel : BaseModel
    {
        private DataBaseConnection Connection { get; }

        public AbstractModel(DataBaseConnection connection)
        {
            if (connection is null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            Connection = connection;
        }

        public List<Dictionary<string, string>> SelectAll()
        {
            string sql = this.BuildSelectSql();

            List<Dictionary<string, string>> data = this.Connection.Select(sql);

            return data;
        }

        public List<Dictionary<string, string>> SelectByPrimaryId(string primaryKeyVaule)
        {
            string sql = this.BuildSelectSql(this.primaryKey, primaryKeyVaule);

            List<Dictionary<string, string>> data = this.Connection.Select(sql);

            return data;
        }

        private string BuildSelectSql(string primaryKey = "", string primaryKeyVaule = "")
        {
            string selectFields = "";

            this.fields.ForEach(delegate (ModelElement modelElement)
            {
                if (selectFields != "")
                {
                    selectFields += ", ";
                }

                selectFields += modelElement.FieldName;
            });

            string sql = "SELECT " + selectFields + " FROM " + this.tableName;

            if (primaryKey != "" && primaryKeyVaule != "")
            {
                sql += " WHERE " + primaryKey + " = '" + primaryKeyVaule + "'";
            }

            return sql;
        }
    }
}
