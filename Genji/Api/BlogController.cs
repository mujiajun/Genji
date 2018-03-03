using Genji.Data.DataOperation;
using Genji.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Genji.Api
{
    [Produces("application/json")]
    [Route("api/Blog")]
    public class BlogController : Controller
    {
        [HttpGet("{id}")]
        public object Get(int id)
        {
            var result = new XResult();

            var select = $"SELECT * FROM BlogArticle WHERE ID = @id";
            var one = XDataHelper.ExcuteReader<BlogArticle>(select, new { id }).SingleOrDefault();
            result.Data = one;
            return result;
        }

        [HttpPost]
        public object Add([FromBody]BlogArticle model)
        {
            var result = new XResult();

            var insert = $@"INSERT INTO BlogArticle (Title,Category,Tag,Content,ReadCount,CreateTime,ModifiedTime)VALUES ('{model.Title}','{model.Category}','{model.Tag}','{model.Content}',0,NOW(),NOW())";

            if (XDataHelper.ExcuteNonQuery(insert))
            {
                return result;
            }
            result.Code = -1;
            result.Message = "操作失败";
            return result;
        }

        [HttpPut("{id}")]
        public object Update(int id, [FromBody]BlogArticle model)
        {
            var result = new XResult();

            var update = $@"UPDATE BlogArticle SET 
                                   Title = '{model.Title}',
                                   Category = '{model.Category}',
                                   Tag = '{model.Tag}',
                                   Content = '{model.Content}',
                                   ModifiedTime = NOW()
                            WHERE ID = @id";

            if (XDataHelper.ExcuteNonQuery(update, new { id }))
            {
                return result;
            }
            result.Code = -1;
            result.Message = "操作失败";
            return result;
        }

        [Route("addReadCount")]
        [HttpGet("{id}")]
        public object Update(int id)
        {
            var result = new XResult();

            var update = $@"UPDATE BlogArticle SET ReadCount = (ReadCount+1) WHERE ID = @id";

            if (XDataHelper.ExcuteNonQuery(update, new { id }))
            {
                return result;
            }
            result.Code = -1;
            result.Message = "操作失败";
            return result;
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            var result = new XResult();
            var delete = "UPDATE BlogArticle SET DELETETIME=NOW(), IsDeleted=1 WHERE ID = @id";

            if (XDataHelper.ExcuteNonQuery(delete, new { id }))
            {
                return result;
            }
            result.Code = -1;
            result.Message = "操作失败";
            return result;
        }

        [Route("getlist")]
        [HttpPost]
        public object GetList()
        {
            //throw new System.Exception("我跑异常啦");
            var result = new XResult();

            var select = $"SELECT * FROM BlogArticle WHERE IsDeleted=0";
            var list = XDataHelper.ExcuteReader<BlogArticle>(select).ToList();
            result.Data = list;
            return result;
        }
    }
}