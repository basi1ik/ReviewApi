using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewApi.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ReviewsCollection { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDatabaseSettings
    {
        string ReviewsCollection { get; set; }
        string ConnectionStrings { get; set; }
        string DatabaseName { get; set; }
    }
}
