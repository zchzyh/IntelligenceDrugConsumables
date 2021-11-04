using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// �� ��
    /// Admin Studio
    /// �� ������������Ա
    /// �� �ڣ�2017-02-22 21:03
    /// �� ����ϵͳ���ܱ�
    /// </summary>
    public class Base_ModuleEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string ModuleId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string ParentId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string EnCode { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string FullName { get; set; }
        /// <summary>
        /// ͼ��
        /// </summary>
        /// <returns></returns>
        public string Icon { get; set; }
        /// <summary>
        /// ������ַ
        /// </summary>
        /// <returns></returns>
        public string UrlAddress { get; set; }
        /// <summary>
        /// ����Ŀ��
        /// </summary>
        /// <returns></returns>
        public string Target { get; set; }
        /// <summary>
        /// �˵�ѡ��
        /// </summary>
        /// <returns></returns>
        public int? IsMenu { get; set; }
        /// <summary>
        /// ����չ��
        /// </summary>
        /// <returns></returns>
        public int? AllowExpand { get; set; }
        /// <summary>
        /// �Ƿ񹫿�
        /// </summary>
        /// <returns></returns>
        public int? IsPublic { get; set; }
        /// <summary>
        /// ����༭
        /// </summary>
        /// <returns></returns>
        public int? AllowEdit { get; set; }
        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <returns></returns>
        public int? AllowDelete { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public int? SortCode { get; set; }
        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// ��Ч��־
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// �޸��û�
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ModuleId = Guid.NewGuid().ToString();
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ModuleId = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}