using Microsoft.AspNetCore.Mvc;
using Shop_Backend.lib.Database;

namespace Shop_Backend.lib.Controller
{
    public abstract class AbstractController : ControllerBase
    {
        protected DataBaseConnection Connection { get; }

        public AbstractController(DataBaseConnection connection)
        {
            if (connection is null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            Connection = connection;
        }
    }
}
