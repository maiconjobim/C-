using System.ComponentModel.DataAnnotations;

namespace ApiAula.models
{   
   public class Product
    {
        [Key]
        public int Id { get; set; }         
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Title { get; set; }

        public string Descripition { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = "o Preço deve ser maior que zero")]        
        public decimal  Price { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = "Categoria Inválida" )]        
        public int categoryId {get; set;}

        public Category Category{get; set;}



    }

}