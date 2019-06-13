namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Domain.Exceptions;

    using WebApplication1.Domain;

    public class Student : AggregateRoot
    {
        protected Student()
        {   
        }

        public Student(string fullName)
        {
            this.FullName = fullName;

            if (this.Enrollments == null)
            {
                this.Enrollments = new List<Enrollment>();
            }
        }

        public virtual string StudentNumber { get; protected set; }

        public virtual string FullName { get; protected set; }

        protected virtual IList<Enrollment> Enrollments { get; }

        public virtual void EnrollIn(Subject subject)
        {
            var totalHourOfEnrolledLecture = this.Enrollments.Sum(enrollment => enrollment.Subject.Lecture.DurationInHour);
            var totalHourOfEnrollingLecture = subject.Lecture.DurationInHour;

            if (totalHourOfEnrolledLecture + totalHourOfEnrollingLecture > 10)
            {
                // TODO: better ex message
                throw new EnrollmentException("Exceeding the allowed total hours of lecture");
            }

            if (!subject.TryEnrollStudent())
            {
                // TODO: better ex message
                throw new EnrollmentException("Lecture reached its maximum capacity");
            }

            this.Enrollments.Add(Enrollment.New(subject, DateTime.UtcNow));
        }
    }
}
