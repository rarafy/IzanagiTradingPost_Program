using Create_Order;
using NCMB;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Order_FormatterForAdmin
{
    public class OrderFormatterForAdmin : MonoBehaviour
    {
        #region Common_Variable_Section
        [SerializeField]
        private GameObject createOrderForAdmin;
        [SerializeField]
        private GameObject dataDisplayer;
        [SerializeField]
        private GameObject panelSwitchController;

        [SerializeField, Tooltip("ユーザー名")]
        private GameObject userId;
        [SerializeField, Tooltip("ユーザー名")]
        private GameObject userURL;
        [SerializeField, Tooltip("出１_種類")]
        private string sell1_1;
        [SerializeField, Tooltip("出１_名称")]
        private GameObject sell1_2;
        [SerializeField, Tooltip("出１_武器種類/個数")]
        private GameObject sell1_3;
        [SerializeField, Tooltip("出１_レア度")]
        private GameObject sell1_4;
        [SerializeField, Tooltip("出１_強化値")]
        private GameObject sell1_5;
        [SerializeField, Tooltip("求１")]
        private GameObject buy1;
        [SerializeField, Tooltip("詳細")]
        private GameObject detail;
        [SerializeField, Tooltip("SS")]
        private GameObject ss;
        #endregion


        #region OnButton_Clicked_Section
        public void OnSendButtonPushed()
        {
            if (sell1_3.transform.GetChild(0).GetComponent<Text>().text == "" ||
                sell1_3.GetComponent<Dropdown>().value == 0 ||
                buy1.transform.GetChild(1).GetComponent<Text>().text == "")
            {
                Error();
            }
            else
            {
                DataAssignment();
                AddNewOrder();

                //求１ 価格を初期化
                buy1.GetComponent<InputField>().text = "";
                //出１ ドロップダウンを初期化
                createOrderForAdmin.GetComponent<CreateOrderForAdmin>().Reset();
                //詳細 値を初期化
                detail.GetComponent<InputField>().text = "";
                //SSを初期化
                ss.GetComponent<AddImage>().texture = null;
                ss.GetComponent<AddImage>().texture2 = null;
                ss.GetComponent<Image>().overrideSprite = null;

                //画面を戻す
                panelSwitchController.GetComponent<PanelSwitchControllerForAdmin>().OnTopButtonPressed(GameObject.Find("出品一覧_NoLoad Button").GetComponent<Button>());
                dataDisplayer.GetComponent<DataDisplayer>().OnSearchButtonClicked();
            }
        }

        public void On_SS_ResetButtonClicked()
        {
            ss.GetComponent<AddImage>().texture = null;
            ss.GetComponent<AddImage>().texture2 = null;
            ss.GetComponent<Image>().overrideSprite = null;
        }
        #endregion


        #region Data_Format_Section
        //ユーザ名 変数
        private string user_ID;
        private string user_URL;

        //出1 変数
        private string itemType;
        private string itemName_UniqueName;
        private string itemName_Type;
        private string itemName_Enhancement;
        private string Rarity;
        private string Number;
        private int number;//Number変換用変数

        //求1 変数
        private double Price;

        //SS 変数
        private byte[] SS;

        //詳細 変数
        private string Detail;

        public void DataAssignment()
        {
            //ユーザー名 変数代入
            user_ID = userId.transform.GetChild(2)
            .gameObject.GetComponent<Text>().text;
            user_URL = userURL.transform.GetChild(2)
            .gameObject.GetComponent<Text>().text;

            //出1 変数代入１
            //itemType,itemName x2代入
            sell1_1 = createOrderForAdmin.GetComponent<CreateOrderForAdmin>().typeDropdown; itemType = sell1_1;//変数の一貫性を保つため二重代入
            itemName_UniqueName = sell1_2.transform.GetChild(0).GetComponent<Text>().text;
            itemName_Enhancement = sell1_5.transform.GetChild(0).GetComponent<Text>().text;


            //出1 変数代入２
            //Rarity,Number,itemName_Type代入...3番と4番が特殊なもの

            Number = "1個";//Numberのデフォルトは１個
            itemName_Type = "";//itemName_Typeのデフォルトは""
            switch (itemType)
            {
                case "武器":
                    Rarity = sell1_4.transform.GetChild(0).GetComponent<Text>().text;
                    itemName_Type = sell1_3.transform.GetChild(0).GetComponent<Text>().text;
                    break;
                case "ネタ武器":
                    Rarity = "SR";
                    itemName_Enhancement = sell1_3.transform.GetChild(0).GetComponent<Text>().text;
                    break;
                case "左手武器":
                    Rarity = sell1_3.transform.GetChild(0).GetComponent<Text>().text;
                    break;
                case "防具":
                    Rarity = sell1_4.transform.GetChild(0).GetComponent<Text>().text;
                    itemName_Type = sell1_3.transform.GetChild(0).GetComponent<Text>().text;
                    break;
                case "顔防具":
                    Rarity = sell1_3.transform.GetChild(0).GetComponent<Text>().text;
                    break;
                case "アクセサリ":
                    Rarity = sell1_3.transform.GetChild(0).GetComponent<Text>().text;
                    break;
                case "メダル":
                    Rarity = sell1_3.transform.GetChild(0).GetComponent<Text>().text;
                    break;
                default:
                    Rarity = sell1_4.transform.GetChild(0).GetComponent<Text>().text;
                    Number = sell1_3.transform.GetChild(0).GetComponent<Text>().text;
                    break;
            }
            number = int.Parse(Number.Replace("個", ""));

            //求1 変数代入
            Price = double.Parse(buy1.transform.GetChild(2).GetComponent<Text>().text);

            //SS 変数代入
            if (ss.GetComponent<AddImage>().texture != null)
            {
                SS = ss.GetComponent<AddImage>().texture.EncodeToPNG();
            }

            //詳細 変数代入
            Detail = detail.gameObject.transform.GetChild(2)
            .gameObject.GetComponent<Text>().text;
        }
        #endregion

        #region Data_Update_Section
        //y → データ本体。中身は以下の構造になってる。
        //{ { "種類", "名称", "レア度", "数量", "値段", "ユーザ名", "詳細", "ユーザURL"} }
        //{ {      0,      1,       2,     3,      4,         5,      6,          7} }

        public void AddNewOrder()
        {
            NCMBObject obj = new NCMBObject("Orders");

            obj["itemType"] = itemType;
            obj["itemName"] = itemName_UniqueName + " " + itemName_Type + " " + itemName_Enhancement;
            obj["Rarity"] = Rarity;
            obj["Number"] = number;
            obj["Price"] = Price;
            obj["UserID"] = user_ID;
            obj["Detail"] = Detail;
            obj["UserURL"] = user_URL;

            Debug.Log(itemType);
            Debug.Log(itemName_UniqueName);
            Debug.Log(itemName_Type);
            Debug.Log(itemName_Enhancement);
            Debug.Log(Rarity);
            Debug.Log(number + "→" + Number);
            Debug.Log(user_ID);
            Debug.Log(Detail);
            Debug.Log(user_URL);

            obj.SaveAsync();


            //SS保存処理 実質３行だがＳＳ命名のため11行になっている。
            if (ss.GetComponent<AddImage>().texture != null)
            {
                NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Orders");
                query.Limit = 1;
                query.OrderByDescending("updateDate");
                query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
                {
                    NCMBFile file = new NCMBFile(System.Convert.ToString(objList[0].ObjectId), SS);
                    file.SaveAsync();
                });
            }
        }

        #endregion


        #region Error_Section
        [SerializeField]
        private GameObject ErrorPanel;

        private void Error()
        {
            ErrorPanel.gameObject.SetActive(true);
        }
        #endregion


        #region Double_List_Manual

        //Listを入れ子にして扱う
        /*https://smdn.jp/programming/
         * dotnet-samplecodes/collections/
         * List%E3%82%92%E5%85%A5%E3%82%8C%E5%AD%90%E3%81
         * %AB%E3%81%97%E3%81%A6%E6%89%B1%E3%81%86
         * .csharp.xhtml
         */

        //二次元ListとListの配列
        /*http://koshinran.hateblo.jp/
         * entry/2017/06/22/202924 
         */
        #endregion

    }
}