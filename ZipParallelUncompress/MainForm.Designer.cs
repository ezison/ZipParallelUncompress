namespace ZipParallelUncompress
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.txtArchiveFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUncompressParallel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnUncompressNormal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(117, 24);
            this.txtThreadCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(97, 25);
            this.txtThreadCount.TabIndex = 1;
            this.txtThreadCount.Text = "4";
            // 
            // txtArchiveFilePath
            // 
            this.txtArchiveFilePath.Location = new System.Drawing.Point(117, 57);
            this.txtArchiveFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtArchiveFilePath.Name = "txtArchiveFilePath";
            this.txtArchiveFilePath.Size = new System.Drawing.Size(826, 25);
            this.txtArchiveFilePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "スレッド数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ファイルパス";
            // 
            // btnUncompressParallel
            // 
            this.btnUncompressParallel.Location = new System.Drawing.Point(117, 89);
            this.btnUncompressParallel.Name = "btnUncompressParallel";
            this.btnUncompressParallel.Size = new System.Drawing.Size(414, 23);
            this.btnUncompressParallel.TabIndex = 4;
            this.btnUncompressParallel.Text = "スレッドを使用した解凍";
            this.btnUncompressParallel.UseVisualStyleBackColor = true;
            this.btnUncompressParallel.Click += new System.EventHandler(this.btnUncompressParallel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "実行時間";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtResult.Location = new System.Drawing.Point(117, 122);
            this.txtResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(826, 89);
            this.txtResult.TabIndex = 6;
            // 
            // btnUncompressNormal
            // 
            this.btnUncompressNormal.Location = new System.Drawing.Point(537, 89);
            this.btnUncompressNormal.Name = "btnUncompressNormal";
            this.btnUncompressNormal.Size = new System.Drawing.Size(406, 23);
            this.btnUncompressNormal.TabIndex = 7;
            this.btnUncompressNormal.Text = "通常解凍";
            this.btnUncompressNormal.UseVisualStyleBackColor = true;
            this.btnUncompressNormal.Click += new System.EventHandler(this.btnUncompressNormal_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 240);
            this.Controls.Add(this.btnUncompressNormal);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUncompressParallel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArchiveFilePath);
            this.Controls.Add(this.txtThreadCount);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "解凍処理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.TextBox txtArchiveFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUncompressParallel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnUncompressNormal;
    }
}

