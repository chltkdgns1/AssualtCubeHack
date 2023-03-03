using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessMemoryReaderLib;
using static ProcessMemoryReaderLib.ProcessMemoryReader;

namespace AssaltCubeHack
{
    public partial class MainForm : Form
    {
        bool isCheckHealthHack = false;
        bool isCheckBulltetHack = false;
        bool isCheckAmmorHack = false;
        bool isEsp = false;

        OverLayForm overLayForm = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult resultDialog;
            resultDialog = MessageBox.Show("종료하시겠습니까?", "Exit", MessageBoxButtons.OKCancel);

            if(resultDialog == DialogResult.OK)
            {
                this.DialogResult = DialogResult.Abort;
                Application.Exit();
            }
        }

        private void ProcessComboBox_Click(object sender, EventArgs e)
        {
            // 기존에 아이템 목록 초기화
            ProcessComboBox.Items.Clear();

            // 프로세스 리스트 초기화
            ProcessManager.Instance.ProcessList = Process.GetProcesses();

            Process[] prcList = ProcessManager.Instance.ProcessList;

            if (prcList == null)
            {
                DialogResult invalidProcessName = MessageBox.Show("프로세스 목록을 가져올 수 없습니다. 다시 시작해주세요", "Error", MessageBoxButtons.OK);
                return;
            }

            for (int i = 0; i < prcList.Length; i++)
            {
                string processInfoStr = prcList[i].ProcessName + "-" + prcList[i].Id;
                ProcessComboBox.Items.Add(processInfoStr);
            }
        }

        private void ProcessComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 입력 데이터 체크
            // 아무것도 선택하지 않았을 경우
            if (ProcessComboBox.SelectedIndex == -1)
            {
                DialogResult invalidProcessName = MessageBox.Show("프로세스를 선택해주세요", "Error", MessageBoxButtons.OK);
                return;
            }

            string selectedItem = ProcessComboBox.SelectedItem.ToString();
            string[] spliltStrArr = selectedItem.Split('-');

            if (spliltStrArr.Length != 2)
            {
                DialogResult invalidProcessName = MessageBox.Show("잘못된 프로세스 데이터입니다. 다시 선택해주세요.", "Error", MessageBoxButtons.OK);
                return;
            }

            int pid = -1;
            string processName = spliltStrArr[0];

            if (string.IsNullOrEmpty(processName))
            {
                DialogResult invalidProcessName = MessageBox.Show("잘못된 프로세스 데이터입니다. 다시 선택해주세요. -0", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion

            #region int parse
            try
            {
                pid = int.Parse(spliltStrArr[1]);
                if (pid == -1)
                {
                    throw new Exception("invalid number");
                }
            }
            catch (FormatException error)
            {
                DialogResult invalidProcessName = MessageBox.Show(error.Message);
                return;
            }
            catch (Exception error)
            {
                DialogResult invalidProcessName = MessageBox.Show(error.Message);
                return;
            }
            #endregion

            ProcessManager.Instance.GetProcess(processName, pid);
        }

        delegate void Add(int number);

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 프로세스 attact 실패 상태라면
            if(ProcessManager.Instance.IsGetAttach == false)
            {
                return;
            }

            // 내 플레이어 데이터가 없는 상태
            if(ProcessManager.Instance.MyPlayerData == null)
            {
                return;
            }

            UpdateMyData();

            if (isCheckHealthHack)
            {
                HackHealth();
            }

            if (isCheckBulltetHack)
            {
                HackBullet();
            }

            if (isCheckAmmorHack)
            {
                HackAmmor();
            }

            if (isEsp)
            {
                EspHack();
            }

            // 키가 눌렸을 때
            RMouseBtnDown(); 
        }

        void UpdateMyData()
        {
            ProcessManager.Instance.UpDate();

            var pData = ProcessManager.Instance.MyPlayerData;

            if (pData == null)
            {
                return;
            }

            HealthLabel.Text = "Health : " + pData.health.ToString();
            BulletLabel.Text = "Bullet : " + pData.bullet.ToString();
            AmmorLabel.Text = "Ammor : " + pData.ammor.ToString();
            PosLabel.Text = "Position : " + pData.xpos.ToString() + " , " + pData.ypos.ToString() + " , " + pData.zpos.ToString();
            AngleLabel.Text = "Angle : " + pData.xyAng.ToString() + " , " + pData.zAng.ToString();
        }

        void HackHealth()
        {
            ProcessManager.Instance.HackHealth();
        }

        void HackBullet()
        {
            ProcessManager.Instance.HackBullet();
        }

        void HackAmmor()
        {
            ProcessManager.Instance.HackAmmor();
        }

        void EspHack()
        {
            ProcessManager.Instance.GetEnemyState();
            // 플레이어들의 위치 정보 전달.
            InitOverlayForm();
            overLayForm.SetEventPrintEnemy(ProcessManager.Instance.PlayerDiffData);
        }

        void RMouseBtnDown()
        {
            int hotKey = ProcessMemoryReaderApi.GetKeyState((int)VirtualKeyStates.VK_RBUTTON);
            if ((hotKey & 0x8000) == 0)
            {
                return;
            }
            ProcessManager.Instance.GetEnemyState();
            ProcessManager.Instance.HackAim();
        }

        private void AmmorHackCheck_CheckedChanged(object sender, EventArgs e)
        {
            isCheckAmmorHack = AmmorHackCheck.Checked;
        }

        private void HealHackCheck_CheckedChanged(object sender, EventArgs e)
        {
            isCheckHealthHack = HealHackCheck.Checked;
        }

        private void BulletHackCheck_CheckedChanged(object sender, EventArgs e)
        {
            isCheckBulltetHack = BulletHackCheck.Checked;
        }

        private void ESPCheck_CheckedChanged(object sender, EventArgs e)
        {
            InitOverlayForm();

            isEsp = ESPCheck.Checked;

            if (ESPCheck.Checked)
            {
                overLayForm.Show();
            }
            else
            {
                overLayForm.Hide();
            }
        }

        void InitOverlayForm()
        {
            if (overLayForm == null || overLayForm.IsDisposed)
            {
                overLayForm = new OverLayForm();
            }
        }
    }
}
