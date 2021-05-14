using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Create_Order
{
    public class CreateOrderForAdmin : MonoBehaviour
    {
        #region Initialize_Section

        private void Start()
        {
            Reset();
        }

        public void Reset()
        {
            typeDropdown = "";
        }

        #endregion

        #region List_Update_Section
        [SerializeField, Tooltip("１階")]
        public string typeDropdown;
        [SerializeField, Tooltip("２階")]
        private Dropdown secondTypeDropdown;
        [SerializeField, Tooltip("３階")]
        private Dropdown thirdTypeDropdown;
        [SerializeField, Tooltip("４階")]
        private Dropdown fourthTypeDropdown;
        [SerializeField, Tooltip("５階")]
        private Dropdown fifthTypeDropdown;
        [SerializeField, Tooltip("６階(価格入力フィールド)")]
        private InputField sixthTypeDropdown;
        [SerializeField, Tooltip("エラーパネル")]
        private GameObject ErrorPanel;

        public void OnListUpdate()//種類
        {
            typeDropdown = this.transform.GetChild(0).gameObject.GetComponent<Text>().text;

            secondTypeDropdown.ClearOptions();
            thirdTypeDropdown.ClearOptions();
            if (typeDropdown == "武器") secondTypeDropdown.AddOptions(weaponList);
            else if (typeDropdown == "ネタ武器") secondTypeDropdown.AddOptions(ideaWeaponList);
            else if (typeDropdown == "左手武器") secondTypeDropdown.AddOptions(leftWeaponList);
            else if (typeDropdown == "防具") secondTypeDropdown.AddOptions(armorList);
            else if (typeDropdown == "顔防具") secondTypeDropdown.AddOptions(faceArmorTypeList);
            else if (typeDropdown == "アクセサリ") secondTypeDropdown.AddOptions(accessoryList);
            else if (typeDropdown == "メダル") secondTypeDropdown.AddOptions(medalList);
            else if (typeDropdown == "異能") secondTypeDropdown.AddOptions(talentList);
            else if (typeDropdown == "口寄せ") secondTypeDropdown.AddOptions(petEggList);
            else if (typeDropdown == "クエスト用品") secondTypeDropdown.AddOptions(questItemList);
            else if (typeDropdown == "消耗品") secondTypeDropdown.AddOptions(consumeList);
            else if (typeDropdown == "金塊") secondTypeDropdown.AddOptions(ingotList);
            else if (typeDropdown == "生産素材") secondTypeDropdown.AddOptions(alchemyItemList);
            else
            {
                ErrorPanel.gameObject.SetActive(true);
                return;
            }
            secondTypeDropdown.value = 0;
            secondTypeDropdown.interactable = true;
            thirdTypeDropdown.interactable = false;
            fourthTypeDropdown.gameObject.SetActive(false);
            fifthTypeDropdown.gameObject.SetActive(false);
        }
        //--------------------------------------------------------
        public void OnSecondListUpdate()//名称
        {
            thirdTypeDropdown.ClearOptions();
            if (typeDropdown == "武器") thirdTypeDropdown.AddOptions(weaponTypeList);
            else if (typeDropdown == "ネタ武器") thirdTypeDropdown.AddOptions(enhanceLevelListForThirdList);
            else if (typeDropdown == "左手武器") thirdTypeDropdown.AddOptions(rarityListForThirdList);
            else if (typeDropdown == "防具") thirdTypeDropdown.AddOptions(armorTypeList);
            else if (typeDropdown == "顔防具") thirdTypeDropdown.AddOptions(rarityListForThirdList);
            else if (typeDropdown == "アクセサリ") thirdTypeDropdown.AddOptions(rarityListForThirdList);
            else if (typeDropdown == "メダル") thirdTypeDropdown.AddOptions(rarityListForThirdList);
            else if (typeDropdown == "異能") thirdTypeDropdown.AddOptions(itemNumList);
            else if (typeDropdown == "口寄せ") thirdTypeDropdown.AddOptions(itemNumList);
            else if (typeDropdown == "クエスト用品") thirdTypeDropdown.AddOptions(itemNumList);
            else if (typeDropdown == "消耗品") thirdTypeDropdown.AddOptions(itemNumList);
            else if (typeDropdown == "金塊") thirdTypeDropdown.AddOptions(itemNumList);
            else if (typeDropdown == "生産素材") thirdTypeDropdown.AddOptions(itemNumList);

            if (secondTypeDropdown.value == 0)
            {
                ErrorPanel.gameObject.SetActive(true);
                return;
            }

            thirdTypeDropdown.value = 0;
            thirdTypeDropdown.interactable = true;
            fourthTypeDropdown.gameObject.SetActive(false);
            fifthTypeDropdown.gameObject.SetActive(false);
        }
        //--------------------------------------------------------
        public void OnThirdListUpdate()//種類・個数
        {
            if (thirdTypeDropdown.value == 0)
            {
                ErrorPanel.gameObject.SetActive(true);
                return;
            }

            fourthTypeDropdown.ClearOptions();
            fifthTypeDropdown.ClearOptions();
            if (typeDropdown == "武器" || typeDropdown == "防具")
            {
                fourthTypeDropdown.AddOptions(rarityList);
                fourthTypeDropdown.value = 0;
                fifthTypeDropdown.AddOptions(enhanceLevelList);
                fifthTypeDropdown.value = 0;
                fourthTypeDropdown.gameObject.SetActive(true);
                fifthTypeDropdown.gameObject.SetActive(false);
            }
            else
            {
                fourthTypeDropdown.gameObject.SetActive(false);
                fifthTypeDropdown.gameObject.SetActive(false);
            }
        }
        //--------------------------------------------------------
        public void OnFourthListUpdate()//レア度
        {
            fifthTypeDropdown.gameObject.SetActive(true);
        }
        //--------------------------------------------------------
        public void OnFifthListUpdate()//強化値
        {
        }
        //--------------------------------------------------------
        public void OnSixthListUpdate()//価格
        {
            if (sixthTypeDropdown.text == "" || sixthTypeDropdown.text == "0") ErrorPanel.gameObject.SetActive(true);
        }
        //--------------------------------------------------------
        public void InputMillion()
        {//9桁以下だったら0を8個末尾に付け足して、単位を億にする
            if (Digit(Convert.ToInt32(sixthTypeDropdown.text)) <= 9) sixthTypeDropdown.text = sixthTypeDropdown.text + "00000000";
        }
        public int Digit(int num)//桁数判定機
        {
            int digit = 1;
            for (int i = num; i >= 10; i /= 10)
            {
                digit++;
            }
            return digit;
        }
        //--------------------------------------------------------
        #endregion

        #region List_Section
        [NonSerialized]
        public static List<string> weaponList = new List<string>
    {
        "武器を選択",
        " 1　古びたシリーズ",
        " 3　汎用シリーズ",
        " 7　新品シリーズ",
        " 8　悦楽シリーズ",
        "14  獅子シリーズ",
        "15  優れたシリーズ",
        "17  悪鬼シリーズ",
        "20  正規品シリーズ",
        "21  戦慄シリーズ",
        "22  百夜叉シリーズ",
        "24  上級シリーズ",
        "26  勇躍シリーズ",
        "29  高品質シリーズ",
        "30  狂喜シリーズ",
        "30  丸太シリーズ",
        "30  復讐者_参シリーズ",
        "32  優等シリーズ",
        "33  羅刹シリーズ",
        "35  知勇シリーズ",
        "36  熟練職人シリーズ",
        "37  激昂シリーズ",
        "39  不知火シリーズ",
        "40  精密シリーズ",
        "43  暴君シリーズ",
        "45  名工シリーズ",
        "48  豪傑シリーズ",
        "49  極上シリーズ",
        "50  ひなり下級シリーズ",
        "50  復讐者_伍シリーズ",
        "53  至極シリーズ",
        "54  侠客シリーズ",
        "55  朧月夜シリーズ",
        "58  格別シリーズ",
        "59  不抜シリーズ",
        "60  御天道シリーズ",
        "62  秘蔵品シリーズ",
        "65  鋭峰シリーズ",
        "66  悪邪鬼シリーズ",
        "68  獄炎シリーズ",
        "70  不浄シリーズ",
        "70  暗影シリーズ",
        "70  復讐者_漆シリーズ",
        "71  五蝠寿シリーズ",
        "72  侵食シリーズ",
        "75  刹那シリーズ",
        "76  白夜叉シリーズ",
        "77  綺羅星シリーズ",
        "78  破邪シリーズ",
        "80  坑道上級シリーズ",
        "80  氷絶零シリーズ",
        "80  進撃の巨人シリーズ",
        "82  蛇影シリーズ",
        "87  護聖シリーズ",
        "90  街道上級シリーズ",
        "90  丸太シリーズ",
        "90  復讐者_玖シリーズ",
        "92  鬼哭劾シリーズ",
        "95  紅蠍シリーズ",
        "95  千輪切シリーズ",
        "97  白焔シリーズ",
        "99  紫水シリーズ",
        "100  復讐者_陌シリーズ",
        "100  暴律シリーズ",
        "101  青嵐シリーズ",
        "102  超域シリーズ",
        "102  闘志シリーズ",
        "103  無頼漢シリーズ",
        "105  実践シリーズ",
        "106  夜霧シリーズ",
        "106  凍雲天シリーズ",
        "107  花菖蒲シリーズ",
        "109  聖門シリーズ",
        "110  復讐者_陌十シリーズ",
        "111  一碧シリーズ",
        "113  尖鋭シリーズ",
        "115  月歌シリーズ",
        "116  征戦シリーズ",
        "117  煙花シリーズ",
        "120  復讐者_陌二十シリーズ",
    };
        [NonSerialized]
        public static List<string> weaponTypeList = new List<string> {
        "種類",
        "槍",
        "太刀",
        "槌",
        "錫杖",
        "銃",
        "日本刀",
    };
        [NonSerialized]
        public static List<string> ideaWeaponList = new List<string>
    {
        "ネタ武器を選択",
        "（錫杖）陰陽師の式神杖",
        "（錫杖）海賊王の船旗",
        "（錫杖）紅血の輸血セット",
        "（錫杖）匂いのデッキブラシ",
        "（錫杖）魔法少女の杖",
        "（銃）アラビアン銃剣",
        "（銃）おもちゃの光線銃",
        "（銃）懐かしの水鉄砲",
        "（太刀）アラビアンシミター",
        "（太刀）大鋏",
        "（太刀）陰陽師の笏",
        "（太刀）黒竜の交通標識",
        "（太刀）武蔵のオール",
        "（槌）鉄血 (ﾃｯｹﾂ) の松葉槌",
        "（槌）とても重いバーベル",
        "（槌）成金金貨袋槌",
        "（槌）火消のまとい",
        "（槌）ピコハン",
        "（日本刀）あの釘バット",
        "（日本刀）牛若の横笛",
        "（日本刀）鬼の棍棒",
        "（日本刀）かぐやの扇子",
        "（日本刀）カワサキ88",
        "（日本刀）きゅうきょくのバット",
        "（日本刀）紅血の黒傘",
        "（日本刀）指揮官用鞭",
        "（日本刀）師範の木刀",
        "（日本刀）ジャグリングのクラブ",
        "（日本刀）職人の包丁",
        "（日本刀）花婿のステッキ",
        "（日本刀）ボタンで開かない傘",
        "（槍）監獄槍",
        "（槍）鋼鉄の熊手",
        "（槍）最上級の竹槍",
        "（槍）弁慶の刺又",
        "（槍）鉄パイプの槍",
        "（槍）ボルト付パイプ",
        "（槍）良い子の水中槍",
    };
        [NonSerialized]
        public static List<string> leftWeaponList = new List<string>
        {
        "左手武器を選択",
        "60 八重波の手甲",
        "60 八重波の懐刀",
        "60 八重波の忍笛",
        "60 八重波の金剛杵",
        "80 太閤桐の手甲",
        "80 太閤桐の懐刀",
        "80 太閤桐の忍笛",
        "80 太閤桐の金剛杵",
        "90 吠丸",
        "90 今剣",
        "90 花立",
        "90 布薩",
        "113 哀叫の手甲",
        "113 哀叫の懐刀",
        "113 哀叫の忍笛",
        "113 哀叫の金剛杵",
        "113 哀哭の手甲",
        "113 哀哭の懐刀",
        "113 哀哭の忍笛",
        "113 哀哭の金剛杵",
        };
        [NonSerialized]
        public static List<string> armorList = new List<string>
    {
        "防具を選択",
        " 1　素人術者シリーズ",
        " 8　悦楽シリーズ",
        "18  トロルシリーズ",
        "20  本格的シリーズ",
        "21  戦慄シリーズ",
        "24  新型シリーズ",
        "26  勇躍シリーズ",
        "29  渡来品シリーズ",
        "30  抑制シリーズ",
        "34  良品シリーズ",
        "36  厳格シリーズ",
        "39  真作シリーズ",
        "40  面妖シリーズ",
        "43  逸品シリーズ",
        "45  黙考シリーズ",
        "48  精良シリーズ",
        "49  静寂シリーズ",
        "50  羅生シリーズ",
        "51  極限シリーズ",
        "53  伝統品シリーズ",
        "54  出雲シリーズ",
        "57  高度シリーズ",
        "59  天涯シリーズ",
        "62  傑作シリーズ",
        "65  荘厳シリーズ",
        "68  黒鱗シリーズ",
        "70  高麗シリーズ",
        "72  天賦シリーズ",
        "75  九曜シリーズ",
        "80  黒銀シリーズ",
        "80  黒正シリーズ",
        "80  黒怨シリーズ",
        "82  芒種シリーズ",
        "90  夜摩シリーズ",
        "95  雨露シリーズ",
        "100  燎原シリーズ",
        "101  藍玉シリーズ",
        "107  悠長シリーズ",
        "110  逆浪シリーズ",
        "115  鉄鎖シリーズ",
    };
        [NonSerialized]
        public static List<string> armorTypeList = new List<string>
    {
        "職業/部位",
        "MAG/頭",
        "MAG/上",
        "MAG/下",
        "ASA/頭",
        "ASA/上",
        "ASA/下",
        "WAR/頭",
        "WAR/上",
        "WAR/下",
        "CLE/頭",
        "CLE/上",
        "CLE/下",
    };
        [NonSerialized]
        public static List<string> faceArmorTypeList = new List<string>
    {
        "顔防具を選択",
        "50 撃心乃影口金(ASA)",
        "50 豪健乃戦口金(WAR)",
        "50 惨毒乃術口金(MAG)",
        "50 早参乃復口金(CLE)",
        "50 卓識乃総口金(ALL)",
        "50 撃心乃影口金(ASA)",
        "50 巧術乃戦口金(WAR)",
        "50 破魔乃術口金(MAG)",
        "50 寂即乃復口金(CLE)",
        "50 応作乃総口金(ALL)",
        "50 馴鹿乃影口金(ASA)",
        "50 鈴鳴乃戦口金(WAR)",
        "50 樅木乃術口金(MAG)",
        "50 聖老乃復口金(CLE)",
        "50 静夜乃総口金(ALL)",
    };
        [NonSerialized]
        public static List<string> enhanceLevelListForThirdList = new List<string>
    {
        "強化値",
        "+0",
        "+1",
        "+2",
        "+3",
        "+4",
        "+5",
        "+6",
        "+7",
        "+8",
        "+9",
        "+10",
        "進化1",
        "進化2",
        "進化3",
        "進化4",
        "進化5",
    };
        [NonSerialized]
        public static List<string> enhanceLevelList = new List<string>
    {
        "+0",
        "+1",
        "+2",
        "+3",
        "+4",
        "+5",
        "+6",
        "+7",
        "+8",
        "+9",
        "+10",
        "進化1",
        "進化2",
        "進化3",
        "進化4",
        "進化5",
    };
        [NonSerialized]
        public static List<string> rarityListForThirdList = new List<string>
    {
        "レア度",
        "C",
        "UC",
        "R",
        "SR",
        "LE",
    };
        [NonSerialized]
        public static List<string> rarityList = new List<string>
    {
        "C",
        "UC",
        "R",
        "SR",
        "LE",
    };
        [NonSerialized]
        public static List<string> accessoryList = new List<string>
    {
        "アクセサリを選択",
        "超生命のピアス",
        "韋駄天のピアス",
        "色欲のピアス",
        "蒼枯のピアス（剛）",
        "霊域のピアス",
        "霊域のピアス・劣",
        "華燭のピアス",
        "篝火のピアス",
        "名欲のピアス",
        "我欲のピアス",
        "惰欲のピアス",
        "永久凍土のピアス",
        "惨烈のピアス",
        "猪鹿蝶のピアス",
        "八連荘のピアス",
        "凍一色のピアス",
        "鬼将のピアス",
        "鬼師のピアス",
        "天淵のピアス",
        "暗泉のピアス",
        "玉葉のピアス",
        "邁進のピアス",
        "漸進のピアス",
        "画一的のピアス",
        "赤一色のピアス",
        "黒書のピアス",
        "冷灰のピアス",
        "杜絶のピアス",
        "突撃のピアス",
        "奇襲のピアス",
        "潜竜のピアス",
        "神気のピアス",
        "天界のピアス",
        "仙界のピアス",
        "高速のピアス",
        "発疹のピアス",
        "倹徳のピアス",
        "刃傷のピアス",
        "弾傷のピアス",
        "聖夜のピアス",
        "右近のリング",
        "左近のリング",
        "強壮のリング",
        "小心者のリング",
        "疾苦のリング",
        "霊域のリング",
        "霊域のリング･劣",
        "どくどくのリング",
        "凍士のリング",
        "みかわしのリング",
        "強賢のリング",
        "諸賢のリング",
        "神滅のリング",
        "破滅のリング",
        "才賢のリング",
        "雨四光のリング",
        "清老頭のリング",
        "凍剛尊のリング",
        "赤剛尊のリング",
        "旭光のリング",
        "暁光のリング",
        "星河のリング",
        "絶海のリング",
        "諷将のリング",
        "諷師のリング",
        "迫撃のリング",
        "猛撃のリング",
        "蛮的のリング",
        "心的のリング",
        "荒山のリング",
        "荒海のリング",
        "異彩のリング",
        "審判のリング",
        "風疹のリング",
        "冷灰のリング",
        "杜絶のリング",
        "突撃のリング",
        "奇襲のリング",
        "山閣のリング",
        "敏才のリング",
        "雨雪のリング",
        "陣頭のリング",
        "謀略のリング",
        "闇夜のリング",
        "城兵のリング",
        "寺兵のリング",
        "支配者のリング",
        "独裁者のリング",
        "聖夜のリング",
        "速唱のリング",
        "漣のリング",
        "偽装のリングⅢ",
        "法閃のリングⅡ",
        "仁閃のリングⅡ",
        "円閃のリングⅡ",
    };
        [NonSerialized]
        public static List<string> accessoryTypeList = new List<string>
    {
        "種類",
        "ピアス",
        "リング",
    };
        [NonSerialized]
        public static List<string> medalList = new List<string>
    {
        "メダルを選択",
        "（武器）氷心氷結のUniqueメダル",
        "（武器）鮭乃富士のNamedメダル",
        "（武器）クインヒルのNamedメダル",
        "（武器）ゴウキンのNamedメダル",
        "（武器）霊王のUpperメダル",
        "（武器）霊妃のUpperメダル",
        "（武器）霊神のUpperメダル",
        "（武器）越辛苦のUpperメダル",
        "（武器）越苦杯のUpperメダル",
        "（武器）越苦難のUpperメダル",
        "（武器）桃源のUpperメダル",
        "（武器）消惑のUpperメダル",
        "（武器）朱雀門のSpecialメダル",
        "（武器）摩天楼のSpecialメダル",
        "（武器）道化師のSpecialメダル",
        "（武器）凍神楽のSpecialメダル",
        "（武器）鬼神楽のSpecialメダル",
        "（武器）仏神楽のSpecialメダル",
        "（武器）宇賀神のSpecialメダル",
        "（武器）付喪神のSpecialメダル",
        "（武器）真達羅のSpecialメダル",
        "（武器）雹絶覇のSpecialメダル",
        "（武器）雹絶詠のSpecialメダル",
        "（武器）炎絶覇のSpecialメダル",
        "（武器）炎絶詠のSpecialメダル",
        "（武器）右閻魔のSpecialメダル",
        "（武器）左閻魔のSpecialメダル",
        "（武器）瑠璃天母のSpecialメダル",
        "（武器）玻璃地母のSpecialメダル",
        "（武器）猛吹雪のSpecialメダル",
        "（武器）地吹雪のSpecialメダル",
        "（武器）颯のReverseメダル",
        "（武器）降誕祭のXmasメダル",
        "（武器）聖誕祭のXmasメダル",
        "（ピアス）怨辛苦のUpperメダル",
        "（ピアス）儚のReverseメダル",
        "（ピアス）巨邪鬼のメダル",
        "（ピアス）真神威のSpecialメダル",
        "（ピアス）偽神威のSpecialメダル",
        "（ピアス）真凌駕のSpecialメダル",
        "（ピアス）偽凌駕のSpecialメダル",
        "（ピアス）破天護法のSpecialメダル",
        "（ピアス）破地護法のSpecialメダル",
        "（リング）怨苦杯のUpperメダル",
        "（リング）湊のReverseメダル",
        "（リング）姫邪鬼のメダル",
        "（リング）杜若のメダル",
        "（リング）劫神薙のメダル",
        "（リング）刹神薙のメダル",
        "（リング）阿蘭若のメダル",
        "（リング）八重桜のメダル",
        "（リング）牡丹桜のメダル",
        "（リング）右明王のSpecialメダル",
        "（リング）左明王のSpecialメダル",
        "（リング）冬銀将のSpecialメダル",
        "（リング）冬銀師のSpecialメダル",
        "（防具）[CT]ジャイアントスロー・剛",
        "（防具）[BDC]ジャイアントスロー・剛",
        "（防具）[IDC]ジャイアントスロー・剛",
        "（防具）[HIT]ジャイアントスロー・剛",
        "（防具）[SC]ジャイアントスロー・剛",
        "（防具）[CT]不屈不撓",
        "（防具）[ST]不屈不撓",
        "（防具）[SC]不屈不撓",
        "（防具）[CT]剣山刀樹",
        "（防具）[BDC]剣山刀樹",
        "（防具）[SC]剣山刀樹",
        "（防具）[CT]防壁・羅生門",
        "（防具）[BDC]防壁・羅生門",
        "（防具）[IDC]防壁・羅生門",
        "（防具）[HIT]防壁・羅生門",
        "（防具）[SC]防壁・羅生門",
        "（防具）[CT]奇門遁甲",
        "（防具）[ST]奇門遁甲",
        "（防具）[SC]奇門遁甲",
        "（防具）[CT]怒髪衝天",
        "（防具）[ST]怒髪衝天",
        "（防具）[BDC]怒髪衝天",
        "（防具）[IDC]怒髪衝天",
        "（防具）[HIT]怒髪衝天",
        "（防具）[SC]怒髪衝天",
        "（防具）[CT]シャドウラッシュ",
        "（防具）[BDC]シャドウラッシュ",
        "（防具）[IDC]シャドウラッシュ",
        "（防具）[HIT]シャドウラッシュ",
        "（防具）[SC]シャドウラッシュ",
        "（防具）[CT]二ノ太刀イラズ",
        "（防具）[ST]二ノ太刀イラズ",
        "（防具）[SC]二ノ太刀イラズ",
        "（防具）[CT]マーダラーインク",
        "（防具）[ST]マーダラーインク",
        "（防具）[BDC]マーダラーインク",
        "（防具）[IDC]マーダラーインク",
        "（防具）[HIT]マーダラーインク",
        "（防具）[SC]マーダラーインク",
        "（防具）[CT]砲術グレネードランチャー",
        "（防具）[ST]砲術グレネードランチャー",
        "（防具）[BDC]砲術グレネードランチャー",
        "（防具）[IDC]砲術グレネードランチャー",
        "（防具）[HIT]砲術グレネードランチャー",
        "（防具）[SC]砲術グレネードランチャー",
        "（防具）[CT]連装発砲術",
        "（防具）[ST]連装発砲術",
        "（防具）[SC]連装発砲術",
        "（防具）[CT]砲術・ガトリングガン",
        "（防具）[ST]砲術・ガトリングガン",
        "（防具）[BDC]砲術・ガトリングガン",
        "（防具）[IDC]砲術・ガトリングガン",
        "（防具）[HIT]砲術・ガトリングガン",
        "（防具）[SC]砲術・ガトリングガン",
        "（防具）[CT]応急支援",
        "（防具）[ST]応急支援",
        "（防具）[SC]応急支援",
        "（防具）[CT]聖遁・サンクチュアリ",
        "（防具）[ST]聖遁・サンクチュアリ",
        "（防具）[SC]聖遁・サンクチュアリ",
        "（防具）[CT]仙人の菩提樹",
        "（防具）[SC]仙人の菩提樹",
        "（防具）[CT]グランドクロス",
        "（防具）[BDC]グランドクロス",
        "（防具）[IDC]グランドクロス",
        "（防具）[HIT]グランドクロス",
        "（防具）[SC]グランドクロス",
        "（防具）[ST]スケープゴート",
        "（防具）[SC]スケープゴート",
        "（防具）[CT]輪廻転生",
        "（防具）[ST]輪廻転生",
        "（防具）[SC]輪廻転生",
        "（防具）[CT]火遁・ニトロスパイク",
        "（防具）[ST]火遁・ニトロスパイク",
        "（防具）[BDC]火遁・ニトロスパイク",
        "（防具）[IDT]火遁・ニトロスパイク",
        "（防具）[HIT]火遁・ニトロスパイク",
        "（防具）[SC]火遁・ニトロスパイク",
        "（防具）[CT]雷遁・サンダーストーム",
        "（防具）[ST]雷遁・サンダーストーム",
        "（防具）[BDC]雷遁・サンダーストーム",
        "（防具）[IDC]雷遁・サンダーストーム",
        "（防具）[HIT]雷遁・サンダーストーム",
        "（防具）[SC]雷遁・サンダーストーム",
        "（防具）[CT]エナジーストライク",
        "（防具）[BDC]エナジーストライク",
        "（防具）[IDC]エナジーストライク",
        "（防具）[HIT]エナジーストライク",
        "（防具）[SC]エナジーストライク",
        "（防具）[CT]火遁・グランドボム",
        "（防具）[ST]火遁・グランドボム",
        "（防具）[BDC]火遁・グランドボム",
        "（防具）[IDC]火遁・グランドボム",
        "（防具）[SC]火遁・グランドボム",
        "（防具）[CT]聖遁・ゴリョウカク",
        "（防具）[SC]聖遁・ゴリョウカク",
        "（防具）[CT]闇遁・ブラックホール",
        "（防具）[ST]闇遁・ブラックホール",
        "（防具）[BDC]闇遁・ブラックホール",
        "（防具）[IDC]闇遁・ブラックホール",
        "（防具）[SC]闇遁・ブラックホール",
        "（防具）修練のメダル・STR",
        "（防具）修練のメダル・DEX",
        "（防具）修練のメダル・VIT",
        "（防具）修練のメダル・MND",
        "（防具）修練のメダル・AGI",
        "（防具）修練のメダル・INT",
    };
        [NonSerialized]
        public static List<string> medalTypeList = new List<string>
    {
        "種類",
        "（武器）",
        "（ピアス）",
        "（リング）",
        "（防具）",
    };
        [NonSerialized]
        public static List<string> talentList = new List<string>
    {
        "アイテムを選択",
        "新異能：[GLA]不鎖",
        "新異能：[GUA]奈護",
        "新異能：[SHA]不政",
        "新異能：[GUN]句夢",
        "新異能：[PRI]羅奈",
        "新異能：[CRU]伊江",
        "新異能：[WIZ]濡賀",
        "新異能：[SAG]栖主",
        "新異能：[GLA]愚亜",
        "新異能：[GUA]御武",
        "新異能：[SHA]迦唖",
        "新異能：[GUN]矢雅",
        "新異能：[PRI]春日",
        "新異能：[CRU]具波",
        "新異能：[WIZ]苦頓",
        "新異能：[SAG]煤覇",
        "新禁忌：[GLA]Lv1 栄梵ノ術",
        "新禁忌：[GLA]Lv2 栄梵ノ術",
        "新禁忌：[GLA]Lv3 栄梵ノ術",
        "新禁忌：[GLA]Lv4 栄梵ノ術",
        "新禁忌：[GLA]Lv5 栄梵ノ術",
        "新禁忌：[GUA]Lv1 黄衣ノ術",
        "新禁忌：[GUA]Lv2 黄衣ノ術",
        "新禁忌：[GUA]Lv3 黄衣ノ術",
        "新禁忌：[GUA]Lv4 黄衣ノ術",
        "新禁忌：[GUA]Lv5 黄衣ノ術",
        "新禁忌：[SHA]Lv1 妖蛆ノ術",
        "新禁忌：[SHA]Lv2 妖蛆ノ術",
        "新禁忌：[SHA]Lv3 妖蛆ノ術",
        "新禁忌：[SHA]Lv4 妖蛆ノ術",
        "新禁忌：[SHA]Lv5 妖蛆ノ術",
        "新禁忌：[GUN]Lv1 瀬羅ノ術",
        "新禁忌：[GUN]Lv2 瀬羅ノ術",
        "新禁忌：[GUN]Lv3 瀬羅ノ術",
        "新禁忌：[GUN]Lv4 瀬羅ノ術",
        "新禁忌：[GUN]Lv5 瀬羅ノ術",
        "新禁忌：[PRI]Lv1 納異ノ術",
        "新禁忌：[PRI]Lv2 納異ノ術",
        "新禁忌：[PRI]Lv3 納異ノ術",
        "新禁忌：[PRI]Lv4 納異ノ術",
        "新禁忌：[PRI]Lv5 納異ノ術",
        "新禁忌：[CRU]Lv1 断罪ノ術",
        "新禁忌：[CRU]Lv2 断罪ノ術",
        "新禁忌：[CRU]Lv3 断罪ノ術",
        "新禁忌：[CRU]Lv4 断罪ノ術",
        "新禁忌：[CRU]Lv5 断罪ノ術",
        "新禁忌：[WIZ]Lv1 死霊ノ術",
        "新禁忌：[WIZ]Lv2 死霊ノ術",
        "新禁忌：[WIZ]Lv3 死霊ノ術",
        "新禁忌：[WIZ]Lv4 死霊ノ術",
        "新禁忌：[WIZ]Lv5 死霊ノ術",
        "新禁忌：[SAG]Lv1 瑠々ノ術",
        "新禁忌：[SAG]Lv2 瑠々ノ術",
        "新禁忌：[SAG]Lv3 瑠々ノ術",
        "新禁忌：[SAG]Lv4 瑠々ノ術",
        "新禁忌：[SAG]Lv5 瑠々ノ術",
    };
        [NonSerialized]
        public static List<string> talentTypeList = new List<string>
    {
        "新異能",
        "新禁忌",
    };
        [NonSerialized]
        public static List<string> petEggList = new List<string>
    {
        "アイテムを選択",
        "口寄せ獣の卵 黒兎（物理）",
        "口寄せ獣の卵 黒兎（術）",
        "口寄せ獣の卵 雪だるま 赤確定",
        "口寄せ獣の卵 トナカイ",
        "口寄せ獣の卵 紫お化け(物理)",
        "口寄せ獣の卵 紫お化け(術)",
        "口寄せ獣の卵 パックマン",
        "口寄せ獣の卵 猫又（黒）",
        "口寄せ獣の卵 猫又（白）",
        "口寄せ獣の卵 パンダ",
        "口寄せ獣の卵 猫又（三毛）",
    };
        [NonSerialized]
        public static List<string> consumeList = new List<string>
    {
        "アイテム名",
        "（リセット）ステータスリセットのボタン",
        "（リセット）スキルリセットのボタン",
        "（リセット）二次職リセットのボタン",
        "（鑑定）再鑑定チケット",
        "（強化）スカンジウム",
        "（強化）黄金の金槌",
        "（強化）黄金の超金槌",
        "（強化）金剛石の金槌",
        "（強化）超成功の金槌",
        "（強化）救済の風呂敷",
        "（強化）救済のハンカチ",
        "（メダル）LEGENDメダル引換券",
        "（メダル）カルサイト",
        "（メダル）ロードナイト",
        "（メダル）鉄製のドリル",
        "（進化）黄金のレンチ",
        "（進化）黄金の超レンチ",
        "（回復）活力ポーション（特上）",
        "（回復）活力ポーション（究極）",
        "（回復）兵糧丸ポーション（特上）",
        "（回復）兵糧丸ポーション（究極）",
        "（回復）完全回復ポーション",
        "（バフ）いのちのホットドッグ",
        "（バフ）指定移動の巻物",
        "（バフ）即時帰還の巻物",
        "（バフ）修理キット",
        "（バフ）鑑定キット",
        "（バフ）移動速度10％アップ(1H)",
        "（バフ）移動速度20％アップ(1H)",
        "（バフ）経験値10%アップ(1H)",
        "（バフ）経験値25%アップ(1H)",
        "（バフ）経験値50%アップ(1H)",
        "（バフ）経験値100%アップ(1H)",
        "（バフ）経験値200%アップ(1H)",
        "（バフ）経験値300%アップ(1H)",
        "（バフ）ドロップ率5%アップ(1H)",
        "（バフ）ドロップ率10%アップ(1H)",
        "（バフ）ドロップ率15%アップ(1H)",
        "（バフ）ドロップ率50%アップ(1H)",
        "（バフ）ドロップ率100%アップ(1H)",
        "（バフ）ドロップ率200%アップ(1H)",
        "（バフ）ドロップ率300%アップ(1H)",
        "（バフ）STR上限解放カプセル（＋1）",
        "（バフ）VIT上限解放カプセル（＋1）",
        "（バフ）INT上限解放カプセル（＋1）",
        "（バフ）MND上限解放カプセル（＋1）",
        "（バフ）AGI上限解放カプセル（＋1）",
        "（バフ）DEX上限解放カプセル（＋1）",
        "（バフ）STR上限解放カプセル（＋2）",
        "（バフ）VIT上限解放カプセル（＋2）",
        "（バフ）INT上限解放カプセル（＋2）",
        "（バフ）MND上限解放カプセル（＋2）",
        "（バフ）AGI上限解放カプセル（＋2）",
        "（バフ）DEX上限解放カプセル（＋2）",
        "（素材）宝箱のカギ",
        "（素材）古代の硬貨",
        "（玉手箱）闘技者の玉手箱",
        "（玉手箱）黒銀シリーズLE確定玉手箱",
    };
        [NonSerialized]
        public static List<string> consumeTypeList = new List<string>
    {
        "種類",
        "（リセット）",
        "（鑑定）",
        "（強化）",
        "（メダル）",
        "（進化）",
        "（回復）",
        "（バフ）",
        "（素材）",
    };
        [NonSerialized]
        public static List<string> ingotList = new List<string>
    {
        "種類を選択",
        "ただの金塊",
        "10倍の金塊",
        "100倍の金塊",
    };
        [NonSerialized]
        public static List<string> questItemList = new List<string>
    {
        "アイテム名",
        "（中忍試験）恵比寿の神石",
        "（中忍試験）寿老人の神石",
        "（煉獄の塔）古代の硬貨",
        "（幻境）爆薬[裏・オルドA]",
        "（幻境）爆薬[裏・オルドB]",
        "（幻境）爆薬[裏・オルドC]",
        "（幻境）爆薬[裏・古木A]",
        "（幻境）爆薬[裏・古木B]",
        "（幻境）爆薬[裏・古木C]",
        "（幻境）爆薬[裏・大滝A]",
        "（幻境）爆薬[裏・大滝B]",
        "（幻境）爆薬[裏・大滝C]",
    };
        [NonSerialized]
        public static List<string> itemNumList = new List<string>
    {
        "個数",
        "1個",
        "2個",
        "3個",
        "4個",
        "5個",
        "6個",
        "7個",
        "8個",
        "9個",
        "10個",
        "11個",
        "12個",
        "13個",
        "14個",
        "15個",
        "16個",
        "17個",
        "18個",
        "19個",
        "20個",
        "21個",
        "22個",
        "23個",
        "24個",
        "25個",
        "26個",
        "27個",
        "28個",
        "29個",
        "30個",
        "31個",
        "32個",
        "33個",
        "34個",
        "35個",
        "36個",
        "37個",
        "38個",
        "39個",
        "40個",
        "41個",
        "42個",
        "43個",
        "44個",
        "45個",
        "46個",
        "47個",
        "48個",
        "49個",
        "50個",
        "51個",
        "52個",
        "53個",
        "54個",
        "55個",
        "56個",
        "57個",
        "58個",
        "59個",
        "60個",
        "61個",
        "62個",
        "63個",
        "64個",
        "65個",
        "66個",
        "67個",
        "68個",
        "69個",
        "70個",
        "71個",
        "72個",
        "73個",
        "74個",
        "75個",
        "76個",
        "77個",
        "78個",
        "79個",
        "80個",
        "81個",
        "82個",
        "83個",
        "84個",
        "85個",
        "86個",
        "87個",
        "88個",
        "89個",
        "90個",
        "91個",
        "92個",
        "93個",
        "94個",
        "95個",
        "96個",
        "97個",
        "98個",
        "99個",
    };

        [NonSerialized]
        public static List<string> alchemyItemList = new List<string>
        {
        "素材を選択",
        "御魂（紅）",
        "御魂（藍）",
        "御魂（翠）",
        "御魂（涅）",
        "御魂（深淵）",
        "御魂・極（深淵）",
        "御魂（喜悦）",
        "御魂・極（喜悦）",
        "御魂（悲涼）",
        "御魂・極（悲涼）",
        "御魂（奈落）",
        "御魂・極（奈落）",
        "御魂（激流）",
        "御魂・極（激流）",
        "呪魂（恐）",
        "呪魂（恨）",
        "呪魂（畏）",
        "呪魂（怨）",
        "呪魂（桃）",
        "呪魂・極（桃）",
        "（植物）青二才",
        "（植物）朝顔",
        "（植物）天道美人",
        "（植物）一周年記念花",
        "（植物）未熟草",
        "（植物）巨風草",
        "（植物）青鬼才",
        "（植物）昼顔",
        "（植物）万年美人",
        "（植物）サラフラワー",
        "（植物）ガーベラ",
        "（植物）ブラッドフラワー",
        "（植物）ケニーフラワー",
        "（植物）エバーゴールド",
        "（植物）ゴールドビショップ",
        "（植物）一周年記念バラ",
        "（植物）ゴールドクイーン",
        "（植物）エバーゴールド",
        "（植物）曼珠沙華",
        "（植物）幽霊沙華",
        "（植物）天上沙華",
        "（液体）ヘドロ水",
        "（液体）泥水",
        "（液体）塩水泥水",
        "（液体）一周年記念泥水",
        "（液体）腐敗水",
        "（液体）下水",
        "（液体）錆水",
        "（液体）雪水",
        "（液体）雨水",
        "（液体）海水",
        "（液体）純水",
        "（液体）アルカリイオン水",
        "（液体）マイナスイオン水",
        "（液体）オゾン水",
        "（液体）一周年記念イオン水",
        "（液体）貧酸素水",
        "（燃料）ミネラルオイル",
        "（燃料）一周年記念オイル",
        "（燃料）ナスティーオイル",
        "（燃料）酸性オイル",
        "（燃料）弱酸性油",
        "（燃料）軽油",
        "（燃料）重油",
        "（燃料）混合油",
        "（燃料）植物性油",
        "（燃料）灯油",
        "（燃料）石油",
        "（燃料）レギュラーガソリン",
        "（燃料）ハイオクガソリン",
        "（燃料）費用削減のオイル",
        "（鉱石）石ころ",
        "（鉱石）岩石",
        "（鉱石）火山岩",
        "（鉱石）隕石",
        "（鉱石）砂利",
        "（鉱石）小石",
        "（鉱石）突起石",
        "（鉱石）深層岩",
        "（鉱石）重鉱石",
        "（鉱石）銅鉱石",
        "（鉱石）固鉱石",
        "（鉱石）鉄鉱石",
        "（鉱石）銀鉱石",
        "（鉱石）光鉱石",
        "（鉱石）金鉱石",
        "（鉱石）鍵石",
        "（木材）モギ",
        "（木材）一周年記念樹木",
        "（木材）ブナ",
        "（木材）スギ",
        "（木材）キハダ",
        "（木材）キリ",
        "（木材）アオキ",
        "（木材）ササキ",
        "（木材）タカギ",
        "（木材）アカギ",
        "（木材）サカキ",
        "（木材）ツバキ",
        "（木材）クワ",
        "（木材）ケヤキ",
        "（木材）イブキ",
        "（木材）カブキ",
        "（木材）コバヤシ",
        "（木材）イブキ",
        "（木材）カシワギ",
        "（食材）ヤマトポテト",
        "（食材）エンペラーポテト",
        "（食材）ジャマポテト",
        "（食材）バロンポテト",
        "（食材）コムギ",
        "（食材）オオムギ",
        "（食材）ウオヌマ",
        "（食材）コメヒカリ",
        "（食材）オカボ",
        "（食材）タイマイ",
        "（食材）有精卵",
        "（食材）無精卵",
        "（食材）ブルーエッグ",
        "（食材）ニワトリスエッグ",
        "（食材）ドーヨ卵",
        "（食材）低脂肪ミルク",
        "（食材）濃厚ミルク",
        "（食材）ジャージャーミルク",
        "（食材）ミンチ",
        "（食材）モモ",
        "（食材）ロース",
        "（食材）ヒレ",
        "（食材）サーロイン",
        "（食材）白身魚",
        "（食材）赤身魚",
        "（食材）オキタナゴ",
        "（食材）新鮮野菜",
        "（食材）小エビ",
        "（食材）シャケ",
        "（食材）大エビ",
        "（食材）レッドタイガー",
        "（薬根）緑ハーブ",
        "（薬根）緑グッドハーブ",
        "（薬根）緑ハイパーハーブ",
        "（薬根）緑グレートハーブ",
        "（薬根）赤ハーブ",
        "（薬根）赤グッドハーブ",
        "（薬根）赤ハイパーハーブ",
        "（薬根）黄ハーブ",
        "（薬根）黄グッドハーブ",
        "（薬根）黄ハイパーハーブ",
        "（薬根）ウコン",
        "（薬根）葛根",
        "（薬根）腐根",
        "（薬根）巨大根",
        "（薬根）霧星大根",
        "（薬根）桔梗",
        "（薬根）当帰",
        "（薬根）柴胡",
        "（薬根）土まみれの根っこ",
        "（薬根）ネを上げた根っこ",
        "（薬根）甘草",
        "（薬根）苦参",
        "（薬根）高麗人参",
        "（薬根）長寿根",
        "（薬根）増幅丸",
        "（薬根）気力を奪う球根",
        "（粘土）紙粘土",
        "（粘土）油粘土",
        "（粘土）木粉粘土",
        "（粘土）石粉粘土",
        "（粘土）泥粘土",
        "（粘土）和紙粘土",
        "（粘土）石灰粘土",
        "（粘土）鉄粉粘土",
        "（粘土）ロウ粘土",
        "（粘土）樹脂粘土",
        "（粘土）銀粘土",
        "（粘土）かぎ粘土",
        "（粘土）毒性のある粘土",
        "（骨董品）カンテラ",
        "（骨董品）手錠",
        "（骨董品）カイガラ",
        "（機械）コイルバネ",
        "（機械）ネジリバネ",
        "（機械）板バネ",
        "（機械）古バネ",
        "（機械）皿ネジ",
        "（機械）丸皿ネジ",
        "（機械）六角ネジ",
        "（機械）組込みネジ",
        "（機械）座金組込みネジ",
        "（機械）六角ボルト",
        "（機械）六角穴付ボルト",
        "（機械）蝶付ボルト",
        "（機械）座金組込みボルト",
        "（機械）一周年記念ボルト",
        "（機械）蝶ボルト",
        "（機械）ローラーチェーン",
        "（機械）タイヤチェーン",
        "（機械）平歯車",
        "（機械）ハスバ歯車",
        "（機械）ヤマバ歯車",
        "（機械）冠歯車",
        "（機械）一周年記念歯車",
        "（機械）規格外の歯車",
        };
        #endregion
    }
}