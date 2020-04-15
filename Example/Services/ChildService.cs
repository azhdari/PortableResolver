using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohmd.AspNetCore.PortableResolver.Sample.Services
{
    public class ChildService
    {
        public ChildService()
        {

        }

        public string Name { get; set; } = "Child's name";

        public string GetParentName()
        {
            var parentService = ResolverContext.Current.Resolve<ParentService>();
            return parentService.Name;
        }
    }
}
