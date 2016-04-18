using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Events
{
    /// <summary>
    /// Event thats gets published when there is a need to refresh data.
    /// </summary>
    public class RefreshEvent : CompositePresentationEvent<bool>
    {
    }
}
