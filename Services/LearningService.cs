public class LearningService : ILearningService {
    private string _currentStatus;

    public LearningService()
    {
        _currentStatus = "initial";
    }

    public string GetCurrentStatus()
    {
        return _currentStatus;
    }

    public void UpdateStatus(string status)
    {
        _currentStatus = status;
    }
}