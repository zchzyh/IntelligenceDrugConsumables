using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.IService.BaseManage;
using LeaRun.Application.Service.BaseManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Busines.BaseManage
{
    /// <summary>
    /// �� �� 6.1
    /// Admin Studio
    /// �� ������������Ա
    /// �� �ڣ�2017-02-22 21:03
    /// �� ����ϵͳ���ܱ�
    /// </summary>
    public class Base_ModuleBLL
    {
        private Base_ModuleIService service = new Base_ModuleService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Base_ModuleEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Base_ModuleEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, Base_ModuleEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
