using Shop_Backend.lib.Database;
using Shop_Backend.lib.Models;

namespace Shop_Backend.src.Models.Articel
{
    public class ArticelModel : AbstractModel
    {
        public ArticelModel(DataBaseConnection connection) : base(connection)
        {
            this.InitModel("articel", "ID");
            this.AddFields("title");
            this.AddFields("description");
            this.AddFields("category_id");
            this.AddFields("user_id");
            this.AddFields("timestamp");
            this.AddFields("last_changed");
            this.AddFields("active");
        }
    }
}
