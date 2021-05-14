using Create_Order;
using NCMB;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplayer : MonoBehaviour
{
    #region Data_Display_Section
    //Fontyuu
    [SerializeField]
    private Font meiryob;

    //親となるContent
    [SerializeField, Tooltip("親となるContent")]
    private GameObject ParentContent;
    //アタッチ後のアイテム
    private List<GameObject> inc;
    //元となるインスタンス
    private GameObject Instance;

    //空欄インスタンス
    private GameObject InstanceEmpty;
    //空欄のHierarchy上のアイテム
    private GameObject incEmpty;

    //親となるContent(出品リスト)
    [SerializeField, Tooltip("親となるContent(出品リスト内)")]
    private GameObject ParentContent_In_MyList;
    //元となるインスタンス for MyList
    private GameObject InstanceForMyList;
    [SerializeField]
    private GameObject userID;
    [SerializeField]
    private GameObject userURL;


    private List<string> s0;//itemType
    private List<string> s1;//itemName
    private List<string> s2;//Rarity
    private List<string> s3;//Number
    private List<string> s4;//Price
    private List<string> s5;//User_ID
    private List<string> s6;//Detail
    private List<string> s7;//User_URL
    private List<string> s8;//Object_ID


    private void Start()
    {
        //各種変数の初期状態のセット
        //Instance = (GameObject)Resources.Load("出品情報１_Instance Empty");
        Instance = (GameObject)Resources.Load("出品情報１_Instance Empty_Black");
        //InstanceForMyList = (GameObject)Resources.Load("出品情報１_Instance Empty for MyList");
        InstanceForMyList = (GameObject)Resources.Load("出品情報１_Instance Empty for MyList_Black");
        InstanceEmpty = (GameObject)Resources.Load("ただの空白 Empty");
        ListReset();
        IncReset();

        //起動時にデータを表示
        DataDisplay();
    }

    private void ListReset()
    {
        s0 = new List<string>();
        s1 = new List<string>();
        s2 = new List<string>();
        s3 = new List<string>();
        s4 = new List<string>();
        s5 = new List<string>();
        s6 = new List<string>();
        s7 = new List<string>();
        s8 = new List<string>();
    }

    private void IncReset()
    {
        inc = new List<GameObject>();
    }

    private void DataDisplay()
    {
        //データストアの"Orders"クラスから検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Orders");

        //"Orders"クラスの'objectId'カラムを降順に並び替え
        query.OrderByDescending("itemName");

        //上位1000個のみ取得
        query.Limit = 1000;

        //実際に取得
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                //検索失敗時の処理
                Debug.Log("<color=#00ccff>Error.</color>");
            }
            else
            {
                //検索成功時の処理
                Debug.LogWarning("<color=#00ccff>Nice.</color>");
                Debug.Log(objList.Count);
                for (int i = 0; i < objList.Count; i++)
                {
                    Debug.Log(i);
                    Debug.LogWarning("<color=#00ccff>Raw s[0]:</color>" + System.Convert.ToString(objList[i]["itemType"]));
                    Debug.LogWarning("<color=#00ccff>Raw s[1]:</color>" + System.Convert.ToString(objList[i]["itemName"]));
                    Debug.LogWarning("<color=#00ccff>Raw s[2]:</color>" + System.Convert.ToString(objList[i]["Rarity"]));
                    Debug.LogWarning("<color=#00ccff>Raw s[3]:</color>" + System.Convert.ToString(objList[i]["Number"]));
                    Debug.LogWarning("<color=#00ccff>Raw s[4]:</color>" + System.Convert.ToString(objList[i]["Price"]));
                    Debug.LogWarning("<color=#00ccff>Raw s[5]:</color>" + System.Convert.ToString(objList[i]["UserID"]));
                    Debug.LogWarning("<color=#00ccff>Raw s[6]:</color>" + System.Convert.ToString(objList[i]["Detail"]));
                    Debug.LogWarning("<color=#00ccff>Raw s[7]:</color>" + System.Convert.ToString(objList[i]["UserURL"]));
                    Debug.LogWarning("<color=#00ccff>Raw s[8]:</color>" + System.Convert.ToString(objList[i].ObjectId));

                    s0.Add(System.Convert.ToString(objList[i]["itemType"]));
                    s1.Add(System.Convert.ToString(objList[i]["itemName"]));
                    s2.Add(System.Convert.ToString(objList[i]["Rarity"]));
                    s3.Add(System.Convert.ToString(objList[i]["Number"]));//文末の「個」を削除してある
                    s4.Add(System.Convert.ToString(objList[i]["Price"]));
                    s5.Add(System.Convert.ToString(objList[i]["UserID"]));
                    s6.Add(System.Convert.ToString(objList[i]["Detail"]));
                    s7.Add(System.Convert.ToString(objList[i]["UserURL"]));
                    s8.Add(System.Convert.ToString(objList[i].ObjectId));
                }
                Debug.LogWarning("<color=#00ccff>Contents s[0]:</color>" + s0[0]);

                GenerateDataInstance(ParentContent, Instance);
            }
        });
    }

    private void GenerateDataInstance(GameObject parentContent, GameObject instance)
    {
        Debug.Log("GenerateDataInstance");
        for (int i = 0; i < s0.Count; i++)
        {
            Debug.Log(i);
            inc.Add(Instantiate(instance, Vector3.zero, Quaternion.identity, parentContent.transform));
            inc[i].GetComponent<OrderID>().objectID = s8[i];
            inc[i].GetComponent<OrderID>().orderID = i;

            //inc[].transform.gt(テーブル).gt(テーブルchild).gt(text)

            //Rarity
            switch (s2[i])
            {
                case "LE"://D056FF
                    inc[i].transform.GetChild(1).GetChild(0)
                        .GetChild(1).GetComponent<Text>().color
                            = new Color(208f / 255f, 86f / 255f, 255f / 255f, 1.0f);
                    break;
                case "SR":
                    inc[i].transform.GetChild(1).GetChild(0)
                        .GetChild(1).GetComponent<Text>().color
                            = new Color(1.0f, 0.596f, 0.0f, 1.0f);
                    break;
                case "R":
                    inc[i].transform.GetChild(1).GetChild(0)
                        .GetChild(1).GetComponent<Text>().color
                            = new Color(1.0f, 1.0f, 0.0f, 1.0f);
                    break;
                case "UC"://FF8D9D
                    inc[i].transform.GetChild(1).GetChild(0)
                        .GetChild(1).GetComponent<Text>().color
                            = new Color(255f / 255f, 141f / 255f, 157f / 255f, 1.0f);
                    break;
                default:
                    inc[i].transform.GetChild(1).GetChild(0)
                        .GetChild(1).GetComponent<Text>().color
                            = Color.white;
                    break;
            }
            //itemNameの丸枠
            if (s0[i] == "武器" || s0[i] == "防具" || s0[i] == "左手武器" || s0[i] == "顔防具")
            {
                inc[i].transform.GetChild(1).GetChild(0)
                    .GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                inc[i].transform.GetChild(1).GetChild(0)
                    .GetChild(0).gameObject.SetActive(false);
            }
            //itemName
            inc[i].transform.GetChild(1).GetChild(0)
                .GetChild(1).GetComponent<Text>().text = s1[i];
            //Number
            inc[i].transform.GetChild(1).GetChild(1)
                .GetChild(0).GetComponent<Text>().text = s3[i] + "個";

            //Price
            if (Digit(Convert.ToInt32(s4[i])) >= 9)//９桁～　太字 + 赤
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().font = meiryob;
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().color = new Color(245f / 255f, 44f / 255f, 44f / 255f, 1.0f);//Color.red;
            }
            else if (Digit(Convert.ToInt32(s4[i])) >= 8)//８桁　黄
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().color = Color.yellow;
            }
            else if (Digit(Convert.ToInt32(s4[i])) >= 7)//７桁　緑
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().color = Color.green;
            }
            else if (Digit(Convert.ToInt32(s4[i])) >= 6)//６桁　水色
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().color = Color.cyan;
            }
            else//～５桁　白
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().color = Color.white;
            }
            //Priceを代入
            if (Digit(Convert.ToInt32(s4[i])) >= 9)
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().text = (int.Parse(s4[i]) / 100000000) + "億Golds";
            }
            else if (Digit(Convert.ToInt32(s4[i])) >= 8)
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().text = (int.Parse(s4[i]) / 10000000) + "千万Golds";
            }
            else if (Digit(Convert.ToInt32(s4[i])) >= 7)
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().text = (int.Parse(s4[i]) / 10000) + "万Golds";
            }
            else
            {
                inc[i].transform.GetChild(1).GetChild(2)
                    .GetChild(0).GetComponent<Text>().text = string.Format("{0:#,0}", int.Parse(s4[i])) + " Golds";
            }

            //User_ID
            inc[i].transform.GetChild(1).GetChild(3)
                .GetChild(0).GetComponent<Text>().text = s5[i];
        }
        incEmpty = Instantiate(InstanceEmpty, Vector3.zero, Quaternion.identity, parentContent.transform);
    }


    private void MyDataDisplay()
    {
        //データストアの"Orders"クラスから検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Orders");

        //"Orders"クラスの'objectId'カラムを降順に並び替え
        query.OrderByDescending("objectId");

        //上位1000個のみ取得
        query.Limit = 1000;

        //実際に取得
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                //検索失敗時の処理
                Debug.Log("<color=#00ccff>Error.</color>");
            }
            else
            {
                //検索成功時の処理
                Debug.LogWarning("<color=#00ccff>Nice.</color>");
                Debug.Log(objList.Count);
                for (int i = 0; i < objList.Count; i++)
                {
                    s0.Add(System.Convert.ToString(objList[i]["itemType"]));
                    s1.Add(System.Convert.ToString(objList[i]["itemName"]));
                    s2.Add(System.Convert.ToString(objList[i]["Rarity"]));
                    s3.Add(System.Convert.ToString(objList[i]["Number"]));
                    s4.Add(System.Convert.ToString(objList[i]["Price"]));
                    s5.Add(System.Convert.ToString(objList[i]["UserID"]));
                    s6.Add(System.Convert.ToString(objList[i]["Detail"]));
                    s7.Add(System.Convert.ToString(objList[i]["UserURL"]));
                    s8.Add(System.Convert.ToString(objList[i].ObjectId));
                }
                Debug.LogWarning("<color=#00ccff>Contents s[0]:</color>" + s0[0]);

                GenerateDataInstance(ParentContent_In_MyList, InstanceForMyList);
                DisplayMyDataOnly();
            }
        });
    }

    private void DisplayMyDataOnly()
    {
        for (int i = 0; i < s0.Count; i++)
        {
            inc[i].SetActive(false);

            //ユーザURLで検索
            if (s7[i].Contains(userURL.transform.GetChild(2)
        .gameObject.GetComponent<Text>().text))
            {
                inc[i].SetActive(true);
            }
        }
    }
    #endregion


    #region OnButton_Clicked_Section
    [SerializeField, Tooltip("詳細Panel(inSearchPanel)をアタッチ")]
    private GameObject DetailPanel;
    [SerializeField, Tooltip("詳細Panel(in出品リスト)をアタッチ")]
    private GameObject DetailPanel_In_MyList;

    //内部処理用。実際に使う方の詳細Panel
    private GameObject detailPanel;

    //詳細 Buttonが押された時
    //num → OrderIDと同じ。内部的に処理するために、このセクションのみで使う一時変数。
    public void OnDetailButtonPressed(int num, string objectID, int detailPanelPos = 0)
    {
        Debug.Log(num);

        Debug.Log(s6[num]);

        if (detailPanelPos == 0)//検索画面の場合
        {
            detailPanel = DetailPanel;
        }
        else if (detailPanelPos == 1)//出品リスト画面の場合
        {
            detailPanel = DetailPanel_In_MyList;
        }

        //詳細textを代入
        this.detailPanel.transform.GetChild(0).transform.GetChild(1)
            .transform.GetChild(0).transform.GetChild(2)
            .transform.GetChild(0)
            .gameObject.GetComponent<InputField>().text = s6[num];


        //SSの文字をリセット
        this.detailPanel.transform.GetChild(0).transform.GetChild(1)
             .transform.GetChild(0).transform.GetChild(1)
             .transform.GetChild(0).transform.GetChild(0)
             .gameObject.SetActive(true);

        //SSをリセット
        this.detailPanel.transform.GetChild(0).transform.GetChild(1)
            .transform.GetChild(0).transform.GetChild(1)
            .transform.GetChild(0)
            .gameObject.GetComponent<Image>().sprite = null;


        //SSを代入
        //1.SSを取得 2.SS(byte[])をtexture→Spriteに変換
        NCMBQuery<NCMBFile> query = NCMBFile.GetQuery();
        query.WhereEqualTo("fileName", objectID);
        query.FindAsync((List<NCMBFile> objList, NCMBException error) =>
        {
            if (error != null)
            {
                //検索失敗
            }
            else
            {
                //検索成功
                foreach (NCMBFile file in objList)
                {
                    file.FetchAsync((byte[] fileData, NCMBException e) =>
                    {
                        if (e != null)
                        {
                            //取得失敗
                        }
                        else
                        {
                            //取得成功
                            //1.SSの文字を消す。
                            this.detailPanel.transform.GetChild(0).transform.GetChild(1)
                                 .transform.GetChild(0).transform.GetChild(1)
                                 .transform.GetChild(0).transform.GetChild(0)
                                 .gameObject.SetActive(false);

                            //2.SSを代入する。
                            Texture2D texture = new Texture2D(100, 100);
                            texture.LoadImage(fileData);
                            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                            this.detailPanel.transform.GetChild(0).transform.GetChild(1)
                                .transform.GetChild(0).transform.GetChild(1)
                                .transform.GetChild(0)
                                .gameObject.GetComponent<Image>().sprite = sprite;
                            Resources.UnloadUnusedAssets();
                        }
                    });
                }
            }
        });
        //--SS処理はここまで。

        //ユーザーのLobi URLを代入
        this.detailPanel.transform.GetChild(0).transform.GetChild(1)
             .transform.GetChild(0).transform.GetChild(3)
             .transform.GetChild(0)
             .gameObject.GetComponent<InputField>().text = s7[num];

        //最後に詳細パネルをオンにする
        this.detailPanel.gameObject.SetActive(true);
    }

    //Lobi Buttonが押された時
    public void OnLobiButtonPressed(int num)
    {
        Application.OpenURL(s7[num]);
    }

    #endregion


    #region OnSearch_Button_Pressed_Section
    public void OnSearchButtonClicked() //「検索ボタン」ではなく、SearchPanelのメニューボタンの方を指す → データ更新処理はここを呼べば良い。
    {

        //インスタンスが既に生成されているなら
        //→ リセット処理をしてから更新
        if (s0.Count != 0)
        {
            Initialization();
            DataDisplay();
        }
        else
        {
            DataDisplay();
        }
    }


    private void Initialization()
    {
        for (int i = 0; i < inc.Count; i++)
        {
            Destroy(inc[i].gameObject);
        }
        Destroy(incEmpty.gameObject);
        ListReset();
        IncReset();
    }

    #endregion


    #region On_MyList_Button_Pressed_Section
    public void OnMyListButtonPressed()
    {
        //インスタンスが既に生成されているなら
        //→ リセット処理をしてから更新
        if (s0.Count != 0)
        {
            Initialization();
            MyDataDisplay();
        }
        else
        {
            MyDataDisplay();
        }
    }
    #endregion


    #region Search_Behavior_Section

    //大分類・全てで検索するときのキーワード
    private string type = "";
    private string keyword = "";

    //中分類で検索するときのキーワード2
    private string keyword_type = "";

    public void OnLeftButtonClicked(string text)//左サイドボタンが押されたとき
    {
        //先に中分類を分けておいて、そうじゃないのは大分類のはずだと解釈する

        if (CreateOrder.weaponTypeList.Contains(text)) //中分類
        {
            type = "武器";
            keyword_type = text;
        }
        else if (CreateOrder.armorTypeList.Contains(text))//中分類2
        {
            type = "防具";
            keyword_type = text;
        }
        else if (CreateOrder.accessoryTypeList.Contains(text))//中分類3
        {
            type = "アクセサリ";
            keyword_type = text;
        }
        else if (CreateOrder.medalTypeList.Contains(text))//メダル_中分類4
        {
            type = "メダル";
            keyword_type = text;
        }
        else if (CreateOrder.talentTypeList.Contains(text))//中分類5
        {
            type = "異能";
            keyword_type = text;
        }
        else if (CreateOrder.consumeTypeList.Contains(text))//消耗品_中分類6
        {
            type = "消耗品";
            keyword_type = text;
        }
        else if (text == "全て") //全て
        {
            type = "";
            keyword_type = "";
        }
        else //大分類
        {
            type = text;
            keyword_type = "";
        }

        Debug.Log(type);

        Search();
    }

    public void OnSearchFunctionButtonClicked(string text)//検索ボタンが押されたとき
    {
        keyword = text;
        Debug.LogWarning(keyword);
        Search();
    }

    private void Search()//絞り込みを実行
    {
        for (int i = 0; i < s0.Count; i++)
        {
            inc[i].SetActive(false);

            if (s1[i].Contains(keyword))//アイテム名で検索
            {
                if (s0[i].Contains(type))//種類(大分類)で絞り込み
                {
                    if (s1[i].Contains(keyword_type))//種類(中分類)で絞り込み
                    {
                        inc[i].SetActive(true);
                    }
                }
            }
        }
        Debug.LogError("Searched by " + type + " " + keyword_type);
    }

    #endregion


    #region Sort_Behavior_Section

    string[][] jag = new string[1000][];

    private void ListCombiner()//リストの結合
    {
        Array.Resize(ref jag, s0.Count);

        for (int i = 0; i < s0.Count; i++)
        {
            jag[i] = new string[] { s0[i], s1[i], s2[i], s3[i], s4[i], s5[i], s6[i], s7[i], s8[i] };
        }
        //0 itemType, 1 itemName, 2 Rarity, 3 Number, 4 Price, 5 User_ID, 6 Detail, 7 user_URL, 8 OrderID
    }

    private void initialization()
    {
        for (int i = 0; i < inc.Count; i++)
        {
            Destroy(inc[i].gameObject);
        }
        Destroy(incEmpty.gameObject);
        inc = new List<GameObject>();
    }

    public void SortByItemName(bool ascending = true)
    {
        ListCombiner();

        IOrderedEnumerable<string[]> sorted;
        if (ascending == false)
        {
            sorted = jag.OrderByDescending(e => e[1]);//s1=itemNameで降順ソート
        }
        else
        {
            sorted = jag.OrderBy(e => e[1]);//s1=itemNameで昇順ソート
        }

        sorted.Distinct().ToList();
        ListReset();

        foreach (var result in sorted)
        {
            s0.Add(result[0]);
            s1.Add(result[1]);
            s2.Add(result[2]);
            s3.Add(result[3]);
            s4.Add(result[4]);
            s5.Add(result[5]);
            s6.Add(result[6]);
            s7.Add(result[7]);
            s8.Add(result[8]);
        }
        Debug.Log(s0[0]);
        initialization();
        GenerateDataInstance(ParentContent, Instance);
        Search();
    }

    public void SortByNumber(bool ascending = true)
    {
        ListCombiner();

        IOrderedEnumerable<string[]> sorted;
        if (ascending == false)
        {
            sorted = jag.OrderByDescending(e => e[3], new SemiNumericComparer());//s3=Numberでintとして降順ソート
        }
        else
        {
            sorted = jag.OrderBy(e => e[3], new SemiNumericComparer());//s3=Numberでintとして昇順ソート
        }

        sorted.Distinct().ToList();
        ListReset();

        foreach (var result in sorted)
        {
            s0.Add(result[0]);
            s1.Add(result[1]);
            s2.Add(result[2]);
            s3.Add(result[3]);
            s4.Add(result[4]);
            s5.Add(result[5]);
            s6.Add(result[6]);
            s7.Add(result[7]);
            s8.Add(result[8]);
        }
        Debug.Log(s0[0]);
        initialization();
        GenerateDataInstance(ParentContent, Instance);
        Search();
    }

    public void SordByPrice(bool ascending = true)
    {
        ListCombiner();

        IOrderedEnumerable<string[]> sorted;
        if (ascending == false)
        {
            sorted = jag.OrderByDescending(e => e[4], new SemiNumericComparer());//s4=Priceでintとして降順ソート
        }
        else
        {
            sorted = jag.OrderBy(e => e[4], new SemiNumericComparer());//s4=Priceでintとして昇順ソート
        }

        sorted.Distinct().ToList();
        ListReset();

        foreach (var result in sorted)
        {
            s0.Add(result[0]);
            s1.Add(result[1]);
            s2.Add(result[2]);
            s3.Add(result[3]);
            s4.Add(result[4]);
            s5.Add(result[5]);
            s6.Add(result[6]);
            s7.Add(result[7]);
            s8.Add(result[8]);
        }
        Debug.Log(s0[0]);
        initialization();
        GenerateDataInstance(ParentContent, Instance);
        Search();
    }

    #endregion


    #region DocumentSection

    //Mbaas(NCMB公式) Queryドキュメント
    //https://mbaas.nifcloud.com/assets/sdk_doc/javascript/jsdoc/classes/Query.html

    #endregion


    public int Digit(int num)//桁数判定機
    {
        int digit = 1;
        for (int i = num; i >= 10; i /= 10)
        {
            digit++;
        }
        return digit;
    }
}

public class SemiNumericComparer : IComparer<string>
{
    public int Compare(string s1, string s2)//数の大小を比較するプログラム
    {
        if (IsNumeric(s1) && IsNumeric(s2))
        {
            if (Convert.ToInt32(s1) > Convert.ToInt32(s2)) return 1;
            if (Convert.ToInt32(s1) < Convert.ToInt32(s2)) return -1;
            if (Convert.ToInt32(s1) == Convert.ToInt32(s2)) return 0;
        }

        if (IsNumeric(s1) && !IsNumeric(s2))
            return -1;

        if (!IsNumeric(s1) && IsNumeric(s2))
            return 1;

        return string.Compare(s1, s2, true);
    }

    public static bool IsNumeric(object value)//数値かどうかを判定
    {
        try
        {
            int i = Convert.ToInt32(value.ToString());
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}