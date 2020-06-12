using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Service
{

    public class CreateIssue
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class IssueCreated
    {
        public Guid IssueId { get; set; }
    }

    public class IssueTitle
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
    }

    public class IssueController
    {
        [HttpPost("/issue")]
        public async Task<IssueCreated> PostIssue(
            [FromBody] CreateIssue command,
            [FromServices] IDocumentSession session)
        {
            var issue = new Issue
            {
                Title = command.Title,
                Description = command.Description
            };

            session.Store(issue);
            await session.SaveChangesAsync();

            return new IssueCreated
            {
                IssueId = issue.Id
            };
        }

        [HttpGet("/issues/{status}/")]
        public Task<IReadOnlyList<IssueTitle>> Issues([FromServices] IQuerySession session, IssueStatus status)
        {
            return session.Query<Issue>()
                .Where(x => x.Status == status)
                .Select(x => new IssueTitle {Title = x.Title, Id = x.Id})
                .ToListAsync();
        }
        
        [HttpGet("/issues/new")]
        public Task<IReadOnlyList<IssueTitle>> NewIssues([FromServices] IQuerySession session)
        {
            return Issues(session, IssueStatus.New);
        }
    }
}
