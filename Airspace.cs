namespace ATISPlugin
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Airspace
    {

        private AirspaceAirport[] systemRunwaysField;

        private AirspaceAirway[] airwaysField;

        private AirspacePoint[] intersectionsField;

        private AirspaceSIDSTARs sIDSTARsField;

        private AirspaceAirport1[] airportsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Airport", IsNullable = false)]
        public AirspaceAirport[] SystemRunways
        {
            get
            {
                return this.systemRunwaysField;
            }
            set
            {
                this.systemRunwaysField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Airway", IsNullable = false)]
        public AirspaceAirway[] Airways
        {
            get
            {
                return this.airwaysField;
            }
            set
            {
                this.airwaysField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Point", IsNullable = false)]
        public AirspacePoint[] Intersections
        {
            get
            {
                return this.intersectionsField;
            }
            set
            {
                this.intersectionsField = value;
            }
        }

        /// <remarks/>
        public AirspaceSIDSTARs SIDSTARs
        {
            get
            {
                return this.sIDSTARsField;
            }
            set
            {
                this.sIDSTARsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Airport", IsNullable = false)]
        public AirspaceAirport1[] Airports
        {
            get
            {
                return this.airportsField;
            }
            set
            {
                this.airportsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceAirport
    {

        private AirspaceAirportRunway[] runwayField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Runway")]
        public AirspaceAirportRunway[] Runway
        {
            get
            {
                return this.runwayField;
            }
            set
            {
                this.runwayField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceAirportRunway
    {

        private AirspaceAirportRunwaySID[] sIDField;

        private AirspaceAirportRunwaySTAR[] sTARField;

        private string nameField;

        private string dataRunwayField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SID")]
        public AirspaceAirportRunwaySID[] SID
        {
            get
            {
                return this.sIDField;
            }
            set
            {
                this.sIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("STAR")]
        public AirspaceAirportRunwaySTAR[] STAR
        {
            get
            {
                return this.sTARField;
            }
            set
            {
                this.sTARField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DataRunway
        {
            get
            {
                return this.dataRunwayField;
            }
            set
            {
                this.dataRunwayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceAirportRunwaySID
    {

        private string nameField;

        private string defaultField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Default
        {
            get
            {
                return this.defaultField;
            }
            set
            {
                this.defaultField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceAirportRunwaySTAR
    {

        private string nameField;

        private string approachNameField;

        private string opDataFlagField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproachName
        {
            get
            {
                return this.approachNameField;
            }
            set
            {
                this.approachNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OpDataFlag
        {
            get
            {
                return this.opDataFlagField;
            }
            set
            {
                this.opDataFlagField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceAirway
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspacePoint
    {

        private string nameField;

        private string typeField;

        private string navaidTypeField;

        private decimal frequencyField;

        private bool frequencyFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NavaidType
        {
            get
            {
                return this.navaidTypeField;
            }
            set
            {
                this.navaidTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Frequency
        {
            get
            {
                return this.frequencyField;
            }
            set
            {
                this.frequencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FrequencySpecified
        {
            get
            {
                return this.frequencyFieldSpecified;
            }
            set
            {
                this.frequencyFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARs
    {

        private AirspaceSIDSTARsSID[] sIDField;

        private AirspaceSIDSTARsSTAR[] sTARField;

        private AirspaceSIDSTARsApproach[] approachField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SID")]
        public AirspaceSIDSTARsSID[] SID
        {
            get
            {
                return this.sIDField;
            }
            set
            {
                this.sIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("STAR")]
        public AirspaceSIDSTARsSTAR[] STAR
        {
            get
            {
                return this.sTARField;
            }
            set
            {
                this.sTARField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Approach")]
        public AirspaceSIDSTARsApproach[] Approach
        {
            get
            {
                return this.approachField;
            }
            set
            {
                this.approachField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARsSID
    {

        private AirspaceSIDSTARsSIDRoute[] routeField;

        private AirspaceSIDSTARsSIDTransition[] transitionField;

        private string nameField;

        private string airportField;

        private string runwaysField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Route")]
        public AirspaceSIDSTARsSIDRoute[] Route
        {
            get
            {
                return this.routeField;
            }
            set
            {
                this.routeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Transition")]
        public AirspaceSIDSTARsSIDTransition[] Transition
        {
            get
            {
                return this.transitionField;
            }
            set
            {
                this.transitionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Airport
        {
            get
            {
                return this.airportField;
            }
            set
            {
                this.airportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Runways
        {
            get
            {
                return this.runwaysField;
            }
            set
            {
                this.runwaysField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARsSIDRoute
    {

        private string runwayField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Runway
        {
            get
            {
                return this.runwayField;
            }
            set
            {
                this.runwayField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARsSIDTransition
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARsSTAR
    {

        private AirspaceSIDSTARsSTARTransition[] transitionField;

        private AirspaceSIDSTARsSTARRoute[] routeField;

        private string nameField;

        private string airportField;

        private string runwaysField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Transition")]
        public AirspaceSIDSTARsSTARTransition[] Transition
        {
            get
            {
                return this.transitionField;
            }
            set
            {
                this.transitionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Route")]
        public AirspaceSIDSTARsSTARRoute[] Route
        {
            get
            {
                return this.routeField;
            }
            set
            {
                this.routeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Airport
        {
            get
            {
                return this.airportField;
            }
            set
            {
                this.airportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Runways
        {
            get
            {
                return this.runwaysField;
            }
            set
            {
                this.runwaysField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARsSTARTransition
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARsSTARRoute
    {

        private string runwayField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Runway
        {
            get
            {
                return this.runwayField;
            }
            set
            {
                this.runwayField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARsApproach
    {

        private AirspaceSIDSTARsApproachTransition[] transitionField;

        private string routeField;

        private string nameField;

        private string airportField;

        private string runwayField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Transition")]
        public AirspaceSIDSTARsApproachTransition[] Transition
        {
            get
            {
                return this.transitionField;
            }
            set
            {
                this.transitionField = value;
            }
        }

        /// <remarks/>
        public string Route
        {
            get
            {
                return this.routeField;
            }
            set
            {
                this.routeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Airport
        {
            get
            {
                return this.airportField;
            }
            set
            {
                this.airportField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Runway
        {
            get
            {
                return this.runwayField;
            }
            set
            {
                this.runwayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceSIDSTARsApproachTransition
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceAirport1
    {

        private AirspaceAirportRunway1[] runwayField;

        private string iCAOField;

        private string fullNameField;

        private string positionField;

        private ushort elevationField;

        private bool elevationFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Runway")]
        public AirspaceAirportRunway1[] Runway
        {
            get
            {
                return this.runwayField;
            }
            set
            {
                this.runwayField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ICAO
        {
            get
            {
                return this.iCAOField;
            }
            set
            {
                this.iCAOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Elevation
        {
            get
            {
                return this.elevationField;
            }
            set
            {
                this.elevationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ElevationSpecified
        {
            get
            {
                return this.elevationFieldSpecified;
            }
            set
            {
                this.elevationFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AirspaceAirportRunway1
    {

        private string nameField;

        private string positionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }
    }


}
