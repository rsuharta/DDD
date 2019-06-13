namespace WebApplication1.Requests
{
    using Contract.Enums;

    public class CreateSubjectRequest
    {
        public string SubjectCode { get; set; }

        public WeekDay LectureDay { get; set; }

        public string LectureStartTime { get; set; }

        public string LectureEndTime { get; set; }

        public int MaximumCapacity { get; set; }
    }
}
