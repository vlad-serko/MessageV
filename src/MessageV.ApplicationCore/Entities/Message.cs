using System;

namespace MessageV.ApplicationCore.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderId {get; set;}

        public User Sender { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

    }
}