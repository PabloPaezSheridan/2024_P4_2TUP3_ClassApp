using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SaleOrder
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
