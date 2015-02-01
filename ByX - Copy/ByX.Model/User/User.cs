using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ByX.Model.Common;


namespace ByX.Model
{
    public class User : Entity<int>
    {

        public User()
        {
          
            IsActive = false;
            RoleId = 2;
            RememberMe = false;
            UserPhoneQuota = 2;

        }
        [Key]
        [Column(Order=2)]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UserUniqueId { get; set; }

       
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        public string Password { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; }

        public string CellPhone { get; set; }


        [Required(ErrorMessage = "{0} alanı gereklidir!")]

        [Display(Name = "E-Posta")]

        public string Email { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir!")]


        public string Name { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]

        public string SureName { get; set; }
        //[StringLength(20, ErrorMessage = "{0} alanı en fazla {1}  uzunluğunda olmalıdır!", MinimumLength = 1)]
        //[Required(ErrorMessage = "{0} alanı gereklidir!")]
        //[Required(ErrorMessage = "{0} alanı gereklidir!")]

        public string City { get; set; }

        public bool IsActive { get; set; }
        public bool RememberMe { get; set; }
        public string LastLoginIp { get; set; }
        public DateTime? LastLoginDate { get; set; }
      

        public string Salt { get; set; }

        public  int UserPhoneQuota { get; set; }

        public ICollection<PhoneDetail.PhoneDetail> PhoneDetail { get; set; }


    }
}
