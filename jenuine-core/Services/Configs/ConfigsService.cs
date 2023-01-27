using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Actions.Configs;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Configs
{
    public class ConfigsService : IConfigsService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public ConfigsService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string id)
        {
            orgId = id;
        }

        public List<MConfig> GetConfigs(MConfig param, QueryParam queryParam)
        {
            var act = new GetConfigsAction(database, orgId);
            var results = act.Apply<MConfig>(param, queryParam);

            return results;
        }

        public MConfig AddConfig(MConfig param)
        {
            var act = new AddConfigAction(database, orgId);
            //Hard code to allow only 1 record in the collection
            //This will raise dupplication error if try to insert more than 1 record
            param.ConfigId = "00000000000000000000";
            var result = act.Apply<MConfig>(param);

            return result;
        }

        public MConfig UpdateConfig(MConfig param)
        {
            var act = new UpdateConfigByIdAction(database, orgId);
            var result = act.Apply<MConfig>(param);

            return result;
        }
    }
}
