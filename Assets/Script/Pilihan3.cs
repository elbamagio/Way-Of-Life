using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilihan3 : MonoBehaviour {

    public GameObject PilihKartu;
    public GameObject GlobalVariable;
    public GameObject Dice;

    // Update is called once per frame
    void Update()
    {

    }

    public void PilihKartuKerja()
    {
        Dice.GetComponent<Dice>().Player1Pos = 41;
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 4;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
        PilihKartu.SetActive(false);
    }

    public void PilihKartuKuliah()
    {
        Dice.GetComponent<Dice>().Player1Pos = 128;
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 4;
        GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 100;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
        PilihKartu.SetActive(false);
    }
}
