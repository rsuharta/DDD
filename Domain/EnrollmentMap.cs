namespace Domain
{
    using FluentNHibernate.Mapping;

    public class EnrollmentMap : ClassMap<Enrollment>
    {
        public EnrollmentMap()
        {
            Id(e => e.Id).GeneratedBy.Identity();
            Map(e => e.EnrollmentDate);

            References(e => e.Subject).Column("SubjectId").Cascade.All();
        }
    }
}
