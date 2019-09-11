using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACIMApp.Module.BusinessObjects
{
    [Persistent("LichSuThemGiay")]
    public class LanThemGiay:XPLiteObject
    {
        public LanThemGiay(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int _id;
        [Key(true)]
        public int id
        {
            get => _id;
            set => SetPropertyValue("id", ref _id, value);
        }

        int _soGiayThem;
        [XafDisplayName("Số Giấy Thêm")]
        public int soGiayThem
        {
            get => _soGiayThem;
            set => SetPropertyValue("soGiayThem", ref _soGiayThem, value);
        }
        DateTime? _ngayThemGiay;
        [XafDisplayName("Ngày Thêm Giấy")]
        public DateTime? ngayThemGiay
        {
            get => _ngayThemGiay;
            set => SetPropertyValue("ngayThemGiay", ref _ngayThemGiay, value);
        }
        string _ghiChu;
        [XafDisplayName("Ghi Chú")]
        public string ghiChu
        {
            get => _ghiChu;
            set => SetPropertyValue("ghiChu", ref _ghiChu, value);
        }

        Printer _mayIn;
        [Association("MayIn-LanThemGiays")]
        public Printer mayIn
        {
            get => _mayIn;
            set => SetPropertyValue("mayIn", ref _mayIn, value);
        }
        

    }
}
