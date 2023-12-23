using h5;
using System;
Person[] people = new Person[10];
for (int i = 0; i < people.Length; i++)
{
    int type = new Random().Next(4);
    switch (type)
    {
        case 0: 
            people[i] = Person.RandomPerson();
            break;
        case 1: 
            people[i] = Student.RandomStudent();
            break;
        case 2: 
            people[i] = Teacher.RandomTeacher();
            break;
        case 3: 
            people[i] = new StudentWithAdvisor(Student.RandomStudent().Name, Student.RandomStudent().Age, Student.RandomStudent().Faculty, Student.RandomStudent().Course, Teacher.RandomTeacher());
            break;
    }
}

Console.WriteLine("Человеки:");
foreach (Person p in people)
{
    p.Print();
    Console.WriteLine();
}
int personCount = 0;
int studentCount = 0;
int teacherCount = 0;
foreach (Person p in people)
{
    if (p is Person) personCount++;
    if (p is Student) studentCount++;
    if (p is Teacher) teacherCount++;
}
Console.WriteLine("В массиве: {0} человек, {1} учащихся и {2} преподавателей.", personCount, studentCount, teacherCount);

foreach (Person p in people)
{
    if (p is Student)
    {
        Student s = p as Student;
        s.Course++;
    }
}
Console.WriteLine("Все студенты переведены на следующий курс.");

Console.WriteLine("Клоны:");
foreach (Person p in people)
{
    Person clone = (Person)p.Clone();
    clone.Print();
    Console.WriteLine();
}

Console.WriteLine("Предки студентов:");
PrintAncestors(typeof(Student));

static void PrintAncestors(Type type)
{

    if (type.BaseType != null)
    {
        PrintAncestors(type.BaseType);
        Console.WriteLine(type.BaseType.Name);
    }
}
