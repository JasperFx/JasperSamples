using System.Linq;
using System.Threading.Tasks;
using Alba;
using Marten;
using Service;
using Shouldly;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace Tests
{
    public class GetOpenIssueCountTest : IClassFixture<AppFixture>
    {
        private IDocumentStore theDocumentStore;
        private SystemUnderTest theSystem;

        public GetOpenIssueCountTest(AppFixture fixture)
        {
            theDocumentStore = fixture.Store;
            theSystem = fixture.System;
        }

        [Fact]
        public async Task can_retrieve_new_issues()
        {
            // Blow away any existing data
            theDocumentStore.Advanced.Clean
                .DeleteAllDocuments();
            
            var issues = new Issue[]
            {
                new Issue{Title = "Approved 1", Status = IssueStatus.Approved},
                new Issue{Title = "Approved 2", Status = IssueStatus.Approved},
                new Issue{Title = "New 1", Status = IssueStatus.New},
                new Issue{Title = "Approved 3", Status = IssueStatus.Approved},
                new Issue{Title = "In Progress", Status = IssueStatus.InProgress},
                new Issue{Title = "Open", Status = IssueStatus.Open},
                new Issue{Title = "New 2", Status = IssueStatus.New},
            };
            
            // Toss in some new issues
            theDocumentStore.BulkInsert(issues);

            // Exercise the HTTP endpoint...
            var titles = await theSystem
                .GetAsJson<IssueTitle[]>("/issues/new");

            titles.OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ShouldBe(new string[]{"New 1", "New 2"});

        }
        
        
        
        [Fact]
        public async Task marten_is_acidic()
        {
            // Blow away any existing data
            theDocumentStore.Advanced.Clean
                .DeleteAllDocuments();
            
            var issues = new Issue[]
            {
                new Issue{Title = "Approved 1", Status = IssueStatus.Approved},
                new Issue{Title = "Approved 2", Status = IssueStatus.Approved},
                new Issue{Title = "New 1", Status = IssueStatus.New},
                new Issue{Title = "Approved 3", Status = IssueStatus.Approved},
                new Issue{Title = "In Progress", Status = IssueStatus.InProgress},
                new Issue{Title = "Open", Status = IssueStatus.Open},
                new Issue{Title = "New 2", Status = IssueStatus.New},
            };

            using (var session = theDocumentStore.LightweightSession())
            {
                session.Store(issues);
                
                session.Store(new User{FirstName = "Han", LastName = "Solo"});
                session.Store(new User{FirstName = "Darth", LastName = "Maul"});
                session.Store(new User{FirstName = "Lando", LastName = "Calrissian"});
                
                await session.SaveChangesAsync();

                var count = await session.Query<Issue>()
                    .CountAsync();
                
                count.ShouldBe(issues.Count());
            }


        }
    }
}