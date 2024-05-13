using System.Data;
using System.Data.SqlClient;

namespace State_New.Models
{

    public class StateDataAccesslayer
    {
        string connectionstring = "Data Source=DESKTOP-LFPLM2I;Initial Catalog=emp_net;Integrated Security=True";
        public IEnumerable<StateModel> GetAllState() 
        {
            List<StateModel> liststates = new List<StateModel>();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("spGetAllState",con);
                cmd.CommandType=CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StateModel statemodel = new StateModel();
                    statemodel.State_Id = Convert.ToInt32(reader["State_Id"]);
                    statemodel.State_Name = reader["State_Name"].ToString();
                    statemodel.IsActive = Convert.ToBoolean(reader["IsActive"]);

                    liststates.Add(statemodel);
                }
                con.Close();
            }
            return liststates;
        }
        public void insertStateModel(StateModel statemodel)
        {
            using (SqlConnection con = new SqlConnection( connectionstring ))
            {
                SqlCommand cmd = new SqlCommand("spInsertState", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", statemodel.State_Name);
                cmd.Parameters.AddWithValue("@IsActive",statemodel.IsActive);

                con.Open( );
                cmd.BeginExecuteNonQuery();
                con.Close( );
            }
        }
        public void updateStateModel(StateModel statemodel)
        {
            using (SqlConnection con = new SqlConnection ( connectionstring ))
            {
                SqlCommand cmd = new SqlCommand("spUpdateState", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ("@Id", statemodel.State_Id);
                cmd.Parameters.AddWithValue("@name", statemodel.State_Name);
                cmd.Parameters.AddWithValue("@IsActive", statemodel.IsActive);
                con.Open ( );
                cmd.ExecuteNonQuery(); 
                con.Close( );
            }
        }
        public StateModel GetStateById(int id)
        {
            StateModel  stateModel = new StateModel();
            using (SqlConnection con = new SqlConnection( connectionstring ))
            {
                SqlCommand cmd = new SqlCommand("GetStateById", con);
                cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                SqlDataReader reader= cmd.ExecuteReader( );
                while (reader.Read())
                {
                    stateModel.State_Id = Convert.ToInt32(reader["State_id"]);
                    stateModel.State_Name = reader["State_name"].ToString();
                    stateModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }
                con.Close();
            }
            return stateModel;
        }
        public void deleteStateModel(int id)
        {
            using (SqlConnection  conn = new SqlConnection( connectionstring ))
            {
                SqlCommand cmd = new SqlCommand("spDeleteState", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
