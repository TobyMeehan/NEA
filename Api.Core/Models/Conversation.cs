using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Models
{
    public class Conversation : Entity
    {
        public string GroupId { get; set; }

        public string Name { get; set; }
    }
}
