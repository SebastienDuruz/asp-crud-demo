using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ArticleController : Controller
    {
        private DbContext _dbContext;

        public ArticleController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(), Route("/")]
        public IEnumerable<Article> Get()
        {
            return _dbContext.Articles;
        }

        [HttpGet(), Route("/{id}")]
        public Article Get(int id)
        {
            return _dbContext.Articles.FirstOrDefault(x => x.Id == id);
        }
    }
}
