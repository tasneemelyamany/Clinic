using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;



namespace Clinic
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public class ClinicDataAccess
            {
                private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ClinicConnection"].ConnectionString;

                public List<Clinic> GetClinicsFromDatabase()
                {
                    List<Clinic> clinics = new List<Clinic>();

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT * FROM Clinics";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Clinic clinic = new Clinic
                                    {
                                        Id = Convert.ToInt32(reader["Id"]),
                                        Name = reader["Name"].ToString(),
                                        PhoneNumber = reader["Phone Number"].ToString(),
                                        Description = reader["Description"].ToString(),
                                    };

                                    clinics.Add(clinic);
                                }
                            }
                        }
                    }

                    return clinics;
                }
            }

    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Image1.ImageUrl = "E:\\visualstudio\\GUC.lib\\Clinic\\Clinic\\German_University_in_Cairo_Logo.jpg";
                Label1.Text = "GUC Clinics for your service";
                //connection data base
                ClinicDataAccess dataAccess = new ClinicDataAccess();
                List<Clinic> clinics = dataAccess.GetClinicsFromDatabase();
                clinicGridView.DataSource = clinics;
                clinicGridView.DataBind();
            }

        }
    }
}