using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssaltCubeHack
{
    public partial class OverLayForm : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        IntPtr hAssaultCube;
        public const string WINDOWNAME = "AssaultCube";
        RECT windowRect;

        Graphics grapics;
        Pen myPen = new Pen(Color.Red);

        const int xyAngle = 94;
        const int middleXYAngle = xyAngle / 2;
        const int zAngle = 68;
        const int middleZAngle = zAngle / 2;
        const int zAdjValue = 10;

        // 캐릭터와 거리가 3 정도 차이날 때 실제 오버레이되는 박스 사이즈
        const int charWidthSize = 120;
        const int charHeightSize = 270;
        const float nominalDistance = 10;

        List<PlayerDiffData> playerDiffData = null;

        public OverLayForm()
        {
            InitializeComponent();
            hAssaultCube = IntPtr.Zero;
        }

        private void OverLayForm_Load(object sender, EventArgs e)
        {
            SetAlphaBackground();
            SetWindowStyle();
            SetWindowSizePos();
            playerDiffData = null;
        }

        bool GetAssaultCubeHandle()
        {
            hAssaultCube = FindWindow(null, WINDOWNAME);

            if (hAssaultCube == IntPtr.Zero)
                return false;
            return true;
        }

        void SetWindowSizePos()
        {
            bool flag = GetAssaultCubeHandle();
            if (flag == false)
                return;

            GetWindowRect(hAssaultCube, out windowRect);

            // 사이즈
            int width = windowRect.Right - windowRect.Left;
            int height = windowRect.Bottom - windowRect.Top;
            this.Size = new Size(new Point(width, height));

            // 위치
            this.Top = windowRect.Top;
            this.Left = windowRect.Left;
        }

        void SetWindowStyle()
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            uint initStyle = GetWindowLong(this.Handle, -20);
            // 마우스 이벤트를 뒤로 전달하는 속성 추가  initStyle | 0x80000 | 0x20
            SetWindowLong(this.Handle, -20, initStyle | 0x80000 | 0x20);
        }

        void SetAlphaBackground()
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
        }

        private void OverLayForm_Paint(object sender, PaintEventArgs e)
        {
            grapics = e.Graphics;
            PrintEnemy();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            SetWindowSizePos();
        }

        public void SetEventPrintEnemy(List<PlayerDiffData> playerDiffData)
        {
            if (playerDiffData == null)
            {
                return;
            }

            this.playerDiffData = playerDiffData;
            Invalidate(false);
        }

        public void PrintEnemy()
        {
            if (playerDiffData == null)
                return;

            int cnt = playerDiffData.Count;
            Pair<int, int> centerPoint = GetCenterPoint();

            int xPerAngPixel = GetXPixelPerXYAngle();
            int yPerAngPixel = GetYPixelPerZAngle();

            for (int i = 0; i < cnt; i++)
            {
                float converXyAngle = GetConvertXYAngleScreen(playerDiffData[i].xyAngle);

                // 특정 앵글에서 벗어나면 그리지 않음.
                if(Math.Abs(converXyAngle) >= (float)(middleXYAngle))
                {
                    continue;
                }

                int centerXpos = centerPoint.first + (int)(converXyAngle * xPerAngPixel);
                int centerYpos = centerPoint.second - (int)(playerDiffData[i].zAngle * yPerAngPixel);

                float distRatio = nominalDistance / playerDiffData[i].distance;

                int cWidthSize = (int)((float)(charWidthSize) * distRatio);
                int cHeightSize = (int)((float)(charHeightSize) * distRatio);

                int left = centerXpos - cWidthSize / 2;
                int top = centerYpos - zAdjValue; // 머리에서 시작하기 때문에 보정치를 준다.

                grapics.DrawRectangle(myPen, left, top, cWidthSize, cHeightSize);
            }
        }

        float GetConvertXYAngleScreen(float xyAngle)
        {
            float converXyAngle = Math.Abs(xyAngle - 360f);

            if (xyAngle > converXyAngle)
            {
                return xyAngle - 360f;
            }
            return xyAngle;
        }

        Pair<int,int> GetCenterPoint()
        {
            return new Pair<int, int>((windowRect.Right - windowRect.Left) / 2, (windowRect.Bottom - windowRect.Top) / 2);
        }

        int GetXPixelPerXYAngle()
        {
            int windowWidth = windowRect.Right - windowRect.Left;
            return windowWidth / xyAngle;
        }

        int GetYPixelPerZAngle()
        {
            int windowHeight = windowRect.Bottom - windowRect.Top;
            return windowHeight / zAngle;
        }
    }
}
