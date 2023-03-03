using System.Diagnostics;
using ProcessMemoryReaderLib;

namespace AssaltCubeHack
{
    public class PlayerMemoryData
    {
        public int baseAddr = -1; // = 0x0017B0B8;
        public int healthOffset = 0xEC;
        public int bulletOffset = 0x140;
        public int ammorOffset = 0xF0;
        public int xpos = 0x28;
        public int ypos = 0x2c;
        public int zpos = 0x30;
        public int xyAng = 0x34;
        public int zAng = 0x38;

        public PlayerMemoryData(int baseAddr)
        {
            this.baseAddr = baseAddr;
        }
    }

    public class PlayerData
    {
        private PlayerMemoryData playerMemData = null;

        public int health { get; set; }
        public int bullet { get; set; }
        public int ammor { get; set; }
        public float xpos { get; set; }
        public float ypos { get; set; }
        public float zpos { get; set; }
        public float xyAng { get; set; }
        public float zAng { get; set; }

        ProcessMemoryReader pMem = null;

        public PlayerMemoryData PlayerMemData
        {
            get { return playerMemData; }
        }

        public PlayerData(ProcessMemoryReader pMem, int baseAddr)
        {

            this.pMem = pMem;
            playerMemData = new PlayerMemoryData(baseAddr);

            health = 0;
            bullet = 0;
            ammor = 0;
            xpos = 0f;
            ypos = 0f;
            zpos = 0f;
            xyAng = 0f;
            zAng = 0f;

            SetPlayerData();
        }

        public void SetPlayerData()
        {
            int baseAddr = playerMemData.baseAddr;
            health = pMem.ReadInt(baseAddr + playerMemData.healthOffset);
            bullet = pMem.ReadInt(baseAddr + playerMemData.bulletOffset);
            ammor = pMem.ReadInt(baseAddr + playerMemData.ammorOffset);
            xpos = pMem.ReadFloat(baseAddr + playerMemData.xpos); ;
            ypos = pMem.ReadFloat(baseAddr + playerMemData.ypos);
            zpos = pMem.ReadFloat(baseAddr + playerMemData.zpos);
            xyAng = pMem.ReadFloat(baseAddr + playerMemData.xyAng);
            zAng = pMem.ReadFloat(baseAddr + playerMemData.zAng);
        }

        public void HackHealth()
        {
            pMem.WriteInt(playerMemData.baseAddr + playerMemData.healthOffset, 10000);
        }

        public void HackBullet()
        {
            pMem.WriteInt(playerMemData.baseAddr + playerMemData.bulletOffset, 10000);
        }

        public void HackAmmor()
        {
            pMem.WriteInt(playerMemData.baseAddr + playerMemData.ammorOffset, 10000);
        }

        public void SetAim(float xyAng, float zAng)
        {
            pMem.WriteFloat(playerMemData.baseAddr + playerMemData.xyAng, xyAng);
            pMem.WriteFloat(playerMemData.baseAddr + playerMemData.zAng, zAng);
        }
    }
}