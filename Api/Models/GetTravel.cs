using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class GetTravel
    {
        public Guid Id { get; set; }

        public string Destiny { get; set; }

        public String Date { get; set; }

        public String DateRegister { get; set; }
    }
}
