using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public partial class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Obligatoriskt med rubrik!")]
        public string HeadLine { get; set; }

        [Required(ErrorMessage = "Obligatoriskt att ange text")]
        [StringLength(2000, ErrorMessage = "Beskrivning kan max vara 2000 tecken!")]
        public string BlogText { get; set; }

        [Required(ErrorMessage = "Obligatoriskt att välja datum!")]
        public DateTime Date { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
