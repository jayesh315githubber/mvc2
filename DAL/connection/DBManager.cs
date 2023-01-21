namespace DAL;
using BOL;
using MySql.Data.MySqlClient;

public class DBManager
{
    public static string conString = @"server=localhost;port=3306;user=root;password=jayesh@974;database=highwayHelp";

    public static List<Admin> getAllAdminFromDB()
    {

        List<Admin> allAdmin = new List<Admin>();

        MySqlConnection con = new MySqlConnection(conString);


        try
        {
            string query = "select * from adminLoginCradentials";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string username = reader["UserName"].ToString();
                string password = reader["Password"].ToString();

                Admin newAdmin = new Admin(id, username, password);
                allAdmin.Add(newAdmin);

            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return allAdmin;
    }


    public static List<Hospital> getAllHospitalFromDB()


    {

        Console.WriteLine("----------------------");
        List<Hospital> allHospitals = new List<Hospital>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "select * from hospitaldetails";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = int.Parse(reader["hospId"].ToString());
                Console.WriteLine(id);
                string name = reader["hospName"].ToString();
                string email = reader["hospEmail"].ToString();
                string pin = reader["hospPin"].ToString();

                Hospital newHospital = new Hospital(id, name, email, pin);
                allHospitals.Add(newHospital);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return allHospitals;
    }

    public static bool InsertIntoDatabase(string name, string email, string pin)
    {

        bool status = false;
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = "INSERT INTO hospitalDetails(hospName,hospEmail,hospPin) " +
                            "VALUES('" + name + "','" + email + "','" + pin +"');" ;
            con.Open();
            Console.WriteLine(query);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandText=query;
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }
}
