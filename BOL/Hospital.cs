

public class Hospital
{

     public int? hospId{get;set;}
    public string? hospName{get;set;}

    public string? hospEmail{get;set;}

    public string? hospPin{get;set;}

    public Hospital(int id,string name,string email,string pin){
        this.hospId = id;
        this.hospName = name;
        this.hospEmail = email;
        this.hospPin = pin;
    }
}