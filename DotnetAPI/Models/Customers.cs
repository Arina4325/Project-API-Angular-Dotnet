
namespace DotnetAPI.Models
{
    public partial class Customers
    {
        public int CustomerId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string CustomerRole {get; set;}
        public int PhoneNumber {get; set;}
        public bool Active {get; set;}

        public Customers()
        {
            if (FirstName == null)
            {
                FirstName = "";
            }
            if (LastName == null)
            {
                LastName = "";
            }
            if (CustomerRole == null)
            {
                CustomerRole = "";
            }

        }

    }

}