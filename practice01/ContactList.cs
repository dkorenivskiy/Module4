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
            Console.WriteLine("***********Contact List***********");
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - Show All Contacts");
            Console.WriteLine("2 - Add Contact");
            Console.WriteLine("3 - Remove Contact");
            Console.WriteLine("4 - Edit Contact");
            Console.WriteLine("5 - Find Contact");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    break;

                case 2:
                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter number:");
                    string number = Console.ReadLine();

                    AddContact(new Contact { Name = name, PhoneNumber = number });
                    break;

                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 0:
                default:
                    break;
            }
        }

        private void PrintContacts()
        {
            using (var db = new ApplicationContext())
            {
                var contacts = db.Contacts
                    .Include(c => c.Group)
                    .ToList();

                foreach(var contact in contacts)
                {
                    Console.WriteLine($"\t{contact.Group.Title}");
                    Console.WriteLine($"{contact.Name} - {contact.PhoneNumber}");
                }
            }
        }

        private void AddContact(Contact contact)
        {
            using(var db = new ApplicationContext())
            {
                var name = contact.Name.ToCharArray();

                if (_alphabet.Contains(name[0]))
                {
                    var group = new Group { Title = name[0].ToString() };
                    db.AddRange(contact, group);
                }
                else
                {
                    if (Char.IsDigit(name[0]))
                    {
                        var group = new Group { Title = "0-9" };
                        db.AddRange(contact, group);
                    }
                    else
                    {
                        var group = new Group { Title = "#" };
                        db.AddRange(contact, group);
                    }
                }

                db.SaveChanges();
            }
        }

        private void FindContact()
        {

        }
    }
}
