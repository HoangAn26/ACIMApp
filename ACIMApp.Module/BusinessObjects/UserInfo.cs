using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
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
    [Persistent("UserInfo")]
    [DefaultProperty("TenNguoiDung")]
    [XafDisplayName("Thông Tin Người Dùng")]
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
        public string TenNguoiDung
        {
            get => _tenNguoiDung;
            set => SetPropertyValue("tenNguoiDung", ref _tenNguoiDung, value);
        }
        public enum GioiTinh
        {
            Nam = 0,
            [XafDisplayName("Nữ")]
            Nu = 1
        }
        GioiTinh _gioiTinh;
        [XafDisplayName("Giới Tính")]
        public GioiTinh gioiTinh
        {
            get => _gioiTinh;
            set => SetPropertyValue("gioiTinh", ref _gioiTinh, value);
        }
        string _MSSV;
        [XafDisplayName("MSSV/MSNV")]
        public string MSSV
        {
            get => _MSSV;
            set => SetPropertyValue("MSSV", ref _MSSV, value);
        }
        public enum Khoa
        {
            [XafDisplayName("ĐIỆN-ĐIỆN TỬ")]
            MayDienDienTu=0,
            [XafDisplayName("KỸ THUẬT XÂY DỰNG")]
            XayDung=1,
            [XafDisplayName("CƠ KHÍ")]
            CoKhi=2,
            [XafDisplayName("KỸ THUẬT HÓA HỌC")]
            HoaHoc=3,
            [XafDisplayName("KHOA HỌC VÀ KỸ THUẬT MÁY TÍNH")]
            Maytinh=4,
            [XafDisplayName("CÔNG NGHỆ VẬT LIỆU")]
            VatLieu=5,
            [XafDisplayName("KHOA HỌC ỨNG DỤNG")]
            UngDung=6,
            [XafDisplayName("KỸ THUẬT GIAO THÔNG")]
            GiaoThong=7,
            [XafDisplayName("KỸ THUẬT VÀ ĐỊA CHẤT DẦU KHÍ")]
            DauKhi=8,
            [XafDisplayName("MÔI TRƯỜNG VÀ TÀI NGUYÊN")]
            MoiTruong=9,
            [XafDisplayName("QUẢN LÝ CÔNG NGHIỆP")]
            QuanLyCongNghiep = 10,
            [XafDisplayName("TRUNG TÂM BẢO DƯỠNG CÔNG NGHIỆP")]
            BaoDuongCongNghiep=11,
            [XafDisplayName("KỸ SƯ CHẤT LƯỢNG CAO PFIEV")]
            ChatLuongCao=12
        };
        Khoa _khoa;
        [XafDisplayName("Khoa")]
        public Khoa khoa
        {
            get => _khoa;
            set => SetPropertyValue("khoa", ref _khoa, value);
        }
        string _SDT;
        [XafDisplayName("Số Điện Thoại")]
        public string SDT
        {
            get => _SDT;
            set => SetPropertyValue("SDT", ref _SDT, value);
        }
        //No have Hyper Link
        string _email;
        [XafDisplayName("Email")]
        [RuleRegularExpression("HyperLinkDemoObject.Url.RuleRegularExpression", DefaultContexts.Save, @"(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})")]
        [EditorAlias("HyperLinkStringPropertyEditor")]
        public string email
        {
            get => _email;
            set => SetPropertyValue("email", ref _email, value);
        }
        DateTime? _ngaySinh;
        [XafDisplayName("Ngày Sinh")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime? ngaySinh
        {
            get => _ngaySinh;
            set => SetPropertyValue("ngaySinh", ref _ngaySinh, value);
        }
        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(false)]
        [ImageEditor(ListViewImageEditorMode =ImageEditorMode.PictureEdit, DetailViewImageEditorMode =ImageEditorMode.PictureEdit)]
        [ValueConverter(typeof(ImageValueConverter))]
        [XafDisplayName("Ảnh Đại Diện")]
        public Image anh
        {
            get { return GetPropertyValue<Image>("anh"); }
            set { SetPropertyValue<Image>("anh", value); }
        }
        string _ghiChu;
        [XafDisplayName("Ghi Chú")]
        public string ghiChu
        {
            get => _ghiChu;
            set => SetPropertyValue("ghiChu", ref _ghiChu, value);
        }
    }
}
