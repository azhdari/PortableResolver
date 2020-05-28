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

        public string GetParentNameScoped()
        {
            using (var engine = ResolverContext.CreateNew())
            {
                var parentService = engine.Resolve<ParentService>();
                return parentService.Name;
            }
        }
    }
}
