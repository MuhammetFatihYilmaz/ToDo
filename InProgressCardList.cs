using System;
using System.Collections.Generic;


namespace ToDo
{
    public class InProgressCardList
    {
        public static List<Card> inProgressCardList {get; set;}


        static InProgressCardList()
        {
            inProgressCardList = new List<Card>();
        }

        public static void WriteInProgressCardData()
        {
            foreach (var item in inProgressCardList)
            {
                Console.WriteLine("Başlık      : "+item.Title);
                Console.WriteLine("İçerik      : "+item.Content);
                Console.WriteLine("Atanan Kişi : "+item.Appointee);
                Console.WriteLine("Büyüklük    : "+item.TaskSize);
                Console.WriteLine("---");
            }
            if(inProgressCardList.Count==0)
            {
                Console.WriteLine("~ BOŞ ~");
                Console.WriteLine("---");
            }
        }
    }

}