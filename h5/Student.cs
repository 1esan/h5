using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h5
{
    public class Student : Person
    {
        private string faculty;
        private int course;

        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public int Course
        {
            get { return course; }
            set
            {
                if (value < 1) value = 1;
                course = value;
            }
        }

        public Student(string name, int age, string faculty, int course) : base(name, age)
        {
            this.faculty = faculty;
            this.course = course;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Факультет: {0}, Курс: {1}", faculty, course);
        }

        public override string ToString()
        {
            return $"Студент: {Name}, {Age}, {faculty}, {course}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Student s = (Student)obj;
            return base.Equals(obj) && faculty == s.faculty && course == s.course;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ faculty.GetHashCode() ^ course.GetHashCode();
        }

        private static Student[] students = new Student[]
        {
        new Student("Анна", 19, "Математика", 1),
        new Student("Александр", 20, "Физика", 2),
        new Student("Евгения", 21, "Химия", 3),
        new Student("Данила", 22, "Биология", 4),
        new Student("Екатерина", 23, "Информатика", 5)
        };

        public static Student RandomStudent()
        {
            Random rnd = new Random();
            int index = rnd.Next(students.Length);
            return students[index];
        }
        public override object Clone()
        {
            return new Student(Name, Age, faculty, course);
        }
    }
}
