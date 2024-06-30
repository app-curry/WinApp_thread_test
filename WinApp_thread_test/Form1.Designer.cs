namespace WinApp_thread_test
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_thread_start = new System.Windows.Forms.Button();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.button_thread_stop = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_suspend = new System.Windows.Forms.Button();
            this.button_resume = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_thread_start
            // 
            this.button_thread_start.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_thread_start.Location = new System.Drawing.Point(12, 12);
            this.button_thread_start.Name = "button_thread_start";
            this.button_thread_start.Size = new System.Drawing.Size(200, 70);
            this.button_thread_start.TabIndex = 0;
            this.button_thread_start.Text = "Thread Start";
            this.button_thread_start.UseVisualStyleBackColor = true;
            this.button_thread_start.Click += new System.EventHandler(this.button_thread_start_Click);
            // 
            // textBox_message
            // 
            this.textBox_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_message.Location = new System.Drawing.Point(0, 0);
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_message.Size = new System.Drawing.Size(277, 681);
            this.textBox_message.TabIndex = 1;
            // 
            // button_thread_stop
            // 
            this.button_thread_stop.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_thread_stop.Location = new System.Drawing.Point(218, 12);
            this.button_thread_stop.Name = "button_thread_stop";
            this.button_thread_stop.Size = new System.Drawing.Size(200, 70);
            this.button_thread_stop.TabIndex = 2;
            this.button_thread_stop.Text = "Thread Stop";
            this.button_thread_stop.UseVisualStyleBackColor = true;
            this.button_thread_stop.Click += new System.EventHandler(this.button_thread_stop_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(552, 681);
            this.dataGridView1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 101);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox_message);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(833, 681);
            this.splitContainer1.SplitterDistance = 277;
            this.splitContainer1.TabIndex = 4;
            // 
            // button_suspend
            // 
            this.button_suspend.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_suspend.Location = new System.Drawing.Point(424, 12);
            this.button_suspend.Name = "button_suspend";
            this.button_suspend.Size = new System.Drawing.Size(200, 70);
            this.button_suspend.TabIndex = 5;
            this.button_suspend.Text = "Suspend";
            this.button_suspend.UseVisualStyleBackColor = true;
            this.button_suspend.Click += new System.EventHandler(this.button_suspend_Click);
            // 
            // button_resume
            // 
            this.button_resume.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_resume.Location = new System.Drawing.Point(630, 12);
            this.button_resume.Name = "button_resume";
            this.button_resume.Size = new System.Drawing.Size(200, 70);
            this.button_resume.TabIndex = 6;
            this.button_resume.Text = "Resume";
            this.button_resume.UseVisualStyleBackColor = true;
            this.button_resume.Click += new System.EventHandler(this.button_resume_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 794);
            this.Controls.Add(this.button_resume);
            this.Controls.Add(this.button_suspend);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button_thread_stop);
            this.Controls.Add(this.button_thread_start);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_thread_start;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Button button_thread_stop;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_suspend;
        private System.Windows.Forms.Button button_resume;
    }
}

