using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesAndEvents.Events
{
    public class PaymentCompleted
    {
        public int OrderId { get; set; }
    }
    public class PaymentFailed
    {
        public int OrderId { get; set; }
        public string? Message { get; set; }
    }
}
