using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Controls;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Utils;
using DevExpress.XtraBars;

namespace ACIMApp.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class FontandIcon : WindowController
    {
        static FontandIcon()
        {
            AppearanceObject.DefaultFont = new Font("Segoe UI", 10);
            // Target required Windows (via the TargetXXX properties) and create their Actions.

        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target Window.
            Window.TemplateChanged += Window_TemplateChanged;
        }
        private void Window_TemplateChanged(object sender, EventArgs e)
        {
            if (Frame.Template is IBarManagerHolder)
            {
                BarManager manager = ((IBarManagerHolder)Frame.Template).BarManager;
                if (manager.Controller == null)
                {
                    manager.Controller = new BarAndDockingController();
                }
                var controller = manager.Controller;
                controller.AppearancesBar.MainMenu.Font = AppearanceObject.DefaultFont;
                controller.AppearancesBar.ItemsFont = AppearanceObject.DefaultFont;
            }
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            Window.TemplateChanged -= Window_TemplateChanged;
            base.OnDeactivated();
        }
    }
}
