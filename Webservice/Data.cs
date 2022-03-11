﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 
namespace CWI.PKOL.Webservice {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class FakturaAdd {
        
        private string queryIdField;
        
        private PracownikPKOL pracownikField;
        
        private Faktura fakturaField;
        
        private FakturaAddPozycja[] pozycjeField;
        
        private decimal nettoField;
        
        private decimal vatField;
        
        private decimal bruttoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string QueryId {
            get {
                return this.queryIdField;
            }
            set {
                this.queryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PracownikPKOL Pracownik {
            get {
                return this.pracownikField;
            }
            set {
                this.pracownikField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Faktura Faktura {
            get {
                return this.fakturaField;
            }
            set {
                this.fakturaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Pozycja", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public FakturaAddPozycja[] Pozycje {
            get {
                return this.pozycjeField;
            }
            set {
                this.pozycjeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal Netto {
            get {
                return this.nettoField;
            }
            set {
                this.nettoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal Vat {
            get {
                return this.vatField;
            }
            set {
                this.vatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal Brutto {
            get {
                return this.bruttoField;
            }
            set {
                this.bruttoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/Common.xsd")]
    public partial class PracownikPKOL {
        
        private string numerKadrowyField;
        
        private string akronimField;
        
        private string loginField;
        
        private string imieField;
        
        private string nazwiskoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string NumerKadrowy {
            get {
                return this.numerKadrowyField;
            }
            set {
                this.numerKadrowyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Akronim {
            get {
                return this.akronimField;
            }
            set {
                this.akronimField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Login {
            get {
                return this.loginField;
            }
            set {
                this.loginField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Imie {
            get {
                return this.imieField;
            }
            set {
                this.imieField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Nazwisko {
            get {
                return this.nazwiskoField;
            }
            set {
                this.nazwiskoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/Common.xsd")]
    public partial class Faktura {
        
        private string numerFakturyField;
        
        private string numerKontaGlownegoField;
        
        private string opisField;
        
        private System.Nullable<System.DateTime> odField;
        
        private System.Nullable<System.DateTime> doField;
        
        private System.Nullable<System.DateTime> terminPlatnosciField;
        
        private decimal prowizjaField;
        
        private FormaWspolpracy formaWspolpracyField;
        
        private bool czyZaplaconaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string NumerFaktury {
            get {
                return this.numerFakturyField;
            }
            set {
                this.numerFakturyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string NumerKontaGlownego {
            get {
                return this.numerKontaGlownegoField;
            }
            set {
                this.numerKontaGlownegoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Opis {
            get {
                return this.opisField;
            }
            set {
                this.opisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", IsNullable=true)]
        public System.Nullable<System.DateTime> Od {
            get {
                return this.odField;
            }
            set {
                this.odField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", IsNullable=true)]
        public System.Nullable<System.DateTime> Do {
            get {
                return this.doField;
            }
            set {
                this.doField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", IsNullable=true)]
        public System.Nullable<System.DateTime> TerminPlatnosci {
            get {
                return this.terminPlatnosciField;
            }
            set {
                this.terminPlatnosciField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal Prowizja {
            get {
                return this.prowizjaField;
            }
            set {
                this.prowizjaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FormaWspolpracy FormaWspolpracy {
            get {
                return this.formaWspolpracyField;
            }
            set {
                this.formaWspolpracyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool CzyZaplacona {
            get {
                return this.czyZaplaconaField;
            }
            set {
                this.czyZaplaconaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/Common.xsd")]
    public enum FormaWspolpracy {
        
        /// <remarks/>
        Pracownik,
        
        /// <remarks/>
        Kontraktor,
        
        /// <remarks/>
        PraktykantStazysta,
        
        /// <remarks/>
        SieciZewnetrzne,
        
        /// <remarks/>
        PracownikZewnetrzny,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class FakturaAddPozycja {
        
        private decimal nettoField;
        
        private decimal vatField;
        
        private decimal bruttoField;
        
        private string opisField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal Netto {
            get {
                return this.nettoField;
            }
            set {
                this.nettoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal Vat {
            get {
                return this.vatField;
            }
            set {
                this.vatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal Brutto {
            get {
                return this.bruttoField;
            }
            set {
                this.bruttoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Opis {
            get {
                return this.opisField;
            }
            set {
                this.opisField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class FakturaAddResponse {
        
        private string queryIdField;
        
        private bool isValidField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string QueryId {
            get {
                return this.queryIdField;
            }
            set {
                this.queryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool IsValid {
            get {
                return this.isValidField;
            }
            set {
                this.isValidField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class KalendarzSwiatGet {
        
        private string queryIdField;
        
        private int rokField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string QueryId {
            get {
                return this.queryIdField;
            }
            set {
                this.queryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Rok {
            get {
                return this.rokField;
            }
            set {
                this.rokField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class KalendarzSwiatGetResponse {
        
        private string queryIdField;
        
        private KalendarzSwiatGetResponseDzienWolny[] dniWolneField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string QueryId {
            get {
                return this.queryIdField;
            }
            set {
                this.queryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("DzienWolny", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public KalendarzSwiatGetResponseDzienWolny[] DniWolne {
            get {
                return this.dniWolneField;
            }
            set {
                this.dniWolneField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class KalendarzSwiatGetResponseDzienWolny {
        
        private System.DateTime dzienField;
        
        private string nazwaField;
        
        private bool czyUstawowoWolneField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
        public System.DateTime Dzien {
            get {
                return this.dzienField;
            }
            set {
                this.dzienField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Nazwa {
            get {
                return this.nazwaField;
            }
            set {
                this.nazwaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool CzyUstawowoWolne {
            get {
                return this.czyUstawowoWolneField;
            }
            set {
                this.czyUstawowoWolneField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class NieobecnoscGet {
        
        private string queryIdField;
        
        private Identifier pracownikField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string QueryId {
            get {
                return this.queryIdField;
            }
            set {
                this.queryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Identifier Pracownik {
            get {
                return this.pracownikField;
            }
            set {
                this.pracownikField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/Common.xsd")]
    public partial class Identifier {
        
        private string itemField;
        
        private ItemChoiceType itemElementNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Login", typeof(string), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("NumerKadrowy", typeof(string), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName {
            get {
                return this.itemElementNameField;
            }
            set {
                this.itemElementNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/Common.xsd", IncludeInSchema=false)]
    public enum ItemChoiceType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute(":Login")]
        Login,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute(":NumerKadrowy")]
        NumerKadrowy,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class NieobecnoscGetResponse {
        
        private string queryIdField;
        
        private PracownikPKOL zastepujacyField;
        
        private PracownikPKOL zastepowanyField;
        
        private System.DateTime odField;
        
        private System.DateTime doField;
        
        private System.DateTime dataZakonczeniaField;
        
        private RodzajNieobecnosci rodzajNieobecnosciField;
        
        private CzyPracuje czyPracujeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string QueryId {
            get {
                return this.queryIdField;
            }
            set {
                this.queryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PracownikPKOL Zastepujacy {
            get {
                return this.zastepujacyField;
            }
            set {
                this.zastepujacyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PracownikPKOL Zastepowany {
            get {
                return this.zastepowanyField;
            }
            set {
                this.zastepowanyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
        public System.DateTime Od {
            get {
                return this.odField;
            }
            set {
                this.odField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
        public System.DateTime Do {
            get {
                return this.doField;
            }
            set {
                this.doField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
        public System.DateTime DataZakonczenia {
            get {
                return this.dataZakonczeniaField;
            }
            set {
                this.dataZakonczeniaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RodzajNieobecnosci RodzajNieobecnosci {
            get {
                return this.rodzajNieobecnosciField;
            }
            set {
                this.rodzajNieobecnosciField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CzyPracuje CzyPracuje {
            get {
                return this.czyPracujeField;
            }
            set {
                this.czyPracujeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/Common.xsd")]
    public enum RodzajNieobecnosci {
        
        /// <remarks/>
        Nieobecnosc,
        
        /// <remarks/>
        Urlop,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/Common.xsd")]
    public enum CzyPracuje {
        
        /// <remarks/>
        Tak,
        
        /// <remarks/>
        Nie,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ZajeciaKomorniczeGet {
        
        private string queryIdField;
        
        private Identifier pracownikField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string QueryId {
            get {
                return this.queryIdField;
            }
            set {
                this.queryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Identifier Pracownik {
            get {
                return this.pracownikField;
            }
            set {
                this.pracownikField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ZajeciaKomorniczeGetResponse {
        
        private string queryIdField;
        
        private PracownikPKOL pracownikField;
        
        private Faktura fakturaField;
        
        private string kontoSAPField;
        
        private string kontoLEOField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string QueryId {
            get {
                return this.queryIdField;
            }
            set {
                this.queryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public PracownikPKOL Pracownik {
            get {
                return this.pracownikField;
            }
            set {
                this.pracownikField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public Faktura Faktura {
            get {
                return this.fakturaField;
            }
            set {
                this.fakturaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string KontoSAP {
            get {
                return this.kontoSAPField;
            }
            set {
                this.kontoSAPField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string KontoLEO {
            get {
                return this.kontoLEOField;
            }
            set {
                this.kontoLEOField = value;
            }
        }
    }
}