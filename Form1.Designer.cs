
namespace Group_assignment1_LPR281
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbxConstraints = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddConstraint = new System.Windows.Forms.Button();
            this.txtX1Coef = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtX2Coef = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSign = new System.Windows.Forms.ComboBox();
            this.txtRHS = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemoveID = new System.Windows.Forms.TextBox();
            this.btnRemoveConstraint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblOF = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtX1CoefOF = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtX2CoefOF = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxMinMax = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1078, 358);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // lbxConstraints
            // 
            this.lbxConstraints.FormattingEnabled = true;
            this.lbxConstraints.Location = new System.Drawing.Point(12, 434);
            this.lbxConstraints.Name = "lbxConstraints";
            this.lbxConstraints.Size = new System.Drawing.Size(424, 199);
            this.lbxConstraints.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Constraints";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAddConstraint
            // 
            this.btnAddConstraint.Location = new System.Drawing.Point(257, 53);
            this.btnAddConstraint.Name = "btnAddConstraint";
            this.btnAddConstraint.Size = new System.Drawing.Size(75, 23);
            this.btnAddConstraint.TabIndex = 3;
            this.btnAddConstraint.Text = "Add Constraint";
            this.btnAddConstraint.UseVisualStyleBackColor = true;
            this.btnAddConstraint.Click += new System.EventHandler(this.btnAddConstraint_Click);
            // 
            // txtX1Coef
            // 
            this.txtX1Coef.Location = new System.Drawing.Point(6, 30);
            this.txtX1Coef.Name = "txtX1Coef";
            this.txtX1Coef.Size = new System.Drawing.Size(51, 20);
            this.txtX1Coef.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X1 + ";
            // 
            // txtX2Coef
            // 
            this.txtX2Coef.Location = new System.Drawing.Point(116, 30);
            this.txtX2Coef.Name = "txtX2Coef";
            this.txtX2Coef.Size = new System.Drawing.Size(58, 20);
            this.txtX2Coef.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "X2";
            // 
            // cbxSign
            // 
            this.cbxSign.FormattingEnabled = true;
            this.cbxSign.Items.AddRange(new object[] {
            ">=",
            "<=",
            "="});
            this.cbxSign.Location = new System.Drawing.Point(206, 30);
            this.cbxSign.Name = "cbxSign";
            this.cbxSign.Size = new System.Drawing.Size(45, 21);
            this.cbxSign.TabIndex = 8;
            // 
            // txtRHS
            // 
            this.txtRHS.Location = new System.Drawing.Point(257, 30);
            this.txtRHS.Name = "txtRHS";
            this.txtRHS.Size = new System.Drawing.Size(75, 20);
            this.txtRHS.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(791, 522);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(299, 82);
            this.button2.TabIndex = 11;
            this.button2.Text = "Draw Feasible Area";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Location = new System.Drawing.Point(12, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 45);
            this.panel1.TabIndex = 12;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(14, 17);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 0;
            this.lblError.Click += new System.EventHandler(this.label4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "X1 Coefficient";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "X2 Coefficient";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sign";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "RHS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Constraint ID";
            // 
            // txtRemoveID
            // 
            this.txtRemoveID.Location = new System.Drawing.Point(6, 41);
            this.txtRemoveID.Name = "txtRemoveID";
            this.txtRemoveID.Size = new System.Drawing.Size(100, 20);
            this.txtRemoveID.TabIndex = 18;
            // 
            // btnRemoveConstraint
            // 
            this.btnRemoveConstraint.Location = new System.Drawing.Point(116, 31);
            this.btnRemoveConstraint.Name = "btnRemoveConstraint";
            this.btnRemoveConstraint.Size = new System.Drawing.Size(104, 39);
            this.btnRemoveConstraint.TabIndex = 19;
            this.btnRemoveConstraint.Text = "Remove Constraint";
            this.btnRemoveConstraint.UseVisualStyleBackColor = true;
            this.btnRemoveConstraint.Click += new System.EventHandler(this.btnRemoveConstraint_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnAddConstraint);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtX1Coef);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtRHS);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtX2Coef);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbxSign);
            this.panel2.Location = new System.Drawing.Point(442, 459);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 84);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtRemoveID);
            this.panel3.Controls.Add(this.btnRemoveConstraint);
            this.panel3.Location = new System.Drawing.Point(443, 549);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 84);
            this.panel3.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.cbxMinMax);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtX1CoefOF);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtX2CoefOF);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.lblOF);
            this.panel4.Location = new System.Drawing.Point(792, 459);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(298, 57);
            this.panel4.TabIndex = 22;
            // 
            // lblOF
            // 
            this.lblOF.AutoSize = true;
            this.lblOF.Location = new System.Drawing.Point(3, 0);
            this.lblOF.Name = "lblOF";
            this.lblOF.Size = new System.Drawing.Size(99, 13);
            this.lblOF.TabIndex = 0;
            this.lblOF.Text = "Objective Function:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "X1 Coefficient";
            // 
            // txtX1CoefOF
            // 
            this.txtX1CoefOF.Location = new System.Drawing.Point(8, 33);
            this.txtX1CoefOF.Name = "txtX1CoefOF";
            this.txtX1CoefOF.Size = new System.Drawing.Size(51, 20);
            this.txtX1CoefOF.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(80, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "X1 + ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(103, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "X2 Coefficient";
            // 
            // txtX2CoefOF
            // 
            this.txtX2CoefOF.Location = new System.Drawing.Point(118, 33);
            this.txtX2CoefOF.Name = "txtX2CoefOF";
            this.txtX2CoefOF.Size = new System.Drawing.Size(58, 20);
            this.txtX2CoefOF.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(182, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "X2 = ";
            // 
            // cbxMinMax
            // 
            this.cbxMinMax.FormattingEnabled = true;
            this.cbxMinMax.Items.AddRange(new object[] {
            "Max",
            "Min"});
            this.cbxMinMax.Location = new System.Drawing.Point(210, 32);
            this.cbxMinMax.Name = "cbxMinMax";
            this.cbxMinMax.Size = new System.Drawing.Size(40, 21);
            this.cbxMinMax.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(255, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Z";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(791, 604);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(299, 29);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 639);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxConstraints);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox lbxConstraints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddConstraint;
        private System.Windows.Forms.TextBox txtX1Coef;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtX2Coef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxSign;
        private System.Windows.Forms.TextBox txtRHS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemoveID;
        private System.Windows.Forms.Button btnRemoveConstraint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtX1CoefOF;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtX2CoefOF;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOF;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxMinMax;
        private System.Windows.Forms.Button btnReset;
    }
}

