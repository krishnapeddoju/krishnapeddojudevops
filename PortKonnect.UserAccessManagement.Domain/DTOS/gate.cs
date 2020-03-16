using System.Xml.Serialization;

[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "PortKonnect.UserAccessManagement.Domain.DTOS", IsNullable = false)]
public class gate
{

    private gateProcesstruck processtruckField;

    
    [XmlElement("process-truck")]
    public gateProcesstruck processtruck
    {
        get
        {
            return processtruckField;
        }
        set
        {
            processtruckField = value;
        }
    }
}


[XmlType(AnonymousType = true)]
public class gateProcesstruck
{

    private string gateidField;

    private string stageidField;

    private string laneidField;

    private gateProcesstruckTruck truckField;

    private gateProcesstruckTruckvisit truckvisitField;

    private System.DateTime timestampField;

    private byte scanstatusField;

    private string scansetidField;

    private bool nocontentField;

    
    [XmlElement("gate-id")]
    public string gateid
    {
        get
        {
            return gateidField;
        }
        set
        {
            gateidField = value;
        }
    }

    
    [XmlElement("stage-id")]
    public string stageid
    {
        get
        {
            return stageidField;
        }
        set
        {
            stageidField = value;
        }
    }

    
    [XmlElement("lane-id")]
    public string laneid
    {
        get
        {
            return laneidField;
        }
        set
        {
            laneidField = value;
        }
    }

    
    public gateProcesstruckTruck truck
    {
        get
        {
            return truckField;
        }
        set
        {
            truckField = value;
        }
    }

    
    [XmlElement("truck-visit")]
    public gateProcesstruckTruckvisit truckvisit
    {
        get
        {
            return truckvisitField;
        }
        set
        {
            truckvisitField = value;
        }
    }

    
    public System.DateTime timestamp
    {
        get
        {
            return timestampField;
        }
        set
        {
            timestampField = value;
        }
    }

    
    [XmlAttribute("scan-status")]
    public byte scanstatus
    {
        get
        {
            return scanstatusField;
        }
        set
        {
            scanstatusField = value;
        }
    }

    
    [XmlAttribute("scan-set-id")]
    public string scansetid
    {
        get
        {
            return scansetidField;
        }
        set
        {
            scansetidField = value;
        }
    }

    
    [XmlAttribute("no-content")]
    public bool nocontent
    {
        get
        {
            return nocontentField;
        }
        set
        {
            nocontentField = value;
        }
    }
}


[XmlType(AnonymousType = true)]
public class gateProcesstruckTruck
{

    private string licensenbrField;

    
    [XmlAttribute("license-nbr")]
    public string licensenbr
    {
        get
        {
            return licensenbrField;
        }
        set
        {
            licensenbrField = value;
        }
    }
}


[XmlType(AnonymousType = true)]
public class gateProcesstruckTruckvisit
{

    private string gostvkeyField;

    
    [XmlAttribute("gos-tv-key")]
    public string gostvkey
    {
        get
        {
            return gostvkeyField;
        }
        set
        {
            gostvkeyField = value;
        }
    }
}

