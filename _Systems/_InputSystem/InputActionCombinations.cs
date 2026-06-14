namespace DenZ.DevelopmentTools.InputSystem
{
    public interface IActionWithPerformAndFinish<T> : IAction, IPerformableAction<T>, IFinishableAction<T> where T : struct { }
}