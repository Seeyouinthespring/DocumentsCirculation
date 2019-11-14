using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.Models
{
    public class Worker
    {
        public int workerID { get; set; }
        public string fio { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime employdate { get; set; }
        public decimal salary { get; set; }

        List<Worker> WorkerList { get; set; }
    }
}