using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDoor : MonoBehaviour, DoorInterface
{
	public Sprite DoorSprite;

	private int[] nextRoomXYZ;

	bool showFlag;

	private RoomInterface ri;

    public EventController eventController;

    public RoundController roundController;

    public void setNextRoomXY (int[] xyz)
	{
		this.nextRoomXYZ = xyz;
	}

	public void setRoom (RoomInterface room)
	{
		this.ri = room;
	}

	public void setShowFlag (bool showFlag)
	{
		//该门状态为显示
		this.showFlag = showFlag;
		//替换门的图片为门
		SpriteRenderer sPrRe = GetComponent<SpriteRenderer> ();
		sPrRe.sprite = DoorSprite;
	}

	int[] DoorInterface.getNextRoomXY ()
	{
		return nextRoomXYZ;
	}

	public RoomInterface getRoom ()
	{
		return ri;
	}

	bool DoorInterface.getShowFlag ()
	{
		return showFlag;
	}

	void DoorInterface.openDoor (GameObject movePoint)
	{
		//可以自定义不同的门，消耗不同的行动力
	}

    // Use this for initialization
    void Start()
    {
        eventController = FindObjectOfType<EventController>();

        roundController = FindObjectOfType<RoundController>();
    }

    // Update is called once per frame
    void Update ()
	{

        //伪代码
        /***
         * 监听门点击事件
         * 
         * 先扣除行动力
         * openDoor（）；
         */ 
         // 调用事件处理器处理事情

         bool result = eventController.excuteLeaveRoomEvent(getRoom(), roundController.getCurrentRoundChar());

        if(result == true)
        {
            //离开门成功
            //进入下一个房间
        }else
        {
            //离开失败
        }
         
        

        

    }

	//鼠标进入门区域
	void OnMouseEnter ()
	{
		//仅对启用的门有效
		if (showFlag) {
			//放大效果
			this.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	//鼠标离开门区域
	void OnMouseExit ()
	{
		//缩小效果
		this.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
	}
		
}
