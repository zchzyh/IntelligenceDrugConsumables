using System;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Application.Entity.PerfConfig;
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
    public class BpcSm001Service : RepositoryFactory<BpcSM001Entity>, IBpcSm001Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSM001Entity> GetList()
        {
            var expression = LinqExtensions.True<BpcSM001Entity>(); 
            return this.HQPASRepository().IQueryable(expression).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpcSM001Entity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpcSM001Entity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["secondCategoryId"].IsEmpty())
            {
                string secondCategoryId = queryParam["secondCategoryId"].ToString();
                expression = expression.And(t => t.TYPEID == secondCategoryId);
            }
            else
            {
                if (!queryParam["firstCategoryId"].IsEmpty())
                {
                    string firstCategoryId = queryParam["firstCategoryId"].ToString();
                    expression = expression.And(t => t.TYPEID.Contains(firstCategoryId));
                }
            }
            if (!queryParam["dataItemNo"].IsEmpty())
            {
                string dataItemNo = queryParam["dataItemNo"].ToString();
                expression = expression.And(t => t.JCSJBM.Contains(dataItemNo));
            }

            if (!queryParam["dataItemName"].IsEmpty())
            {
                string dataItemName = queryParam["dataItemName"].ToString();
                expression = expression.And(t => t.JCSJMC.Contains(dataItemName));
            }

            return HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public BpcSM001Entity GetEntity(string keyValue)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void AddorUpdateRecord(BpcSM001Entity entity)
        {
            try
            {

                if (!string.IsNullOrEmpty(entity.JCSJBM))
                {
                    entity.Modify(entity.JCSJBM);
                    HQPASRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    entity.JCSJBM = GetDataItemId(entity.TYPEID);
                    HQPASRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 数据项Id
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        private string GetDataItemId(string  typeId)
        {
            string shortId;
            string strSql = $"SELECT count(1) FROM [BPMS].[BPC_SM001] WHERE typeid='{typeId}'";
            var obj= new RepositoryFactory().HQPASRepository().FindObject(strSql);
            int cnt = 0;
            int.TryParse(obj.ToString(), out cnt);
            if (cnt == 0)
            {
                shortId = "001";
            }
            else
            {
                strSql=$"SELECT isnull(substring(max(jcsjbm),5,3),0)  FROM [BPMS].[BPC_SM001] WHERE typeid ='{typeId}'";
                obj = new RepositoryFactory().HQPASRepository().FindObject(strSql);
                shortId = obj.ToString();
                shortId = (int.Parse(shortId) + 1).ToString().PadLeft(3,'0');

            }
           string cjbbmId= 'S'+ typeId+ shortId;
            return cjbbmId;
        }
    }
}
