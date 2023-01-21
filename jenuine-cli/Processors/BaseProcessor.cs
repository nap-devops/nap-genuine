using System;
using System.Threading;

namespace Its.Jenuiue.Cli.Processors
{
    public abstract class BaseProcessor : IProcessor
    {
        protected abstract void Init(string[] args);

        public void Run(string[] args)
        {
            Init(args);
        }
    }
}
