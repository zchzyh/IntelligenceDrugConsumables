using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 
    /// </summary>
    public class BpcSm002Service : RepositoryFactory<BpcSM002Entity>, IBpcSm002Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSM002Entity> GetList()
        {
            var expression = LinqExtensions.True<BpcSM002Entity>();
            return this.HQPASRepository().IQueryable(expression).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IEnumerable<BpcSM002Entity> GetList(string grade, string parentId)
        {
            var expression = LinqExtensions.True<BpcSM002Entity>();
            if (!grade.IsEmpty())
                expression = expression.And(e => e.GRADE == grade);
            if (!parentId.IsEmpty())
                expression = expression.And(e => e.PARENT == parentId);
            return this.HQPASRepository().IQueryable(expression).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpcSM002Entity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpcSM002Entity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["categoryName"].IsEmpty())
            {
                string categoryName = queryParam["categoryName"].ToString();
                expression = expression.And(t => t.NAME.Contains(categoryName));
            }

            if (!queryParam["parentId"].IsEmpty())
            {
                string parentId = queryParam["parentId"].ToString();
                if (parentId != "root")
                    expression = expression.And(t => t.PARENT.Contains(parentId));
            }

            if (!queryParam["status"].IsEmpty())
            {
                string status = queryParam["status"].ToString();
                expression = expression.And(t => t.STATUS == status);
            }

            return HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public BpcSM002Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteRecord(string keyValue)
        {
            HQPASRepository().Delete(keyValue);
        }

        private string CreateNewTypeId(string parentId)
        {
            string lastTypeId = string.Empty;
            var allRecords = GetList("", "");

            var list = HQPASRepository().IQueryable(t => t.PARENT == parentId);
            var lastList = list.OrderBy(l => l.TYPEID.Substring(1)).ToList();
            if (parentId == "root")
            {
                var roots = allRecords.Where(r => r.TYPEID.Length == 1).OrderByDescending(r => r.TYPEID);
                var letterNumber = Convert.ToInt32(Encoding.UTF8.GetBytes("A")[0]);
                while (true)
                {
                    var letter = (char) (letterNumber);
                    if (roots.ToList().Exists(r => r.TYPEID.ToUpper() == letter.ToString()))
                    {
                        letterNumber = letterNumber + 1;
                    }
                    else
                    {
                        lastTypeId = letter.ToString();
                        break;
                    }

                    if (letterNumber > 90)
                    {
                        throw new Exception("超出分类个数，请确认");
                    }
                }
            }
            else
            {
                string typeId = lastList.Count > 0 ? lastList.Last().TYPEID : parentId;
                string number = lastList.Count > 0 ? typeId.Substring(1) : "0";
                if (number.IsEmpty()) number = "0";
                number = (int.Parse(number) + 1).ToString();
                if (number.Length % 2 != 0) number = "0" + number;
                lastTypeId =
                    (lastList.Count > 0 ? typeId.Substring(0, 1) : typeId) + number;
            }

            return lastTypeId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="Exception"></exception>
        public void AddOrUpdateRecord(BpcSM002Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.TYPEID))
            {
                entity.Modify(entity.TYPEID);
                HQPASRepository().Update(entity);
            }
            else
            {
                bool sameRecord = CheckDataItemTypeName(entity.PARENT, entity.NAME);
                if (sameRecord) throw new Exception("同一父节点下不能存在相同名称");
                entity.Create();
                entity.TYPEID = CreateNewTypeId(entity.PARENT);
                if (entity.PARENT == "root")
                {
                    entity.PARENT = null;
                }

                HQPASRepository().Insert(entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public bool CheckDataItemTypeName(string parentId, string typeName)
        {
            var list = HQPASRepository().IQueryable(t => t.PARENT == parentId && t.NAME.Trim() == typeName.Trim());
            return list.Any();
        }
    }
}