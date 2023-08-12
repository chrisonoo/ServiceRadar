using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceRadar.MVC.Models;

namespace ServiceRadar.MVC.Extensions;

public static class ControllerExtensions
{
    public static void SetNotification(this Controller controller, string type, string message)
    {
        var notification = new Notification(type, message);
        // TempData only accepts a string, we need to serialize the object first
        controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
    }
}
