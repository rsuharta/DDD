namespace Domain
{
    using System;

    using WebApplication1;

    public class Enrollment : Entity
    {
        protected Enrollment()
        {
        }

        private Enrollment(Subject subject, DateTime enrolledDate)
        {
            this.Subject = subject;
            this.EnrollmentDate = enrolledDate;
        }
        
        public static Enrollment New(Subject subject, DateTime enrolledDate)
        {
            return new Enrollment(subject, enrolledDate);
        }
         
        public DateTime EnrollmentDate { get; protected set; }
        
        public virtual Subject Subject { get; protected set; }
    }
}
