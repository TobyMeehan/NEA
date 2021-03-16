using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Models
{
    public class Message : Entity
    {
        public string AuthorId { get; set; }
        public string ConversationId { get; set; }

        public string Body { get; set; }
    }
}
