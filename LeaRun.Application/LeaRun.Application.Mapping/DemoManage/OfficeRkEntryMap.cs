using LeaRun.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.WeChatManage
{
    /// <summary>
    /// �� ��
    /// Admin Studio
    /// �� ������������Ա
    /// �� �ڣ�2016-12-06 17:29
    /// �� ����OfficeRk
    /// </summary>
    public class OfficeRkEntryMap : EntityTypeConfiguration<OfficeRkEntryEntity>
    {
        public OfficeRkEntryMap()
        {
            #region ��������
            //��
            this.ToTable("OfficeRkEntry");
            //����
            this.HasKey(t => t.RkEntryId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}