using System;
using System.Collections.Generic;

namespace ToDo
{
    public class ToDoCardList
    {
        public static List<Card> toDoCardList {get; set;}


        static ToDoCardList()
        {
            toDoCardList = new List<Card>();
        }

        public static void WriteToDoCardData()
        {
            foreach (var item in toDoCardList)
            {
                Console.WriteLine("Başlık      : "+item.Title);
                Console.WriteLine("İçerik      : "+item.Content);
                Console.WriteLine("Atanan Kişi : "+item.Appointee);
                Console.WriteLine("Büyüklük    : "+item.TaskSize);
                Console.WriteLine("---");
            }
            if(toDoCardList.Count==0)
            {
                Console.WriteLine("~ BOŞ ~");
                Console.WriteLine("---");
            }
        }
    }

}