using System;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using Service;
using Shouldly;
using Xunit;

namespace Tests
{
    public class UsingCompiledQuery : IClassFixture<AppFixture>
    {
        private IDocumentStore theDocumentStore;

        public UsingCompiledQuery(AppFixture fixture)
        {
            theDocumentStore = fixture.Store;
            
            // Blow away any existing data
            theDocumentStore.Advanced.Clean
                .DeleteAllDocuments();

        }

        [Fact]
        public async Task try_it_out()
        {
            var userId = Guid.NewGuid();
            
            var issues = new Issue[]
            {
                new Issue{AssignedUser = userId, Title = "Approved 1", Status = IssueStatus.Approved},
                new Issue{Title = "Approved 2", Status = IssueStatus.Approved},
                new Issue{Title = "New 1", Status = IssueStatus.New},
                new Issue{Title = "Approved 3", Status = IssueStatus.Approved},
                new Issue{AssignedUser = userId, Title = "In Progress", Status = IssueStatus.InProgress},
                new Issue{AssignedUser = userId, Title = "Open", Status = IssueStatus.Open},
                new Issue{Title = "New 2", Status = IssueStatus.New},
            };
            
            // Toss in some new issues
            theDocumentStore.BulkInsert(issues);

            using (var session = theDocumentStore.QuerySession())
            {
                var query = new OpenIssuesByUser
                {
                    UserId = userId
                };

                var actual = await session.QueryAsync(query);
                
                actual.Single().Title.ShouldBe("Open");
            }

        }
    }
}