namespace eFAlarmSet
{
    partial class SetPara
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbALMEN = new System.Windows.Forms.CheckBox();
            this.txtLO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLL = new System.Windows.Forms.TextBox();
            this.txtHH = new System.Windows.Forms.TextBox();
            this.txtHI = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbALMEN
            // 
            this.cbALMEN.AutoSize = true;
            this.cbALMEN.Location = new System.Drawing.Point(24, 25);
            this.cbALMEN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbALMEN.Name = "cbALMEN";
            this.cbALMEN.Size = new System.Drawing.Size(104, 28);
            this.cbALMEN.TabIndex = 0;
            this.cbALMEN.Text = "报警使能";
            this.cbALMEN.UseVisualStyleBackColor = true;
            // 
            // txtLO
            // 
            this.txtLO.Location = new System.Drawing.Point(138, 84);
            this.txtLO.Name = "txtLO";
            this.txtLO.Size = new System.Drawing.Size(135, 31);
            this.txtLO.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "高限值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "低限值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "低低限值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "高高限值：";
            // 
            // txtLL
            // 
            this.txtLL.Location = new System.Drawing.Point(138, 135);
            this.txtLL.Name = "txtLL";
            this.txtLL.Size = new System.Drawing.Size(135, 31);
            this.txtLL.TabIndex = 6;
            // 
            // txtHH
            // 
            this.txtHH.Location = new System.Drawing.Point(398, 138);
            this.txtHH.Name = "txtHH";
            this.txtHH.Size = new System.Drawing.Size(135, 31);
            this.txtHH.TabIndex = 7;
            // 
            // txtHI
            // 
            this.txtHI.Location = new System.Drawing.Point(398, 81);
            this.txtHI.Name = "txtHI";
            this.txtHI.Size = new System.Drawing.Size(135, 31);
            this.txtHI.TabIndex = 8;
            // 
            // SetPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtHI);
            this.Controls.Add(this.txtHH);
            this.Controls.Add(this.txtLL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLO);
            this.Controls.Add(this.cbALMEN);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SetPara";
            this.Size = new System.Drawing.Size(571, 212);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox cbALMEN;
        public System.Windows.Forms.TextBox txtLO;
        public System.Windows.Forms.TextBox txtLL;
        public System.Windows.Forms.TextBox txtHH;
        public System.Windows.Forms.TextBox txtHI;
    }
}
