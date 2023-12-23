using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h5
{
    public class StudentWithAdvisor : Student
    {
        private Teacher advisor;

        public Teacher Advisor
        {
            get { return advisor; }
            set { advisor = value; }
        }

        public StudentWithAdvisor(string name, int age, string faculty, int course, Teacher advisor) : base(name, age, faculty, course)
        {
            this.advisor = advisor;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Преподаватель: {0}", advisor.Name);
        }

        public override string ToString()
        {
            return $"Студент с преподавателем: {Name}, {Age}, {Faculty}, {Course}, {advisor.Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            StudentWithAdvisor s = (StudentWithAdvisor)obj;
            return base.Equals(obj) && advisor.Equals(s.advisor);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ advisor.GetHashCode();
        }
        public override object Clone()
        {
            return new StudentWithAdvisor(Name, Age, Faculty, Course, (Teacher)advisor.Clone());
        }
    }
}
