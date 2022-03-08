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
        public View()
        {
            InitializeComponent();
            //split
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.SplitterDistance = 50;//固定的高度
            splitContainer1.IsSplitterFixed = true;//固定panel1
            //
            dataTable.Columns.Add("点名", typeof(string));
            dataTable.Columns.Add("描述", typeof(string));
            dataTable.Columns.Add("当前值", typeof(double));
            dataTable.Columns.Add("使能报警", typeof(bool));
            dataTable.Columns.Add("低限", typeof(double));
            dataTable.Columns.Add("低低限", typeof(double));
            dataTable.Columns.Add("高限", typeof(double));
            dataTable.Columns.Add("高高限", typeof(double));
        }

        public void UpdateView()
        {
            if (m_HMIInterface.IsRunMode())
            {
                
            }
            
        }

        public void UpdateTableContent()
        {

        }
        public void SetHmi(HMIInterface.CHMIInterface cHMIInterface)
        {
            if (null!=cHMIInterface)
                m_HMIInterface=cHMIInterface;
        }
    }
}
