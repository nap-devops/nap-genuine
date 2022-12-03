using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Api.ModelsViews
{
    public class BaseModelView
    {
        public string Id { get; set; }
        public QueryParam QueryParam { get; set; }
    }
}
