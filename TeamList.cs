using System;
using System.Collections.Generic;

namespace ToDo
{
    public class TeamList
    {
        public static List<TeamMember> teamMembers { get; set;}
        static TeamList()
        {
            teamMembers = new List<TeamMember>();
            teamMembers.Add(new TeamMember(1,"Mert","Arif"));
            teamMembers.Add(new TeamMember(2,"Ahmet","Yavuz"));
            teamMembers.Add(new TeamMember(3,"Yeliz","Kurt"));
            teamMembers.Add(new TeamMember(4,"Derya","Yıldırım"));
            teamMembers.Add(new TeamMember(5,"Arzu","Kar"));
            teamMembers.Add(new TeamMember(6,"Veli","Kır"));
            teamMembers.Add(new TeamMember(7,"Demet","Er"));
            teamMembers.Add(new TeamMember(8,"Ferhat","Bakan"));
            teamMembers.Add(new TeamMember(9,"Bayram","Ömer"));
            teamMembers.Add(new TeamMember(10,"Erkan","Gök"));
        }
    }

}