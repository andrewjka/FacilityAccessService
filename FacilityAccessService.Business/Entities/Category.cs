namespace FacilityAccessService.Business.Entities
{
    /// <summary>
    /// Describes a set of facilities in the access control system.
    /// </summary>
    public class Category
    {
        public string Name { get; private set; }
        public Object[] Objects { get; private set; }


        public Category(string name, Object[] objects)
        {
            this.Name = name;
            this.Objects = objects;
        }
    }
}