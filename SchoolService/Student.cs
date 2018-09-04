using System.Runtime.Serialization;

namespace SchoolService
{
    [DataContract]
    public class Student
    {
        public Student()
        {
        }

        public Student(string studentName)
        {
            StudentName = studentName;
        }

        public Student(int studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
        }

        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string StudentName { get; set; }

        public override string ToString()
        {
            return StudentId + ".\t" + StudentName + ";";
        }
    }
}