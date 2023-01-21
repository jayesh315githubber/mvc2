namespace BLL;
using DAL;
using BOL;


public class AppManager
{
    public bool doValidate(string username, string password)
    {
        List<Admin> allAdmin = DBManager.getAllAdminFromDB();

        foreach (Admin admin in allAdmin)
        {
            if (admin.UserName == username && admin.Password == password)
            {
                return true;
            }
        }
        return false;
    }

    public List<Hospital> geAllHopitals()
    {
        List<Hospital> allHospitals = DBManager.getAllHospitalFromDB();
        return allHospitals;
    }

    public bool InsertHospital(string name, string email, string pin){
        
      bool status =  DBManager.InsertIntoDatabase(name,email,pin);
Console.WriteLine(status + "in manager");
      return status;
    }
}
