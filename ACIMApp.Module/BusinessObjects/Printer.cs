using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
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
    [XafDisplayName("Printer Information")]
    public class Printer: XPLiteObject
    {
        public Printer(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int _id;
        [Key(true)]
        [XafDisplayName("Printer ID")]
        public int maMay
        {
            get => _id;
            set => SetPropertyValue("id", ref _id, value);
        }
        string _tenMay;
        [XafDisplayName("Printer Name")]
        public string TenMay
        {
            get => _tenMay;
            set => SetPropertyValue("TenMay", ref _tenMay, value);
        }
        int _soGiayHienTai;
        [XafDisplayName("Current Number of Paper")]
        public int soGiayHienTai
        {
            get => _soGiayHienTai;
            set => SetPropertyValue("soGiayHienTai", ref _soGiayHienTai, value);
        }
        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(false)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        [ValueConverter(typeof(ImageValueConverter))]
        [XafDisplayName("Image")]
        public Image anh
        {
            get { return GetPropertyValue<Image>("anh"); }
            set { SetPropertyValue<Image>("anh", value); }
        }
        [Association("MayIn-LanThemGiays")]
        [XafDisplayName("History of Adding Paper")]
        public XPCollection<LanThemGiay> lichSuThemGiay
        {
            get => GetCollection<LanThemGiay>("lichSuThemGiay");
        }
        //Not Done
        

    }
}
