using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Librarian
    {
        string bookName, bookWriter;
        int bookId;
        string issueDate;
        public void AddBookToTheLibrary()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystem.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);

            int counter = 1, totalBooks;
            Console.WriteLine("Enter total number Of books you want to store in the library");
            totalBooks = Convert.ToInt32(Console.ReadLine());

            while (counter <= totalBooks)
            {

                Console.WriteLine("Enter Book Id.");
                bookId = Convert.ToInt32(Console.ReadLine());
                streamWriterObj.Write(bookId + ",");

                Console.WriteLine("Enter book name.");
                bookName = Console.ReadLine();
                streamWriterObj.Write(bookName + ",");

                Console.WriteLine("Enter book writer name.");
                bookWriter = Console.ReadLine();
                streamWriterObj.WriteLine(bookWriter);
                counter++;
            }
            streamWriterObj.Close();
            fileStreamObj.Close();
            Console.WriteLine("File write operation completed");

        }

        public void StoreBorrowerDetails(String borrowerName, int borrowerId, string bookName)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\Borrowers.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);

            streamWriterObj.Write(borrowerName + ",");

            streamWriterObj.Write(borrowerId + ",");

            streamWriterObj.Write(bookName + ",");

            issueDate = DateTime.Now.ToShortDateString();
            streamWriterObj.WriteLine(issueDate);

            streamWriterObj.Close();
            fileStreamObj.Close();

            Console.WriteLine("File write operation completed");
          
            UpdateBooksDetailFile(bookName);


        }

        public void UpdateBooksDetailFile(string bookName)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystem.txt", FileMode.Open, FileAccess.Read);

            FileStream fileStreamWObj = new FileStream(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystemNew.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamWObj);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] bookDataArr = line.Split(',');
                if (line.Contains(bookName))
                {
                    continue;

                }
                else
                {
                    for (int i = 0; i < bookDataArr.Length; i++)
                        streamWriterObj.Write(bookDataArr[i] + ",");
                }
                streamWriterObj.Write("\n");
            }
            streamWriterObj.Close();
            streamReaderObj.Close();
            fileStreamWObj.Close();

            File.Delete(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystem.txt");
            File.Move(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystemNew.txt", @"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystem.txt");

        }

        public void ShowAvailableBooksInLibrary()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystem.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            Console.WriteLine("BookId\tBookName\tBookAuthor");
            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] bookDataArr = line.Split(',');

                for (int i = 0; i < bookDataArr.Length; i++)
                {
                    Console.Write(bookDataArr[i] + "\t");
                    if (i == 1)
                    {
                        Console.Write("\t");
                    }
                }
                Console.WriteLine("");
            }
            streamReaderObj.Close();
            fileStreamObj.Close();
        }




    }
}
