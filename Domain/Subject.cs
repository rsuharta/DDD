namespace Domain
{
    using System;
    using WebApplication1.Domain;

    public class Subject : AggregateRoot
    {
        protected Subject()
        {   
        }

        public Subject(Schedule schedule, Lecture lecture, string subjectCode)
        {
            this.Schedule = schedule;
            this.Lecture = lecture;
            this.SubjectCode = subjectCode;
        }

        public virtual long ScheduleId { get; protected set; }

        public virtual Schedule Schedule { get; protected set; }

        public virtual long LectureId { get; protected set; }

        public virtual Lecture Lecture { get; protected set; }

        public virtual String SubjectCode { get; protected set; }

        public virtual int NumberOfStudentEnrolled { get; protected set; }
        
        internal virtual bool TryEnrollStudent()
        {
            if (this.CanEnrollStudent())
            {
                this.NumberOfStudentEnrolled++;
                return true;
            }

            return false;
        }

        private bool CanEnrollStudent()
        {
            var lectureCapacity = this.Lecture.Theater.Capacity;
            return lectureCapacity > this.NumberOfStudentEnrolled;
        }
    }
}
