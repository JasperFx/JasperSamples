using System;
using Marten.Schema;

namespace Service
{
    public enum IssueStatus
    {
        New,
        Open,
        InProgress,
        Approved,
        Completed
    }
    
    
    public class Issue
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public IssueStatus Status { get; set; } = IssueStatus.New;
        
        public string Description { get; set; }
        public Guid? AssignedUser { get; set; }
    }


    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class IssueTask
    {
        public DateTimeOffset Assigned { get; set; }
        public bool Completed { get; set; }
        public string Title { get; set; }
    }

    public class Comment
    {
        public string Text { get; set; }
    }
    
    public class CommentAdded
    {
        public string Text { get; set; }
    }

    public class IssueAssigned
    {
        public Guid IssueId { get; set; }
        public Guid User { get; set; }
    }

    public class IssueCompleted
    {

    }

    

}