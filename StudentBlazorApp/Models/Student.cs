using System;
using System.ComponentModel.DataAnnotations;

namespace StudentBlazorApp.Models
{
  public class Student
  {
    [Key]
    [Display(Name = "ID #")]
    public string StudentId { get; set; }

    [Display(Name = "First Name")]
    [Required]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required]
    public string LastName { get; set; }

    [Display(Name = "Email Address")]
    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [MaxLength(15)]
    [Display(Name = "Mobile Number")]
    [Phone]
    [Required]
    public string MobileNumber { get; set; }

    [Display(Name = "Area of Specialization")]
    [Required]
    public string Specialization { get; set; }

    [Display(Name = "City of Residence")]
    [Required]
    public string City { get; set; }

    [Display(Name = "Province of Residence")]
    [Required]
    public string Province { get; set; }

    [Required]
    public string Employer { get; set; }
  }

}
