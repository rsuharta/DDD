namespace Domain
{
    using FluentNHibernate;
    using FluentNHibernate.Mapping;

    public class LectureMap : ClassMap<Lecture>
    {
        public LectureMap()
        {
            Id(x => x.Id);
            Map(x => x.DurationInHour);
            Map(x => x.TheaterId);

            HasOne(x => x.Theater).ForeignKey("TheaterId").Cascade.All();
        }
    }
}
