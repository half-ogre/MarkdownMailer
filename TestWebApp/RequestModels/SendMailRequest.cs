using System.ComponentModel.DataAnnotations;

namespace TestWebApp {
    public class SendMailRequest {
        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string Subject { get; set; }
        
        [DataType(DataType.MultilineText), Required]
        public string Body { get; set; }
    }
}