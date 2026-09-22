

using Microsoft.AspNetCore.SignalR;

namespace Challenge3_StudentRegistryCThomason.Models
{
    public class Students
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public int Age{get; set;}
        public string Job{get; set;}
        public bool Attendance{get; set;}

    }
}