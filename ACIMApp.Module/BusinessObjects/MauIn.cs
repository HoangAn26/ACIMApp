﻿using DevExpress.Data.Filtering;
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
    [DefaultClassOptions]
    [Persistent("MauIn")]
    [DefaultProperty("Ten")]
    [XafDisplayName("Quản Lý Mẫu In")]
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
        [XafDisplayName("Tên Mẫu In")]
        public string Ten
        {
            get => _ten;
            set => SetPropertyValue("Ten", ref _ten, value);
        }
        [Association("MauIn-CapNhatMaus")]
        [XafDisplayName("Lịch Sử Cập Nhật")]
        public XPCollection<CapNhatMau> lichSuCapNhat
        {
            get => GetCollection<CapNhatMau>("lichSuCapNhat");
        }
        
    }
}