using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class Bank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string BankName { get; set; }

        public string FullName { get; set; }

        public int Iban { get; set; }

        public int CVC { get; set; }

        public int InstalmentID { get; set; }

        public virtual Instalment Instalment { get; set; }
    }
}