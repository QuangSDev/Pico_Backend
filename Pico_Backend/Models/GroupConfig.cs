using System.Data.Common;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using System;

namespace Pico_Backend.Models
{
    public class GroupConfig
    {
        public int GroupFieldConfigID { get; set; }
        public string? Label { get; set; }
        public string? FieldName { get; set; }
        public int? FieldType { get; set; }
        public bool IsRequired { get; set; }
        public string? Placeholder { get; set; }
        public int Column { get; set; }
        public string? ErrorText { get; set; }
        public int? DrodownListID { get; set; }
        public int? GroupConfigID { get; set; }
        public string? GroupName { get; set; }
        public int? GroupType { get; set; }
        public string? DropdownList { get; set; }


    }
}
