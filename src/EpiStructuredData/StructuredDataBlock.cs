using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

// ReSharper disable Mvc.TemplateNotResolved

namespace EpiStructuredData
{
    [ContentType(DisplayName = "Structured Data", GUID = "73B1CC41-CE8E-40A0-B476-5ACAC5A78526", AvailableInEditMode = false)]
    public class StructuredDataBlock : BlockData
    {
        [UIHint(UIHint.Textarea)]
        [Display(Name = "Structured Data models", GroupName = "Structured Data")]
        public virtual IList<string> Models { get; set; }
    }
}