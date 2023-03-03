using ProcessMemoryReaderLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssaltCubeHack
{
    class ProcessManager : SingleTon<ProcessManager>
    {
        Process[] processList = null;
        ProcessMemoryReader memoryReader = new ProcessMemoryReader();

        PlayerController playerController = new PlayerController();

        public bool IsGetAttach
        {
            get
            {
                return memoryReader.IsGetProcess;
            }
        }

        public List<PlayerDiffData> PlayerDiffData
        {
            get
            {
                if (playerController == null)
                    return null;
                return playerController.GetDiffPlayerDataList();
            }
        }

        public PlayerData MyPlayerData
        {
            get { return playerController.MyPlayerData; }
        }

        public Process[] ProcessList
        {
            set
            {
                processList = value;

                if(processList == null)
                {
                    return;
                }

                Array.Sort(processList, (a, b) =>
                {
                    return string.Compare(a.ProcessName, b.ProcessName) > 0 ? 1 : -1;
                });
            }
            get
            {
                return processList;
            }
        }

        protected override void Init()
        {
            playerController.init();
        }

        public void SetProcess(Process[] process)
        {

        }

        public void CloseAttach()
        {
            Init();

            if (memoryReader.IsGetProcess)
            {
                try
                {
                    memoryReader.CloseHandle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public void GetProcess(string processName, int pid)
        {
            CloseAttach();

            #region 프로세스 attach
            try
            {
                Process attachProcess = Process.GetProcessById(pid);

                if(attachProcess == null)
                {
                    throw new Exception("attachProcess is null");
                }

                if (memoryReader == null)
                {
                    memoryReader = new ProcessMemoryReader();
                }

                memoryReader.ReadProcess = attachProcess;
                if (memoryReader.OpenProcess())
                {
                    MessageBox.Show("프로세스 열기 성공 " + processName);
                    GetProcessMemoryData();
                }
                else
                {
                    MessageBox.Show("프로세스 열기 실패");
                    memoryReader.ReadProcess = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("프로세스 열기 실패 : " + error.Message);
            }
            #endregion
        }

        void GetProcessMemoryData()
        {
            if(memoryReader.IsGetProcess == false)
            {
                MessageBox.Show("GetProcessMemoryData is Failed");
                return;
            }

            playerController.GetMyData(memoryReader);
            playerController.GetRoomData(memoryReader);
            UpDate();
        }

        public void UpDate()
        {
            playerController.SetMyData();
            //playerController.SetRoomData();
        }

        public void HackHealth()
        {
            if(memoryReader == null || memoryReader.IsGetProcess == false)
            {
                return;
            }

            playerController.HackMyHealth();
        }

        public void HackBullet()
        {
            if (memoryReader == null || memoryReader.IsGetProcess == false)
            {
                return;
            }

            playerController.HackMyBullet();
        }

        public void HackAmmor()
        {
            if (memoryReader == null || memoryReader.IsGetProcess == false)
            {
                return;
            }

            playerController.HackMyAmmor();
        }

        public void HackAim()
        {
            playerController.HackAim();
        }

        public void GetEnemyState()
        {
            playerController.GetEnemyState(memoryReader);
        }
    }
}
