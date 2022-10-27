using sutoss.Domain.Services.Domain.Attributes;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JobSeekerRecruitingApp.Data.Models.QueryParams.Base
{
    public abstract class BaseQueryParams
    {
        public string BasePath { get; set; }
        public virtual string BuildUrlQuery()
        {
            var queryParams = new List<string>();
            Type classType = this.GetType();
            var properties = classType.GetProperties().Where(x => x.Name != "BasePath").ToList();

            foreach (var currentProperty in properties)
            {
                if (currentProperty.GetValue(this) != null)
                {
                    var urlAtribute = currentProperty.GetCustomAttribute<UrlAttribute>();
                    queryParams.Add($"{urlAtribute.UrlAlias}={currentProperty.GetValue(this)}");
                }
            }

            string output = queryParams.Count > 0 ? BasePath + "?" + string.Join("&", queryParams) : BasePath;
            return output;
        }

        public virtual void UpdateFilterFromUri(Uri uri)
        {
            StringValues output = "";
            Type classType = GetType();
            var properties = classType.GetProperties().Where(x => x.Name != "BasePath").ToList();

            foreach (var currentProperty in properties)
            {
                var urlAtribute = currentProperty.GetCustomAttribute<UrlAttribute>();
                if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(urlAtribute.UrlAlias, out output))
                {
                    currentProperty.SetValue(this, output.ToString());
                }
            }

        }
    }
}
