using UnityEngine;  
using System.Collections;  
public class Player : MonoBehaviour
{
    public GameObject GlobalVariable;
    public GameObject Player1;  
    public GameObject Player2;  
    public GameObject Dice;  
    public GameObject[] Plat;  
    int Player1Pos, Player2Pos, CounterPos, TargetPos, Turn;  
    bool Player1Move, Player2Move;  
    // Use this for initialization  
    void Start()
    {
        Player1Pos = 0;
        Player2Pos = 0;
        Player1Move = false;
        Player2Move = false;
    }  
    // Update is called once per frame  
    void Update()
    {
        if (Player1Move)
        {
            Player1.transform.position = Vector3.MoveTowards(Player1.transform.position, Plat[Player1Pos].transform.position, 0.1f);
            if (Vector3.Distance(Player1.transform.position, Plat[Player1Pos].transform.position) < 0.1f)
            {
                if (CounterPos < TargetPos)
                {
                    CounterPos++;
                    Player1Pos++;
                }
                else
                {
                    Player1Move = false;
                    if (Player1Pos == Plat.Length - 1)
                    {
                        Debug.Log("Player 1 Wins!");
                    }
                }
            }
        }
        else
        if (Player2Move)
        {
            Player2.transform.position = Vector3.MoveTowards(Player2.transform.position, Plat[Player2Pos].transform.position, 0.1f);
            if (Vector3.Distance(Player2.transform.position, Plat[Player2Pos].transform.position) < 0.1f)
            {
                if (CounterPos < TargetPos)
                {
                    CounterPos++;
                    Player2Pos++;
                }
                else
                {
                    Player2Move = false;
                    if (Player2Pos == Plat.Length - 1)
                    {
                        Debug.Log("Player 2 Wins!");
                    }
                }
            }
        }
    }  
    public void ExecPlayer1Move()
    {
        Player1Move = true;
        TargetPos = Dice.GetComponent<Dice>().finalSide;
        if ((TargetPos + Player1Pos) < Plat.Length)
        {
            Player1Pos++;
            CounterPos = 1;
        }
    }  
    public void ExecPlayer2Move()
    {
        Player2Move = true;
        TargetPos = Dice.GetComponent<Dice>().finalSide;
        if ((TargetPos + Player2Pos) < Plat.Length)
        {
            Player2Pos++;
            CounterPos = 1;
        }
    }  
}