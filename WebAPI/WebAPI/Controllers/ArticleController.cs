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
        public async Task<ActionResult<IEnumerable<Article>>> Get()
        {
            return Ok(_dbContext.Articles);
        }

        [HttpGet(), Route("/{id}")]
        public async Task<ActionResult<Article>> Get(int id)
        {
            if(_dbContext.Articles.Any(x => x.Id == id))
                return Ok(_dbContext.Articles.First(x => x.Id == id));
            return NotFound();
        }

        [HttpPost(), Route("/")]
        public async Task<ActionResult<Article>> Post([FromBody]Article article)
        {
            article.Id = _dbContext.Articles.Count + 1;
            _dbContext.Articles.Add(article);

            return Created();
        }

        [HttpDelete(), Route("/{id}")]
        public async Task<ActionResult<Article>> Delete(int id)
        {
            if(_dbContext.Articles.Any(x => x.Id == id))
            {
                _dbContext.Articles.Remove(_dbContext.Articles.First(x => x.Id == id));
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut(), Route("/{id}")]
        public async Task<ActionResult<Article>> Update(int id, [FromBody]Article article)
        {
            if(_dbContext.Articles.Any(x => x.Id == id))
            {
                Article articleToUpdate = _dbContext.Articles.First(x => x.Id == id);
                articleToUpdate.Title = article.Title;
                articleToUpdate.Content = article.Content;
                articleToUpdate.Date = DateTime.Now;

                return NoContent();
            }

            return NotFound();
        }
    }
}
