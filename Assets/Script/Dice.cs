using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Dice : MonoBehaviour {

    public GameObject GlobalVariable;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject[] Plat;
    public int Player1Pos, Player2Pos, CounterPos, TargetPos;
    public int Kartu = 0;
    public bool Player1Move, Player2Move;
    [SerializeField] private Text CostumText;
    [SerializeField] private Image CostumImage;
    [SerializeField] private Text TextKartu1;
    [SerializeField] private Text TextKartu2;
    [SerializeField] private Image ImageKartu;
    [SerializeField] private Text Text1;
    [SerializeField] private Text Text2;
    [SerializeField] private Text Text3;
    Collider d_collider;
    public GameObject Pilihan1;
    public GameObject Pilihan2;
    public GameObject Pilihan3;
    public GameObject Pilihan4;
    public GameObject Pilihan5;
    public GameObject Pilihan6;
    public GameObject GameOver;

    // Array of dice sides sprites to load from Resources folder
    public Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    public SpriteRenderer rend;

    public int finalSide = 0;

    // Use this for initialization
    public void Start () {
        d_collider = GetComponent<Collider>();
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        Pilihan1.SetActive(true);
        GlobalVariable.GetComponent<GlobalVariable>().Turn = -1;

        Player1Move = false;
        Player2Move = false;

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();
        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}

    private void Update()
    {
        if(GlobalVariable.GetComponent<GlobalVariable>().Turn == 1)
        {
            GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
            Pilihan2.SetActive(true);
        }
        //Percabangan ke-2
        //Player1
        if (GlobalVariable.GetComponent<GlobalVariable>().Turn == 3)
        {
            GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
            Pilihan3.SetActive(true);
        }
        //Player2
        if (GlobalVariable.GetComponent<GlobalVariable>().Turn == 5)
        {
            GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
            Pilihan4.SetActive(true);
        }

        //Percabangan ke-3
        //Player1
        if (GlobalVariable.GetComponent<GlobalVariable>().Turn == 7)
        {
            GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
            Pilihan5.SetActive(true);
        }
        //Player2
        if (GlobalVariable.GetComponent<GlobalVariable>().Turn == 9)
        {
            GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
            Pilihan6.SetActive(true);
        }
        if (GlobalVariable.GetComponent<GlobalVariable>().GameIsPaused == 1)
        {
            d_collider.enabled = false;
        }
        else
        {
            d_collider.enabled = true;
        }

        if (Player1Move && GlobalVariable.GetComponent<GlobalVariable>().tunggu == 0)
        {
            Player1.transform.position = Vector3.MoveTowards(Player1.transform.position, Plat[Player1Pos].transform.position, 0.2f);
            if (Vector3.Distance(Player1.transform.position, Plat[Player1Pos].transform.position) < 0.1f)
            {
                if (Player1Pos == 41)
                {
                    StartCoroutine("Milih1");
                }
                if (Player1Pos == 68)
                {
                    StartCoroutine("Milih3");
                }
                //Gajian
                if (Player1Pos == 7 || Player1Pos == 15 || Player1Pos == 37 || Player1Pos == 54 || Player1Pos == 62 || Player1Pos == 89 || Player1Pos == 44)
                {
                    GlobalVariable.GetComponent<GlobalVariable>().tunggu = 1;
                    StartCoroutine("Player1Gajian");
                    
                }
                //Nikah
                if (Player1Pos == 29)
                {
                    GlobalVariable.GetComponent<GlobalVariable>().tunggu = 1;
                    StartCoroutine("Player1Nikah");
                }
                //Kondisi menang
                if (Player1Pos == 112)//112
                {
                    Player1Move = false;
                    int TotalScore1 = GlobalVariable.GetComponent<GlobalVariable>().Player1Money + (GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu * 5) +(GlobalVariable.GetComponent<GlobalVariable>().Player1Anak * 10);
                    int TotalScore2 = GlobalVariable.GetComponent<GlobalVariable>().Player2Money + (GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu * 5) + (GlobalVariable.GetComponent<GlobalVariable>().Player2Anak * 10);
                    Text1.text = " Player 1\n Money = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Money + "000 / 1000\n Total Cards = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu + " * 5\n Total Childs = "+ GlobalVariable.GetComponent<GlobalVariable>().Player1Anak+"\n Total Score = "+TotalScore1;
                    Text2.text = " Player 2\n Money = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Money + "000 / 1000\n Total Cards = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu + " * 5\n Total Childs = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Anak + "\n Total Score = " + TotalScore2;
                    if (TotalScore1 > TotalScore2)
                    {
                        Text3.text = "Player 1 Win!!";
                    }
                    else if (TotalScore1 < TotalScore2)
                    {
                        Text3.text = "Player 2 Win!!";
                    }
                    else
                    {
                        Text3.text = "Draw!!";
                    }
                    GameOver.SetActive(true);
                    Time.timeScale = 0f;
                    GlobalVariable.GetComponent<GlobalVariable>().GameIsPaused = 1;
                }
                if (Player1Pos == 125)//Lulus Kuliah
                {
                    StartCoroutine("LulusKuliah1");
                    Player1Move = false;
                }
                if (Player1Pos == 136)//Lulus Kuliah
                {
                    StartCoroutine("LulusKuliah1");
                    Player1Move = false;
                }
                if (Player1Pos == 127)//Akhir percabangan 1
                {
                    Player1Pos = 8;
                }
                if (Player1Pos == 141)//Akhir percabangan 2
                {
                    Player1Pos = 50;
                }
                if (Player1Pos == 150)//Akhir percabangan 3
                {
                    Player1Pos = 78;
                }
                if (CounterPos < TargetPos)
                {
                    CounterPos++;
                    Player1Pos++;
                }
                else
                {
                    GlobalVariable.GetComponent<GlobalVariable>().Giliran = 1;
                    Player1Move = false;
                    if (Player1Pos == 125)//Akhir percabangan 1
                    {
                        StartCoroutine("LulusKuliah1");
                        Player1Move = false;
                    }
                    if (Player1Pos == 136)//Lulus Kuliah
                    {
                        StartCoroutine("LulusKuliah1");
                        Player1Move = false;
                    }
                    if (Player1Pos == 127)//Akhir percabangan 1
                    {
                        Player1Pos = 8;
                    }
                    if (Player1Pos == 141)//Akhir percabangan 2
                    {
                        Player1Pos = 50;
                    }
                    if (Player1Pos == 150)//Akhir percabangan 3
                    {
                        Player1Pos = 78;
                    }
                    //Dapet Anak
                    if (Player1Pos == 71 || Player1Pos == 73 || Player1Pos == 74 || Player1Pos == 80 || Player1Pos == 85)
                    {
                        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 1;
                        StartCoroutine("Player1DapetAnak");
                    }
                    //Dapet kartu
                    if (Player1Pos != 7 || Player1Pos != 15 || Player1Pos != 37 || Player1Pos != 54 || Player1Pos != 62 || Player1Pos != 89 || Player1Pos != 44)
                    {
                        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 1;
                        StartCoroutine("DapetKartu1");
                    }
                    if (GlobalVariable.GetComponent<GlobalVariable>().Turn == 0)
                    {
                        GlobalVariable.GetComponent<GlobalVariable>().Turn = 1;
                    }
                    //Kondisi menang
                    if (Player1Pos == 112)//112
                    {
                        Player1Move = false;
                        int TotalScore1 = GlobalVariable.GetComponent<GlobalVariable>().Player1Money + (GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu * 5) + (GlobalVariable.GetComponent<GlobalVariable>().Player1Anak * 10);
                        int TotalScore2 = GlobalVariable.GetComponent<GlobalVariable>().Player2Money + (GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu * 5) + (GlobalVariable.GetComponent<GlobalVariable>().Player2Anak * 10);
                        Text1.text = " Player 1\n Money = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Money + "000 / 1000\n Total Cards = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu + " * 5\n Total Childs = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Anak + "\n Total Score = " + TotalScore1;
                        Text2.text = " Player 2\n Money = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Money + "000 / 1000\n Total Cards = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu + " * 5\n Total Childs = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Anak + "\n Total Score = " + TotalScore2;
                        if (TotalScore1 > TotalScore2)
                        {
                            Text3.text = "Player 1 Win!!";
                        }
                        else if (TotalScore1 < TotalScore2)
                        {
                            Text3.text = "Player 2 Win!!";
                        }
                        else
                        {
                            Text3.text = "Draw!!";
                        }
                        GameOver.SetActive(true);
                        Time.timeScale = 0f;
                        GlobalVariable.GetComponent<GlobalVariable>().GameIsPaused = 1;
                    }
                }
            }
        }
        else
        if (Player2Move && GlobalVariable.GetComponent<GlobalVariable>().tunggu == 0)
        {
            Player2.transform.position = Vector3.MoveTowards(Player2.transform.position, Plat[Player2Pos].transform.position, 0.2f);
            if (Vector3.Distance(Player2.transform.position, Plat[Player2Pos].transform.position) < 0.1f)
            {
                if (Player2Pos == 41)
                {
                    StartCoroutine("Milih2");
                }
                if (Player2Pos == 68)
                {
                    StartCoroutine("Milih4");
                }
                //Gajian
                if (Player2Pos == 7 || Player2Pos == 15 || Player2Pos == 37 || Player2Pos == 54 || Player2Pos == 62 || Player2Pos == 89 || Player2Pos == 44)
                {
                    GlobalVariable.GetComponent<GlobalVariable>().tunggu = 1;
                    StartCoroutine("Player2Gajian");
                }
                //Nikah
                if (Player2Pos == 29)
                {
                    GlobalVariable.GetComponent<GlobalVariable>().tunggu = 1;
                    StartCoroutine("Player2Nikah");
                }
                //Kondisi menang
                if (Player2Pos == 112)//112
                {
                    Player2Move = false;
                    int TotalScore1 = GlobalVariable.GetComponent<GlobalVariable>().Player1Money + (GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu * 5) + (GlobalVariable.GetComponent<GlobalVariable>().Player1Anak * 10);
                    int TotalScore2 = GlobalVariable.GetComponent<GlobalVariable>().Player2Money + (GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu * 5) + (GlobalVariable.GetComponent<GlobalVariable>().Player2Anak * 10);
                    Text1.text = " Player 1\n Money = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Money + "000 / 1000\n Total Cards = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu + " * 5\n Total Childs = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Anak + "\n Total Score = " + TotalScore1;
                    Text2.text = " Player 2\n Money = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Money + "000 / 1000\n Total Cards = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu + " * 5\n Total Childs = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Anak + "\n Total Score = " + TotalScore2;
                    if (TotalScore1 > TotalScore2)
                    {
                        Text3.text = "Player 1 Win!!";
                    }
                    else if (TotalScore1 < TotalScore2)
                    {
                        Text3.text = "Player 2 Win!!";
                    }
                    else
                    {
                        Text3.text = "Draw!!";
                    }
                    GameOver.SetActive(true);
                    Time.timeScale = 0f;
                    GlobalVariable.GetComponent<GlobalVariable>().GameIsPaused = 1;
                }
                if (Player2Pos == 125)//Akhir percabangan 1
                {
                    StartCoroutine("LulusKuliah2");
                    Player2Move = false;
                }
                if (Player2Pos == 136)//Lulus Kuliah
                {
                    StartCoroutine("LulusKuliah2");
                    Player2Move = false;
                }
                if (Player2Pos == 127)//Akhir percabangan 1
                {
                    Player2Pos = 8;
                }
                if (Player2Pos == 141)//Akhir percabangan 2
                {
                    Player2Pos = 50;
                }
                if (Player2Pos == 150)//Akhir percabangan 3
                {
                    Player2Pos = 78;
                }
                if (CounterPos < TargetPos)
                {
                    CounterPos++;
                    Player2Pos++;
                }
                else
                {
                    GlobalVariable.GetComponent<GlobalVariable>().Giliran = 0;
                    Player2Move = false;
                    if (Player2Pos == 125)//Akhir percabangan 1
                    {
                        StartCoroutine("LulusKuliah2");
                        Player2Move = false;
                    }
                    if (Player2Pos == 136)//Lulus Kuliah
                    {
                        StartCoroutine("LulusKuliah2");
                        Player2Move = false;
                    }
                    if (Player2Pos == 127)//Akhir percabangan 1
                    {
                        Player2Pos = 8;
                    }
                    if (Player2Pos == 141)//Akhir percabangan 2
                    {
                        Player2Pos = 50;
                    }
                    if (Player2Pos == 150)//Akhir percabangan 3
                    {
                        Player2Pos = 78;
                    }
                    //Dapet kartu
                    if (Player2Pos != 7 || Player2Pos != 15 || Player2Pos != 37 || Player2Pos != 54 || Player2Pos != 62 || Player2Pos != 89 || Player2Pos != 44)
                    {
                        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 1;
                        StartCoroutine("DapetKartu2");
                    }
                    else
                    {

                    }
                    //Dapet Anak
                    if (Player2Pos == 71 || Player2Pos == 73 || Player2Pos == 74 || Player2Pos == 80 || Player2Pos == 85)
                    {
                        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 1;
                        StartCoroutine("Player2DapetAnak");
                    }
                    if (GlobalVariable.GetComponent<GlobalVariable>().Turn == 0)
                    {
                        GlobalVariable.GetComponent<GlobalVariable>().Turn = 1;
                    }
                    //Kondisi menang
                    if (Player2Pos == 112)//112
                    {
                        Player2Move = false;
                        int TotalScore1 = GlobalVariable.GetComponent<GlobalVariable>().Player1Money + (GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu * 5) + (GlobalVariable.GetComponent<GlobalVariable>().Player1Anak * 10);
                        int TotalScore2 = GlobalVariable.GetComponent<GlobalVariable>().Player2Money + (GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu * 5) + (GlobalVariable.GetComponent<GlobalVariable>().Player2Anak * 10);
                        Text1.text = " Player 1\n Money = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Money + "000 / 1000\n Total Cards = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu + " * 5\n Total Childs = " + GlobalVariable.GetComponent<GlobalVariable>().Player1Anak + "\n Total Score = " + TotalScore1;
                        Text2.text = " Player 2\n Money = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Money + "000 / 1000\n Total Cards = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu + " * 5\n Total Childs = " + GlobalVariable.GetComponent<GlobalVariable>().Player2Anak + "\n Total Score = " + TotalScore2;
                        if (TotalScore1 > TotalScore2)
                        {
                            Text3.text = "Player 1 Win!!";
                        }
                        else if (TotalScore1 < TotalScore2)
                        {
                            Text3.text = "Player 2 Win!!";
                        }
                        else
                        {
                            Text3.text = "Draw!!";
                        }
                        GameOver.SetActive(true);
                        Time.timeScale = 0f;
                        GlobalVariable.GetComponent<GlobalVariable>().GameIsPaused = 1;
                    }
                }
            }
        }
    }

    IEnumerator Milih1()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 3;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        Player1Move = false;
        yield return new WaitForSeconds(0);
    }
    IEnumerator Milih2()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 5;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        Player2Move = false;
        yield return new WaitForSeconds(0);
    }
    IEnumerator Milih3()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 7;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        Player1Move = false;
        yield return new WaitForSeconds(0);
    }
    IEnumerator Milih4()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Turn = 9;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        Player2Move = false;
        yield return new WaitForSeconds(0);
    }

    IEnumerator timer(int waktu)
    {

        yield return new WaitForSeconds(waktu);
    }

    IEnumerator DapetKartu1()
    {
        Kartu = Random.Range(0, 10)+1;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        if (Kartu == 1)
        {
            TextKartu1.text = "Bank memutuskan untuk menghadiahi nasabah dengan sejumlah uang";
            TextKartu2.text = "Mendapatkan uang 5k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money += 5;
        }
        else if (Kartu == 2)
        {
            TextKartu1.text = "Kamu sekeluarga pergi ke Djakarta Warehouse Party";
            TextKartu2.text = "Membayar uang 10k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 10;
        }
        else if (Kartu == 3)
        {
            TextKartu1.text = "Karena layanganmu adalah layangan terbaik di festival layangan, dan sultan ingin membeli layanganmu";
            TextKartu2.text = "Mendapatkan uang 25k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money += 25;
        }
        else if (Kartu == 4)
        {
            TextKartu1.text = "Orangtuamu sakit dan membutuhkan biaya untuk berobat";
            TextKartu2.text = "Membayar uang 25k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 25;
        }
        else if (Kartu == 5)
        {
            TextKartu1.text = "Kamu bertemu dengan dimas kanjeng";
            TextKartu2.text = "Mendapatkan uang 10k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money += 10;
        }
        else if (Kartu == 6)
        {
            TextKartu1.text = "Kamu terlambat membayar pajak maka dari itu kamu harus membayar denda";
            TextKartu2.text = "Membayar uang 15k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 15;
        }
        else if (Kartu == 7)
        {
            TextKartu1.text = "Kamu lembur dan bos melihat kerja kerasmu dan dia berinisiatif untuk memberimu bonus";
            TextKartu2.text = "Mendapatkan uang 20k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money += 20;
        }
        else if (Kartu == 8)
        {
            TextKartu1.text = "Kamu sekeluarga ingin pergi berlibur ke luar negeri";
            TextKartu2.text = "Membayar uang 25k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 25;
        }
        else if (Kartu == 9)
        {
            TextKartu1.text = "1..2..3.. tiket lotre yang kamu beli berhasil keluar dalam undian";
            TextKartu2.text = "Mendapatkan uang 30k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money += 30;
        }
        else if (Kartu == 10)
        {
            TextKartu1.text = "Film yang lagi hits muncul di bioskop dan kamu pergi untuk menontonnya";
            TextKartu2.text = "Membayar uang 5k";
            GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 5;
        }

        TextKartu1.enabled = true;
        TextKartu2.enabled = true;
        ImageKartu.enabled = true;
        yield return new WaitForSeconds(5);
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        TextKartu1.enabled = false;
        TextKartu2.enabled = false;
        ImageKartu.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Player1Kartu += 1;
        if (GlobalVariable.GetComponent<GlobalVariable>().Turn == -1)
        {
            GlobalVariable.GetComponent<GlobalVariable>().Turn = 1;
        }
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }

    IEnumerator DapetKartu2()
    {
        Kartu = Random.Range(0, 6)+1;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        if (Kartu == 1)
        {
            TextKartu1.text = "Bank memutuskan untuk menghadiahi nasabah dengan sejumlah uang";
            TextKartu2.text = "Mendapatkan uang 5k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money += 5;
        }
        else if (Kartu == 2)
        {
            TextKartu1.text = "Kamu sekeluarga pergi ke Djakarta Warehouse Party";
            TextKartu2.text = "Membayar uang 10k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money -= 10;
        }
        else if (Kartu == 3)
        {
            TextKartu1.text = "Karena layanganmu adalah layangan terbaik di festival layangan, dan sultan ingin membeli layanganmu";
            TextKartu2.text = "Mendapatkan uang 25k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money += 25;
        }
        else if (Kartu == 4)
        {
            TextKartu1.text = "Orangtuamu sakit dan membutuhkan biaya untuk berobat";
            TextKartu2.text = "Membayar uang 25k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money -= 25;
        }
        else if (Kartu == 5)
        {
            TextKartu1.text = "Kamu bertemu dengan dimas kanjeng";
            TextKartu2.text = "Mendapatkan uang 10k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money += 10;
        }
        else if (Kartu == 6)
        {
            TextKartu1.text = "Kamu terlambat membayar pajak maka dari itu kamu harus membayar denda";
            TextKartu2.text = "Membayar uang 15k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money -= 15;
        }
        else if (Kartu == 7)
        {
            TextKartu1.text = "Kamu lembur dan bos melihat kerja kerasmu dan dia berinisiatif untuk memberimu bonus";
            TextKartu2.text = "Mendapatkan uang 20k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money += 20;
        }
        else if (Kartu == 8)
        {
            TextKartu1.text = "Kamu sekeluarga ingin pergi berlibur ke luar negeri";
            TextKartu2.text = "Membayar uang 25k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money -= 25;
        }
        else if (Kartu == 9)
        {
            TextKartu1.text = "1..2..3.. tiket lotre yang kamu beli berhasil keluar dalam undian";
            TextKartu2.text = "Mendapatkan uang 30k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money += 30;
        }
        else if (Kartu == 10)
        {
            TextKartu1.text = "Film yang lagi hits muncul di bioskop dan kamu pergi untuk menontonnya";
            TextKartu2.text = "Membayar uang 5k";
            GlobalVariable.GetComponent<GlobalVariable>().Player2Money -= 5;
        }

        TextKartu1.enabled = true;
        TextKartu2.enabled = true;
        ImageKartu.enabled = true;
        yield return new WaitForSeconds(5);
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        TextKartu1.enabled = false;
        TextKartu2.enabled = false;
        ImageKartu.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Player2Kartu += 1;

        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }

    IEnumerator LulusKuliah1()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        TextKartu1.text = "Selamat Anda sudah lulus kuliah";
        TextKartu2.text = "Langsung mendapatkan pekerjaan dengan gaji lebih tinggi";
        TextKartu1.enabled = true;
        TextKartu2.enabled = true;
        ImageKartu.enabled = true;
        yield return new WaitForSeconds(5);
        GlobalVariable.GetComponent<GlobalVariable>().Player1Gaji += 20;
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        TextKartu1.enabled = false;
        TextKartu2.enabled = false;
        ImageKartu.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Giliran = 1;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }
    IEnumerator LulusKuliah2()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        TextKartu1.text = "Selamat Anda sudah lulus kuliah";
        TextKartu2.text = "Langsung mendapatkan pekerjaan dengan gaji lebih tinggi";
        TextKartu1.enabled = true;
        TextKartu2.enabled = true;
        ImageKartu.enabled = true;
        yield return new WaitForSeconds(5);
        GlobalVariable.GetComponent<GlobalVariable>().Player2Gaji += 20;
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        TextKartu1.enabled = false;
        TextKartu2.enabled = false;
        ImageKartu.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Giliran = 0;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }

    IEnumerator Player1Gajian()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        CostumText.text = "Player 1 mendapatkan gaji sebesar "+ GlobalVariable.GetComponent<GlobalVariable>().Player1Gaji+" K";
        CostumText.enabled = true;
        CostumImage.enabled = true;
        yield return new WaitForSeconds(2);
        GlobalVariable.GetComponent<GlobalVariable>().Player1Money += GlobalVariable.GetComponent<GlobalVariable>().Player1Gaji;
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        CostumText.enabled = false;
        CostumImage.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }

    IEnumerator Player2Gajian()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        CostumText.text = "Player 2 mendapatkan gaji sebesar "+ GlobalVariable.GetComponent<GlobalVariable>().Player2Gaji + " K";
        CostumText.enabled = true;
        CostumImage.enabled = true;
        yield return new WaitForSeconds(2);
        GlobalVariable.GetComponent<GlobalVariable>().Player2Money += GlobalVariable.GetComponent<GlobalVariable>().Player2Gaji;
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        CostumText.enabled = false;
        CostumImage.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }

    IEnumerator Player1Nikah()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        CostumText.text = "Selamat Anda sudah menikah\nMendapat uang hadiah sebesar 25k dari player lain";
        CostumText.enabled = true;
        CostumImage.enabled = true;
        yield return new WaitForSeconds(8);
        GlobalVariable.GetComponent<GlobalVariable>().Player1Money += 25;
        GlobalVariable.GetComponent<GlobalVariable>().Player2Money -= 25;
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        CostumText.enabled = false;
        CostumImage.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }
    IEnumerator Player2Nikah()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        CostumText.text = "Selamat Anda sudah menikah\nMendapat uang hadiah sebesar 25k dari player lain";
        CostumText.enabled = true;
        CostumImage.enabled = true;
        yield return new WaitForSeconds(8);
        GlobalVariable.GetComponent<GlobalVariable>().Player2Money += 25;
        GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 25;
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        CostumText.enabled = false;
        CostumImage.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }

    IEnumerator Player1DapetAnak()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        CostumText.text = "Selamat Anda mendapatkan seorang anak\nMendapat uang hadiah sebesar 50k dari player lain";
        CostumText.enabled = true;
        CostumImage.enabled = true;
        yield return new WaitForSeconds(8);
        GlobalVariable.GetComponent<GlobalVariable>().Player1Anak += 1;
        GlobalVariable.GetComponent<GlobalVariable>().Player1Money += 50;
        GlobalVariable.GetComponent<GlobalVariable>().Player2Money -= 50;
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        CostumText.enabled = false;
        CostumImage.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }
    IEnumerator Player2DapetAnak()
    {
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
        CostumText.text = "Selamat Anda mendapatkan seorang anak\nMendapat uang hadiah sebesar 50k dari player lain";
        CostumText.enabled = true;
        CostumImage.enabled = true;
        yield return new WaitForSeconds(8);
        GlobalVariable.GetComponent<GlobalVariable>().Player2Anak += 1;
        GlobalVariable.GetComponent<GlobalVariable>().Player2Money += 50;
        GlobalVariable.GetComponent<GlobalVariable>().Player1Money -= 50;
        GlobalVariable.GetComponent<GlobalVariable>().tunggu = 0;
        CostumText.enabled = false;
        CostumImage.enabled = false;
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
    }

    public void ExecPlayer1Move()
    {
        Player1Move = true;
        TargetPos = finalSide;
        if ((TargetPos + Player1Pos) < Plat.Length)
        {
            Player1Pos++;
            CounterPos = 1;
        }
    }
    public void ExecPlayer2Move()
    {
        Player2Move = true;
        TargetPos = finalSide;
        if ((TargetPos + Player2Pos) < Plat.Length)
        {
            Player2Pos++;
            CounterPos = 1;
        }
    }


    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        if(GlobalVariable.GetComponent<GlobalVariable>().Jalan == 0)
        {
            StartCoroutine("RollTheDice");
        }
        GlobalVariable.GetComponent<GlobalVariable>().Jalan = 1;
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 6);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;
        yield return new WaitForSeconds(1f);

        if (GlobalVariable.GetComponent<GlobalVariable>().Giliran == 0)
        {
            ExecPlayer1Move();
            GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
            
        }
        else if (GlobalVariable.GetComponent<GlobalVariable>().Giliran == 1)
        {
            ExecPlayer2Move();
            GlobalVariable.GetComponent<GlobalVariable>().Jalan = 0;
            
        }

        // Show final dice value in Console
        Debug.Log(finalSide);
    }
}
