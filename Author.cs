using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignAuthor.Models
{
    public class Authors
    {
        public int AuthorId { set; get; }
        [Required(ErrorMessage ="First Name Mandotory")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last Name Mandotory")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Last Name Mandotory")]
        public string Genre { set; get; }

    }
}