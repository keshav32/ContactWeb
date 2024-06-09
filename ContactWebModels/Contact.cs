using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
    public class Contact
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="First name is required")]
        [Display(Name ="First Name")]
        [StringLength(ContactConstant.MAX_FIRST_NAME_LENGTH)]
        public string First_name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        [StringLength(ContactConstant.MAX_State_name_length)]
        public string Last_name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email Address")]
        [StringLength(ContactConstant.MAX_EMAIL_LENGTH)]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Mobile Phone")]
        [StringLength(ContactConstant.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage ="Invalid Phone Number")]
        public string PhonePrimary { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Home / office Phone")]
        [StringLength(ContactConstant.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneSecondary { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name ="Street Address line 1")]
        [StringLength(ContactConstant.MAX_STREET_ADDRESS_LENGTH)]
        public string Address1 { get; set; }

        [Display(Name = "Street Address line 2")]
        [StringLength(ContactConstant.MAX_STREET_ADDRESS_LENGTH)]
        public string Address2 { get; set; }

        [Required(ErrorMessage ="City is required")]
        [StringLength(ContactConstant.MAX_CITY_LENGTH)]
        public string City { get; set; }

        [Display(Name ="State")]
        [Required(ErrorMessage ="State is required")]
        public string StateID { get; set; }

        public virtual State State { get; set; }

        [Required(ErrorMessage ="The user Id is required in order to map the contact to a user correctly")]
        public String UserID { get; set; }

        [Display(Name ="Zip code")]
        [Required(ErrorMessage ="Zip code is required")]
        [StringLength(ContactConstant.MAX_ZIP_CODE_LENGTH)]
        [RegularExpression("/^[abceghjklmnprstvxy][0-9][abceghjklmnprstvwxyz]\\s?[0-9][abceghjklmnprstvwxyz][0-9]$/i" , ErrorMessage ="Zip code is invalid" ]
        public string Zip { get; set; }

        [Display(Name ="Full name")]
        public string FriendlyName => $"{First_name} {Last_name}";

        [Display(Name = "Full Address")]
        public string FriendlyAddress => State is null ? "" : String.IsNullOrWhiteSpace(Address1) ? $"{City},{State.abbrevation},{Zip}":
            String.IsNullOrWhiteSpace(Address2) ? $"{Address1} , {City} , {State.abbrevation} , {Zip}" : $"{Address1}-{Address2} ,{Zip},{City},{State.abbrevation}"

    }
}
