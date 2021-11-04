using System;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    public class BpcSp002BLL
    {
        private readonly IBpcSp002Service _service = new BpcSp002Service();
        private readonly BpcSp003BLL _bpcSp003Bll = new BpcSp003BLL();
        private readonly BpcSm003BLL _bpcSm003Bll = new BpcSm003BLL();
        private readonly SystemBLL _systemBll = new SystemBLL();
        private readonly BpcSp008Bll _bpcSp008Bll = new BpcSp008Bll();

        public IEnumerable<TaskInfoModel> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination, queryJson);
        }

        public PMR001MorEntity GetOrganization()
        {
            return _service.GetOrganization();
        }

        public BpcSp002Entity GetEntity(string keyValue)
        {
            return _service.GetEntity(keyValue);
        }

        public void AdjustTaskDate(BpcSp002Entity entity)
        {
            _service.AdjustTaskDate(entity);
        }

        public void AdjustTasksDate(string taskIds, string startDate, string endDate)
        {
            _service.AdjustTasksDate(taskIds, startDate, endDate);
        }
        public TaskInfoModel GetTaskInfo(string keyValue)
        {
            return _service.GetTaskInfo(keyValue);
        }
        /// <summary>
        /// 任务生成
        /// </summary>
        /// <param name="jxbm"></param>
        /// <param name="year"></param>
        public void CreateTask(string jxbm, string year)
        {
            var yearTables = _bpcSp003Bll.GetTableListByYear(year);
            var collectionTimes = _bpcSm003Bll.GetList(year, "").ToList();
            var tableParameters = _bpcSp008Bll.GetList().ToList();
            //没配置科室的。暂用机构编码
            var org = GetOrganization();
            var initYear = DateTime.Parse(year + "-01-01");
            List<BpcSp002Entity> sp002Entities = new List<BpcSp002Entity>();

            foreach (var e in yearTables)
            {
                var timeObject = collectionTimes.FirstOrDefault(c => c.PLBH == e.CJPL);
                var tbParameter = tableParameters.FirstOrDefault(m => m.CJBBM == e.CJBBM);
                var officeId = tbParameter != null ? tbParameter.DWCSBM : "";
                if (officeId.IsEmpty())
                {
                    officeId = org.ORGID;//.OrganizeId;

                }
                DateTime startTime;
                DateTime endTime;
                BpcSp002Entity entity;
                timeObject = timeObject == null ? new BpcSm003Entity() { SX = 0, XX = 0 } : timeObject;

                decimal decimalYear = 0;
                decimal.TryParse(year, out decimalYear);
                switch (e.CJPL)
                {
                    case "3": //月度
                        for (int i = 1; i <= 12; i++)
                        {
                            startTime = initYear.AddMonths(i).AddDays(-timeObject.XX);
                            endTime = initYear.AddMonths(i).AddDays(timeObject.SX);
                            entity = new BpcSp002Entity()
                            {
                                KSSJ = startTime,
                                JZSJ = endTime,
                                ND = decimalYear,
                                CJBBM = e.CJBBM,
                                JGDM = officeId,
                                YD = i,
                                STATUS = "1",
                                JXBM = jxbm
                            };
                            sp002Entities.Add(entity);
                        }

                        break;
                    case "4": //季度
                        for (int i = 1; i <= 12; i++)
                        {
                            if (i == 3 || i == 6 || i == 9)
                            {
                                startTime = initYear.AddMonths(i).AddDays(-timeObject.XX);
                                endTime = initYear.AddMonths(i).AddDays(timeObject.SX);
                                entity = new BpcSp002Entity()
                                {
                                    KSSJ = startTime,
                                    JZSJ = endTime,
                                    ND = decimalYear,
                                    CJBBM = e.CJBBM,
                                    JGDM = officeId,
                                    YD = i,
                                    STATUS = "1",
                                    JXBM = jxbm
                                };
                                sp002Entities.Add(entity);
                            }
                        }

                        break;

                    case "5": //半年
                        for (int i = 1; i <= 12; i++)
                        {
                            if (i == 6 || i == 12)
                            {
                                startTime = initYear.AddMonths(i).AddDays(-timeObject.XX);
                                endTime = initYear.AddMonths(i).AddDays(timeObject.SX);
                                entity = new BpcSp002Entity()
                                {
                                    KSSJ = startTime,
                                    JZSJ = endTime,
                                    ND = decimalYear,
                                    CJBBM = e.CJBBM,
                                    JGDM = officeId,
                                    YD = i,
                                    STATUS = "1",
                                    JXBM = jxbm
                                };
                                sp002Entities.Add(entity);
                            }
                        }

                        break;

                    case "6": //年度
                        startTime = initYear.AddMonths(12).AddDays(-timeObject.XX);
                        endTime = initYear.AddMonths(12).AddDays(timeObject.SX);
                        entity = new BpcSp002Entity()
                        {
                            KSSJ = startTime,
                            JZSJ = endTime,
                            ND = decimalYear,
                            CJBBM = e.CJBBM,
                            JGDM = officeId,
                            YD = 12,
                            STATUS = "1",
                            JXBM = jxbm
                        };
                        sp002Entities.Add(entity);
                        break;
                }
            }

            _service.CreateTask(year, sp002Entities);
        }

        public List<string> GetNotExistsOfficeTable(string year)
        {
            var yearTables = _bpcSp003Bll.GetTableListByYear(year).ToList();
            var tableParameters = _bpcSp008Bll.GetList().ToList();
            var tables = yearTables.FindAll(t => tableParameters.Exists(p => p.CJBBM == t.CJBBM));
            var exceptTables = yearTables.Except(tables);
            return exceptTables.Select(t=>t.CJBMC).ToList();
        }
    }
}