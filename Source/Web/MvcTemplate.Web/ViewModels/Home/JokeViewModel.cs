namespace MvcTemplate.Web.ViewModels.Home
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class JokeViewModel : IMapFrom<Joke>
    {
        public string Content { get; set; }
    }
}
