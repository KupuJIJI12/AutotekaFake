namespace AutoInfo.Domain.Models
{
    public class Person
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string? PresentAddress { get; set; }
        public string? CitizenShip { get; set; }

        protected Person(string firstName, string secondName, string middleName = "")
        {
            FirstName = firstName;
            SecondName = secondName;
            MiddleName = middleName;
            FullName = $"{firstName} {secondName}{(string.IsNullOrEmpty(middleName) ? "" : " " + middleName)}";
        }
    }
}