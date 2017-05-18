using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class initMap : MonoBehaviour
{

	[Tooltip ("请指定Prefab基本房间")]public GameObject unitMap;
	[Range(-1,0,1)]public int roomLevel=0;
	[Range (1, 15)]public int roomAmount = 5;
	[Tooltip ("水平调整偏移")][Range (0f, 30f)]public float horizonDis = 7.5f;
	[Tooltip ("竖直调整偏移")][Range (0f, 30f)]public float vertiDis = 7.5f;

	//房间生成的起点坐标
	private Transform mapSpawnPoint;
	//地图生成器，产生房间坐标
	private MapContraller mapManager;
	//房间生成器，生成门生成相邻房间
	private RoomContraller roomManager;

	// Use this for initialization
	void Start ()
	{
		mapManager = new MapContraller ();
		roomManager = GetComponent<RoomContraller> ();

		//在场景中搜索房间起点
		mapSpawnPoint = GameObject.Find ("MapSpawnPoint").GetComponent<Transform> ();
		//生成好的地图数据<房间坐标xy,门的信息>
		Dictionary<int[], int[]> map = mapManager.genMap (roomLevel,roomAmount);

		foreach (int[] key in map.Keys) {
			//预备给新房间的坐标
			Vector3 newMap = mapSpawnPoint.position;
			//根据房间的宽度，水平偏移
			if (key [0] != 0) {
				newMap.x = key [0] * horizonDis;      
			}
			//根据房间的高度，竖直偏移
			if (key [1] != 0) {
				newMap.y = key [1] * vertiDis;
			}
			//z值为0
			newMap.z = key[2];

			int[] rXYZ = {key[0],key[1],key[2]};
			//房间生成器返回新生成的房间
			unitMap = roomManager.genRoom (rXYZ,map [key]);
			//设置新房间的坐标
			unitMap.transform.position = newMap;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
