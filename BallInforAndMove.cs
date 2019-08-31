using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInforAndMove : MonoBehaviour
{

  //이건 공이 만들어질시 자동으로 공(게임내 생성된 오브젝트)에 붙은체 시작.(BallControl에서 조작했음)
  
    public GameObject BallObjectSelf;//공
    public Vector3 BallMoveMent;//공이동
    public Rigidbody RigidBody_Ball;
    public float Elasticity=0.9f;//벽충돌시 탄성력? 속도 몇배로 되는지.

    //공 초기세팅. z축회전막아서 평면회전시킴.
    private void Start()
    {
        BallObjectSelf = GameObject.Find("HockeyBall");
        RigidBody_Ball = BallObjectSelf.AddComponent<Rigidbody>();
        RigidBody_Ball.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
    //매번 볼동작시킴.
    void Update()
    {
        RigidBody_Ball.AddForce(BallMoveMent);

    }
    //이 cs파일 붙은 오브젝트 충돌시 판정하는거.
    void OnCollisionEnter(Collision coll)
    {
        GameObject colldedOBJ = coll.gameObject;
        Vector3 vec3 = BallMoveMent;
        
        //부딫친 물체 종류에 따라 공방향&속도 바꿔줌. 
        if (colldedOBJ.name == "Wall_Left" || colldedOBJ.name == "Wall_Right")
        {
            BallMoveMent *= Elasticity;
            BallMoveMent.x *= -1;
        }
        else if (colldedOBJ.name == "Wall_Front" || colldedOBJ.name == "Wall_Back")
        {
            BallMoveMent *= Elasticity;
            BallMoveMent.y *= -1;
        }
        else if(colldedOBJ.name=="Stick")
        {
            HockeyStickInf hockeyStickInfor = colldedOBJ.GetComponent<HockeyStickInf>();
            BallMoveMent = new Vector3(0,0,0);
            BallMoveMent = hockeyStickInfor.StickSpeed * hockeyStickInfor.NormalizedStickMoveMent;
        }
    }







}
