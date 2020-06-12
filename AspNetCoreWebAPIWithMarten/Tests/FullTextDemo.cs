using System;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using Marten.Schema;
using Service;
using Shouldly;
using Xunit;

namespace Tests
{
    
    public class BlogPost
    {
        public Guid Id { get; set; }

        public string Category { get; set; }

        [FullTextIndex]
        public string EnglishText { get; set; }

        [FullTextIndex(RegConfig = "italian")]
        public string ItalianText { get; set; }

        [FullTextIndex(RegConfig = "french")]
        public string FrenchText { get; set; }
    }
    
    
    public class FullTextDemo : IClassFixture<AppFixture>
    {
        private IDocumentStore theDocumentStore;

        public FullTextDemo(AppFixture fixture)
        {
            theDocumentStore = fixture.Store;
            
            // Blow away any existing data
            theDocumentStore.Advanced.Clean
                .DeleteAllDocuments();
        }

        [Fact]
        public void search_in_query_sample()
        {
            var expectedId = Guid.NewGuid();

            using (var session = theDocumentStore.OpenSession())
            {
                session.Store(new BlogPost { Id = expectedId, EnglishText = "there's some text with the phrase it is broken in it somewhere" });
                session.Store(new BlogPost { Id = Guid.NewGuid(), ItalianText = "An Italian version of the text above" });
                session.SaveChanges();
            }

            using (var session = theDocumentStore.OpenSession())
            {
                var posts = session.Query<BlogPost>()
                    .Where(x => x.Search("broken"))
                    .ToList();

                posts.Count.ShouldBe(1);
                posts.Single().Id.ShouldBe(expectedId);
            }
        }

    }
}