using DietitianTrackingSystemApp.Core.Enumerations;

namespace DietitianTrackingSystemApp.Core.CustomAttributes
{
    public class PageRoleActionAttribute : Attribute
    {
        public PageRoleActionType Action { get; set; }

        public PageRoleActionAttribute(PageRoleActionType pageRoleAction)
        {
            Action = pageRoleAction;
        }
    }
}