using System;
using System.Collections.Generic;
using TechVerse.Utilities; 

namespace TechVerse.Models
{
    public class Student
    {
        public int UserID { get; private set; }// Primary Key
        public string? FullName { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public int Age { get; private set; }
        public string? Country { get; private set; }
        public string? PhoneNumber { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public int LearningHours { get; private set; }
        public int CertificatesCount { get; private set; }

        public virtual ICollection<Submission> Submissions { get; private set; } = new List<Submission>();

        protected Student() { }

        public Student(string fullName, string email, string password, int age, string country, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty");
            if (age < 12) throw new ArgumentException("Student is too young");

            FullName = fullName;
            Email = email;

            Password = PasswordHasher.HashPassword(password);

            Age = age;
            Country = country;
            PhoneNumber = phoneNumber;

            RegistrationDate = DateTime.UtcNow;
            LearningHours = 0;
            CertificatesCount = 0;
        }
        public string RegisterDateFormatted => RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss");
    }
}