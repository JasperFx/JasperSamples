using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Marten.Linq;

namespace Service
{
    public class OpenIssuesByUser : ICompiledListQuery<Issue>
    {
        public Expression<Func<IQueryable<Issue>, IEnumerable<Issue>>> QueryIs()
        {
            return q => q
                .Where(x => x.Status == IssueStatus.Open && x.AssignedUser == UserId);
        }
        
        public Guid UserId { get; set; }
    }
}