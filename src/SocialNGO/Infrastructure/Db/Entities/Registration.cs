using SocialNGO.Common.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocialNGO.Infrastructure.Db.Entities
{
    /// <summary> </summary>
    [Table(TableSchema.Registration)]
    public class Registration: BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public Roles role { get; set; }

        /// <summary>
        /// 
        /// </summary>


        public string EmailId { get; set; }

       public string MobileNumber { get; set; }
       
       public string AlternateMobileNumber { get; set; }

        public Date DOB { get; set; }
        public string Gender { get; set; }
        public  BloodGroup bloodGroup { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddressLine2 { get; set; }

        public  City city { get; set; }

        public  State state { get; set; }
        public  Country country { get; set; }

        public  Region region { get; set; }

        public string PostalCode { get; set; }

        public string EmpCode { get; set; }
        public string OfficeName { get; set; }
        public  Department department { get; set; }

        public  Designation degsignation { get; set; }
        public  PostingBlock postingBlock { get; set; }

        public  PostingCity postingCity { get; set; }

        public  PostingState postingState { get; set; }

        public string Nominee1 { get; set; }

        public string Nominee1Relation { get; set; }

        public string Nominee1MobileNumber { get; set; }
        public string Nominee2 { get; set; }

        public string Nominee2Relation { get; set; }

        public string Nominee2MobileNumber { get; set; }

        public bool IsDesease { get; set; }

        public string DeseaseDescription { get; set; }

        public bool IsAlreadyRegister { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

        public bool IsConfirmed { get; set; }

        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }

        public Date RegistrationDate { get; set; }
    }
}
