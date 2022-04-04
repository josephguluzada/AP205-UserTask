using AccountTask.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountTask.Models
{
    public class Group
    {
        //private Student[] _students = new Student[0];
        private string _groupNo;


        public string GroupNo
        {
            get { return _groupNo; }
            set { if (CheckGroupNo(value)) _groupNo = value; }
        }
        public int StudentLimit { get; set; }
        public List<Student> Students { get; set; }



        public Group(string groupNo, int studentLimit)
        {
            GroupNo = groupNo;
            StudentLimit = studentLimit;
        }

        public bool CheckGroupNo(string groupNo) // 203AP
        {
            if (groupNo.Length == 5 && !String.IsNullOrEmpty(groupNo) && !String.IsNullOrWhiteSpace(groupNo))
            {
                int upperLetterCount = 0;
                int digitCount = 0;

                for (int i = 0; i < groupNo.Length; i++)
                {
                    if (i < 2)
                    {
                        if (char.IsUpper(groupNo[i])) upperLetterCount++;
                    }
                    else if (upperLetterCount == 2 && i >= 2)
                    {
                        if (char.IsDigit(groupNo[i])) digitCount++;
                    }
                    else
                    {
                        return false;
                    }
                    if (upperLetterCount == 2 && digitCount == 3) return true;
                }
            }

            return false;
        }



        public void AddStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException("Student can't be null!");

            if (Students.Count < StudentLimit) Students.Add(student);

            else throw new ArgumentOutOfRangeException("Limit overflow");

        }

        public Student GetStudent(int? studentId)
        {
            if (studentId == null) throw new NullReferenceException("Id can't be null!");

            Student wantedStudent = Students.Find(s => s.Id == studentId);

            if (wantedStudent == null) throw new Exception("Student yoxdur");

            return wantedStudent;
        }

        public List<Student> GetAllStudents() => Students;




        // Add Student
        //public void AddStudent(Student student)
        //{
        //    if(_students.Length <= StudentLimit)
        //    {
        //        Array.Resize(ref _students, _students.Length + 1);
        //        //_students[_students.Length - 1] = student;
        //        _students[^1] = student;
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException();
        //    }
        //}


        // Get Student
        //public Student GetStudent(int? studentId)
        //{
        //    if(studentId != null)
        //    {
        //        foreach (Student student in _students)
        //        {
        //            if (student.Id == studentId) return student;
        //        }

        //    }
        //    else
        //    {
        //        throw new NullReferenceException("Id null ola bilmez!");
        //    }

        //    throw new NotFoundException("Axtardiginiz telebe yoxdur cunki bu bizim siyahimizda deyil,mentiqle bele olmalidir,cunki yoxdur!");
        //}

        // Get All Students
        //public Student[] GetAllStudents()
        //{
        //    return _students;
        //}

    }
}
