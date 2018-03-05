using Genji.Data.Common;
using Genji.Data.DataOperation;
using Genji.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Genji.Api
{
    [Produces("application/json")]
    [Route("api/Blog")]
    public class BlogController : Controller
    {
        [Route("getone")]
        [HttpGet]
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
                                   Title = @Title,
                                   Category = {model.Category},
                                   Tag = @Tag,
                                   Content = @Content,
                                   ModifiedTime = '{DateTime.Now}'
                            WHERE ID = @id";

            var whereObj= new { id, Tag = model.Tag, Title = model.Title, Content = model.Content };
            if (XDataHelper.ExcuteNonQuery(update, whereObj))
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
        public object GetList([FromBody]XPagination page)
        {
            var whereSql = $"WHERE IsDeleted=0 AND {page.WhereTags} AND {page.WhereCategory}";
            var selectSql = $@"SELECT * FROM BlogArticle {whereSql}
                            ORDER BY Id DESC
                            LIMIT {page.Index * page.Size},{page.Size}";
            var countSql = $"SELECT COUNT(1) AS count FROM BlogArticle {whereSql}";

            var list = XDataHelper.ExcuteReader<BlogArticle>(selectSql).ToList();

            var count = XDataHelper.ExcuteScalar<int>(countSql);

            var result = new XResult();
            //C#匿名对象
            result.Data = new
            {
                Content = list,
                Count = count
            };
            return result;
        }
    }
    public class XPagination
    {
        public int Index { get; set; } = 0;
        public int Size { get; set; } = 8;
        /// <summary>
        /// 默认全部
        /// </summary>
        public int Category { get; set; } = 0;
        /// <summary>
        /// 以空格字符相隔
        /// </summary>
        public string Tags { get; set; }

        [JsonIgnore]
        public string WhereTags
        {
            get
            {
                if (!string.IsNullOrEmpty(Tags))
                {
                    var whereString = "(";
                    var tagList = Tags.Split(' ').ToList();
                    foreach (var item in tagList)
                    {
                        whereString += $"Tags LIKE '%{item.DelSpace()}%' OR";
                    }
                    whereString = whereString.Trim("OR") + ")";
                    return whereString;
                }
                return "1=1";
            }
        }

        /// <summary>
        /// 如果分类大于1,才加入where条件语句
        /// </summary>
        [JsonIgnore]
        public string WhereCategory => Category > 0 ? $"Category={Category}" : "1=1";
    }
}