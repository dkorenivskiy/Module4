using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice01
{
    public class ContactList
    {
        private char[] _alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public void Run()
        {
            string choice = "null";

            while (choice != "0")
            {
                Console.WriteLine("***********Contact List***********");
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - Show All Contacts");
                Console.WriteLine("2 - Add Contact");
                Console.WriteLine("3 - Remove Contact");
                Console.WriteLine("4 - Edit Contact");
                Console.WriteLine("5 - Find Contact");
                choice = Console.ReadLine();

                string name, number;
                switch (choice)
                {
                    case "1":
                        PrintContacts();

                        Console.WriteLine("\nDone");
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("Enter name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter number:");
                        number = Console.ReadLine();

                        AddContact(new Contact { Name = name, PhoneNumber = number });

                        Console.WriteLine("\nDone");
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.WriteLine("Enter name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter number:");
                        number = Console.ReadLine();

                        RemoveContact(new Contact { Name = name, PhoneNumber = number });

                        Console.WriteLine("\nDone");
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        Console.WriteLine("Enter name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter number:");
                        number = Console.ReadLine();

                        EditContact(new Contact { Name = name, PhoneNumber = number });

                        Console.WriteLine("\nDone");
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":
                        Console.WriteLine("Enter name(if you don't remember, you can skip):");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter number(if you don't remember, you can skip):");
                        number = Console.ReadLine();

                        Console.WriteLine("Results:");
                        foreach (var contact in FindContact(new Contact { Name = name, PhoneNumber = number }))
                        {
                            Console.WriteLine($"{contact.Name} - {contact.PhoneNumber}");
                        }

                        Console.WriteLine("\nDone");
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Wrong value!");
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private void PrintContacts()
        {
            using (var db = new ApplicationContext())
            {
                foreach (Group group in db.Groups.Where(x => x.Contacts.Count > 0).Include(x => x.Contacts))
                {
                    Console.WriteLine($"\t{group.Title}");
                    foreach (var contact in group.Contacts)
                    {
                        Console.WriteLine($"{contact.Name} - {contact.PhoneNumber}");
                    }
                }
            }
        }

        private void AddContact(Contact contact)
        {
            using (var db = new ApplicationContext())
            {
                var groupTitle = char.IsDigit(contact.Name[0]) ? "0-9"
                    : char.IsLetter(contact.Name[0]) ? contact.Name[0].ToString()
                    : "#";

                contact.Group =
                    db.Groups
                        .FirstOrDefault(x => x.Title == groupTitle) ??
                    new Group { Title = groupTitle };

                db.Contacts.Add(contact);

                db.SaveChanges();
            }
        }

        private void RemoveContact(Contact contact)
        {
            using (var db = new ApplicationContext())
            {
                if (FindContact(contact).Count > 1)
                {
                    List<Contact> contacts = FindContact(contact);
                    Console.WriteLine($"There are {contacts.Count} contacts. Which one you want to remove(type number of contact)?");

                    int count = 1;
                    foreach (var cont in contacts)
                    {
                        Console.WriteLine($"{count}. {cont}");
                    }

                    int choice = Convert.ToInt32(Console.ReadLine());
                    db.Remove(contacts[choice - 1]);
                    db.SaveChanges();
                }
                else
                {
                    db.RemoveRange(FindContact(contact));
                    db.SaveChanges();
                }
            }
        }

        private void EditContact(Contact contact)
        {
            using (var db = new ApplicationContext())
            {
                List<Contact> contacts = FindContact(contact);
                Console.WriteLine($"There is/are {contacts.Count} contacts. Which one you want to change(type number of contact)?");

                int count = 1;
                foreach (var cont in contacts)
                {
                    Console.WriteLine($"{count}. {cont}");
                }

                int choice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Type new name of this contact");
                string newName = Console.ReadLine();
                Console.WriteLine("Type new Phone Number of this contact");
                string newNumber = Console.ReadLine();
                RemoveContact(contact);
                AddContact(new Contact { Name = newName, PhoneNumber = newNumber });
                db.SaveChanges();
            }
        }

        private List<Contact> FindContact(Contact contact)
        {
            using (var db = new ApplicationContext())
            {
                List<Contact> contacts = new List<Contact>();
                contacts = db.Contacts.Where(c => c.PhoneNumber == contact.PhoneNumber || c.Name == contact.Name).ToList();

                return contacts;
            }
        }
    }
}
