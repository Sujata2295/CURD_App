using System.Data;
using System.Data.SqlClient;

namespace State_New.Models
{
    public class CityDataAccessLayer
    {
        string conntionstring = "Data Source=DESKTOP-LFPLM2I;Initial Catalog=emp_net;Integrated Security=True";
        public IEnumerable<CityModel> GetAllCity()
        {
            List<CityModel> listcity = new List<CityModel>();
            using(SqlConnection conn = new SqlConnection(conntionstring))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCity",conn);
                cmd.CommandType=CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CityModel citymodel = new CityModel();
                    citymodel.City_Id = Convert.ToInt32(reader["City_Id"]);
                    citymodel.City_Name = reader["City_Name"].ToString();
                    citymodel.State_Id = Convert.ToInt32(reader["State_id"]);
                    citymodel.State_Name = reader["State_Name"].ToString();
                    citymodel.IsActive = Convert.ToBoolean(reader["IsActive"]);

                    listcity.Add(citymodel);
                }
                conn.Close();
            }
            return listcity;
        }
        public void deleteCityModel(int id)
        {
            //using(SqlConnection conn = new SqlConnection(connectionString))
            //{

            //}
        }
    }
}
