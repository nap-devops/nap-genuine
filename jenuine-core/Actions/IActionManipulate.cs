
namespace Its.Jenuiue.Core.Actions
{
    public interface IActionManipulate
    {
        public T Apply<T>(T param);
    }
}
