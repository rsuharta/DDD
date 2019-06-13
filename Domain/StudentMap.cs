namespace Domain
{
    using FluentNHibernate;
    using FluentNHibernate.Mapping;
    
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.FullName);
            Map(x => x.StudentNumber);

            HasMany<Enrollment>(Reveal.Member<Student>("Enrollments"))
                .Cascade.SaveUpdate()
                .Not.LazyLoad()
                .Inverse();

            //HasMany<Enrollment>(Reveal.Member<Student>("Enrollments"))
            //    .Inverse()
            //    .Cascade.All()
            //    .Table("Enrollment");
        }
    }
}
