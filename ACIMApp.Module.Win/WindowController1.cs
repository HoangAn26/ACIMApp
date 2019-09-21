using System;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Controls;

namespace ACIMApp.Module.Win
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class WindowController1 : WindowController
    {
        static WindowController1()
        {
            AppearanceObject.DefaultFont = new Font("Segoe UI", 10);
        }
        //public WindowController1()
        //{
        //    InitializeComponent();
        //    // Target required Windows (via the TargetXXX properties) and create their Actions.
        //}
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
            Window.TemplateChanged -= Window_TemplateChanged;
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

    }
}
