using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LearningController : Controller
{
    private readonly ILearningService _learningService;

    public LearningController(ILearningService learningService)
    {
        _learningService = learningService;
    }

    [HttpGet]
    [Route("status")]
    [AllowAnonymous]
    public string GetStatus(){
        return _learningService.GetCurrentStatus();
    }

    [HttpPost]
    [Route("update")]
    [ClaimRequirement(ClaimTypes.Role, "Taey")]
    public string UpdateStatus(UpdateStatusRequest newStatus){
        _learningService.UpdateStatus(newStatus.Status);
        return "DONE";
    }
}