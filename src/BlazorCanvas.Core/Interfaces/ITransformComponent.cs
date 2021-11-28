namespace BlazorCanvas.Core.Interfaces
{
    public interface ITransformComponent
    {
        Transform Local { get; }
        Transform World { get; }
    }
}