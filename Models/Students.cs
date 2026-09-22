

using Microsoft.AspNetCore.SignalR;

namespace Challenge3_StudentRegistryCThomason.Models
{
    public class Students
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string LastName{get; set;}
        public string Hobby{get; set;}
        public string Email{get; set;}
        public string SlackName{get; set; }

    }
}