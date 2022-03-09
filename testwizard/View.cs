using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFAlarmSet
{
    public partial class View : UserControl
    {
        HMIInterface.CHMIInterface m_HMIInterface;
        DataTable dataTable = new DataTable();

        List<RowValue> rowValues = new List<RowValue>();
        public View()
        {
            InitializeComponent();
            //split
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.SplitterDistance = 50;
            splitContainer1.IsSplitterFixed = true;
            //
            dataTable.Columns.Add("点名", typeof(string));
            dataTable.Columns.Add("描述", typeof(string));
            dataTable.Columns.Add("当前值", typeof(double));
            dataTable.Columns.Add("使能报警", typeof(bool));
            dataTable.Columns.Add("低限", typeof(double));
            dataTable.Columns.Add("低低限", typeof(double));
            dataTable.Columns.Add("高限", typeof(double));
            dataTable.Columns.Add("高高限", typeof(double));
            DataColumn[] keys = new DataColumn[1];
            keys[0] = dataTable.Columns["点名"];
            dataTable.PrimaryKey = keys;
            dataGridView1.DataSource = dataTable.DefaultView;
            dataGridView1.ReadOnly = true;
        }
        public void UpdateView()
        {
            foreach (RowValue r in rowValues)
            {
                r.Update();
                DataRow dataRow = dataTable.Rows.Find(r.Name);
                dataRow["描述"]=r.Desc;
                dataRow["当前值"]=r.PV;
                dataRow["使能报警"]=r.ALMENAB;
                dataRow["低限"]=r.LO;
                dataRow["低低限"]=r.LL;
                dataRow["高限"]=r.HI;
                dataRow["高高限"]=r.HH;
            }
        }
        public void UpdateTableContent(List<RowValue > values)
        {
            rowValues=values;
            for (int i = 0; i<values.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["点名"]=values[i].Name;
                dataRow["描述"]=values[i].Desc;
                dataRow["当前值"]=values[i].PV;
                dataRow["使能报警"]=values[i].ALMENAB;
                dataRow["低限"]=values[i].LO;
                dataRow["低低限"]=values[i].LL;
                dataRow["高限"]=values[i].HI;
                dataRow["高高限"]=values[i].HH;

                dataTable.Rows.Add(dataRow);
            }
        }
        public void SetHmi(HMIInterface.CHMIInterface cHMIInterface)
        {
            if (null!=cHMIInterface)
                m_HMIInterface=cHMIInterface;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text==""||txtFilter.Text=="*")
            {
                dataTable.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                string selectstr = "描述 like " + "'%" + txtFilter.Text + "%'" + " OR 点名 like " + "'%" + txtFilter.Text + "%'";
                dataTable.DefaultView.RowFilter = selectstr;
            }
        }
        private void DataGridViewListCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (m_HMIInterface.IsRunMode())
            {
                if (e.RowIndex >= 0)
                {
                    DataTable table = dataTable.DefaultView.ToTable();
                    string id = table.Rows[e.RowIndex]["点名"].ToString();
                    RowValue row = rowValues.Find(x => x.Name==id);
                    if (row.Name==id)
                    {
                        SetPara pWin = new SetPara(row);
                        m_HMIInterface.InitSheet();
                        m_HMIInterface.AddPage((IntPtr)pWin.Handle);
                        if (m_HMIInterface.DoModal() == 1)
                        {
                            if (double.TryParse(pWin.txtHH.Text, out double var1))
                                row.HH=var1;
                            if (double.TryParse(pWin.txtHI.Text, out double var2))
                                row.HI=var2;
                            if (double.TryParse(pWin.txtLL.Text, out double var3))
                                row.LL=var3;
                            if (double.TryParse(pWin.txtLO.Text, out double var4))
                                row.LO=var4;
                            row.ALMENAB=pWin.cbALMEN.Checked;                           
                            bool b = row.Write();
                        }
                    }
                }
            }
        }

    }
}
