namespace LunchPicker.Domain
{
    public interface IUser
    {
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
    }
}
