using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreateAt { get; set; }


    }
}
