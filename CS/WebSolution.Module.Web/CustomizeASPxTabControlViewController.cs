using System;
using DevExpress.ExpressApp;
using System.Web.UI;
using DevExpress.ExpressApp.Editors;
using DevExpress.Web.ASPxTabControl;
using System.Drawing;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Web.Layout;
using DevExpress.ExpressApp.Model;

namespace MainDemo.Module.Web {
    public partial class CustomizeASPxTabControlViewController : ViewController {
        public CustomizeASPxTabControlViewController() {
            InitializeComponent();
            RegisterActions(components);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated() {
            base.OnActivated();
            ((WebLayoutManager)((DetailView)View).LayoutManager).ItemCreated += new EventHandler<ItemCreatedEventArgs>(CustomizeASPxTabControlViewController_ItemCreated); 
        }
        void CustomizeASPxTabControlViewController_ItemCreated(object sender, ItemCreatedEventArgs e) {
            if (e.ModelLayoutElement is IModelTabbedGroup) {
                CustomizeASPxTabControl(FindFirstControl<ASPxTabControlBase>(e.TemplateContainer));
            }
        }
        private T FindFirstControl<T>(Control parent) where T : Control {
            foreach (Control control in parent.Controls) {
                if (control is T) {
                    return (T)control;
                }
            }
            foreach (Control control in parent.Controls) {
                return FindFirstControl<T>(control);
            }
            return null;
        }
        protected override void OnDeactivated() {
            ((WebLayoutManager)((DetailView)View).LayoutManager).ItemCreated -= new EventHandler<ItemCreatedEventArgs>(CustomizeASPxTabControlViewController_ItemCreated); 
            base.OnDeactivated();
        }
        private void CustomizeASPxTabControl(ASPxTabControlBase tabControl) {
            tabControl.ActiveTabStyle.Border.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            tabControl.ActiveTabStyle.Border.BorderWidth = 5;
            tabControl.ActiveTabStyle.Border.BorderColor = Color.Red;
        }
    }
}