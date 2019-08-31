using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    //게임이나 컨트롤러 관련 아무 오브젝트 1개에게 달아주면 됨.
    //정확히 이거 기능은 게임에서 다루면 되는건데 그냥 나눠서 작업하니 분리.
    //역할은 (일단)볼만들고 배치관리.

    public GameObject BallObject;


    void Start()
    {
        SpawnNewBall(new Vector3(0, 1F, 0), new Vector3(10,0,0));
    }

    // Update is called once per frame
   


    //볼생성함수
    public void SpawnNewBall(Vector3 spawnPosition, Vector3 ballDirection)
    {
        BallObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        BallObject.name = "HockeyBall";
        BallObject.transform.position = spawnPosition;
        BallObject.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
        BallObject.AddComponent<BallInforAndMove>();
        BallObject.GetComponent<BallInforAndMove>().BallMoveMent = ballDirection;
    }





    public void DestroyBall()
    {
        Destroy(BallObject);
    }


}
