namespace BookingServices.Model.UserModels;

public class LoginResponseModel 
{
    public UserDTO UserInfor { get; set; }
    public string JwtToken { get; set; }
}
