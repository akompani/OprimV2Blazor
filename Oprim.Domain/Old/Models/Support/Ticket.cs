using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Support
{
    public class Ticket
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "لطفا نوع را انتخاب کنید")]
        [Range(1,3,ErrorMessage = "لطفا مقصد تیکت را انتخاب کنید")]
        [Display(Name = "مقصد تیکت")]
        public byte TicketType { get; set; }

        [Display(Name = "زمان ایجاد تیکت")]
        public DateTime TicketTime { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage = "لطفا ایمیل را صحیح وارد کنید")]
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        public string UserEmail { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "لطفا موضوع را وارد کنید")]
        [Display(Name = "موضوع تیکت")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "لطفا توضیحات را وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Notes { get; set; }

        [Display(Name = "وضعیت")]
        public byte Situation { get; set; }

        [Display(Name = "تاریخ پاسخ")]
        public DateTime AnswerDate { get; set; }

        [Display(Name = "پاسخ")]
        public string AnswerNotes { get; set; }

        [Display(Name = "کاربر پاسخگو")]
        public string AnswerUserId { get; set; }

    }
}
