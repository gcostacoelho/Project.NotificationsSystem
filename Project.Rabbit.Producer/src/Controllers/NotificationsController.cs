using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Project.Rabbit.Producer.src.Models;
using Project.Rabbit.Producer.src.Services;

namespace Project.Rabbit.Producer.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController(IMessagingService messagingService) : ControllerBase
{
    private readonly IMessagingService _messagingService = messagingService;

    [HttpPost("SendNotification")]
    public IActionResult SendNotification([FromBody, Required] Notification notification)
    {
        _messagingService.SendMessageToRabbit(notification);

        return Accepted();
    }
}