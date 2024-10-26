using Directory.Classes;
using static System.Console;
namespace Directory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase ContactsDB = new DataBase();
            if (!ContactsDB.IsExist(name: "Андрей Петрович")) ContactsDB.AddContact(new Contact("Андрей Петрович", "+111111", false));
            if (!ContactsDB.IsExist(name: "Изольда Павловна")) ContactsDB.AddContact(new Contact("Изольда Павловна", "+222222", true));
            if (!ContactsDB.IsExist(name: "Персивальд Артемович")) ContactsDB.AddContact(new Contact("Персивальд Артемович", "+333333", false));

            ContactsDB.ShowAll();

            Contact findContact = ContactsDB.GetByName("Перс");
            if (findContact != null)
            {
                ContactsDB.SetChosen(findContact, true);
                WriteLine("Контакт с подстрокой \"Перс\" был найден и добавлен в избранное");
            }
            else WriteLine("Контакт с подстрокой \"Перс\" найден не был");


            ContactsDB.AddContact(new Contact("Веряскин Иван","+123456",true));

            Contact DellContact = ContactsDB.GetAllChosen(true).FirstOrDefault(contact=>contact.PhoneNumber.Contains("+1"));
            if (DellContact != null)WriteLine($"Пользователь начинающийся с номера +1 и первый в избранном был найден, это : \n {DellContact.ToString()}");
            else WriteLine($"Пользователь начинающийся с номера +1 и первый в избранном не был найден");

            ContactsDB.RemoveContact(DellContact);

            ContactsDB.ShowAll();
        }
    
    }
}
