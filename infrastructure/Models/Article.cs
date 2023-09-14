using System.ComponentModel.DataAnnotations;

namespace infrastructure.DataModels;

public class Article
{
    public int ArticleId { get; set; }
    
    [MinLength(5)]
    [MaxLength(30)]
    public string Headline { get; set; }
    
    [MaxLength(1000)]
    public string Body { get; set; }
    
    
    [ValueIsOneOf(new []{"Bob", "Rob", "Dob", "Lob"})]
    public string Author { get; set; }
    public string ArticleImgUrl { get; set; }
    
    public class ValueIsOneOf : ValidationAttribute
    {
        private readonly string[] _validStrings;
        private readonly string? _errorMessage;

        public ValueIsOneOf(string[] validStrings, string? errorMessage = "")
        {
            _validStrings = validStrings;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object? givenString, ValidationContext validationContext)
        {
            if (!_validStrings.Contains(givenString))
            {
                return new ValidationResult(_errorMessage);
            }

            return ValidationResult.Success!;
        }
    }
}