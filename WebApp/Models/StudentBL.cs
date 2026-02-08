namespace WebApp.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>() { 
                new Student() {Id=1,Name="ahmed",ImageURl="m.png"},
                new Student() {Id=2,Name="Eslam",ImageURl="m.png"},
                new Student() {Id=3,Name="Amira",ImageURl="2.jpg"},
                new Student() {Id=4,Name="Sara",ImageURl="2.jpg"},
            };
        }

        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetByID(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
