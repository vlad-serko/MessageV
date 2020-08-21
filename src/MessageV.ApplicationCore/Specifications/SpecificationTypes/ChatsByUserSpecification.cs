using System;
using System.Linq;
using System.Linq.Expressions;
using MessageV.ApplicationCore.Entities;

namespace MessageV.ApplicationCore.Specifications.SpecificationTypes
{
    public class ChatsByUserSpecification : BaseSpecification<Chat>
    {
        public ChatsByUserSpecification(Guid userId)
        {
            Criteria = (Chat chat) => chat.Members.Any(x => x.UserId == userId);
        }
    }
}