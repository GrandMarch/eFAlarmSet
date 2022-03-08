using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eFAlarmSet
{
    public partial class UserPropertyPage : UserControl
    {
        HMIInterface.CHMIInterface m_HMIInterface;
        List<RowValue>values=new List<RowValue>();

        private int delindex = -1;
        private string del_name = "";

        public UserPropertyPage()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Name","Name");
            dataGridView1.Columns["Name"].Width =100;
            //this.dataGridView1.CellClick +=DataGridView1_CellClick;
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tag=m_HMIInterface.VarSel(true, HMIInterface.CHMIInterface.DataType.dt_all, "");
            if (!string.IsNullOrEmpty(tag))
            {
                string[] vs = tag.Split('.');
                var temp = new RowValue(vs[0], m_HMIInterface);
                if (values.FindIndex(x => x.Name==temp.Name)<0)
                {
                    values.Add(temp);
                    var index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value=temp.Name;
                }
                else
                {
                    MessageBox.Show("已经存在：{0}", vs[0]);
                }
            }

        }

        ~UserPropertyPage()
        {
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TextTag.Text = m_HMIInterface.VarSel(true, HMIInterface.CHMIInterface.DataType.dt_int, TextTag.Text);
        }
        public void SetHMI(HMIInterface.CHMIInterface hmi)
        {
            m_HMIInterface = hmi;
        }

        public void SetRows(List<RowValue> rows)
        {
            values=rows;

            foreach (RowValue r in values)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value=r.Name;
            }

        }
        public List<RowValue> GetRows()
        {
            return values;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                if (e.RowIndex>=0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Selected==false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected=true;
                        delindex=e.RowIndex;
                        del_name=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tag = m_HMIInterface.VarSel(true, HMIInterface.CHMIInterface.DataType.dt_all, "");
            if (!string.IsNullOrEmpty(tag))
            {
                string[] vs = tag.Split('.');
                var temp = new RowValue(vs[0], m_HMIInterface);
                if (values.FindIndex(x => x.Name==temp.Name)<0)
                {
                    values.Add(temp);
                    var index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value=temp.Name;
                }
                else
                {
                    MessageBox.Show("已经存在：{0}", vs[0]);
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (delindex>-1)
            {
                values.RemoveAt(values.FindIndex(x => x.Name==del_name));
                dataGridView1.Rows.RemoveAt(delindex);
                //foreach (RowValue r in values)
                //{
                //    var index = dataGridView1.Rows.Add();
                //    dataGridView1.Rows[index].Cells[0].Value=r.Name;
                //}
            }

        }
    }
}
