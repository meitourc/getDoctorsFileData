using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTownpageData
{
    class TownpageItem
    {
        public string itemName { get; set; } //名前
        public string itemKanaName { get; set; } //カナ名前
        public List<string> itemCategory { get; set; } //詳細業種

        public string itemDescription { get; set; } //紹介文
        public string itemPostalCode { get; set; } //郵便番号
        public string itemAddress{ get; set; } //住所
        public string itemTell { get; set; } //電話番号

        public string itemOfficialUrl { get; set; } //公式URL
        public List<string> itemNearStation { get; set; } //最寄り駅
        public string itemTownpageUrl { get; set; } //タウンページ詳細ページ
    }

    class TownpageAreaItem
    {
        public string areaCode{ get; set; } //エリアコード
        public string areaName { get; set; } //エリア名
    }
}
