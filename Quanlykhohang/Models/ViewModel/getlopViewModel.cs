
namespace Quanlykhohang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class getlopViewModel
    {
        [NotMapped] 
        public int Id { get; set; } 
        public string tensv { get; set; }
        public string masv { get; set; }
        public string tenlop { get; set; }
        public string dia_chi { get; set; }
        public string tenkhoa { get; set; }
    }
}
