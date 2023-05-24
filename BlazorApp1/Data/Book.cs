using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }
        [Required(ErrorMessage = "Please Enter Valid Book Name.")]
        [StringLength(25,ErrorMessage ="Book Name Can Not Exceed 20 Character")]
        
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Please Enter Book Category.")]
        

        public string Category { get; set; } = "";
        [Required(ErrorMessage = "Please Enter Book Author.")]
        [StringLength(25, ErrorMessage = "Author Name Can Not Exceed 20 Character")]
        public string Author { get; set; } = "";
        [Required(ErrorMessage = "Please Enter Book Pages.")]
        [Range(100,2000,ErrorMessage = "Book Pages Must Be In Rang 100 : 2000 Page.")]
        public int NumberOfPages { get; set; } = 0;
    }
    public enum CategoryItems
    {
        Adventure=1,
        Biography=2,
        Sport=3,
        Business_Economics= 4,
        Children=5,
        Classics = 6,
        Education=7,
        History=9,
        Philosophy=10

    }
}
