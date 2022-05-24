using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Users
    {

        public string userName, bookName;
        public int userId;
        // DateTime issueDate;

        Librarian librarian = new Librarian();
        public void BorrowBook()
        {
            Console.WriteLine("Enter Your name");
            userName = Console.ReadLine();

            Console.WriteLine("Enter Your borrower Id");
            userId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the book name you want to borrow.");
            bookName = Console.ReadLine();

            librarian.StoreBorrowerDetails(userName, userId, bookName);
            Console.WriteLine("Thanks for borrowing.");
            Console.WriteLine("You hava to pay 15 rs per day of a book");

        }

        public void InventoryDetails(string returnDate, int userId)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystemInventory.txt", FileMode.Open, FileAccess.Read);
            FileStream fileStreamWObj = new FileStream(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystemInventory.txt", FileMode.Append, FileAccess.Write);

            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamWObj);

            DateTime dt1 = Convert.ToDateTime(returnDate);
            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] borrowerArr = line.Split(',');
                DateTime dt2 = Convert.ToDateTime(borrowerArr[3]);


                if (borrowerArr[1] == Convert.ToString(userId))
                {
                    var t = dt1 - dt2;
                    int rentPeriod = t.Days;

                    streamWriterObj.Write(borrowerArr[1] + ",");
                    streamWriterObj.Write(borrowerArr[0] + ",");
                    streamWriterObj.WriteLine(rentPeriod * 15);
                }


            }
            streamWriterObj.Close();
            streamReaderObj.Close();
            fileStreamObj.Close();
        }
        public void ShowInventoryDetails()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\LUCKY\source\repos\LibraryManagementSystem\LibraryManagementSystemInventory.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            Console.WriteLine("UserId\tuserName\tBill");

            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                string[] dataArr = line.Split(',');
                for (int i = 0; i < dataArr.Length; i++)
                {
                    Console.Write(dataArr[i] + "\t");
                    if (i == 1)
                    {
                        Console.Write("\t");
                    }
                }
                Console.WriteLine();
            }

            streamReaderObj.Close();
            fileStreamObj.Close();

        }
    }
}

