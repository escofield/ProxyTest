using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
namespace RequestIntercessor.Models
{
    public class MirrorView
    {
        public IHeaderDictionary Headers { get; set;}
        public string Body { get; set; }
        public string Url { get; set; }
        public IDictionary<string,string> Form { get; set; }

        public MirrorView()
        {
            this.Form = new Dictionary<string,string>();
        }
    }
}