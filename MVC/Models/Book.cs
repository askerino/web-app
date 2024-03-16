using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Book : IValidatableObject
    {
        public int Id { get; set; }
        [Display(Name = "書名")]
        [Required(ErrorMessage = "{0}は必須です。")]
        public string Title { get; set; } = String.Empty;
        [Display(Name = "価格")]
        [DataType(DataType.Currency)]
        [Range(0, 5000, ErrorMessage = "{0}は{1}～{2}以内で入力してください。")]
        public int Price { get; set; }
        [Display(Name = "出版社")]
        [StringLength(20, ErrorMessage = "{0}は{1}文字以内で入力してください。")]
        public string Publisher { get; set; } = String.Empty;
        [Display(Name = "配布サンプル")]
        public bool Sample { get; set; }
        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Publisher == "DPub" && this.Price > 0)
            {
                yield return new ValidationResult("DPubの価格は0円でなければいけません。");
            }
        }
    }
}
