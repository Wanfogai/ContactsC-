namespace Directory.Classes
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool isChosen { get; set; }

        public Contact() { }

        public Contact(string name, string phoneNumber, bool ischosen)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            isChosen = ischosen;
        }

        public string ToString()
        {
            string isChosen = this.isChosen ? "Избранный" : "Не избранный";
            return $"ФИО: {Name}\n Телефон: {PhoneNumber}\n {isChosen}";
        }
    }
}
