using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;

namespace CS.Model {
    public class MyModel {
        public static DataTable GetCategories() {
            DataTable dataTableCategories = new DataTable();
            using(OleDbConnection connection = GetConnection()) {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = "SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]";
                adapter.Fill(dataTableCategories);
            }
            return dataTableCategories;
        }
        public static DataTable GetProducts(object masterRowKey) {
            DataTable dataTableProducts = new DataTable();
            using(OleDbConnection connection = GetConnection()) {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = "SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Products]";

                if(masterRowKey != null) {
                    adapter.SelectCommand.CommandText += "WHERE [CategoryID] = @CategoryID";
                    
                    adapter.SelectCommand.Parameters.Add("@CategoryID", OleDbType.SmallInt);
                    adapter.SelectCommand.Parameters["@CategoryID"].Value = masterRowKey;
                    adapter.Fill(dataTableProducts);
                }
                
            }
            return dataTableProducts;
        }

        static OleDbConnection GetConnection() {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/nwind.mdb"));
            return connection;
        }

    }

    public class MyViewModel {
        public DataTable Categories { get; set; }
        public DataTable Products { get; set; }
    }
}