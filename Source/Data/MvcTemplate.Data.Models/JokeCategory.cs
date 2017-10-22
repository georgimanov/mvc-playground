namespace MvcTemplate.Data.Models
{
    using MvcTemplate.Data.Common.Models;
    using System.Collections.Generic;

    public class JokeCategory : BaseModel<int>
    {
        public JokeCategory()
        {
            this.Jokes = new HashSet<Joke>();
        }

        public string Name { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }
    }
}