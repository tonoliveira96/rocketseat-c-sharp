namespace MyFirstApi.Comunication.Requests
{
    public class RequestChangePasswordJson
    {
        public string Currentpassword { get; set; }  = string.Empty;
        public string  NewPassword { get; set; } = string.Empty ;
    }
}
