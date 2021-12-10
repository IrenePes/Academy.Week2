using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Demo
{
    internal class Demo3
    {
        public static void DemoAnonymousTypes()
        { 

            var myAnonymousType = new // Definiamo un tipo "anonimo"
            {
                myProp1 = 1,
                MyProp2 = "ciao"
            };

            List<Student> students = new List<Student>()
            {
                new Student(){ Id = 1, Name = "Mario Rossi", ClassId = 1 },
                new Student(){ Id = 2, Name ="Sara Bianchi", ClassId = 1 },
                new Student(){ Id = 3, Name = "Nino Nini", ClassId = 2},
                new Student(){ Id = 4, Name = "Marta Neri", ClassId = 2}
            };

            List<SchoolClass> classes = new List<SchoolClass>()
            {
                new SchoolClass(){ Id = 1, Code = "1A" },
                new SchoolClass(){Id = 2, Code = "2B" }
            };

            // Mario Rossi in 1A
            // Sara Bianchi in 1A
            // Nino Nini in 2B
            // Marta Neri in 2B

            // Vogliamo combinare l'elenco di studenti con l'elenco delle classi

            // dal lato degli studenti 
            var list = students.Join(
                classes,
                s => s.ClassId,
                c => c.Id,
                (s, c) => new
                {
                    StudentName = s.Name,
                    ClassCode = c.Code
                }
                );

            foreach(var obj in list)
                Console.WriteLine(obj.StudentName + " in " + obj.ClassCode);

            // voglio raggruppare gli studenti per codice id della classe 

            var list2 = students.GroupBy(s => s.ClassId).ToList();

            // vogliamo fare in modo che per ogni classe id abbiamo tutti gli studenti che ci stanno

            foreach (var group in list2)
            {
                Console.WriteLine(group.Key);

                foreach (var student in group)
                    Console.WriteLine(student.Name);
            }


            var list3 = classes.GroupJoin(
                students,
                c => c.Id,
                s => s.ClassId,
                (c, studentsSubgroup) => new
                {
                    ClassCode = c.Code,
                    Names = studentsSubgroup.Select(student => student.Name)
                }
                );

            foreach(var item in list3)
            { 
                Console.WriteLine(item.ClassCode);
                foreach(var name in item.Names)
                    Console.WriteLine(name);
            }

        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }

    }

    public class SchoolClass
    {
        public int Id { get; set; }
        public string Code { get; set; }

    }
}
