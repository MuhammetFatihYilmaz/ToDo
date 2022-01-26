using System;

namespace ToDo
{
    public class Board
    {
        public void ToDoLine()
        {
            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");

            ToDoCardList.WriteToDoCardData();
            
        }

        public void InProgressLine()
        {
            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("************************");

            InProgressCardList.WriteInProgressCardData();
        }

        public void DoneLine()
        {
            Console.WriteLine("DONE Line");
            Console.WriteLine("************************");
            DoneCardList.WriteDoneCardData();
        }
    }

}