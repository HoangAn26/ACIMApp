﻿using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACIMApp.Module.BusinessObjects
{
    [XafDisplayName("Quyền Nhân Viên")]
    public class EmployeeRole : PermissionPolicyRole, IPermissionPolicyRoleWithUsers
    {

        public EmployeeRole(Session session) : base(session) { }

        protected override void OnLoading()
        {
            base.OnLoading();
        }
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        protected override void BeginEdit()
        {
            base.BeginEdit();
        }
        [Association("NguoiDungs-EmployeeRoles")]
        [XafDisplayName("Danh Sách Người Dùng")]
        public XPCollection<NguoiDung> NguoiDungs
        {
            get
            {
                return GetCollection<NguoiDung>("NguoiDungs");
            }
        }
        IEnumerable<IPermissionPolicyUser> IPermissionPolicyRoleWithUsers.Users
        {
            get { return NguoiDungs.OfType<IPermissionPolicyUser>(); }
        }
    }
}
