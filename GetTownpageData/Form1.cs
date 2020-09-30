using Codeplex.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GetDoctorsFileData.Common;
using static GetDoctorsFileData.MessageManagement;
using static GetDoctorsFileData.DoctorsFileItem;






namespace GetDoctorsFileData
{
    public partial class Form1 : Form
    {

        //シングルトン
        static System.OperatingSystem os = System.Environment.OSVersion;
        static System.Text.Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
        static List<TownpageItem> townpageItemList = new List<TownpageItem>();
        static List<TownpageAreaItem> townpageAreaItemList = new List<TownpageAreaItem>();

        static List<DoctorsFileItem> doctorsFileDataList = new List<DoctorsFileItem>();


        static int SLEEP_TIME = 3000;
        int NO = 0;

        //処理状態メッセージ用変数
        static int PROC_STATUS = PROC_STANDBY;

        string OUTPUT_FOLDAR_PATH = "";
        

        



        public Form1()
        {
            InitializeComponent();
            conponentControl(PROC_STANDBY);
            //this.Size = new Size(2451, 811

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //業種コードのテキストボックスをデフォルトにする。
            radioButton1.Checked = true;
            textBox_keyword.Enabled = false;

            label_output_error1.Visible = false;

            //テスト用
            textBox_IndustryCode.Text = "66";
            //textBox_subgenre.Text = "70";
            textBox_area.Text = "03";
            textBox_output.Text = @"C:\Users\meito\OneDrive\Desktop\新しいフォルダー";
            //テスト用

        }
        /// <summary>
        /// 実行ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_exec_Click(object sender, EventArgs e)
        {
            OUTPUT_FOLDAR_PATH = textBox_output.Text;

            if (!checkOutputDirectory())
            {
                return;
            }

            //リストを初期化
            conponentControl(PROC_START);
            int i = 0;

            townpageItemList = new List<TownpageItem>();
            townpageAreaItemList = new List<TownpageAreaItem>();
            //string url = "https://doctorsfile.jp/search/pv666/page/2/";
            //string url = "https://doctorsfile.jp/search/pv666/page/";
            //string url = "https://doctorsfile.jp/search/ms72_pv666/page/2/";
            string targetUrl = "https://doctorsfile.jp/search/ms72_pv666/page/"; ;

            for (int pageNum = 1;pageNum <= 35;pageNum++)
            //for (int pageNum = 1; pageNum <= 2; pageNum++)
            {
                string url = targetUrl + pageNum + "/";
                ScrapingTownpageData(url);
            }

            csvWrite_doctorsFileData();
            //scrapingMain();
            //csvWrite_townpageData();

            conponentControl(PROC_END);

        }

        private bool checkOutputDirectory()
        {
            bool directoryExisitFlag = false;
            if (Directory.Exists(textBox_output.Text))
            {
                label_output_error1.Visible = false;
                directoryExisitFlag = true;
            }
            else
            {
                label_output_error1.Visible = true;
                directoryExisitFlag = false;
            }
            return directoryExisitFlag;
        }

        /// <summary>
        /// スクレイピングメイン処理
        /// </summary>
        private void scrapingMain()
        {

            string todoFukenCode = textBox_area.Text;
            getAreaData(todoFukenCode);


            TownpageItem townPageData = new TownpageItem();
            foreach (var areaData in townpageAreaItemList)
            {
                string baseUrl = "https://itp.ne.jp/search?";
                string urlParam_1 = "media=pc";
                string urlParam_2 = "sortby=01";
                string urlParam_3 = "size=100";
                string fromNum = "0";
                string urlParam_4 = "from=" + fromNum;
                string urlParam_5 = "";
                string urlParam_6 = "area=" + areaData.areaCode;

                if (radioButton1.Checked == true) {
                    urlParam_5 = "cat=" + textBox_IndustryCode.Text;

                    //urlParam_5 = "genre=" + textBox_IndustryCode.Text + 
                    //    AMPERSAND 
                    //    + "subgenre=" + textBox_subgenre.Text;

                }
                else {
                    urlParam_5 = "kw=" + textBox_keyword.Text;
                }

                string url = baseUrl
                    + urlParam_1 + AMPERSAND
                    + urlParam_2 + AMPERSAND
                    + urlParam_3 + AMPERSAND
                    + urlParam_4 + AMPERSAND
                    + urlParam_5 + AMPERSAND
                    + urlParam_6;

                int i = 0;
                //string url3 = "&size=20&from=" + i;

                //@空だったらとまるようにする。
                bool dataEmptyFlag = false;
                for (i = 0; true; i += 100)
                {
                    fromNum = i.ToString();
                    urlParam_4 = "from=" + fromNum;

                    url = baseUrl
                    + urlParam_1 + AMPERSAND
                    + urlParam_2 + AMPERSAND
                    + urlParam_3 + AMPERSAND
                    + urlParam_4 + AMPERSAND
                    + urlParam_5 + AMPERSAND
                    + urlParam_6;

                    //dataEmptyFlag = ScrapingTownpageData(url);
                    if (dataEmptyFlag)
                    {
                        break;
                    }
                    Thread.Sleep(SLEEP_TIME);
                }
            }

        }


        /// <summary>
        /// 都道府県コードから各都道府県の詳細エリアコードと詳細エリア名を取得
        /// </summary>
        /// <param name="todoFukenCode"></param>
        private void getAreaData(string todoFukenCode)
        {
            //string url = "https://support-api.itp.ne.jp/address/list?code=03";
            string url = "https://support-api.itp.ne.jp/address/list?code=" + todoFukenCode;


            Thread.Sleep(SLEEP_TIME);
            string jsonDataStr = getHtml(url);
            //Debug.WriteLine(htmlData);
            var jsonData = DynamicJson.Parse(jsonDataStr);


            //townpageTotalNumVar
            //string str = Convert.ToString(townpageTotalNumVar);
            //int townpageTotalNum = int.Parse(str);

            var jsonTownpageItems = jsonData.results;

            TownpageAreaItem townpageAreaItem = new TownpageAreaItem();
            try
            {
                foreach (var jsonTownpageItem in jsonTownpageItems)
                {
                    townpageAreaItem = new TownpageAreaItem();
                    Console.WriteLine("---------------------------------------------------------");

                    if (jsonTownpageItem.IsDefined("code"))
                    {
                        if (jsonTownpageItem.code != null)
                        {
                            Console.WriteLine(jsonTownpageItem.code);
                            townpageAreaItem.areaCode = jsonTownpageItem.code;
                        }
                    }

                    if (jsonTownpageItem.IsDefined("name"))
                    {
                        if (jsonTownpageItem.code != null)
                        {
                            Console.WriteLine(jsonTownpageItem.name);
                            townpageAreaItem.areaName = jsonTownpageItem.name;
                        }
                    }
                    townpageAreaItemList.Add(townpageAreaItem);
                }
            }catch(Exception ex)
            {
                conponentControl(PROC_ERROR);
                Console.WriteLine(ex + "Errorが発生しました。");
            }
        }




        /// <summary>
        /// スクレイピング処理
        /// </summary>
        /// <param name="url"></param>
        private void ScrapingTownpageData(string url)
        {

            Thread.Sleep(3000);
            string source = getHtml(url);
            //Console.WriteLine(source);
            string replaceHtmlData = getReplaceHtmlData(source);

            //Console.WriteLine(replaceHtmlData);

            //getTownpageTotalNum(jsonDataStr);
            //Debug.WriteLine(htmlData);

            string pattern = "<divclass=.result-header.>(.*?)<!--各種リンクend-->";
            MatchCollection match = extractingDataWithRegexMulti(replaceHtmlData, pattern);

            string baseUrl = "https://doctorsfile.jp/";
            string detailUrl = "";


            string source2 = "";
            string replaceHtmlData2 = "";

            try
            {
                // 何か例外が発生するかもしれないコード
                // ...

                foreach (Match m in match)
                {

                    Console.WriteLine("-------------------------------------------------------------------------");

                    detailUrl = "";
                    source2 = "";
                    replaceHtmlData2 = "";




                    //pattern = "<aclass=.result__name.href=.(.*?).>";
                    //String strItemDetailUrl = extractingDataWithRegexSingle(m.ToString(), pattern);
                    //Console.WriteLine(strItemDetailUrl);

                    //string pattern2 = "<aclass=.result__name.href=.(.*?).>";
                    //MatchCollection match2 = extractingDataWithRegexMulti(replaceHtmlData, pattern2);

                    string pattern2 = "<aclass=.result__name.href=.(.*?).>";
                    string url2 = extractingDataWithRegexSingle(m.ToString(), pattern2);
                    Console.WriteLine(url2);

                    detailUrl = baseUrl + url2;

                    if (detailUrl != "")
                    {


                        Thread.Sleep(SLEEP_TIME);
                        source2 = getHtml(detailUrl);
                        replaceHtmlData2 = getReplaceHtmlData(source2);


                        string pattern3 = "<!--#####パンくずend#####-->(.*?)<!--#####メイン・サブカラム構成start#####-->";
                        string match3 = extractingDataWithRegexSingle(replaceHtmlData2, pattern3);
                        //Console.WriteLine(doctorsFileItem.ItemTitle);

                        DoctorsFileItem doctorsFileItem = new DoctorsFileItem();


                        pattern2 = "name.:\"(.*?)\"";
                        doctorsFileItem.ItemTitle = extractingDataWithRegexSingle(match3, pattern2);
                        Console.WriteLine(doctorsFileItem.ItemTitle);

                        pattern2 = "telephone.:\"(.*?)\"";
                        doctorsFileItem.ItemTelephone = extractingDataWithRegexSingle(match3, pattern2);
                        Console.WriteLine(doctorsFileItem.ItemTelephone);

                        pattern2 = "postalCode.:\"(.*?)\"";
                        doctorsFileItem.ItemPostalCode = extractingDataWithRegexSingle(match3, pattern2);

                        Console.WriteLine(doctorsFileItem.ItemPostalCode);

                        pattern2 = "addressRegion.:\"(.*?)\"";
                        doctorsFileItem.ItemAddressRegion = extractingDataWithRegexSingle(match3, pattern2);

                        Console.WriteLine(doctorsFileItem.ItemAddressRegion);

                        pattern2 = "addressLocality.:\"(.*?)\"";
                        doctorsFileItem.ItemaddressLocality = extractingDataWithRegexSingle(match3, pattern2);

                        Console.WriteLine(doctorsFileItem.ItemaddressLocality);

                        pattern2 = "streetAddress.:\"(.*?)\"";
                        doctorsFileItem.ItemStreetAddress = extractingDataWithRegexSingle(match3, pattern2);
                        Console.WriteLine(doctorsFileItem.ItemStreetAddress);



                        doctorsFileItem.ItemDetailUrl = detailUrl;


                        NO++;
                        Console.WriteLine("***********************");
                        Console.WriteLine(NO);
                        Console.WriteLine("***********************");

                        doctorsFileDataList.Add(doctorsFileItem);


                    }
                    else
                    {
                        Console.WriteLine("抽出失敗：" + NO);
                    }
       

                    //if(NO == 3)
                    //{
                    //    break;
                    //}



                }
            }
            catch (Exception ex)
            {
                // 何もしない
                conponentControl(PROC_ERROR);
                Console.WriteLine(ex + "Errorが発生しました。");

            }

        }

        /// <summary>
        /// タウンページのデータ総数取得
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private int getTownpageTotalNum(string jsonDataStr)
        {
            //string jsonDataStr = getHtml(url);
            var jsonData = DynamicJson.Parse(jsonDataStr);
            var townpageTotalNumVar = jsonData.hits.total;
            //townpageTotalNumVar
            string str = Convert.ToString(townpageTotalNumVar);
            int townpageTotalNum = int.Parse(str);
            
            return townpageTotalNum;
        }


        private void csvWrite_doctorsFileData()
        {
            string nowDate = getNowDateByString();

            string output_file_path = OUTPUT_FOLDAR_PATH + @".\rakutenItemInfoResult" + nowDate + ".csv";
            //string output_file_name = @"\townpageDataeResult";
            string strData = ""; //1行分のデータ
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(output_file_path,
                                                                   false,
                                                                   System.Text.Encoding.Default);
                //ヘッダ書き込み
                strData = "名前" + DELIMITER +
                    "電話番号" + DELIMITER +
                    "郵便番号" + DELIMITER +
                    "住所1" + DELIMITER +
                    "住所2" + DELIMITER +
                    "住所3" + DELIMITER +
                    "URL";
                sw.WriteLine(strData);

                foreach (var data in doctorsFileDataList)
                {
                    strData =
                        DOUBLE_QUOTATION + data.ItemTitle + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.ItemTelephone + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.ItemPostalCode + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.ItemAddressRegion + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.ItemaddressLocality + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.ItemStreetAddress + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.ItemDetailUrl + DOUBLE_QUOTATION;


                    //DOUBLE_QUOTATION + ;data.itemNearStation + DOUBLE_QUOTATION + DELIMITER +

                    sw.WriteLine(strData);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                conponentControl(PROC_ERROR);
                Console.WriteLine(ex + "Errorが発生しました。");
            }


        }

        /// <summary>
        /// CSV書き込み
        /// </summary>
        private void csvWrite_townpageData()
        {
            string output_file_dir = @textBox_output.Text;
            string output_file_name = @"\townpageDataeResult";
            string strData = ""; //1行分のデータ

            

            DateTime dt = DateTime.Now;
            string dateStr = dt.ToString("yyyyMMddHHmm");

            output_file_name += "_" + dateStr + ".csv";
            string output_file_path = output_file_dir + output_file_name;

            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(output_file_path,
                                                                   false,
                                                                   System.Text.Encoding.Default);
                //ヘッダ書き込み
                strData = "名前" + DELIMITER +
                    "名前（カナ）" + DELIMITER +
                    "詳細業種" + DELIMITER +
                    "紹介文" + DELIMITER +
                    "郵便番号" + DELIMITER +
                    "住所" + DELIMITER +
                    "電話番号" + DELIMITER +
                    "公式URL" + DELIMITER +
                    "最寄駅" + DELIMITER +
                    "タウンページ詳細ページ";
                sw.WriteLine(strData);

                foreach (var data in townpageItemList)
                {
                    strData =
                        DOUBLE_QUOTATION + data.itemName + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.itemKanaName + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION;
                        foreach (var category in data.itemCategory)
                        {
                            strData += category;
                            strData += "/";
                        }
                    strData +=
                        DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.itemDescription + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.itemPostalCode + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.itemAddress + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.itemTell + DOUBLE_QUOTATION + DELIMITER +
                        DOUBLE_QUOTATION + data.itemOfficialUrl + DOUBLE_QUOTATION + DELIMITER +

                        DOUBLE_QUOTATION;
                    foreach (var nearStation in data.itemNearStation)
                    {
                        strData += nearStation;
                        strData += "/";
                    }

                    strData +=
                        DOUBLE_QUOTATION + DELIMITER + DOUBLE_QUOTATION +
                       data.itemTownpageUrl + DOUBLE_QUOTATION;
                    //DOUBLE_QUOTATION + ;data.itemNearStation + DOUBLE_QUOTATION + DELIMITER +
 
                    sw.WriteLine(strData);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                conponentControl(PROC_ERROR);
                Console.WriteLine(ex + "Errorが発生しました。");
            }

        }


        //private void scarapingTownpageData(string source){
        //
        //    //Debug.WriteLine(source);
        //
        //    string replaceHtmlData = getReplaceHtmlData(source);
        //
        //
        //    string pattern = "m-article-card__body(.*?)http://www.w3.org/2000/svg";
        //    //Debug.WriteLine("---------------------------------------------------------------");
        //
        //    MatchCollection match = extractingDataWithRegexMulti(replaceHtmlData, pattern);
        //
        //    try
        //    {
        //        foreach (Match m in match)
        //        {
        //            //タイトル
        //            pattern = "m-article-card__header__title__link\".*\">(.*?)</a></h1>";
        //            String strItemTitle = extractingDataWithRegexSingle(m.ToString(), pattern);
        //            Debug.WriteLine("-----------------------");
        //            Debug.WriteLine(strItemTitle);
        //            Debug.WriteLine("-----------------------");
        //
        //
        //        }
        //    }
        //
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex + "Errorが発生しました。");
        //    }
        //
        //    Debug.WriteLine(replaceHtmlData);
        //
        //    townpageItemList = new List<TownpageItem>();
        //}

        /// <summary>
        /// 処理途中はボタンおよびラベルを無効化する
        /// </summary>
        private void conponentControl(int procStatus)
        {
            PROC_STATUS = procStatus;
            if (PROC_STATUS == PROC_STANDBY)
            {
                label_procStatus.Text = "--スタンバイ--";
                label_procStatus.ForeColor = System.Drawing.Color.Black;
                buttonAndTextBoxControl(true);
            }

            if (PROC_STATUS == PROC_START)
            {
                label_procStatus.Text = "--処理を実行しています--";
                label_procStatus.ForeColor = System.Drawing.Color.Black;
                buttonAndTextBoxControl(true);
            }
            else if (PROC_STATUS == PROC_END)
            {
                label_procStatus.Text = "--処理が完了しました--";
                label_procStatus.ForeColor = System.Drawing.Color.Blue;
                //buttonAndTextBoxControl(true);
            }
            else if (PROC_STATUS == PROC_ERROR)
            {
                label_procStatus.Text = "--処理の途中にエラーが発生しました--\n";
                label_procStatus.ForeColor = System.Drawing.Color.Red;
                buttonAndTextBoxControl(true);
            }
        }


        /// <summary>
        /// ボタンとテキストボックスのコントロール（実行中は非活性）
        /// </summary>
        /// <param name="statusIsReady"></param>
        private void buttonAndTextBoxControl(bool status)
        {
            bool isEnabled = status;
            if (status)
            {
                button_exec.Enabled = isEnabled;
                textBox_area.Enabled = isEnabled;
                textBox_keyword.Enabled = isEnabled;
            }
            else
            {
                button_exec.Enabled = isEnabled;
                textBox_area.Enabled = isEnabled;
                textBox_keyword.Enabled = isEnabled;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_IndustryCode.Enabled = true;
            textBox_subgenre.Enabled = true;
            textBox_keyword.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_IndustryCode.Enabled = false;
            textBox_subgenre.Enabled = false;
            textBox_keyword.Enabled = true; ;
        }

        private void button_output_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            folderBrowserDialog1.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            //folderBrowserDialog1.SelectedPath = @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            folderBrowserDialog1.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                Console.WriteLine(folderBrowserDialog1.SelectedPath);
                textBox_output.Text = folderBrowserDialog1.SelectedPath; ;
                OUTPUT_FOLDAR_PATH = textBox_output.Text;
            }
        }

    }

}
