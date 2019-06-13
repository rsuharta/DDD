namespace Domain
{
    using Contract.Enums;

    using WebApplication1;

    public class Schedule : Entity
    {
        protected Schedule()
        {
        }

        public virtual WeekDay Day { get; protected set; }

        public virtual string StartTime { get; protected set; }

        public virtual string EndTime { get; protected set; }
    }
}
