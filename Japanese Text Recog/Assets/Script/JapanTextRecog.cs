using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class JapanTextRecog : MonoBehaviour
{
    
    public Texture2D texture;
    public RawImage image;
    bool grab;
    public string[] OutputText;
    public Text text;    
    public string getresult;
    public GameObject captureimage;
    public GameObject captureBTN;
    public GameObject TranslateBtn;
    public GameObject RecaptureBTN;
    public GameObject Panel;
    public GameObject Frame;


    void CopyFile(string folder, string file)
    {
        string fileUrl = System.IO.Path.Combine(Application.streamingAssetsPath, folder + file);
        string fileDirectory = System.IO.Path.Combine(Application.persistentDataPath, folder);
        string filePath = System.IO.Path.Combine(fileDirectory, file);
        Debug.Log("Copying: " + fileUrl);
        if (!Directory.Exists(fileDirectory))
        {
            Directory.CreateDirectory(fileDirectory);
        }
        WWW www = new WWW(fileUrl);
        while (!www.isDone)
        {
            Debug.Log("Reading");
        }
        File.WriteAllBytes(filePath, www.bytes);
        Debug.Log("file copy done (" + www.bytes.Length.ToString() + "): " + filePath);
        www.Dispose();
        www = null;
    }

    public void Translate()
    {
        text.text = "Please wait..."; 
      //CopyFile("tessdata/", "eng.cube.bigrams");
      //CopyFile("tessdata/", "eng.cube.fold");
      //CopyFile("tessdata/", "eng.cube.lm");
     // CopyFile("tessdata/", "eng.cube.nn");
     // CopyFile("tessdata/", "eng.cube.params");
     // CopyFile("tessdata/", "eng.cube.size");
     // CopyFile("tessdata/", "eng.cube.word-freq");
     // CopyFile("tessdata/", "eng.tesseract_cube.nn");
     // CopyFile("tessdata/", "eng.traineddata");
      CopyFile("tessdata/", "jpn.traineddata");
        CopyFile("tessdata/", "jpn_vert.trainneddata");
     // CopyFile("tessdata/", "eng.user-patterns");
     // CopyFile("tessdata/", "eng.user-words");
        CopyFile("tessdata/", "osd.traineddata");
        CopyFile("tessdata/", "pdf.ttf");
        CopyFile("tessdata/tessconfigs/", "debugConfigs.txt");
        CopyFile("tessdata/tessconfigs/", "recognitionConfigs.txt");
        string datapath = System.IO.Path.Combine(Application.persistentDataPath, "tessdata");
        TesseractWrapper_And tesseract = new TesseractWrapper_And();
       // tesseract.Init("eng", datapath);
        tesseract.Init("jpn", datapath);
        string result = tesseract.RecognizeFromTexture(texture, false);
        getresult = result;
        getresult = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));
        OutputData();
        Record();
    }

    void Record()
    {
     string path = Application.persistentDataPath + "/RecordData.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, getresult + "\n");
            
        }
        else
        {
            File.AppendAllText(path, getresult + "\n");
        }
    }
    public void Capture()
    {

        grab = true;
        


    }
    public void Recapture()
    {
        grab = false;
        Panel.SetActive(false);
        captureimage.SetActive(false);
        Frame.SetActive(false);
        TranslateBtn.SetActive(false);
        RecaptureBTN.SetActive(false);
        captureBTN.SetActive(true);
        text.text = "";
        getresult = "";
    }
    private void OnPostRender()
    {
        if (grab)
        {
            Texture2D textture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            textture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            textture.Apply();
            texture = textture;
            image.texture = textture;          
            grab = false;
            Panel.SetActive(true);
            captureimage.SetActive(true);
            Panel.SetActive(true);
            Frame.SetActive(true);
            TranslateBtn.SetActive(true);
            RecaptureBTN.SetActive(true);
            captureBTN.SetActive(false);
            
        }
    }
    void OutputData()
    {
        
        if (getresult==OutputText[0]|| getresult == "にんげん、")
        {
            text.text = "Human\n" + "Ningen";
        }

        else  if (getresult == OutputText[1])
        {
            text.text = "Humanity\n" + "Jinrui";
        }

        else if (getresult == OutputText[2])
        {
            text.text = "Person\n" + "Hito";
        }

        else if (getresult == OutputText[3])
        {
            text.text = "Male\n" + "Otoko";
        }

        else if (getresult == OutputText[4])
        {
            text.text = "Man\n" + "Otokonohito";
        }

        else if (getresult == OutputText[5])
        {
            text.text = "Boy\n" + "Otokonoko";
        }

        else if (getresult == OutputText[6])
        {
            text.text = "Female\n" + "Onna";
        }

        else if (getresult == OutputText[7])
        {
            text.text = "Woman\n" + "Onnanohito";
        }

        else if (getresult == OutputText[8])
        {
            text.text = "Girl\n" + "Onnanoko";
        }

        else if (getresult == OutputText[9])
        {
            text.text = "Baby\n" + "Akachan";
        }

        else if (getresult == OutputText[10])
        {
            text.text = "Young Person\n" + "Wakamano";
        }

        else if (getresult == OutputText[11])
        {
            text.text = "Girl\n" + "Shoujo";
        }

        else if (getresult == OutputText[12])
        {
            text.text = "Young Boy\n" + "Shounen";
        }

        else if (getresult == OutputText[13])
        {
            text.text = "Doctor\n" + "Isha";
        }

        else if (getresult == OutputText[14])
        {
            text.text = "Nurse\n" + "Kangoshi";
        }

        else if (getresult == OutputText[15])
        {
            text.text = "Female Nurse\n" + "Kangofu";
        }

        else if (getresult == OutputText[16])
        {
            text.text = "Politician\n" + "Seijika";
        }

        else if (getresult == OutputText[17])
        {
            text.text = "Lawyer\n" + "Bengoshi";
        }

        else if (getresult == OutputText[18])
        {
            text.text = "Firefighter\n" + "Shouboushi";
        }

        else if (getresult == OutputText[19])
        {
            text.text = "Police Officer\n" + "Keisatsukan";
        }

        else if (getresult == OutputText[20])
        {
            text.text = "Soldier\n" + "Heishi";
        }

        else if (getresult == OutputText[21])
        {
            text.text = "Architect\n" + "Kenchikuka";
        }

        else if (getresult == OutputText[22])
        {
            text.text = "Teacher\n" + "Sensei";
        }

        else if (getresult == OutputText[23])
        {
            text.text = "Academic Teacher\n" + "Kyoushi";
        }

        else if (getresult == OutputText[24])
        {
            text.text = "Singer\n" + "Kashu";
        }

        else if (getresult == OutputText[25])
        {
            text.text = "Heel\n" + "Kakato";
        }

        else if (getresult == OutputText[26])
        {
            text.text = "Shin\n" + "Sune";
        }

        else if (getresult == OutputText[27])
        {
            text.text = "Knee\n" + "Hiza";
        }

        else if (getresult == OutputText[28])
        {
            text.text = "Thigh\n" + "Momo";
        }

        else if (getresult == OutputText[29])
        {
            text.text = "Head\n" + "Atama";
        }

        else if (getresult == OutputText[30])
        {
            text.text = "Face\n" + "Kao";
        }

        else if (getresult == OutputText[31])
        {
            text.text = "Lips\n" + "Kuchibiru";
        }

        else if (getresult == OutputText[32])
        {
            text.text = "Coffee\n" + "Kōhī";
        }

        else if (getresult == OutputText[33])
        {
            text.text = "Nose\n" + "Hana";
        }

        else if (getresult == OutputText[34])
        {
            text.text = "Hair\n" + "Kami";
        }

        else if (getresult == OutputText[35]||getresult== "〝みみ"||getresult== "みみ{")
        {
            text.text = "Ear\n" + "Mimi";
        }

        else if (getresult == OutputText[36])
        {
            text.text = "Stomach\n" + "Onaka";
        }

        else if (getresult == OutputText[37])
        {
            text.text = "Arm\n" + "Ude";
        }

        else if (getresult == OutputText[38]|| getresult == "ーひじ"||getresult== "ひじ`")
        {
            text.text = "Elbow\n" + "Hiji";
        }

        else if (getresult == OutputText[39]||getresult== "きかた")
        {
            text.text = "Shoulder\n" + "Kata";
        }

        else if (getresult == OutputText[40]||getresult== "〕〝つめ")
        {
            text.text = "Nail\n" + "Tsume";
        }

        else if (getresult == OutputText[41])
        {
            text.text = "Wrist\n" + "Tekubi";
        }

        else if (getresult == OutputText[42])
        {
            text.text = "Finger\n" + "Yubi";
        }

        else if (getresult == OutputText[43])
        {
            text.text = "Buttocks\n" + "Shiri";
        }

        else if (getresult == OutputText[44]||getresult == "醸きも嚢")
        {
            text.text = "Liver\n" + "Kimo";
        }

        else if (getresult == OutputText[45])
        {
            text.text = "Muscle\n" + "Kin'niku";
        }

        else if (getresult == OutputText[46])
        {
            text.text = "Sugar\n" + "Satō";
        }

        else if (getresult == OutputText[47])
        {
            text.text = "Waist\n" + "Koshi";
        }

        else if (getresult == OutputText[48]||getresult== "しんぞう")
        {
            text.text = "Heart\n" + "Shinzō";
        }

        else if (getresult == OutputText[49])
        {
            text.text = "Back\n" + "Senaka";
        }

        else if (getresult == OutputText[50])
        {
            text.text = "Blood\n" + "Chi";
        }

        else if (getresult == OutputText[51]||getresult== "力夕ツムリ")
        {
            text.text = "Snail\n" + "Katatsumuri";
        }

        else if (getresult == OutputText[52]||getresult== "`ひふ")
        {
            text.text = "Skin\n" + "Hifu";
        }

        else if (getresult == OutputText[53])
        {
            text.text = "Bone\n" + "Hone";
        }

        else if (getresult == OutputText[54])
        {
            text.text = "Cockroach\n" + "Gokiburi";
        }

        else if (getresult == OutputText[55])
        {
            text.text = "Diarrhea\n" + "Geri";
        }

        else if (getresult == OutputText[56]||getresult== "びようき")
        {
            text.text = "Illness\n" + "Byōki";
        }

        else if (getresult == OutputText[57]||getresult== "かぞく")
        {
            text.text = "Family\n" + "Kazoku";
        }

        else if (getresult == OutputText[58])
        {
            text.text = "Parents\n" + "Ryoushin";
        }

        else if (getresult == OutputText[59])
        {
            text.text = "Child\n" + "Kodomi";
        }

        else if (getresult == OutputText[60])
        {
            text.text = "Father\n" + "Otou-san";
        }

        else if (getresult == OutputText[61])
        {
            text.text = "Mother\n" + "Okaa-san";
        }

        else if (getresult == OutputText[62])
        {
            text.text = "Wife\n" + "Tsuma";
        }

        else if (getresult == OutputText[63])
        {
            text.text = "FireFly\n" + "Hotaru";
        }

        else if (getresult == OutputText[64])
        {
            text.text = "Slug\n" + "Namekuji";
        }

        else if (getresult == OutputText[65]||getresult== "さんまキ")
        {
            text.text = "Pike\n" + "Sanma";
        }

        else if (getresult == OutputText[66])
        {
            text.text = "Grasshopper\n" + "Batta";
        }

        else if (getresult == OutputText[67]||getresult== "キ卜ンボ")
        {
            text.text = "Tree\n" + "Ki";
        }

        else if (getresult == OutputText[68]||getresult== "きようだい")
        {
            text.text = "Brothers\n" + "Kyōdai";
        }

        else if (getresult == OutputText[69])
        {
            text.text = "Sisters\n" + "Shimai";
        }

        else if (getresult == OutputText[70])
        {
            text.text = "Grandfather\n" + "Ojii-san";
        }

        else if (getresult == OutputText[71])
        {
            text.text = "GrandMother\n" + "Obaa-san";
        }

        else if (getresult == OutputText[72])
        {
            text.text = "Grandchild\n" + "Mago";
        }

        else if (getresult == OutputText[73])
        {
            text.text = "Niece\n" + "Mei";
        }

        else if (getresult == OutputText[74])
        {
            text.text = "Nephew\n" + "Oi";
        }

        else if (getresult == OutputText[75])
        {
            text.text = "Living Creatures\n" + "Ikimino";
        }

        else if (getresult == OutputText[76])
        {
            text.text = "Monster\n" + "Bakemono";
        }

        else if (getresult == OutputText[77])
        {
            text.text = "Stem\n" + "Kuki";
        }

        else if (getresult == OutputText[78])
        {
            text.text = "Dog\n" + "Inu";
        }

        else if (getresult == OutputText[79])
        {
            text.text = "Cat\n" + "Neko";
        }

        else if (getresult == OutputText[80])
        {
            text.text = "Cow\n" + "Ushi";
        }

        else if (getresult == OutputText[81])
        {
            text.text = "Pig\n" + "buta";
        }

        else if (getresult == OutputText[82])
        {
            text.text = "Horse\n" + "Uma";
        }

        else if (getresult == OutputText[83])
        {
            text.text = "Chrysanthemum\n" + "Kiku";
        }

        else if (getresult == OutputText[84]||getresult== "〝さる")
        {
            text.text = "Monkey\n" + "Saru";
        }

        else if (getresult == OutputText[85]||getresult== "ねずみ〟")
        {
            text.text = "Mouse\n" + "Nezumi";
        }

        else if (getresult == OutputText[86])
        {
            text.text = "Snake\n" + "Hebi";
        }

        else if (getresult == OutputText[87]||getresult== "オオ力ミ")
        {
            text.text = "Wolf\n" + "Ōkami";
        }

        else if (getresult == OutputText[88] || getresult== "うさぎ}")
        {
            text.text = "Rabbit\n" + "Usagi";
        }

        else if (getresult == OutputText[89]||getresult== "`りゆう")
        {
            text.text = "Dragon\n" + "Tatsu";
        }

        else if (getresult == OutputText[90])
        {
            text.text = "Bear\n" + "Kuma";
        }

        else if (getresult == OutputText[91])
        {
            text.text = "Frog\n" + "Kaeru";
        }

        else if (getresult == OutputText[92])
        {
            text.text = "Toad\n" + "Gama";
        }

        else if (getresult == OutputText[93])
        {
            text.text = "Spider\n" + "Kumo";
        }

        else if (getresult == OutputText[94])
        {
            text.text = "Giraffe\n" + "Kirin";
        }

        else if (getresult == OutputText[95])
        {
            text.text = "Elephant\n" + "Zō";
        }

        else if (getresult == OutputText[96])
        {
            text.text = "Bird\n" + "Tori";
        }

        else if (getresult == OutputText[97])
        {
            text.text = "Chicken\n" + "Niwatori";
        }

        else if (getresult == OutputText[98])
        {
            text.text = "Sparrow\n" + "Suzume";
        }

        else if (getresult == OutputText[99])
        {
            text.text = "Crow\n" + "Karasu";
        }
        else
        {
            text.text = "Sorry I Can't Translate this!";
        }
       


    }

}
