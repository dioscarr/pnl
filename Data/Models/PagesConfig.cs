using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Data.Models
{
    public class PagesConfig
    {
        public HtmlString Title { get; set; } = new HtmlString("<p>default content</p>");
        public HtmlString TopSubTitle { get; set; } = new HtmlString("<p>default Contrent</p>");
        public HtmlString Message { get; set; } = new HtmlString("<p>Message</p>");
    }
}
