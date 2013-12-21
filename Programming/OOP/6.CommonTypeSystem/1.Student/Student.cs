using System;
using System.Linq;
using System.Text;

public class Student : ICloneable, IComparable<Student>
{
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public string Ssn { get; private set; }
    public string PermanentAddress { get; private set; }
    public string MobilePhone { get; private set; }
    public string Email { get; private set; }
    public string Course { get; private set; }
    public Specialties? Specialties { get; private set; }
    public Universities? Universities { get; private set; }
    public Faculties? Faculties { get; private set; }

    public Student(string firstName, string middleName, string lastName, string ssn)
        : this(firstName, middleName, lastName, ssn, null, null, null, null, null, null, null)
    {

    }
    public Student(string firstName, string middleName, string lastName, string ssn, string permanentAddress, string mobilePhone, string eMail, string course, Specialties? specialty, Universities? university, Faculties? faculty)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.Ssn = ssn;
        this.PermanentAddress = permanentAddress;
        this.MobilePhone = mobilePhone;
        this.Email = eMail;
        this.Course = course;
        this.Specialties = specialty;
        this.Universities = university;
        this.Faculties = faculty;
    }

    public override bool Equals(object param)
    {
        // If the cast is invalid, the result will be null
        Student student = param as Student;
        // Check if we have valid not null Student object
        if (student == null)
            return false;
        if (!Object.Equals(this.Ssn, student.Ssn))
            return false;
        return true;
    }

    public static bool operator ==(Student student1,
                                  Student student2)
    {
        return Equals(student1, student2);
    }

    public static bool operator !=(Student student1,
                       Student student2)
    {
        return !(Equals(student1, student2));
    }

    public override int GetHashCode()
    {
        return Ssn.GetHashCode();
    }

    public object Clone()
    {
        return new Student(
            this.FirstName, this.MiddleName, this.LastName, this.Ssn, this.PermanentAddress, this.MobilePhone,
            this.Email, this.Course, this.Specialties, this.Universities, this.Faculties
            ) as object;
    }

    public int CompareTo(Student other)
    {
        if (!(Equals(this, other)))
        {
            Student[] students = { this, other };
            students.OrderBy(s => s.FirstName).ThenBy(s => s.MiddleName).ThenBy(s => s.LastName).ThenBy(s => s.Ssn);

            return Equals(students.First(), other) ? 1 : -1;
        }
        return 0;
    }

    public override string ToString()
    {
        StringBuilder infoBuilder = new StringBuilder();
        infoBuilder.AppendFormat("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName).AppendLine();
        infoBuilder.AppendLine("SSN: " + this.Ssn);
        if (!String.IsNullOrEmpty(this.PermanentAddress))
            infoBuilder.AppendFormat("Address: {0} \n", this.PermanentAddress);
        if (!String.IsNullOrEmpty(this.MobilePhone))
            infoBuilder.AppendFormat("Mobile Phone: {0} \n", this.MobilePhone);
        if (!String.IsNullOrEmpty(this.Email))
            infoBuilder.AppendFormat("Email: {0} \n", this.Email);
        if (!String.IsNullOrEmpty(this.Course))
            infoBuilder.AppendFormat("Course: {0} \n", this.Course);
        if (!String.IsNullOrEmpty(this.Specialties.ToString()))
            infoBuilder.AppendFormat("Specialties: {0} \n", this.Specialties);
        if (!String.IsNullOrEmpty(this.Universities.ToString()))
            infoBuilder.AppendFormat("Universities: {0} \n", this.Universities);
        if (!String.IsNullOrEmpty(this.Faculties.ToString()))
            infoBuilder.AppendFormat("Faculties: {0} \n", this.Faculties);
        return infoBuilder.ToString();
    }


}
