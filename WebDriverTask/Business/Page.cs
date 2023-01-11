using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Business
{
    public class Page
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Language { get; set; }

        public Page(string? name = null, string? description = null, string? title = null, string? url = null, string? language = null)
        {
            Name = name;
            Description = description;
            Title= title;
            Url = url;
            Language = language;
        }
    }
}
