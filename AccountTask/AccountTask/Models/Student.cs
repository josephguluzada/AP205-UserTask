using System;
using System.Collections.Generic;
using System.Text;

namespace AccountTask.Models
{
    public class Student
    {
        private static int _id;
        public int Id { get;}
        public string Fullname { get; set; }
        public double Point { get; set; }

        static Student()
        {
            _id = 0;
        }

        private Student()
        {
            _id++;
            Id = _id;
        }

        public Student(string fullname, double point):this()
        {
            Fullname = fullname;
            Point = point;
        }


        public void StudentInfo()
        {
            Console.WriteLine($"Id: {Id} Fullname: {Fullname} Point: {Point}");
        }
    }
}
