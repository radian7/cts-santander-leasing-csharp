using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SantanderLeasing.DotnetCore.Models
{

    [XmlRoot("Produkt")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        [XmlAttribute("color")]
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
    }


    // Edit | Paste Special | Paste XML as Classes

}
