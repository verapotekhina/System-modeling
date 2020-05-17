﻿namespace Histogram
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxDeltaTau = new System.Windows.Forms.TextBox();
            this.textBoxLambda = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(343, 25);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.LabelBorderWidth = 10;
            series1.Legend = "Legend1";
            series1.Name = "Experimental";
            series2.BorderWidth = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Teoretical";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1104, 780);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(18, 224);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Построить гистограмму";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество чисел:";
            // 
            // textBoxN
            // 
            this.textBoxN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxN.Location = new System.Drawing.Point(226, 91);
            this.textBoxN.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(109, 30);
            this.textBoxN.TabIndex = 6;
            // 
            // textBoxDeltaTau
            // 
            this.textBoxDeltaTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxDeltaTau.Location = new System.Drawing.Point(226, 170);
            this.textBoxDeltaTau.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDeltaTau.Name = "textBoxDeltaTau";
            this.textBoxDeltaTau.Size = new System.Drawing.Size(109, 30);
            this.textBoxDeltaTau.TabIndex = 7;
            // 
            // textBoxLambda
            // 
            this.textBoxLambda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxLambda.Location = new System.Drawing.Point(226, 132);
            this.textBoxLambda.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLambda.Name = "textBoxLambda";
            this.textBoxLambda.Size = new System.Drawing.Size(109, 30);
            this.textBoxLambda.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(13, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "λ:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(14, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "дельта тау:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1463, 818);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxLambda);
            this.Controls.Add(this.textBoxDeltaTau);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Потехина Вера - Гистограмма";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.TextBox textBoxDeltaTau;
        private System.Windows.Forms.TextBox textBoxLambda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

