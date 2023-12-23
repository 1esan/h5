using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h5
{
    public class Teacher : Person
    {
        private string department;
        private string position;
        private List<Student> students;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public Teacher(string name, int age, string department, string position, List<Student> students) : base(name, age)
        {
            this.department = department;
            this.position = position;
            this.students = students;
        }

        public override void Print()
        {
            Console.WriteLine("-----------------------------------------------");
            base.Print();
            Console.WriteLine("Отдел: {0}, Должность: {1}", department, position);
            Console.WriteLine("Студенты:");
            foreach (Student s in students)
            {
                s.Print();
            }
            Console.WriteLine("-----------------------------------------------");
        }

        public override string ToString()
        {
            return $"Учителя: {Name}, {Age}, {department}, {position}, {students.Count} студентов(а)";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Teacher t = (Teacher)obj;
            return base.Equals(obj) && department == t.department && position == t.position && students.Equals(t.students);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ department.GetHashCode() ^ position.GetHashCode() ^ students.GetHashCode();
        }

        private static Teacher[] teachers = new Teacher[] {
        new Teacher("Сергей", 40, "Матиматика", "Профессор", new List<Student>() { Student.RandomStudent(), Student.RandomStudent() }),
        new Teacher("Николай", 41, "Физика", "Доцент", new List<Student>() { Student.RandomStudent(), Student.RandomStudent() }),
        new Teacher("Владимир", 42, "Химия", "Доцент", new List<Student>() { Student.RandomStudent() })
        };



        public static Teacher RandomTeacher()
        {
            Random rnd = new Random();
            int index = rnd.Next(teachers.Length);
            return (Teacher)teachers[index].Clone();
        }

        public override object Clone()
        {
            return new Teacher(Name, Age, department, position, new List<Student>(students));
        }
    }
}
