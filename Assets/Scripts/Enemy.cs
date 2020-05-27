using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State  {
        LOOKFOR,
        GOTO,
        ATTACK,
    }
    public State CurState;
    public float Speed = .5f;
    public float GoToDistance = 13;
    public float AttackDistance = 4;
    public Transform Target;
    public string PlayerTag = "Player";

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true){
            switch(CurState){
                case State.LOOKFOR:
                    LookFor();
                    break;
                case State.GOTO: 
                    GoTo();
                     break;
                case State.ATTACK:
                    Attack();
                     break;

            }
            yield return 0;
        }
        
    }

    // Update is called once per frame
    void LookFor()
    {
       print("hi we are in Lookfor"); 
    }
    void GoTo(){
        print("hi we are in GoTo");

    }
    void Attack(){
        print ("hi we are in Attack");
    }

}
