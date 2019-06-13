namespace Domain
{
    using FluentNHibernate;
    using FluentNHibernate.Mapping;
    
    public class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap()
        {
            Id(x => x.Id);
            Map(x => x.SubjectCode);
            Map(x => x.ScheduleId);
            Map(x => x.LectureId);

            HasOne(x => x.Schedule).ForeignKey("ScheduleId").Cascade.All();
            HasOne(x => x.Lecture).ForeignKey("LectureId").Cascade.All();

            HasMany<Enrollment>(Reveal.Member<Subject>("Enrollments")).KeyColumn("Id")
                .Cascade.SaveUpdate()
                .Not.LazyLoad()
                .Inverse();
        }
    }
}
