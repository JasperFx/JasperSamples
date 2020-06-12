using System;
using Marten.Events.Projections;

namespace Service
{
    public class IssueProjection : ViewProjection<Issue, Guid>
    {
        public IssueProjection()
        {
            ProjectEvent<IssueAssigned>((i, evt) => i.AssignedUser = evt.User);
            ProjectEvent<IssueCompleted>((i, evt) => i.Status = IssueStatus.Completed);
        }
    }
}