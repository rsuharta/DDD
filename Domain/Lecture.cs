namespace Domain
{
    using WebApplication1;

    public class Lecture : Entity
    {
        protected Lecture()
        {    
        }

        public Lecture(Theater theater, int durationInHour)
        {
            this.DurationInHour = durationInHour;
        }

        public virtual long TheaterId { get; protected set; }

        public virtual Theater Theater { get; protected set; }

        public virtual int DurationInHour { get; protected set; }
    }
}
