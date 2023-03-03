using ProcessMemoryReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssaltCubeHack
{
    public class RoomMemoryData
    {
        public int baseAddr;
        public int playerOffset = 0x4D8;

        public RoomMemoryData(int baseAddr)
        {
            this.baseAddr = baseAddr;
        }
    }

    public class RoomData
    {
        private RoomMemoryData roomMemData = null;
        public int playerCnt { get; set; }

        ProcessMemoryReader pMem = null;

        public RoomData(ProcessMemoryReader pMem, int baseAddr)
        {
            this.pMem = pMem;
            roomMemData = new RoomMemoryData(baseAddr);
            SetRoomData();
        }

        public void SetRoomData()
        {
            playerCnt = pMem.ReadInt(roomMemData.baseAddr + roomMemData.playerOffset);
        }
    }
}
