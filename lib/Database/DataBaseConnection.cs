using MySql.Data.MySqlClient;

namespace Shop_Backend.lib.Database
{
    public class DataBaseConnection : IDisposable
    {
        public MySqlConnection Connection { get; set; }

        private bool disposedValue;

        public DataBaseConnection(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public List<Dictionary<string, string>> Select(string selectionString)
        {
            var rows = new List<Dictionary<string, string>>();
            using var command = new MySqlCommand(selectionString, Connection)
            {
                CommandTimeout = 60
            };
            using var reader = command.ExecuteReader();

            if (reader.HasRows && reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    var row = new Dictionary<string, string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var name = reader.GetName(i);
                        var value = reader.GetString(i);
                        row.Add(name, value);
                    }
                    rows.Add(row);
                }
            }
            return rows;
        }

        public int Execute(string insertString)
        {
            using var command = new MySqlCommand(insertString, Connection);
            return command.ExecuteNonQuery();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Connection.Close();
                Connection.Dispose();
                disposedValue = true;
            }
        }

        ~DataBaseConnection()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
