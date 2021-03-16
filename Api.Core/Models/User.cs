using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
    }
}
