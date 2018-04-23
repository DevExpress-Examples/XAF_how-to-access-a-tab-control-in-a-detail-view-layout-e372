using System;
using DevExpress.ExpressApp;
using System.Web.UI;
using DevExpress.ExpressApp.Editors;
using DevExpress.Web.ASPxTabControl;
using System.Drawing;

namespace MainDemo.Module.Web {
    public partial class CustomizeASPxTabControlViewController : ViewController {
        public CustomizeASPxTabControlViewController() {
            InitializeComponent();
            RegisterActions(components);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.ControlsCreated += new EventHandler(View_ControlsCreated);
        }
        protected override void OnDeactivating() {
            View.ControlsCreated -= new EventHandler(View_ControlsCreated);
            base.OnDeactivating();
        }
        void View_ControlsCreated(object sender, EventArgs e) {
            ((Control)View.Control).PreRender += new EventHandler(CustomizeASPxTabControlViewController_PreRender);
        }
        void CustomizeASPxTabControlViewController_PreRender(object sender, EventArgs e) {
            ((Control)View.Control).PreRender -= new EventHandler(CustomizeASPxTabControlViewController_PreRender);
            DetailView detailView = (DetailView)View;
            foreach (ListPropertyEditor editor in detailView.GetItems<ListPropertyEditor>()) {
                ASPxTabControlBase tabControl = FindASPxTabControl(editor.Control as Control) as ASPxTabControlBase;
                if (tabControl != null) {
                    CustomizeASPxTabControl(tabControl);
                }
            }
        }
        private Control FindASPxTabControl(Control control) {
            if (control == null || control is ASPxTabControlBase) {
                return control;
            }
            else {
                return FindASPxTabControl(control.Parent);
            }
        }
        private void CustomizeASPxTabControl(ASPxTabControlBase tabControl) {
            tabControl.ContentStyle.Border.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            tabControl.ContentStyle.Border.BorderWidth = 5;
            tabControl.ContentStyle.Border.BorderColor = Color.Red;
        }
    }
}