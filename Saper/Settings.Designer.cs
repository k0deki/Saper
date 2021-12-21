
namespace Saper
{
    partial class Settings
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
            this.Difficulty = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Custom = new System.Windows.Forms.Panel();
            this.BombCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MapSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.BombSize = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SPSet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Custom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Difficulty
            // 
            this.Difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Difficulty.FormattingEnabled = true;
            this.Difficulty.Location = new System.Drawing.Point(291, 201);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(174, 33);
            this.Difficulty.TabIndex = 3;
            this.Difficulty.SelectedIndexChanged += new System.EventHandler(this.Difficulty_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(165, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Difficulty ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(149, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "User name";
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserName.Location = new System.Drawing.Point(291, 30);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(174, 31);
            this.UserName.TabIndex = 1;
            // 
            // Custom
            // 
            this.Custom.Controls.Add(this.BombCount);
            this.Custom.Controls.Add(this.label4);
            this.Custom.Controls.Add(this.MapSize);
            this.Custom.Controls.Add(this.label3);
            this.Custom.Location = new System.Drawing.Point(128, 267);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(430, 249);
            this.Custom.TabIndex = 3;
            this.Custom.Visible = false;
            // 
            // BombCount
            // 
            this.BombCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BombCount.Location = new System.Drawing.Point(163, 141);
            this.BombCount.Name = "BombCount";
            this.BombCount.Size = new System.Drawing.Size(174, 31);
            this.BombCount.TabIndex = 6;
            this.BombCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BombCount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bomb count";
            // 
            // MapSize
            // 
            this.MapSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MapSize.Location = new System.Drawing.Point(163, 40);
            this.MapSize.Name = "MapSize";
            this.MapSize.Size = new System.Drawing.Size(174, 31);
            this.MapSize.TabIndex = 5;
            this.MapSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MapSize_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(37, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Map size";
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Location = new System.Drawing.Point(608, 460);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(158, 47);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl.Location = new System.Drawing.Point(143, 115);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(122, 25);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Button Size";
            // 
            // BombSize
            // 
            this.BombSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BombSize.Location = new System.Drawing.Point(291, 115);
            this.BombSize.Name = "BombSize";
            this.BombSize.Size = new System.Drawing.Size(174, 31);
            this.BombSize.TabIndex = 2;
            this.BombSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MapSize_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(633, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 102);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // SPSet
            // 
            this.SPSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SPSet.FormattingEnabled = true;
            this.SPSet.Location = new System.Drawing.Point(693, 49);
            this.SPSet.Name = "SPSet";
            this.SPSet.Size = new System.Drawing.Size(174, 33);
            this.SPSet.TabIndex = 4;
            this.SPSet.SelectedIndexChanged += new System.EventHandler(this.SPSet_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(567, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sprite set";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 562);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Custom);
            this.Controls.Add(this.BombSize);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SPSet);
            this.Controls.Add(this.Difficulty);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Custom.ResumeLayout(false);
            this.Custom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Difficulty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Panel Custom;
        private System.Windows.Forms.TextBox BombCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MapSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox BombSize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox SPSet;
        private System.Windows.Forms.Label label5;
    }
}