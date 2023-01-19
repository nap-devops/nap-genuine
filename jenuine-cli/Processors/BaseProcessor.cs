using System;
using System.Threading;

namespace Its.Jenuiue.Cli.Processors
{
    public abstract class BaseProcessor : IProcessor
    {
        protected abstract void Init();

        public void Run()
        {
            Init();
        }
    }
}
