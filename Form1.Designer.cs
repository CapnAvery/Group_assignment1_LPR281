
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.chart1.Size = new System.Drawing.Size(949, 358);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // lbxConstraints
            // 
            this.lbxConstraints.FormattingEnabled = true;
            this.lbxConstraints.Location = new System.Drawing.Point(967, 38);
            this.lbxConstraints.Name = "lbxConstraints";
            this.lbxConstraints.Size = new System.Drawing.Size(424, 329);
            this.lbxConstraints.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(964, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Constraints";
            // 
            // btnAddConstraint
            // 
            this.btnAddConstraint.Location = new System.Drawing.Point(967, 373);
            this.btnAddConstraint.Name = "btnAddConstraint";
            this.btnAddConstraint.Size = new System.Drawing.Size(75, 23);
            this.btnAddConstraint.TabIndex = 3;
            this.btnAddConstraint.Text = "Add Constraint";
            this.btnAddConstraint.UseVisualStyleBackColor = true;
            this.btnAddConstraint.Click += new System.EventHandler(this.btnAddConstraint_Click);
            // 
            // txtX1Coef
            // 
            this.txtX1Coef.Location = new System.Drawing.Point(945, 427);
            this.txtX1Coef.Name = "txtX1Coef";
            this.txtX1Coef.Size = new System.Drawing.Size(51, 20);
            this.txtX1Coef.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1007, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X1 + ";
            // 
            // txtX2Coef
            // 
            this.txtX2Coef.Location = new System.Drawing.Point(1045, 427);
            this.txtX2Coef.Name = "txtX2Coef";
            this.txtX2Coef.Size = new System.Drawing.Size(58, 20);
            this.txtX2Coef.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1118, 430);
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
            this.cbxSign.Location = new System.Drawing.Point(1144, 426);
            this.cbxSign.Name = "cbxSign";
            this.cbxSign.Size = new System.Drawing.Size(45, 21);
            this.cbxSign.TabIndex = 8;
            // 
            // txtRHS
            // 
            this.txtRHS.Location = new System.Drawing.Point(1220, 426);
            this.txtRHS.Name = "txtRHS";
            this.txtRHS.Size = new System.Drawing.Size(100, 20);
            this.txtRHS.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 639);
            this.Controls.Add(this.txtRHS);
            this.Controls.Add(this.cbxSign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtX2Coef);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtX1Coef);
            this.Controls.Add(this.btnAddConstraint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxConstraints);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
    }
}

