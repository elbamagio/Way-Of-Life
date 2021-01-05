using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilihan1 : MonoBehaviour {

    public GameObject PilihKartu;
    public GameObject GlobalVariable;
    public GameObject Dice;
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PilihKartuKerja()
    {
        Dice.SetActive(true);
        Dice.GetComponent<Dice>().Player1Pos = 0;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
        PilihKartu.SetActive(false); 
    }

    public void PilihKartuKuliah()
    {
        Dice.SetActive(true);
        Dice.GetComponent<Dice>().Player1Pos = 113;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
        GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 100;
        GlobalVariable.GetComponent<GlobalVariable>().Player1Gaji = 40;
        PilihKartu.SetActive(false);
    }
}
