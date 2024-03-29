﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Models
{
    // child
    public class Blog
    {
        public int Id { get; set; }
        //parent
        //Once we have users and image data the null property can go away and set to not null in database table property
        public string? BlogUserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        [Display(Name = "Blog Image")]
        //Once we have users and image data the null property can go away and set to not null in database table property
        public byte[]? ImageData { get; set; }

        [Display(Name = "Image Type")]
        //Once we have users and image data the null property can go away and set to not null in database table property
        public string? ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        // Navigation property
        [Display(Name="Author")]
        //Once we have users and image data the null property can go away and set to not null in database table property
        public virtual BlogUser? BlogUser { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
