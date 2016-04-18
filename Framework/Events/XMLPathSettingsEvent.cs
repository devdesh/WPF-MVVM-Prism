using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Events
{
    /// <summary>
    /// Event that gets published when XML file Paths are received.
    /// </summary>
    public class XMLPathSettingsEvent : CompositePresentationEvent<XMLFilePaths>
    {
    }

    /// <summary>
    /// Custom class which acts as payload for the XMLPathSettingsEvent
    /// </summary>
    public class XMLFilePaths
    {
        public string TablesXMLFilePath { get; set; }
        public string ReservationsXMLFilePath { get; set; }
    }
}
