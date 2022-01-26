using System;
using System.Collections.Generic;


namespace ToDo
{
    public class DoneCardList
    {
        public static List<Card> doneCardList {get; set;}


        static DoneCardList()
        {
            doneCardList = new List<Card>();
        }

        public static void WriteDoneCardData()
        {
            foreach (var item in doneCardList)
            {
                Console.WriteLine("Başlık      : "+item.Title);
                Console.WriteLine("İçerik      : "+item.Content);
                Console.WriteLine("Atanan Kişi : "+item.Appointee);
                Console.WriteLine("Büyüklük    : "+item.TaskSize);
                Console.WriteLine("---");
            }
            if(doneCardList.Count==0)
            {
                Console.WriteLine("~ BOŞ ~");
                Console.WriteLine("---");
            }
        }
    }
    

}