using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters
{
    /*public class MyLogAttribute : Attribute, IAsyncActionFilter
    {
        //    public void OnActionExecuted(ActionExecutedContext context)
        //    {
        //        Console.WriteLine($"Filter: {context.ActionDescriptor.DisplayName} is executed.");
        //    }

        //    public void OnActionExecuting(ActionExecutingContext context)
        //    {
        //        Console.WriteLine($"Filter: {context.ActionDescriptor.DisplayName} will be executed.");
        //    }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Filter: {context.ActionDescriptor.DisplayName} is executed.");
            Console.WriteLine($"Filter: {context.ActionDescriptor.DisplayName} will be executed.");
        }
    }*/

    public class MyLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //base.OnActionExecuted(context);
            Console.WriteLine($"Filter: {context.ActionDescriptor.DisplayName} is executed.");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //base.OnActionExecuting(context);
            Console.WriteLine($"Filter: {context.ActionDescriptor.DisplayName} will be executed.");
        }
    }
}
