using System.Collections.Generic;

namespace Engines.Engines.CheckProxyListEngine
{
    public class CheckProxyListModel
    {
        public int PageLoadTime { get; set; }

        public List<CheckProxyListAnswerModel> ProxyList { get; set; } 
    }
}
