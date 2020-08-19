using System.Collections.Generic;

namespace MessageV.ApplicationCore.Entities
{
    public class User : BaseEntity
    {
        public ICollection<UserChat> Chats { get; set; }

        public ICollection<Message> Messages {get; set;}
    }
}