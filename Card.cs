using System;

namespace ToDo
{
    public enum Size{XS=1,S=2,M=3,L=4,XL=5};
    public class Card
    {
        private string title;
        private string content;
        private string appointee;
        private Size taskSize;

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string Appointee { get => appointee; set => appointee = value; }
        public Size TaskSize { get => taskSize; set => taskSize = value; }

        public Card()
        {

        }
        public Card(string title, string content, string appointee, Size tasksize)
        {
            Title = title;
            Content = content;
            Appointee = appointee;
            TaskSize = tasksize;
        }

    }

    
}