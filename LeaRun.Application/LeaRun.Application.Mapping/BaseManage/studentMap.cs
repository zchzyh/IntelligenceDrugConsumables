using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Admin Studio
    /// �� ������������Ա
    /// �� �ڣ�2017-02-23 15:30
    /// �� ����ѧ����
    /// </summary>
    public class studentMap : EntityTypeConfiguration<studentEntity>
    {
        public studentMap()
        {
            #region ������
            //��
            this.ToTable("student");
            //����
            this.HasKey(t => t.id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
