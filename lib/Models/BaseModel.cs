using Shop_Backend.lib.ValueObjects.Models;

namespace Shop_Backend.lib.Models
{
    public abstract class BaseModel
    {
        protected string tableName = "";
        protected string primaryKey = "";
        protected List<ModelElement> fields = new List<ModelElement>();

        protected void InitModel(string tableName, string primaryKey)
        {
            this.tableName = tableName;
            this.primaryKey = primaryKey;

            fields.Add(new ModelElement(primaryKey));
        }

        protected void AddFields(string fieldname)
        {
            fields.Add(new ModelElement(fieldname));
        }
    }
}
