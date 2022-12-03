
namespace Its.Jenuiue.Core.Actions
{
    public interface IActionDelete
    {
        public T Apply<T>(string objectId);
    }
}
