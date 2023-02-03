using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.ModelsViews
{
    public class BaseModelView
    {
        public string LastActionStatus { get; set; }
        public string Id { get; set; }
        public QueryParam QueryParam { get; set; }
    }
}
