using System;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Book
    {
        private static Random random = new Random();
        
        public int ID { set; get; }
        [Display(Name = "Название книги")]
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Author { set; get; }
        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string BookName { set; get; }
        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public decimal Price { get; set; }
        public static Book build()
        {
            int index = random.Next(0, 1000);
            return new Book()
            {
                  ID = index,
                  BookName = "Book_" + index,
                  Price = 5 * index,
                  Author = "Autotho_" + index
            };
        }
    }
}