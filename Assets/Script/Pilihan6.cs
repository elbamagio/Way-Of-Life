using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilihan6 : MonoBehaviour {

    public GameObject PilihKartu;
    public GameObject GlobalVariable;
    public GameObject Dice;

    // Update is called once per frame
    void Update()
    {

    }

    public void PilihKartuKeluarga()
    {
        Dice.GetComponent<Dice>().Player2Pos = 68;
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 10;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
        PilihKartu.SetActive(false);
    }

    public void PilihKartuKerja()
    {
        Dice.GetComponent<Dice>().Player2Pos = 142;
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 10;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
        PilihKartu.SetActive(false);
    }
}
