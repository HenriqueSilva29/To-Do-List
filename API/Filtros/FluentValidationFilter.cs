using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace API.Filtros
{
    public class FluentValidationFilter : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public FluentValidationFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var errors = new Dictionary<string, string[]>();

            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument is null)
                    continue;

                var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());

                if (_serviceProvider.GetService(validatorType) is not IValidator validator)
                    continue;

                var validationContext = new ValidationContext<object>(argument);
                var result = await validator.ValidateAsync(validationContext);

                if (result.IsValid)
                    continue;

                foreach (var group in result.Errors.GroupBy(x => x.PropertyName))
                {
                    errors[group.Key] = group
                        .Select(x => x.ErrorMessage)
                        .Distinct()
                        .ToArray();
                }
            }

            if (errors.Count > 0)
            {
                var problemDetails = new ValidationProblemDetails(errors)
                {
                    Type = "validation-error",
                    Title = "Erro de validacao",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = context.HttpContext.Request.Path
                };

                problemDetails.Extensions["traceId"] =
                    Activity.Current?.TraceId.ToString() ?? context.HttpContext.TraceIdentifier;

                if (context.HttpContext.Items.TryGetValue("CorrelationId", out var correlationId))
                    problemDetails.Extensions["correlationId"] = correlationId?.ToString();

                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            await next();
        }
    }
}
