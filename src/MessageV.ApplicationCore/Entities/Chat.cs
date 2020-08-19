using System.Collections.Generic;
using MessageV.ApplicationCore.Entities.Enums;

namespace MessageV.ApplicationCore.Entities
{
    public class Chat : BaseEntity
    {
        public ChatType Type { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<UserChat> Members { get; set; }

    }
}