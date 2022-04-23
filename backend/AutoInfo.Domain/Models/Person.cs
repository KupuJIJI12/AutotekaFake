namespace AutoInfo.Domain.Models
{
    public class Person
    {
        public string FullName { get; }
        public string? PresentAddress { get; set; }
        public string? CitizenShip { get; set; }

        protected Person(string name, string surname, string patronymic = "")
        {
            FullName = $"{name} {surname}{(string.IsNullOrEmpty(patronymic) ? "" : " " +  patronymic)}";
        }
    }
}