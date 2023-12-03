namespace ATISPlugin
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Sectors
    {

        private SectorsSector[] sectorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Sector")]
        public SectorsSector[] Sector
        {
            get
            {
                return this.sectorField;
            }
            set
            {
                this.sectorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SectorsSector
    {

        private string volumesField;

        private string responsibleSectorsField;

        private string fullNameField;

        private decimal frequencyField;

        private string callsignField;

        private string nameField;

        private string displayInSectorsWindowField;

        private string displayInHandoffWindowField;

        /// <remarks/>
        public string Volumes
        {
            get
            {
                return this.volumesField;
            }
            set
            {
                this.volumesField = value;
            }
        }

        /// <remarks/>
        public string ResponsibleSectors
        {
            get
            {
                return this.responsibleSectorsField;
            }
            set
            {
                this.responsibleSectorsField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Callsign
        {
            get
            {
                return this.callsignField;
            }
            set
            {
                this.callsignField = value;
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
        public string DisplayInSectorsWindow
        {
            get
            {
                return this.displayInSectorsWindowField;
            }
            set
            {
                this.displayInSectorsWindowField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DisplayInHandoffWindow
        {
            get
            {
                return this.displayInHandoffWindowField;
            }
            set
            {
                this.displayInHandoffWindowField = value;
            }
        }
    }


}
