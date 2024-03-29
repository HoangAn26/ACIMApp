﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
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
    [Persistent("MauIn")]
    [DefaultProperty("Ten")]
    [XafDisplayName("Printed Form Management")]
    public class MauIn: XPLiteObject
    {
        public MauIn(Session session) : base(session) { }
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
        string _ten;
        [XafDisplayName("Name of Printed Form")]
        public string Ten
        {
            get => _ten;
            set => SetPropertyValue("Ten", ref _ten, value);
        }
        DateTime? _ngayCapNhat;
        [XafDisplayName("Update Time")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime? ngayCapNhat
        {
            get => _ngayCapNhat;
            set => SetPropertyValue("ngayCapNhat", ref _ngayCapNhat, value);
        }
        FileData _fileMau;
        [XafDisplayName("Printed Form File")]
        public FileData fileMau
        {
            get => _fileMau;
            set => SetPropertyValue("fileMau", ref _fileMau, value);
        }
        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(false)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        [ValueConverter(typeof(ImageValueConverter))]
        [XafDisplayName("Image")]
        public Image anhMauIn
        {
            get { return GetPropertyValue<Image>("anhMauIn"); }
            set { SetPropertyValue<Image>("anhMauIn", value); }
        }
        [Association("MauIn-CapNhatMaus")]
        [XafDisplayName("Printed History")]
        public XPCollection<CapNhatMau> lichSuCapNhat
        {
            get => GetCollection<CapNhatMau>("lichSuCapNhat");
        }
        
    }
}
