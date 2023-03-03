using ProcessMemoryReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssaltCubeHack
{
    class PlayerController
    {
        PlayerData myPlayerData = null;
        RoomData roomData = null;

        const int myPlayerBaseAddr = 0x0017B0B8;
        const int otherPlayerBaseAddr = 0x0018EFDC; // 다른 유저 첫번째 ADDR
        const int roomBaseAddr = 0x000069F0;

        const int playerCnt = 32;
        List<PlayerData> playerDataList = new List<PlayerData>();

        const float limitDistance = 40f;

        public PlayerData MyPlayerData
        {
            get { return myPlayerData; }
        }

        public void init()
        {
            myPlayerData = null;
            roomData = null;
            playerDataList.Clear();
        }

        public void GetEnemyState(ProcessMemoryReader memoryReader)
        {
            playerDataList.Clear();

            int basePtr = memoryReader.ReadProcess.MainModule.BaseAddress.ToInt32() + otherPlayerBaseAddr;
            int []offsetArray = { 0, 0 };

            for (int i = 0; i < playerCnt; i++)
            {
                int baseAddr = memoryReader.ReadMultiLevelPointer(basePtr, 4, offsetArray);
                playerDataList.Add(new PlayerData(memoryReader, baseAddr));
                offsetArray[0] += 4;
            }
        }

        float GetXYAngle(PlayerData from, PlayerData to)
        {
            double xdist = from.xpos - to.xpos;
            double ydist = from.ypos - to.ypos;

            double radian = Math.Atan2(ydist, xdist);
            double degree = radian * 180 / Math.PI;

            degree -= 90d;

            if (degree < 0)
            {
                degree += 360d;
            }
            return (float)degree;
        }

        float GetZAngle(PlayerData from, PlayerData to)
        {
            double xyDist = GetDistance2D(from, to);
            double zDist = to.zpos - from.zpos;

            double radian = Math.Atan2(zDist, xyDist);
            double degree = radian * 180 / Math.PI;

            return (float)degree; 
        }

        float GetDistance3D(PlayerData from, PlayerData to)
        {
            float dist = (from.xpos - to.xpos) * (from.xpos - to.xpos) + (from.ypos - to.ypos) * (from.ypos - to.ypos)
                + (from.zpos - to.zpos) * (from.zpos - to.zpos);
            return (float)Math.Sqrt(dist);
        }

        float GetDistance2D(PlayerData from, PlayerData to)
        {
            float dist = (from.xpos - to.xpos) * (from.xpos - to.xpos) + (from.ypos - to.ypos) * (from.ypos - to.ypos);
            return (float)Math.Sqrt(dist);
        }

        PlayerData JudgeAimEnemy()
        {
            if (myPlayerData == null || playerDataList.Count == 0 || roomData == null)
            {
                return null;
            }

            roomData.SetRoomData();

            List<PlayerData> nearestList = new List<PlayerData>();

            // limitDistance 거리 안에 있는 요소만 뽑음
            int cnt = Math.Min(playerDataList.Count, roomData.playerCnt) - 1;

            for (int i = 0; i < cnt; i++)
            {
                if (0 > playerDataList[i].health || playerDataList[i].health > 100) 
                    continue;

                float dist = GetDistance3D(myPlayerData, playerDataList[i]);
                if (dist <= limitDistance)
                {
                    nearestList.Add(playerDataList[i]);
                }
            }

            int nearCnt = nearestList.Count;
            int index = -1;
            float minEvValue = float.MaxValue;

            for (int i = 0; i < nearCnt; i++)
            {
                float xyAngle = GetXYAngle(myPlayerData, nearestList[i]);
                float zAngle = GetZAngle(myPlayerData, nearestList[i]);

                float evValue = (xyAngle - myPlayerData.xyAng) * (xyAngle - myPlayerData.xyAng) + (zAngle - myPlayerData.zAng) * (zAngle - myPlayerData.zAng);

                if(minEvValue > evValue)
                {
                    minEvValue = evValue;
                    index = i;
                }
            }

            if(index == -1)
            {
                return null;
            }

            return nearestList[index];
        }

        List<Pair<int, float>> GetNearestEnemyList()
        {
            if (myPlayerData == null)
            {
                return null;
            }

            List<Pair<int, float>> distList = new List<Pair<int, float>>();

            int cnt = playerDataList.Count;
            for (int i = 0; i < cnt; i++)
            {
                float dist = GetDistance3D(myPlayerData, playerDataList[i]);
                distList.Add(new Pair<int, float>(i, dist));
            }

            distList.Sort((a, b) =>
            {
                if (a.second < b.second) return -1;
                return 1;
            });

            return distList;
        }

        public void GetMyData(ProcessMemoryReader memoryReader)
        {
            int basePtr = memoryReader.ReadProcess.MainModule.BaseAddress.ToInt32() + myPlayerBaseAddr;
            int baseAddr = memoryReader.ReadInt(basePtr);
            myPlayerData = new PlayerData(memoryReader, baseAddr);
        }

        public void GetRoomData(ProcessMemoryReader memoryReader)
        {
            int basePtr = memoryReader.ReadProcess.MainModule.BaseAddress.ToInt32() + roomBaseAddr;
            int baseAddr = memoryReader.ReadInt(basePtr);
            roomData = new RoomData(memoryReader, baseAddr);
        }

        public void SetMyData()
        {
            if(myPlayerData == null)
            {
                return;
            }

            myPlayerData.SetPlayerData();
        }

        public void SetRoomData()
        {
            if(roomData == null)
            {
                return;
            }

            roomData.SetRoomData();
        }

        public void HackMyHealth()
        {
            myPlayerData.HackHealth();
        }

        public void HackMyBullet()
        {
            myPlayerData.HackBullet();
        }

        public void HackMyAmmor()
        {
            myPlayerData.HackAmmor();
        }

        public void HackAim()
        {
            PlayerData targetEnemy = JudgeAimEnemy();

            if (targetEnemy == null)
            {
                return;
            }

            float xyAngle = GetXYAngle(myPlayerData, targetEnemy);
            float zAngle = GetZAngle(myPlayerData, targetEnemy);
            myPlayerData.SetAim(xyAngle, zAngle);
        }
    }
}
