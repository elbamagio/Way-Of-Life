using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilihan2 : MonoBehaviour {

    public GameObject PilihKartu;
    public GameObject GlobalVariable;
    public GameObject Dice;

    // Update is called once per frame
    void Update()
    {

    }

    public void PilihKartuKerja()
    {
        Dice.GetComponent<Dice>().Player2Pos = 0;
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 2;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan  = 0;
        PilihKartu.SetActive(false);
    }

    public void PilihKartuKuliah()
    {
        Dice.GetComponent<Dice>().Player2Pos = 113;
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 2;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
        GlobalVariable.GetComponent<GlobalVariable>().Player2Money -= 100;
        GlobalVariable.GetComponent<GlobalVariable>().Player2Gaji = 40;
        PilihKartu.SetActive(false);
    }
}
