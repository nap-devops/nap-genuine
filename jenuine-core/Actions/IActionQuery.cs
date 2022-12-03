using System.Collections.Generic;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Actions
{
    public interface IActionQuery
    {
        public List<T> Apply<T>(T param, QueryParam queryParam);
    }
}
