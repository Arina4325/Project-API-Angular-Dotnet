
namespace DotnetAPI.Models
{
    public partial class UserJobInfo
    {
        public int UserId {get; set;}
        public string JobTitle {get; set;}
        public string Depertment {get; set;}


        public UserJobInfo()
        {
            if (JobTitle == null)
            {
                JobTitle = "";
            }
            if (Depertment == null)
            {
                Depertment = "";
            }
         
        }

    }

}