using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.Models
{
    public class PdfContent
    {
        public int CustomerNumber { get; set; }


        public Guid DocumentNumber { get; set; }


        public string? DocumentText { get; set; }
    }
}
