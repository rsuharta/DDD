namespace WebApplication1.V1.UseCases.Enrollment
{
    public class EnrollStudentResponse
    {
        public string SubjectCode { get; set; }

        public string StudentCode { get; set; }

        public bool IsEnrolled { get; set; }
    }
}
