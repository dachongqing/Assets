using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BookRoom : MonoBehaviour, RoomInterface
{

	private String roomName;

	private int[] xyz;

	private RoomConstant rc;

	public GameObject northDoor;

	public GameObject southDoor;

	public GameObject eastDoor;

	public GameObject westDoor;

    private Dictionary<String, EventInterface> eventsList = new Dictionary<string, EventInterface>();


	string RoomInterface.getRoomName ()
	{
		return "书房";
	}

	int RoomInterface.getRoomType ()
	{
		return rc.ROOM_TYPE_LOBBY;
	}



	int[] RoomInterface.getXYZ ()
	{
		return xyz;
	}

	public void setXYZ (int[] xyz)
	{
		this.xyz = xyz;
	}


	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void northDoorEnable ()
	{
//		northDoor.GetComponent<DoorInterface>().enabled = true;
		northDoor.GetComponent<DoorInterface> ().setShowFlag (true);//门的图片要替换
	}

	public void southDoorEnable ()
	{
//		southDoor.GetComponent<DoorInterface>().enabled = true;
		southDoor.GetComponent<DoorInterface> ().setShowFlag (true);//门的图片要替换
		
	}

	public void westDoorEnable ()
	{
//           westDoor.GetComponent<MonoBehaviour>().enabled = true;

		eastDoor.GetComponent<DoorInterface> ().setShowFlag (true);//门的图片要替换
	}

	public void eastDoorEnable ()
	{
//           eastDoor.GetComponent<MonoBehaviour>().enabled = true;
		westDoor.GetComponent<DoorInterface> ().setShowFlag (true);//门的图片要替换
	}

	GameObject RoomInterface.getNorthDoor()
	{
		return northDoor;
	}

    public EventInterface getEvent(string eventType)
    {
        return eventsList[eventType];
    }

    public void setEvent(EventInterface ei)
    {
        eventsList.Add(ei.getEventType(), ei);

    }
}
