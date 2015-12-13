using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PathItem
{
    public PathItem(string boxName, string gateName, string gateText)
    {
        BoxName = boxName;
        GateName = gateName;
        GateText = gateText;
    }

    public string BoxName { get; set; }

    public string GateName { get; set; }

    public string GateText { get; set; }
}
