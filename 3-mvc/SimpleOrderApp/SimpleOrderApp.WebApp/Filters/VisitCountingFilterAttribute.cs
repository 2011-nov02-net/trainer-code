using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleOrderApp.WebApp.Services;

namespace SimpleOrderApp.WebApp.Filters
{
    public class VisitCountingFilterAttribute : ActionFilterAttribute
    {
        private readonly VisitCounter _visitCounter;

        public VisitCountingFilterAttribute(VisitCounter visitCounter)
        {
            _visitCounter = visitCounter;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.ActionDescriptor.Id;
            if (!_visitCounter.VisitCounts.ContainsKey(action))
            {
                _visitCounter.VisitCounts[action] = 0;
            }
            if (context.Controller is Controller controller)
            {
                controller.ViewData["PageVisits"] = ++_visitCounter.VisitCounts[action];
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
