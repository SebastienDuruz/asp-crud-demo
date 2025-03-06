using WebAPI.Models;

namespace WebAPI
{
    public class DbContext
    {
        public List<Article> Articles { get; set; } = new List<Article>();

        public DbContext()
        {
            Articles.Add(new Article()
            {
                Id = 1,
                Title = "Article 1",
                Content = "Article content 1",
                Date = DateTime.Now.AddDays(-1)
            });
            Articles.Add(new Article()
            {
                Id = 2,
                Title = "Article 2",
                Content = "Article content 2",
                Date = DateTime.Now.AddDays(-2)
            });
            Articles.Add(new Article()
            {
                Id = 3,
                Title = "Article 3",
                Content = "Article content 3",
                Date = DateTime.Now.AddDays(-3)
            });
        }
    }
}
