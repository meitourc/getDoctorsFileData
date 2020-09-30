using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDoctorsFileData
{
    class DoctorsFileItem
    {
        public string ItemTitle { get; set; } //名前
        public string ItemTelephone { get; set; } //電話番号
        public string ItemPostalCode { get; set; } //郵便番号
        public string ItemAddressRegion { get; set; } //都道府県
        public string ItemaddressLocality { get; set; } //市区町村
        public string ItemStreetAddress { get; set; } //番地
        public string ItemDetailUrl { get; set; } //詳細ページ

    }


}
