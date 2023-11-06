using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;

namespace LegacyLibrary
{
     class ProjectCode
    {


      /**  private static void Main(string[] args)
        {

            //System librarySystem = new Sytsem();
            // librarySystem.Signup();
            //  librarySystem.Login();
            Console.WriteLine("Hello, World!");
            Book b = new Book("ho", "ho", "ho", "blah", 0.0);
            Console.WriteLine(b.ToString());

            //Console.ReadKey();  
        }
      **/


        public interface System
        {

            // SearchBook();

            bool Login(string username,string password);
            void Signup(string username, string password, int id, string typeUser, int phoneNumber, string email);



        }

        public class Book
        {
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Edition { get; set; }
            public double Price { get; set; }
            public bool IsBorrowed { get; set; }
            public DateTime BorrowDate { get; set; }
            private DateTime expectedReturnDate;
            public static List<Book> BorrowedBooks { get; } = new List<Book>();
            public static List<Book> AvailableBooks { get; } = new List<Book>();
            private List<Book> Books = new List<Book>();

            public DateTime ExpectedReturnDate
            {
                get { return expectedReturnDate; }
                set
                {
                    ExpectedReturnDate = value;
                    CalculateExpectedReturnDate();
                }
            }
            //this is called in the setter 
            private void CalculateExpectedReturnDate()
            {
                expectedReturnDate = BorrowDate.AddDays(30);
            }

            //come back to it
            public Book(string isbn, string title, string author, string edition, double price)
            {
                ISBN = isbn;
                Title = title;
                Author = author;
                Edition = edition;
                Price = price;
                IsBorrowed = false;
                BorrowDate = DateTime.MinValue;
                ExpectedReturnDate = DateTime.MinValue;
            }

            public override string ToString()
            {//fix
                return "hiiii";
            }
            public static void UpdateBorrowedBooks(Book book)
            {
                // IsBorrowed = true;
                AvailableBooks.Remove(book);
                BorrowedBooks.Add(book);
            }

            public static void UpdateAvailableBooks(Book book)
            {
                //  IsBorrowed = false;
                BorrowedBooks.Remove(book);
                AvailableBooks.Add(book);
            }

            public void AddBook(Book book)
            {
                Books.Add(book);
            }

            //addition
            //is this necessary?
            //method is responsible for displaying the state (borrowed or available) of each book in the provided list b with book title
            public void ViewBookState()
            {
                foreach (var book in Books)
                {
                    if (book.IsBorrowed)
                    {
                        Console.WriteLine("{0} is borrowed", book.Title);
                    }
                    else
                    {
                        Console.WriteLine("{0} is available", book.Title);
                    }
                }
            }
            //returns a list of all the borrowed books
            public List<Book> GetBorrowedBooks()
            {
                //List<Book> borrowedBooks = Books.FindAll(book => book.IsBorrowed);
                return Book.BorrowedBooks;
            }
            //returns a list of all available books
            public List<Book> GetAvailableBooks()
            {
                // List<Book> availableBooks = Books.FindAll(book => !book.IsBorrowed);

                return Book.AvailableBooks;
            }
            //called from borrower and librarian class
            //goes thru list b based on the books given ISBN 
            //if the boook is found in the list it searches if its borrowed or not
            //then if foundbook is empty then it gives an error message
            public virtual void UpdateBookStatus(List<Book> b, string isbn, bool isBorrowed, DateTime borrowDate, DateTime expectedReturnDate) //removed lists
            {
                Book foundBook = Books.Find(book => book.ISBN == isbn);

                if (foundBook != null)
                {
                    if (isBorrowed)
                    {

                        Book.UpdateBorrowedBooks(foundBook);
                        foundBook.IsBorrowed = true;
                        foundBook.BorrowDate = borrowDate;
                        foundBook.ExpectedReturnDate = expectedReturnDate;
                        Console.WriteLine($"{foundBook.Title} is borrowed by a borrower.");
                    }
                    else
                    {
                        Book.UpdateAvailableBooks(foundBook);
                        foundBook.IsBorrowed = false;
                        foundBook.BorrowDate = DateTime.MinValue;
                        foundBook.ExpectedReturnDate = DateTime.MinValue;
                        Console.WriteLine($"{foundBook.Title} is returned and available.");
                    }
                }

                else
                {
                    Console.WriteLine("Book not found in the library.");
                }
            }

        }


        public class user : System
        {
            public string Username { get; set; }
            public string Password { get; set; }
            int ID { get; set; }
            public string TypeUser { get; set; }
            int PhoneNumber { get; set; }
            public string Email { get; set; }
            public static List<user> validusers;


            public user(string username, string password, int id, string typeUser, int phoneNumber, string email)
            {
                Username = username;
                Password = password;
                ID = id;
                TypeUser = typeUser;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public user(string username,string password)
            {
                Username = username;
                Password = password;
            }

            public user()
            {
                validusers = new List<user>();
            }
            public bool Login(string inputUsername,string inputPassword)
            {
                //here are they local varaibles or 
              //  Console.WriteLine("Enter your username:");
                //string inputUsername = Console.ReadLine();

               // Console.WriteLine("Enter your password:");
               // string inputPassword = Console.ReadLine();


                 user validUser = validusers.FirstOrDefault(user => user.Username == inputUsername && user.Password == inputPassword);

                if (validUser != null)
                {
                    Console.WriteLine("Login successful!");
                    // Perform further actions after successful login
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Login failed.");
                }
                return Username==inputUsername && Password==inputPassword;

            }
            public void Signup(string username, string password, int id, string typeUser, int phoneNumber, string email)
            {
                Console.WriteLine("Enter your username:");
                string inputUsername = Console.ReadLine();

                // Check if the username already exists
                bool usernameExists = validusers.Any(user => user.Username == inputUsername);

                if (usernameExists)
                {
                    Console.WriteLine("Username already exists. Please choose a different username.");
                }
                else
                {
                    Console.WriteLine("Enter your password:");
                    string inputPassword = Console.ReadLine();

                    Console.WriteLine("Enter your ID:");
                    int inputId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your user type:");
                    string inputUserType = Console.ReadLine();

                    Console.WriteLine("Enter your phone number:");
                    int inputPhoneNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your email:");
                    string inputEmail = Console.ReadLine();

                    user newUser = new user(inputUsername, inputPassword, inputId, inputUserType, inputPhoneNumber, inputEmail);

                    // Add the new user to the list of valid users
                    validusers.Add(newUser);

                    Console.WriteLine("Signup successful!");

                }
            }
        }


        public class Librarian : user
        {
            public user LibrarianUser;
            public Book LibrarianBook;

            List<Book> books = new List<Book>();
            public Librarian(string username, string password, int id, string typeUser, int phoneNumber, string email) : base(username, password, id, typeUser, phoneNumber, email)
            {

            }

            //goes thru list b based on the books given ISBN 
            //if the boook is found in the list it searches if its borrowed or not
            //then if foundbook is empty then it gives an error message
            public void UpdateStatus(List<Book> b, string isbn, bool isBorrowed, DateTime borrowDate, DateTime expectedReturnDate) //removed lists
            {
                LibrarianBook.UpdateBookStatus(b, isbn, isBorrowed, borrowDate, expectedReturnDate);
            }
        }



        public class Borrower : user
        {   //shall i keep this or do private user and pass for each account type
            public System BorrowerUser;
            public Book BorrowerBook;
            // public List<Book> BorrowedBooks { get; set; }
            private string username;
            private string password;



            public Borrower(String username, String password, int iD, String typeUser, int phoneNumber, String email) : base() //removed lists
            {
                // BorrowedBooks = new List<Book>();
            }
            //searches for the specific  book b1 based on the ISBN in list b
            //it tells you whether thebook in the list is borrwed or not
            public Boolean SearchBook(List<Book> b, Book b1)
            {
                Boolean flag = false;
                if (Book.BorrowedBooks.Contains(b1))
                {
                    Console.WriteLine($"{b1.Title} is borrowed");
                    flag = true;
                }
                else if (Book.AvailableBooks.Contains(b1))
                {
                    Console.WriteLine($"{b1.Title} is available");
                    flag = false;
                }
                else
                    Console.WriteLine($"{b1.Title} is not found in the library");


                return flag;

            }
            //makes sure that the book is only borrowed if its available to ensure data consistency
            public void BorrowBook(Book book)
            {
                // if (book.IsBorrowed)
                if (Book.AvailableBooks.Contains(book))
                {
                    Console.WriteLine($"{book.Title} is already borrowed.");
                }
                else if (Book.AvailableBooks.Contains(book))
                {
                    Book.UpdateBorrowedBooks(book);
                    //add username field
                    Console.WriteLine($"{book.Title} is borrowed by.");
                }

            }
            //here we physically return the book
            public void ReturnBook(Book book)
            {

                if (Book.BorrowedBooks.Contains(book))
                {
                    Book.UpdateAvailableBooks(book);
                    //Console.WriteLine($"{book.Title} is returned by {Username}.");
                    //add username field

                    Console.WriteLine($"{book.Title} is returned by .");
                }

                else
                {
                    Console.WriteLine($"{book.Title} has already been returned.");
                }
            }

            //tells if available or not in gen
            //then views all borrowed books
            public void UpdateStatus(List<Book> b, string isbn, bool isBorrowed, DateTime borrowDate, DateTime expectedReturnDate) //removed lists
            {

                // BorrowerBook.UpdateBookStatus(b, isbn, isBorrowed, borrowDate, expectedReturnDate);

                if (isBorrowed)
                {
                    //add username field
                    Console.WriteLine($"Borrowed books by :");

                    //here it replaced method viewborrowedbooks
                    foreach (var book in Book.BorrowedBooks)
                    {
                        Console.WriteLine($"{book.Title} (Borrowed on {book.BorrowDate.ToShortDateString()}, Expected return on {book.ExpectedReturnDate.ToShortDateString()})");
                    }


                }

            }
            //calculates fine by multiplying num of days late by 10
            //calculates the total fine about for a specific user
            //displays the fine amount for each late-return book and the total amount for the user
            public void CalculateFine()
            {
                DateTime currentDate = DateTime.Now;
                decimal totalFine = 0;

                foreach (var book in Book.BorrowedBooks)
                {

                    if (currentDate > book.ExpectedReturnDate)
                    {
                        int daysLate = (int)(currentDate - book.ExpectedReturnDate).TotalDays;
                        decimal fine = daysLate * 10;
                        totalFine += fine;
                        Console.WriteLine($"Fine for {book.Title}: {fine} SAR");
                    }
                }
                //add username field

                Console.WriteLine($"Total fine for : {totalFine} SAR");
            }
        }
    }
}


