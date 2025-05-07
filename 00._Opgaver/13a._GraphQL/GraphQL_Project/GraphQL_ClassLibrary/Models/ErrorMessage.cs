using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_ClassLibrary.Models
{
    public class ErrorMessage
    {
        public string? Message { get; set; }
        public int? ErrorCode { get; set; }
    }
}
