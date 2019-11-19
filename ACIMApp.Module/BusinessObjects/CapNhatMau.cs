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
    [Persistent("CapNhatMau")]
    [DefaultProperty("NgayCapNhat")]
    [XafDisplayName("Update Form")]
    public class CapNhatMau:XPLiteObject
    {
        public CapNhatMau(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int _id;
        [Key(true)]
        [XafDisplayName("STT")]
        public int id
        {
            get => _id;
            set => SetPropertyValue("id", ref _id, value);
        }

        DateTime? _ngayCapNhat;
       
        [XafDisplayName("Update Time")]
        public DateTime? ngayCapNhat
        {
            get => _ngayCapNhat;
            set => SetPropertyValue("ngayCapNhat", ref _ngayCapNhat, value);
        }
        MauIn _mauIn;
        [Association("MauIn-CapNhatMaus")]
        public MauIn mauIn
        {
            get => _mauIn;
            set => SetPropertyValue("mauIn", ref _mauIn, value);
        }
        string _ghiChu;
        [XafDisplayName("Notes")]
        public string ghiChu
        {
            get => _ghiChu;
            set => SetPropertyValue("ghiChu", ref _ghiChu, value);
        }

    }
}
