using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.util.json_structs
{
    public class OcclusionBlog
    {
        public long Id { get; set; }

        public string FileName { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Tags { get; set; }

        public string Author { get; set; }

        public string AuthorURL { get; set; }

        public string DatePosted { get; set; }

        public string BackgroundURL { get; set; }

        public string BodyMarkdown { get; set; }

        public DateTime CreationDate { get; set; }
    }

    public class OcclusionBlogs
    {
        public OcclusionBlog[] Blogs { get; set; }
    }
}
