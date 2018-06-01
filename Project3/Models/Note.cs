using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public int StudentID { get; set; }
        public string Body { get; set; }
        

        public Student Student { get; set; }
        
    }
}
