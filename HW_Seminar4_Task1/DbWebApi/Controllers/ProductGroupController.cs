using DbWebApi.Models.Dto;
using DbWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        [HttpPost(template: "addgroup")]
        public ActionResult AddGroup(string name, string description)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.ProductGroups.Count(x => x.Name!.ToLower() == name.ToLower()) > 0)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.ProductGroups.Add(new ProductGroup { Name = name, Description = description });
                        ctx.SaveChanges();
                    }
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet(template: "getgroups")]
        public ActionResult<IEnumerable<ProductGroupModel>> GetGroups()
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var list = ctx.ProductGroups.Select(x => new ProductGroupModel { Id = x.Id, Name = x.Name!, Description = x.Description! }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpDelete(template: "deletegroup")]
        public ActionResult DeleteGroup(int id)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.ProductGroups.Count(x => x.Id == id) > 0)
                    {
                        var deleteRec = ctx.ProductGroups.FirstOrDefault(x => x.Id == id);
                        ctx.ProductGroups.Remove(deleteRec!);
                        ctx.SaveChanges();

                        return Ok();
                    }

                    return StatusCode(404);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
