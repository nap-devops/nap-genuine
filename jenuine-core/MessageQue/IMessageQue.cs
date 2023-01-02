using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.MessageQue
{
    public interface IMessageQue
    {
        public void Init();
        public MJob GetMessage();
    }
}
