namespace Dhhr.KppParser.Service.Models
{
    using System;
    using System.Collections.Generic;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.npr.no/xmlstds/55_0_1_kpp")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.npr.no/xmlstds/55_0_1_kpp", IsNullable=false)]
    public partial class Melding
    {
        
        private System.Collections.Generic.List<Institusjon> institusjonField;
        
        private string versjonField;
        
        private string meldingstypeField;
        
        private System.DateTime fraDatoPeriodeField;
        
        private System.DateTime uttakDatoField;
        
        private string leverandorField;
        
        private string navnEPJField;
        
        private string versjonEPJField;
        
        private string versjonUtField;
        
        private string lopenrField;
        
        private System.DateTime tilDatoPeriodeField;
        
        private string lokalidentField;
        
        public Melding()
        {
            this.versjonField = "55.0.1";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Institusjon")]
        public System.Collections.Generic.List<Institusjon> Institusjon
        {
            get
            {
                return this.institusjonField;
            }
            set
            {
                this.institusjonField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string versjon
        {
            get
            {
                return this.versjonField;
            }
            set
            {
                this.versjonField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string meldingstype
        {
            get
            {
                return this.meldingstypeField;
            }
            set
            {
                this.meldingstypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
        public System.DateTime fraDatoPeriode
        {
            get
            {
                return this.fraDatoPeriodeField;
            }
            set
            {
                this.fraDatoPeriodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
        public System.DateTime uttakDato
        {
            get
            {
                return this.uttakDatoField;
            }
            set
            {
                this.uttakDatoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string leverandor
        {
            get
            {
                return this.leverandorField;
            }
            set
            {
                this.leverandorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string navnEPJ
        {
            get
            {
                return this.navnEPJField;
            }
            set
            {
                this.navnEPJField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string versjonEPJ
        {
            get
            {
                return this.versjonEPJField;
            }
            set
            {
                this.versjonEPJField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string versjonUt
        {
            get
            {
                return this.versjonUtField;
            }
            set
            {
                this.versjonUtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
        public string lopenr
        {
            get
            {
                return this.lopenrField;
            }
            set
            {
                this.lopenrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
        public System.DateTime tilDatoPeriode
        {
            get
            {
                return this.tilDatoPeriodeField;
            }
            set
            {
                this.tilDatoPeriodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string lokalident
        {
            get
            {
                return this.lokalidentField;
            }
            set
            {
                this.lokalidentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.npr.no/xmlstds/55_0_1_kpp")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.npr.no/xmlstds/55_0_1_kpp", IsNullable=false)]
    public partial class Institusjon
    {
        
        private System.Collections.Generic.List<Objektholder> objektholderField;
        
        private string institusjonIDField;
        
        private string foretakIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Objektholder")]
        public System.Collections.Generic.List<Objektholder> Objektholder
        {
            get
            {
                return this.objektholderField;
            }
            set
            {
                this.objektholderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string institusjonID
        {
            get
            {
                return this.institusjonIDField;
            }
            set
            {
                this.institusjonIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string foretakID
        {
            get
            {
                return this.foretakIDField;
            }
            set
            {
                this.foretakIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.npr.no/xmlstds/55_0_1_kpp")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.npr.no/xmlstds/55_0_1_kpp", IsNullable=false)]
    public partial class Objektholder
    {
        
        private System.Collections.Generic.List<EpisodeKPP> episodeKPPField;
        
        private string pasientNrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EpisodeKPP")]
        public System.Collections.Generic.List<EpisodeKPP> EpisodeKPP
        {
            get
            {
                return this.episodeKPPField;
            }
            set
            {
                this.episodeKPPField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pasientNr
        {
            get
            {
                return this.pasientNrField;
            }
            set
            {
                this.pasientNrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.npr.no/xmlstds/55_0_1_kpp")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.npr.no/xmlstds/55_0_1_kpp", IsNullable=false)]
    public partial class EpisodeKPP
    {
        
        private System.Collections.Generic.List<TjenesteKPP> tjenesteKPPField;
        
        private string episodeIDField;
        
        private string drgField;
        
        private decimal totalField;
        
        private bool totalFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TjenesteKPP")]
        public System.Collections.Generic.List<TjenesteKPP> TjenesteKPP
        {
            get
            {
                return this.tjenesteKPPField;
            }
            set
            {
                this.tjenesteKPPField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string episodeID
        {
            get
            {
                return this.episodeIDField;
            }
            set
            {
                this.episodeIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string drg
        {
            get
            {
                return this.drgField;
            }
            set
            {
                this.drgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalSpecified
        {
            get
            {
                return this.totalFieldSpecified;
            }
            set
            {
                this.totalFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.npr.no/xmlstds/55_0_1_kpp")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.npr.no/xmlstds/55_0_1_kpp", IsNullable=false)]
    public partial class TjenesteKPP
    {
        
        private string kostnadKodeField;
        
        private decimal kostnadField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string kostnadKode
        {
            get
            {
                return this.kostnadKodeField;
            }
            set
            {
                this.kostnadKodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal kostnad
        {
            get
            {
                return this.kostnadField;
            }
            set
            {
                this.kostnadField = value;
            }
        }
    }
}
