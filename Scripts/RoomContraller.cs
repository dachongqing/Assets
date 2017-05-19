using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomContraller : MonoBehaviour
{

	private Queue<String> groundRoomType = new Queue<String> ();

	private Queue<String> upRoomType = new Queue<String> ();

	private Queue<String> downRoomType = new Queue<String> ();

    private Dictionary<int[], RoomInterface> roomList = new Dictionary<int[], RoomInterface>();

    private List<EventInterface> events = new List<EventInterface>();

    private RoomConstant roomConstant;

    private System.Random random = new System.Random();



    public RoomContraller ()
	{

        genRoomType();

    }

    private void genRoomEvent() {
        EventInterface ei = new SpeedLeveaRoomEvent();
        events.Add(ei);
        
    }

    private EventInterface getRandomEvent() {
        return events[random.Next(events.Count)];
    }

   

    private void genRoomType() {
    //这个队列的长度，限制了房间最大数量
		groundRoomType.Enqueue ("LobbyRoom");
		groundRoomType.Enqueue ("BookRoom");
		groundRoomType.Enqueue ("LobbyRoom");
		groundRoomType.Enqueue ("BookRoom");
		groundRoomType.Enqueue ("LobbyRoom");
		groundRoomType.Enqueue ("BookRoom");
		groundRoomType.Enqueue ("LobbyRoom");
		groundRoomType.Enqueue ("BookRoom");
		groundRoomType.Enqueue ("LobbyRoom");
		groundRoomType.Enqueue ("BookRoom");
		groundRoomType.Enqueue ("LobbyRoom");
		groundRoomType.Enqueue ("BookRoom");
		groundRoomType.Enqueue ("LobbyRoom");
		groundRoomType.Enqueue ("BookRoom");
		groundRoomType.Enqueue ("LobbyRoom");
		groundRoomType.Enqueue ("BookRoom");
    }

    private void setRoomEvents(RoomInterface room) {

        //判定房间是处于什么位置 楼上 地面 楼下， 不能出现 有冲突的事件， 比如楼下不能出现掉落事件

        if (room.getXYZ()[2] == roomConstant.ROOM_TYPE_GROUND) {

          //  if () {
          //      room.setEvent(getRandomEvent());
          //  }
        } else if (room.getXYZ()[2] == roomConstant.ROOM_TYPE_UP)
        {

        } else {
        }

    }


	public GameObject genRoom (int[] xyz,int[] door)
	{
        string roomType = "";
        //房间Prefab所在文件夹路径
        if (xyz[2] == roomConstant.ROOM_TYPE_GROUND) {
            roomType = groundRoomType.Dequeue();
        } else if (xyz[2] == roomConstant.ROOM_TYPE_UP)
        {
            roomType = upRoomType.Dequeue();
        }
        else {
            roomType = downRoomType.Dequeue();
        }
		 
		string url = "Prefabs/" + roomType;

		//仅用Resources.Load会永久修改原形Prefab。应该用Instatiate,操作修改原形的克隆体
		GameObject room = Instantiate (Resources.Load (url)) as GameObject;

		if (room == null) {
			Debug.Log ("cant find room Prefab !!!");
		} else {
			RoomInterface ri = room.GetComponent (System.Type.GetType (roomType)) as RoomInterface;
			ri.setXYZ(xyz);

            //随机生成事件
            setRoomEvents(ri);

            //根据数据生成门
            if (door [0] == 1) {
				int[] nextRoomXYZ=xyz;
				nextRoomXYZ[1]+=1;
				ri.northDoorEnable ();
				GameObject doorGo=ri.getNorthDoor();
				doorGo.GetComponent<DoorInterface>().setRoom(ri);
				doorGo.GetComponent<DoorInterface>().setNextRoomXYZ(nextRoomXYZ);

			}
			if (door [1] == 1) {
				ri.southDoorEnable ();
			}
			if (door [2] == 1) {
				ri.eastDoorEnable ();

			}
			if (door [3] == 1) {
				
				ri.westDoorEnable ();
			}
        roomList.Add(ri.getXYZ(),ri);
		}

        return room;
	}


    public RoomInterface findRoomByXYZ(int[] xyz) {

        foreach (int[] key in roomList.Keys)
        {
            if (key[0] == xyz[0] && key[1] == xyz[1] && key[2] == xyz[2])
            {
                return roomList[key];
            }
        }
        return null;
    }
}
