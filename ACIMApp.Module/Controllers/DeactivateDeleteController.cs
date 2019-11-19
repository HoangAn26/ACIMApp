using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACIMApp.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace ACIMApp.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DeactivateDeleteController : ViewController
    {
        private const string Key = "Deactivation in code";
        DeleteObjectsViewController DeleteController;
        NewObjectViewController NewController;
        RefreshController refreshController;
        ModificationsController modificationsController;
        RecordsNavigationController recordsNavigationController;
        ResetViewSettingsController resetViewSettingsController;
        OpenObjectController openObjectController;
        

        public DeactivateDeleteController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            //Delete
            DeleteController =
            Frame.GetController<DeleteObjectsViewController>();
            if (DeleteController != null)
            {
                DeleteController.Active[Key] =
                    !(View.ObjectTypeInfo.Type == typeof(MauIn) && View is ListView);
            }
            //New
            NewController =
            Frame.GetController<NewObjectViewController>();
            if (NewController != null)
            {
                NewController.Active[Key] =
                    !(View.ObjectTypeInfo.Type == typeof(MauIn) && View is ListView);
            }
            //Refresh
            refreshController =
            Frame.GetController<RefreshController>();

            if (refreshController != null)
            {
                refreshController.Active[Key] =
                    !(View.ObjectTypeInfo.Type == typeof(MauIn) && View is ListView);
            }
            //Modification
            modificationsController =
            Frame.GetController<ModificationsController>();
            if (modificationsController != null)
            {
                modificationsController.Active[Key] =
                    !(View.ObjectTypeInfo.Type == typeof(MauIn) && View is ListView);
            }
            //recordsNavigationController
            recordsNavigationController =
            Frame.GetController<RecordsNavigationController>();
            if (recordsNavigationController != null)
            {
                recordsNavigationController.Active[Key] =
                    !(View.ObjectTypeInfo.Type == typeof(MauIn) && View is ListView);
            }
            // Reset View Settings
            resetViewSettingsController =
            Frame.GetController<ResetViewSettingsController>();
            if (resetViewSettingsController != null)
            {
                resetViewSettingsController.Active[Key] =
                    !(View.ObjectTypeInfo.Type == typeof(MauIn) && View is ListView);
            }
            //Open object
            openObjectController =
            Frame.GetController<OpenObjectController>();
            if (openObjectController != null)
            {
                openObjectController.Active[Key] =
                    !(View.ObjectTypeInfo.Type == typeof(MauIn) && View is ListView);
            }
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            if (DeleteController != null)
            {
                DeleteController.Active.RemoveItem(Key);
                DeleteController = null;
            }

            if (NewController != null)
            {
                NewController.Active.RemoveItem(Key);
                NewController = null;
            }

            if (refreshController != null)
            {
                refreshController.Active.RemoveItem(Key);
                refreshController = null;
            }

            if (modificationsController != null)
            {
                modificationsController.Active.RemoveItem(Key);
                modificationsController = null;
            }

            if (recordsNavigationController != null)
            {
                recordsNavigationController.Active.RemoveItem(Key);
                recordsNavigationController = null;
            }

            if (resetViewSettingsController != null)
            {
                resetViewSettingsController.Active.RemoveItem(Key);
                resetViewSettingsController = null;
            }

            if (openObjectController != null)
            {
                openObjectController.Active.RemoveItem(Key);
                openObjectController = null;
            }

            base.OnDeactivated();
        }
    }
}
