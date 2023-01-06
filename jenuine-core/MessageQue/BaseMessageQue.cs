using System;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.MessageQue
{
    public abstract class BaseMessageQue : IMessageQue
    {
        protected abstract void Initlize();

        public void Init()
        {
            Initlize();
        }

        public virtual MJob GetMessage()
        {
            return null;
        }
    }
}
