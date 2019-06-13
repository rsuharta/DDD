
namespace Domain
{
    using Contract.Enums;

    using FluentNHibernate.Mapping;
    
    public class ScheduleMap : ClassMap<Schedule>
    {
        public ScheduleMap()
        {
            Id(x => x.Id);
            Map(x => x.StartTime);
            Map(x => x.EndTime);

            Map(x => x.Day).CustomType<WeekDay>();
        }
    }
}
