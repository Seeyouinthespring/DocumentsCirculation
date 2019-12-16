using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class Worker
    {
        [Display(Name = "ID работника")]
        public int workerID { get; set; }

        [Display(Name = "ФИО")]
        public string fio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime birthdate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата приема")]
        public DateTime employdate { get; set; }

        [Display(Name = "Зарплата")]
        public decimal salary { get; set; }

        [Display(Name = "Должность")]
        public string role { get; set; }

        List<Worker> WorkerList { get; set; }
    }
}