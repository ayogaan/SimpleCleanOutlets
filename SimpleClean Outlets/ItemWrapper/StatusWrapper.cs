using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.ItemWrapper
{
    class StatusWrapper
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public StatusWrapper(string id, string status) {
            Id = id;
            Status = status;
        }
    }
}
