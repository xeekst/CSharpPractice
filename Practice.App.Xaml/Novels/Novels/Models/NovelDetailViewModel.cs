using System;
using System.Collections.Generic;

namespace Novels.Models
{
    public class NovelDetailViewModel
    {

        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public List<string> Contents { get; set; }
    }
}
