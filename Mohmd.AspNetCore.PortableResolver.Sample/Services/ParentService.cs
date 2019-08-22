using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohmd.AspNetCore.PortableResolver.Sample.Services
{
    public class ParentService
    {
        private readonly ChildService _childService;

        public ParentService(ChildService childService)
        {
            _childService = childService;
        }

        public string Name { get; set; } = "Parent's name";

        public string GetChildName()
        {
            return _childService.Name;
        }
    }
}
