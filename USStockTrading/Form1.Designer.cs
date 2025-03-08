namespace USStockTrading
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.btnAddSymbol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(428, 73);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(289, 28);
            this.txtSymbol.TabIndex = 0;
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(837, 55);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(99, 61);
            this.btnFetch.TabIndex = 1;
            this.btnFetch.Text = "Search";
            this.btnFetch.UseVisualStyleBackColor = true;
            // 
            // chartStock
            // 
            chartArea2.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartStock.Legends.Add(legend2);
            this.chartStock.Location = new System.Drawing.Point(267, 134);
            this.chartStock.Name = "chartStock";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartStock.Series.Add(series2);
            this.chartStock.Size = new System.Drawing.Size(800, 358);
            this.chartStock.TabIndex = 2;
            this.chartStock.Text = "chart1";
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 18;
            this.lstRecommendations.Location = new System.Drawing.Point(331, 520);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(669, 112);
            this.lstRecommendations.TabIndex = 3;
            // 
            // btnAddSymbol
            // 
            this.btnAddSymbol.Location = new System.Drawing.Point(41, 236);
            this.btnAddSymbol.Name = "btnAddSymbol";
            this.btnAddSymbol.Size = new System.Drawing.Size(142, 118);
            this.btnAddSymbol.TabIndex = 4;
            this.btnAddSymbol.Text = "SYMBOL-DICT";
            this.btnAddSymbol.UseVisualStyleBackColor = true;
            this.btnAddSymbol.Click += new System.EventHandler(this.btnAddSymbol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 644);
            this.Controls.Add(this.btnAddSymbol);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.chartStock);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.txtSymbol);
            this.Name = "Form1";
            this.Text = "US-STOCK : TRADE HELP PROGRAM";
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Button btnAddSymbol;
    }
}

