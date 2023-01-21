namespace BOL;

public class Admin
{

    public int Id{get;set;}

    public string? UserName{get;set;}

    public string? Password {get;set;}

    public Admin(int id, string username,string password){
        this.Id = id;
        this.UserName =username;
        this.Password = password;
    }
   
}
