using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<object> Entities = new List<object>();
    }
}
