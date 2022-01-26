using System;

namespace ToDo
{
    public class TeamMember
    {
        private int id;
        private string name;
        private string surname;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }

        public TeamMember(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}