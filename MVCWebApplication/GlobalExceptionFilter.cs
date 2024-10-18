using System;
using System.Web.Mvc;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext filterContext)
    {
        // Log the exception or handle it as needed
        Exception ex = filterContext.Exception;
        string errorMessage = ex.ToString();
        // You can write the errorMessage to a log file or handle it in any other way
    }
}