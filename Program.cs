using System;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstCardsInBoard();
            Options();          
        }

        #region FirstCards
        static void FirstCardsInBoard()
        {
            Card firstCardToDO = new Card();
            firstCardToDO.Title = "Rehber Uygulaması".ToUpper();
            firstCardToDO.Content = "Rehber Uygulaması Yapılacak.";
            firstCardToDO.Appointee = TeamList.teamMembers[0].Name + " " + TeamList.teamMembers[0].Surname;
            firstCardToDO.TaskSize = Size.S;
            ToDoCardList.toDoCardList.Add(firstCardToDO);
            //
            Card secondCardToDO = new Card();
            secondCardToDO.Title = "Test".ToUpper();
            secondCardToDO.Content = "Uygulama test edilecek.";
            secondCardToDO.Appointee = TeamList.teamMembers[1].Name + " " + TeamList.teamMembers[1].Surname;
            secondCardToDO.TaskSize = Size.S;
            ToDoCardList.toDoCardList.Add(secondCardToDO);
            //
            Card thirdCardInProgress = new Card();
            thirdCardInProgress.Title = "ToDo Uygulaması".ToUpper();
            thirdCardInProgress.Content = "ToDo Uygulaması Yapılacak.";
            thirdCardInProgress.Appointee = TeamList.teamMembers[2].Name + " " + TeamList.teamMembers[2].Surname;
            thirdCardInProgress.TaskSize = Size.M;
            InProgressCardList.inProgressCardList.Add(thirdCardInProgress);
        }
        #endregion

        #region Options
        static void Options()
        {
            Board newboard = new Board();
            OptionsText();
            int number;
            bool isNum = int.TryParse(Console.ReadLine(), out number);
            while(!isNum)
            {
                Console.WriteLine("Hatalı giriş yaptınız");
                OptionsText();
                isNum = int.TryParse(Console.ReadLine(), out number);
            }

            switch(number)
            {
                case 1:
                    newboard.ToDoLine();
                    newboard.InProgressLine();
                    newboard.DoneLine();
                    Program.Options();
                    break;
                case 2:
                    AddCardToBoard();
                    break;
                case 3:
                    DeleteCardInBoard();
                    break;
                case 4:
                    ReplaceCard();
                    break;
            }
        }
        static void OptionsText()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :");
            Console.WriteLine("******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
        }
        

        static void AddCardToBoard()
        {
            Console.WriteLine("Başlık Giriniz                                  :");
            string titleAnswer = Console.ReadLine().ToUpper();
            //
            Console.WriteLine("İçerik Giriniz                                  :");
            string contentAnswer = Console.ReadLine();
            //
            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            int sizeAnswer;
            bool isSizeNum = int.TryParse(Console.ReadLine(), out sizeAnswer);
            while(!isSizeNum || (sizeAnswer<1 || sizeAnswer>5))
            {
                Console.WriteLine("Hatalı giriş yaptınız. Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
                isSizeNum = int.TryParse(Console.ReadLine(), out sizeAnswer);
            }
            //
            Console.WriteLine("Kişi Seçimi İçin ID Numarasını Giriniz          :");
            int idAnwer;
            bool isIdNum = int.TryParse(Console.ReadLine(), out idAnwer);
            while(!isIdNum || (idAnwer<1 || idAnwer>10))
            {
                Console.WriteLine("Hatalı giriş yaptınız. Kişi Seçimi İçin ID Numarasını Giriniz          :");
                isIdNum = int.TryParse(Console.ReadLine(), out idAnwer);
            }
            //
            Card newCard = new Card();
            newCard.Title = titleAnswer;
            newCard.Content = contentAnswer;
            newCard.Appointee = TeamList.teamMembers[idAnwer-1].Name + " " + TeamList.teamMembers[idAnwer-1].Surname;
            newCard.TaskSize = (Size)sizeAnswer;
            ToDoCardList.toDoCardList.Add(newCard);
            Program.Options();
        }

        static void DeleteCardInBoard()
        {
            bool find = false;
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız:  ");
            string deleteCardAnswer = Console.ReadLine().ToUpper();
            for (int i = 0; i < ToDoCardList.toDoCardList.Count; i++)
            {
                if(ToDoCardList.toDoCardList[i].Title == deleteCardAnswer)
                {
                    find = true;
                    ToDoCardList.toDoCardList.Remove(ToDoCardList.toDoCardList[i]);
                    Console.WriteLine("Kartı başarıyla sildiniz.");
                } 
            }
            //
            for (int i = 0; i < InProgressCardList.inProgressCardList.Count; i++)
            {
                if(InProgressCardList.inProgressCardList[i].Title == deleteCardAnswer)
                {
                    find = true;
                    InProgressCardList.inProgressCardList.Remove(InProgressCardList.inProgressCardList[i]);
                    Console.WriteLine("Kartı başarıyla sildiniz.");
                }
            }
            //
            for (int i = 0; i < DoneCardList.doneCardList.Count; i++)
            {
                if(DoneCardList.doneCardList[i].Title == deleteCardAnswer)
                {
                    find = true;
                    DoneCardList.doneCardList.Remove(DoneCardList.doneCardList[i]);
                    Console.WriteLine("Kartı başarıyla sildiniz.");
                }
            }
            //
            if(!find)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                int notFoundAnswer = int.Parse(Console.ReadLine());
                while(notFoundAnswer<1||notFoundAnswer>2)
                {
                    Console.WriteLine("Hatalı bir giriş yaptınız. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için : (2)");
                    notFoundAnswer = int.Parse(Console.ReadLine());
                }
                switch(notFoundAnswer)
                {
                    case 1:
                        Program.Options();
                        break;
                    case 2:
                        Program.DeleteCardInBoard();
                        break;
                }
            }
            Program.Options();
        }
    
        static void ReplaceCard()
        {
            bool find = false;
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız:  ");
            string replaceCardAnswer = Console.ReadLine().ToUpper();
            int foundListNumberInList = 0;
            for (int i = 0; i < ToDoCardList.toDoCardList.Count; i++)
            {
                if(ToDoCardList.toDoCardList[i].Title == replaceCardAnswer)
                {
                    find = true;
                    foundListNumberInList = i;
                    Console.WriteLine("Başlık      : {0}",ToDoCardList.toDoCardList[i].Title);
                    Console.WriteLine("İçerik      : {0}",ToDoCardList.toDoCardList[i].Content);
                    Console.WriteLine("Atanan Kişi : {0}",ToDoCardList.toDoCardList[i].Appointee);
                    Console.WriteLine("Büyüklük    : {0}",ToDoCardList.toDoCardList[i].TaskSize);
                    Console.WriteLine("Line        : ToDo Line");
                    ToDoFoundCardToReplace(foundListNumberInList);

                } 
            }
            //
            for (int i = 0; i < InProgressCardList.inProgressCardList.Count; i++)
            {
                if(InProgressCardList.inProgressCardList[i].Title == replaceCardAnswer)
                {
                    find = true;
                    foundListNumberInList = i;
                    Console.WriteLine("Başlık      : {0}",InProgressCardList.inProgressCardList[i].Title);
                    Console.WriteLine("İçerik      : {0}",InProgressCardList.inProgressCardList[i].Content);
                    Console.WriteLine("Atanan Kişi : {0}",InProgressCardList.inProgressCardList[i].Appointee);
                    Console.WriteLine("Büyüklük    : {0}",InProgressCardList.inProgressCardList[i].TaskSize);
                    Console.WriteLine("Line        : In Progress Line");
                    InProgressFoundCardToReplace(foundListNumberInList);
                    
                }
            }
            //
            for (int i = 0; i < DoneCardList.doneCardList.Count; i++)
            {
                if(DoneCardList.doneCardList[i].Title == replaceCardAnswer)
                {
                    find = true;
                    foundListNumberInList = i;
                    Console.WriteLine("Başlık      : {0}",DoneCardList.doneCardList[i].Title);
                    Console.WriteLine("İçerik      : {0}",DoneCardList.doneCardList[i].Content);
                    Console.WriteLine("Atanan Kişi : {0}",DoneCardList.doneCardList[i].Appointee);
                    Console.WriteLine("Büyüklük    : {0}",DoneCardList.doneCardList[i].TaskSize);
                    Console.WriteLine("Line        : Done Line");
                    DoneFoundCardToReplace(foundListNumberInList);
                }
            }
            //
            if(!find)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                int notFoundAnswer = int.Parse(Console.ReadLine());
                while(notFoundAnswer<1||notFoundAnswer>2)
                {
                    Console.WriteLine("Hatalı bir giriş yaptınız. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için : (2)");
                    notFoundAnswer = int.Parse(Console.ReadLine());
                }
                switch(notFoundAnswer)
                {
                    case 1:
                        Program.Options();
                        break;
                    case 2:
                        Program.ReplaceCard();
                        break;
                }
            }
        }

        static void ToDoFoundCardToReplace(int listNumber)
        {
            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");
            int numeric;
            bool isNum = int.TryParse(Console.ReadLine(), out numeric);
            while(!isNum || (numeric<1 || numeric>3))
            {
            Console.WriteLine("Hatalı giriş yaptınız. Lütfen taşımak istediğiniz Line'ı seçiniz:");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");
            isNum = int.TryParse(Console.ReadLine(), out numeric);
            }
            //
            if(numeric == 1)
                ToDoCardList.toDoCardList.Add(ToDoCardList.toDoCardList[listNumber]);
            else if(numeric == 2)
                InProgressCardList.inProgressCardList.Add(ToDoCardList.toDoCardList[listNumber]);
            else if(numeric == 3)
                DoneCardList.doneCardList.Add(ToDoCardList.toDoCardList[listNumber]);
            //
            ToDoCardList.toDoCardList.RemoveAt(listNumber);
            Console.WriteLine("Kart başarılı bir şekilde taşındı.");
            Program.Options();
        }

        static void InProgressFoundCardToReplace(int listNumber)
        {
            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");
            int numeric;
            bool isNum = int.TryParse(Console.ReadLine(), out numeric);
            while(!isNum || (numeric<1 || numeric>3))
            {
            Console.WriteLine("Hatalı giriş yaptınız. Lütfen taşımak istediğiniz Line'ı seçiniz:");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");
            isNum = int.TryParse(Console.ReadLine(), out numeric);
            }
            //
            if(numeric == 1)
                ToDoCardList.toDoCardList.Add(InProgressCardList.inProgressCardList[listNumber]);
            else if(numeric == 2)
                InProgressCardList.inProgressCardList.Add(InProgressCardList.inProgressCardList[listNumber]);
            else if(numeric == 3)
                DoneCardList.doneCardList.Add(InProgressCardList.inProgressCardList[listNumber]);
            //
            InProgressCardList.inProgressCardList.RemoveAt(listNumber);
            Console.WriteLine("Kart başarılı bir şekilde taşındı.");
            Program.Options();
        }

        static void DoneFoundCardToReplace(int listNumber)
        {
            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");
            int numeric;
            bool isNum = int.TryParse(Console.ReadLine(), out numeric);
            while(!isNum || (numeric<1 || numeric>3))
            {
            Console.WriteLine("Hatalı giriş yaptınız. Lütfen taşımak istediğiniz Line'ı seçiniz:");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");
            isNum = int.TryParse(Console.ReadLine(), out numeric);
            }
            //
            if(numeric == 1)
                ToDoCardList.toDoCardList.Add(DoneCardList.doneCardList[listNumber]);
            else if(numeric == 2)
                InProgressCardList.inProgressCardList.Add(DoneCardList.doneCardList[listNumber]);
            else if(numeric == 3)
                DoneCardList.doneCardList.Add(DoneCardList.doneCardList[listNumber]);
            //
            DoneCardList.doneCardList.RemoveAt(listNumber);
            Console.WriteLine("Kart başarılı bir şekilde taşındı.");
            Program.Options();
        }

        #endregion
    }
}
