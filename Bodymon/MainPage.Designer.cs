
namespace Bodymon
{
    partial class MainPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.pb_PlayingField = new System.Windows.Forms.PictureBox();
            this.tmr_Movement = new System.Windows.Forms.Timer(this.components);
            this.pb_Player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_PlayingField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Player)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_PlayingField
            // 
            this.pb_PlayingField.Image = ((System.Drawing.Image)(resources.GetObject("pb_PlayingField.Image")));
            this.pb_PlayingField.Location = new System.Drawing.Point(215, 60);
            this.pb_PlayingField.Name = "pb_PlayingField";
            this.pb_PlayingField.Size = new System.Drawing.Size(476, 390);
            this.pb_PlayingField.TabIndex = 0;
            this.pb_PlayingField.TabStop = false;
            // 
            // tmr_Movement
            // 
            this.tmr_Movement.Enabled = true;
            this.tmr_Movement.Tick += new System.EventHandler(this.tmr_Movement_Tick);
            // 
            // pb_Player
            // 
            this.pb_Player.Image = ((System.Drawing.Image)(resources.GetObject("pb_Player.Image")));
            this.pb_Player.Location = new System.Drawing.Point(278, 290);
            this.pb_Player.Name = "pb_Player";
            this.pb_Player.Size = new System.Drawing.Size(27, 50);
            this.pb_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Player.TabIndex = 1;
            this.pb_Player.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pb_Player);
            this.Controls.Add(this.pb_PlayingField);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pb_PlayingField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_PlayingField;
        private System.Windows.Forms.Timer tmr_Movement;
        private System.Windows.Forms.PictureBox pb_Player;
    }
}