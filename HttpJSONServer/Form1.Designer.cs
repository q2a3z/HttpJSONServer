
namespace HttpJSONServer
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
            this.ReqBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReqBtn
            // 
            this.ReqBtn.Location = new System.Drawing.Point(128, 148);
            this.ReqBtn.Name = "ReqBtn";
            this.ReqBtn.Size = new System.Drawing.Size(155, 112);
            this.ReqBtn.TabIndex = 0;
            this.ReqBtn.Text = "REQUEST";
            this.ReqBtn.UseVisualStyleBackColor = true;
            this.ReqBtn.Click += new System.EventHandler(this.RequestBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.Green;
            this.StartBtn.Location = new System.Drawing.Point(443, 148);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(153, 112);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "START";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.ReqBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReqBtn;
        private System.Windows.Forms.Button StartBtn;
    }
}

