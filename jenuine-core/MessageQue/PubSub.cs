using System;
using Serilog;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.MessageQue
{
    public class PubSubMQ : BaseMessageQue
    {
        protected override void Initlize()
        {
            Log.Information("Initialize Pub/Sub message retrieval");
        }

        public override MJob GetMessage()
        {
            Guid guid = Guid.NewGuid();
            string regId = guid.ToString();
            
            var m = new MJob()
            {
                JobId = regId
            };

            return m;
        }        
    }
}
