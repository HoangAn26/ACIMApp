using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACIMApp.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("Printer")]
    [DefaultProperty("TenMay")]
    [XafDisplayName("Thông Tin Máy In")]
    public class Printer: XPLiteObject
    {
        public Printer(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int _id;
        [Key(true)]
        [XafDisplayName("Mã Máy In")]
        public int maMay
        {
            get => _id;
            set => SetPropertyValue("id", ref _id, value);
        }
        string _tenMay;
        [XafDisplayName("Tên Máy In")]
        public string TenMay
        {
            get => _tenMay;
            set => SetPropertyValue("TenMay", ref _tenMay, value);
        }
        int _soGiayHienTai;
        [XafDisplayName("Số Giấy Hiện Tai")]
        public int soGiayHienTai
        {
            get => _soGiayHienTai;
            set => SetPropertyValue("soGiayHienTai", ref _soGiayHienTai, value);
        }
        
        [Association("MayIn-LanThemGiays")]
        [XafDisplayName("Lịch Sử Thêm Giấy")]
        public XPCollection<LanThemGiay> lichSuThemGiay
        {
            get => GetCollection<LanThemGiay>("lichSuThemGiay");
        }
        //Not Done
        

    }
}
