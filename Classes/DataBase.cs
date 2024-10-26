using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static System.Console;
using System.Numerics;

namespace Directory.Classes
{
    public class DataBase : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DatabaseFacade db { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ContactsDB.db");
        }

        public DataBase() { db = Database; db.EnsureCreated(); }
        public bool IsExist(string name = "", string phoneNumber = "")
        {
            if (name == "")
            {
                return GetByPhone(phoneNumber) != null;
            }
            else if (phoneNumber == "")
            {
                return GetByName(name) != null;
            }
            else
            {
                return GetByName(name) != null & GetByPhone(phoneNumber) != null;
            }
        }
        public void AddContact(Contact NewContact)
        {
            Contacts.Add(NewContact);
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"Новый контакт : ФИО: {NewContact.Name} Т:{NewContact.PhoneNumber} был успешно добавлен");
            ForegroundColor = ConsoleColor.Gray;
            SaveChanges();
        }
        public void RemoveContact(Contact RemContact)
        {
            Contacts.Remove(RemContact);
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"Контакт : ФИО: {RemContact.Name} Т:{RemContact.PhoneNumber} был успешно удален");
            ForegroundColor = ConsoleColor.Gray;
            SaveChanges();
        }
        public void UpdateCurrent(Contact CurContact) { Contacts.Update(CurContact); SaveChanges(); }
        public Contact GetByPhone(string phone) { return Contacts.FirstOrDefault(contact => contact.PhoneNumber.Contains(phone)); }
        public Contact GetByName(string name) { return Contacts.FirstOrDefault(contact => contact.Name.Contains(name)); }
        public void SetChosen(Contact contact, bool chosen)
        {
            contact.isChosen = chosen;
            UpdateCurrent(contact);
        }
        public IQueryable<Contact> GetAllChosen(bool isChosen) { return Contacts.Where(contact => contact.isChosen == isChosen); }
        public IQueryable<Contact> GetAll() { return Contacts; }
        public void ShowAll()
        {
            WriteLine("Полный список контактов : ");
            foreach (Contact contact in Contacts)
            {
                WriteLine(contact.ToString());
            }
        }
    }
}
