using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Receiver
    {
        public int ReceiverId { get; set; }

        [Required (ErrorMessage = "Error 27082100. ")]
        public string CurrentUserId { get; set; }

        // Паспортные данные и ИНН

        [Required (ErrorMessage = "Необходимо ввести Гражданство")]
        public string Nationality { get; set; } // 1. Гражданство
        
        [Required (ErrorMessage = "Необходимо ввести Серию паспорта")]
        [StringLength(4, MinimumLength = 1)]
        public string PassportSeries { get; set; } // 2. Серия паспорта
        
        [Required (ErrorMessage = "Необходимо ввести Номер паспорта")]
        [StringLength(7, MinimumLength = 1)]
        public string PassportID { get; set; } // 3. Номер паспорта
        
        [Required (ErrorMessage = "Необходимо ввести Дата выдачи паспорта")]
        public DateTime PassportIssueDate { get; set; } // 4. Дата выдачи
        
        [Required(ErrorMessage = "Необходимо ввести Кем выдан паспорт")]
        [StringLength(150, MinimumLength = 5)]
        public string PassportIssuedBy { get; set; } // 5. Кем выдан

        [Required(ErrorMessage = "Необходимо ввести Фамилию")]
        [StringLength(70)]
        public string SecondName { get; set; } // 6. Фамилия

        [Required(ErrorMessage = "Необходимо ввести Имя")]
        [StringLength(70)]
        public string FirstName { get; set; } // 7. Имя

        [Required(ErrorMessage = "Необходимо ввести Отчество")]
        [StringLength(70)]
        public string Surname { get; set; } // 8. Отчество


        // Адрес регистрации
        
        [Required]
        public string Country { get; set; } // 9. Страна
        
        [Required]
        public string Region { get; set; } // 10. Область
        
        [Required]
        public string City { get; set; } // 11. Город
        
        [Required]
        public string Street { get; set; } // 12. Улица
        
        [Required]
        public int House { get; set; } // 13. Дом
        
        [Required]
        public string HouseBuildingNumber { get; set; } // 14. Корпус
        
        [Required]
        public int Flat { get; set; } // 15. Квартира
        
        [Required]
        public string Index { get; set; } // 16. Индекс
        
        [Required]
        public string Phone { get; set; } // 17. Контактный номер

        [Required]
        public string PassportScan { get; set; } // 18. Скан паспорта

        public string Description { get; set; } = "";

        public bool IsDefault { get; set; } = false;

        // ---
        [StringLength(70)]
        public string Email { get; set; }
        public string Iin { get; set; }

        public int Hide { get; set; } = 0;
        public DateTime? Birthdate { get; set; }
        public int? Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Fullname { get; set; }
        public string Passport { get; set; }
        public string PassportHumanDate { get; set; }
        public string PassportDateForm { get; set; }
        public string BirthdateForm { get; set; }

        public int SbsId { get; set; }

        // Relatins Object
        public List<Purchase> Purchases { get; set; }
    }
}
