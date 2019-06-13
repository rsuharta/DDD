namespace Domain
{
    using FluentNHibernate.Mapping;

    public class TheaterMap : ClassMap<Theater>
    {
        public TheaterMap()
        {
            Id(x => x.Id);
            Map(x => x.Capacity);
        }
    }
}
