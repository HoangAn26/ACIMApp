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
    [Persistent("UserInfo")]
    [DefaultProperty("TenNguoiDung")]
    [XafDisplayName("Người Dùng")]
    public class UserInfo : XPLiteObject
    {
        public UserInfo(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        protected override void OnSaving()
        {
            base.OnSaving();
        }

        int _STT;
        [XafDisplayName("STT")]
        [Key(true)]
        public int STT
        {
            get => _STT;
            set => SetPropertyValue("STT", ref _STT, value);
        }
        string _tenNguoiDung;
        [XafDisplayName("Họ Và Tên")]
        public string tenNguoiDung
        {
            get => _tenNguoiDung;
            set => SetPropertyValue("tenNguoiDung", ref _tenNguoiDung, value);
        }
        int _MSSV;
        [XafDisplayName("MSSV")]
        public int MSSV
        {
            get => _MSSV;
            set => SetPropertyValue("MSSV", ref _MSSV, value);
        }
        
        
    }
}
