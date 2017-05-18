using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomContraller : MonoBehaviour
{

	private Queue<String> groundRoomType = new Queue<String> ();

	private Queue<String> upRoomType = new Queue<String> ();

	private Queue<String> downRoomType = new Queue<String> ();

	//这个队列的长度，限制了房间最大数量
	public RoomContraller ()
	{
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


	public GameObject genRoom (int[] xyz,int[] door)
	{
		//房间Prefab所在文件夹路径
		string roomType = groundRoomType.Dequeue ();
		string url = "Prefabs/" + roomType;

		//仅用Resources.Load会永久修改原形Prefab。应该用Instatiate,操作修改原形的克隆体
		GameObject room = Instantiate (Resources.Load (url)) as GameObject;

		if (room == null) {
			Debug.Log ("cant find room Prefab !!!");
		} else {
			RoomInterface ri = room.GetComponent (System.Type.GetType (roomType)) as RoomInterface;
			ri.setXYZ(xyz);

			//根据数据生成门
			if (door [0] == 1) {
				int[] nextRoomXYZ=xyz;
				nextRoomXYZ[1]+=1;
				ri.northDoorEnable ();
				GameObject doorGo=ri.getNorthDoor();
				doorGo.GetComponent<DoorInterface>().setRoom(ri);
				doorGo.GetComponent<DoorInterface>().setNextRoomXY(nextRoomXYZ);

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
		}

		return room;
	}
	
}
