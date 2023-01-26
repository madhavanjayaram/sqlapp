using sqlapp.Models;
using System.Data.SqlClient;
namespace sqlapp.Services
{
    public class ProductService : IProductService
    {
        //private static string db_source = "dbserver-devops1.database.windows.net";
        //private static string db_user = "madhavanjayaram";
        //private static string db_password = "kl04@c!s68@22";
        //private static string db_name = "db-devops1";
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_name;

            var connectionstring = _configuration.GetConnectionString("db-devops1Connection");

            return new SqlConnection(connectionstring);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> _product_list = new List<Product>();
            string stmt = "SELECT * FROM Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(stmt);
            cmd.Connection = conn;
            using (SqlDataReader _reader = cmd.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductId = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };
                    _product_list.Add(_product);
                }
            }
            conn.Close();
            return _product_list;

        }

    }
}
