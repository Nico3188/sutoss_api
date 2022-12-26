using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Attributes
{
    public class UrlAttribute : Attribute
    {
        private string urlAlias;
        public string UrlAlias
        {
            get { return urlAlias; }
        }

        public UrlAttribute(string urlAlias)
        {
            this.urlAlias = urlAlias;
        }
    }
}
