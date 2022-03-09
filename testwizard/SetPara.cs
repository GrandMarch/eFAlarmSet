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
    public partial class SetPara : UserControl
    {
        public SetPara(RowValue value)
        {
            InitializeComponent();
            txtHI.DataBindings.Add("Text", value, "HI");
            txtHH.DataBindings.Add("Text", value, "HH");
            txtLO.DataBindings.Add("Text", value, "LO");
            txtLL.DataBindings.Add("Text", value, "LL");
            cbALMEN.DataBindings.Add("Checked", value, "ALMENAB");
        }
    }
}
