
namespace AssaltCubeHack
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TitleLable = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.ProcessComboBox = new System.Windows.Forms.ComboBox();
            this.PlayerDataGroup = new System.Windows.Forms.GroupBox();
            this.AngleLabel = new System.Windows.Forms.Label();
            this.PosLabel = new System.Windows.Forms.Label();
            this.AmmorLabel = new System.Windows.Forms.Label();
            this.BulletLabel = new System.Windows.Forms.Label();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.SelectProcessLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.HealHackCheck = new System.Windows.Forms.CheckBox();
            this.BulletHackCheck = new System.Windows.Forms.CheckBox();
            this.AmmorHackCheck = new System.Windows.Forms.CheckBox();
            this.AimHackCheck = new System.Windows.Forms.CheckBox();
            this.ESPCheck = new System.Windows.Forms.CheckBox();
            this.PlayerDataGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLable
            // 
            this.TitleLable.AutoSize = true;
            this.TitleLable.Font = new System.Drawing.Font("맑은 고딕", 36F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TitleLable.Location = new System.Drawing.Point(42, 20);
            this.TitleLable.Name = "TitleLable";
            this.TitleLable.Size = new System.Drawing.Size(569, 65);
            this.TitleLable.TabIndex = 0;
            this.TitleLable.Text = "AssaultCube GameHack";
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.Location = new System.Drawing.Point(551, 310);
            this.Exit.Margin = new System.Windows.Forms.Padding(100);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(102, 27);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "종료";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ProcessComboBox
            // 
            this.ProcessComboBox.FormattingEnabled = true;
            this.ProcessComboBox.Location = new System.Drawing.Point(53, 129);
            this.ProcessComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.ProcessComboBox.Name = "ProcessComboBox";
            this.ProcessComboBox.Size = new System.Drawing.Size(265, 25);
            this.ProcessComboBox.TabIndex = 3;
            this.ProcessComboBox.Text = "Select Process";
            this.ProcessComboBox.SelectedIndexChanged += new System.EventHandler(this.ProcessComboBox_SelectedIndexChanged);
            this.ProcessComboBox.Click += new System.EventHandler(this.ProcessComboBox_Click);
            // 
            // PlayerDataGroup
            // 
            this.PlayerDataGroup.Controls.Add(this.AngleLabel);
            this.PlayerDataGroup.Controls.Add(this.PosLabel);
            this.PlayerDataGroup.Controls.Add(this.AmmorLabel);
            this.PlayerDataGroup.Controls.Add(this.BulletLabel);
            this.PlayerDataGroup.Controls.Add(this.HealthLabel);
            this.PlayerDataGroup.Location = new System.Drawing.Point(337, 129);
            this.PlayerDataGroup.Name = "PlayerDataGroup";
            this.PlayerDataGroup.Size = new System.Drawing.Size(274, 164);
            this.PlayerDataGroup.TabIndex = 4;
            this.PlayerDataGroup.TabStop = false;
            this.PlayerDataGroup.Text = "Player Data";
            // 
            // AngleLabel
            // 
            this.AngleLabel.AutoSize = true;
            this.AngleLabel.Location = new System.Drawing.Point(22, 129);
            this.AngleLabel.Name = "AngleLabel";
            this.AngleLabel.Size = new System.Drawing.Size(51, 17);
            this.AngleLabel.TabIndex = 0;
            this.AngleLabel.Text = "Angle :";
            // 
            // PosLabel
            // 
            this.PosLabel.AutoSize = true;
            this.PosLabel.Location = new System.Drawing.Point(22, 103);
            this.PosLabel.Name = "PosLabel";
            this.PosLabel.Size = new System.Drawing.Size(63, 17);
            this.PosLabel.TabIndex = 0;
            this.PosLabel.Text = "Position :";
            // 
            // AmmorLabel
            // 
            this.AmmorLabel.AutoSize = true;
            this.AmmorLabel.Location = new System.Drawing.Point(22, 77);
            this.AmmorLabel.Name = "AmmorLabel";
            this.AmmorLabel.Size = new System.Drawing.Size(60, 17);
            this.AmmorLabel.TabIndex = 0;
            this.AmmorLabel.Text = "Ammor :";
            // 
            // BulletLabel
            // 
            this.BulletLabel.AutoSize = true;
            this.BulletLabel.Location = new System.Drawing.Point(22, 51);
            this.BulletLabel.Name = "BulletLabel";
            this.BulletLabel.Size = new System.Drawing.Size(49, 17);
            this.BulletLabel.TabIndex = 0;
            this.BulletLabel.Text = "Bullet :";
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.Location = new System.Drawing.Point(22, 25);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(54, 17);
            this.HealthLabel.TabIndex = 0;
            this.HealthLabel.Text = "Health :";
            // 
            // SelectProcessLabel
            // 
            this.SelectProcessLabel.AutoSize = true;
            this.SelectProcessLabel.Location = new System.Drawing.Point(53, 102);
            this.SelectProcessLabel.Name = "SelectProcessLabel";
            this.SelectProcessLabel.Size = new System.Drawing.Size(92, 17);
            this.SelectProcessLabel.TabIndex = 5;
            this.SelectProcessLabel.Text = "Select Process";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // HealHackCheck
            // 
            this.HealHackCheck.AutoSize = true;
            this.HealHackCheck.Location = new System.Drawing.Point(53, 176);
            this.HealHackCheck.Name = "HealHackCheck";
            this.HealHackCheck.Size = new System.Drawing.Size(99, 21);
            this.HealHackCheck.TabIndex = 6;
            this.HealHackCheck.Text = "Health Hack";
            this.HealHackCheck.UseVisualStyleBackColor = true;
            this.HealHackCheck.CheckedChanged += new System.EventHandler(this.HealHackCheck_CheckedChanged);
            // 
            // BulletHackCheck
            // 
            this.BulletHackCheck.AutoSize = true;
            this.BulletHackCheck.Location = new System.Drawing.Point(53, 210);
            this.BulletHackCheck.Name = "BulletHackCheck";
            this.BulletHackCheck.Size = new System.Drawing.Size(94, 21);
            this.BulletHackCheck.TabIndex = 6;
            this.BulletHackCheck.Text = "Bullet Hack";
            this.BulletHackCheck.UseVisualStyleBackColor = true;
            this.BulletHackCheck.CheckedChanged += new System.EventHandler(this.BulletHackCheck_CheckedChanged);
            // 
            // AmmorHackCheck
            // 
            this.AmmorHackCheck.AutoSize = true;
            this.AmmorHackCheck.Location = new System.Drawing.Point(53, 244);
            this.AmmorHackCheck.Name = "AmmorHackCheck";
            this.AmmorHackCheck.Size = new System.Drawing.Size(105, 21);
            this.AmmorHackCheck.TabIndex = 6;
            this.AmmorHackCheck.Text = "Ammor Hack";
            this.AmmorHackCheck.UseVisualStyleBackColor = true;
            this.AmmorHackCheck.CheckedChanged += new System.EventHandler(this.AmmorHackCheck_CheckedChanged);
            // 
            // AimHackCheck
            // 
            this.AimHackCheck.AutoSize = true;
            this.AimHackCheck.Location = new System.Drawing.Point(53, 278);
            this.AimHackCheck.Name = "AimHackCheck";
            this.AimHackCheck.Size = new System.Drawing.Size(84, 21);
            this.AimHackCheck.TabIndex = 6;
            this.AimHackCheck.Text = "Aim Hack";
            this.AimHackCheck.UseVisualStyleBackColor = true;
            this.AimHackCheck.CheckedChanged += new System.EventHandler(this.AimHackCheck_CheckedChanged);
            // 
            // ESPCheck
            // 
            this.ESPCheck.AutoSize = true;
            this.ESPCheck.Location = new System.Drawing.Point(53, 312);
            this.ESPCheck.Name = "ESPCheck";
            this.ESPCheck.Size = new System.Drawing.Size(48, 21);
            this.ESPCheck.TabIndex = 6;
            this.ESPCheck.Text = "ESP";
            this.ESPCheck.UseVisualStyleBackColor = true;
            this.ESPCheck.CheckedChanged += new System.EventHandler(this.ESPCheck_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 348);
            this.Controls.Add(this.ESPCheck);
            this.Controls.Add(this.AimHackCheck);
            this.Controls.Add(this.AmmorHackCheck);
            this.Controls.Add(this.BulletHackCheck);
            this.Controls.Add(this.HealHackCheck);
            this.Controls.Add(this.SelectProcessLabel);
            this.Controls.Add(this.PlayerDataGroup);
            this.Controls.Add(this.ProcessComboBox);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.TitleLable);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "AssaultCube GameHack";
            this.PlayerDataGroup.ResumeLayout(false);
            this.PlayerDataGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label TitleLable;
        public System.Windows.Forms.Button Exit;
        public System.Windows.Forms.ComboBox ProcessComboBox;
        public System.Windows.Forms.GroupBox PlayerDataGroup;
        public System.Windows.Forms.Label BulletLabel;
        public System.Windows.Forms.Label HealthLabel;
        public System.Windows.Forms.Label AmmorLabel;
        public System.Windows.Forms.Label PosLabel;
        public System.Windows.Forms.Label AngleLabel;
        public System.Windows.Forms.Label SelectProcessLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox HealHackCheck;
        private System.Windows.Forms.CheckBox BulletHackCheck;
        private System.Windows.Forms.CheckBox AmmorHackCheck;
        private System.Windows.Forms.CheckBox AimHackCheck;
        private System.Windows.Forms.CheckBox ESPCheck;
    }
}

