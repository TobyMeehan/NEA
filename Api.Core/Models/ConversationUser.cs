using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Models
{
    public class ConversationUser
    {
        public string ConversationId { get; set; }
        public string UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
