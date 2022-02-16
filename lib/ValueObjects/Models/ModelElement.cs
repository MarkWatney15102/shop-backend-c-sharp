namespace Shop_Backend.lib.ValueObjects.Models
{
    public class ModelElement
    {
        private string fieldName;

        public ModelElement(string fieldname)
        {
            this.fieldName = fieldname;
        }

        public string FieldName { get { return fieldName;} }
    }
}
