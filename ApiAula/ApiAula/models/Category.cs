
using System.ComponentModel.DataAnnotations;

namespace ApiAula.models
{

    public class Category
    {
       
        [Key]
        public int Id { get; set; }         
        
        public string Title {get; set;}

        
    }




}