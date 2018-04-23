using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;

using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Web.TestScripts;
using DevExpress.ExpressApp;

public partial class Default : System.Web.UI.Page, IWindowTemplate, IViewSiteTemplate, ISupportViewControlAdding {
    private ContextActionsMenu contextMenu;
    protected override void InitializeCulture() {
        base.InitializeCulture();
        WebApplication.Instance.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e) {
        contextMenu = new ContextActionsMenu(this, "RecordEdit", "ObjectsCreation", "ListView");
        Header.Title = WebApplication.Instance.Title;
        ApplicationTitle.Text = WebApplication.Instance.Title;
        ApplicationTitle.NavigateUrl = Request.ApplicationPath + "/";
        Copyright.Text = WebApplication.Instance.Info.GetAttributeValue("Copyright");
        ImageInfo logoImageInfo = ImageLoader.Instance.GetImageInfo(WebApplication.Instance.Info.GetAttributeValue("Logo", "ExpressAppLogo"));
        if (!logoImageInfo.IsEmpty) {
            LogoImage.ImageUrl = logoImageInfo.ImageUrl;
        }
        else {
            LogoImage.Visible = false;
        }
        WebApplication.Instance.CreateControls(this);
    }
    protected void Page_Prerender(object sender, EventArgs e) {
        if (TestScriptsManager.EasyTestEnabled) {
            ViewCaption.Attributes[EasyTestTagHelper.TestField] = "FormCaption";
            ViewCaption.Attributes[EasyTestTagHelper.TestControlClassName] = JSLabelTestControl.ClassName;
        }
    }
    public override void Dispose() {
        if (contextMenu != null) {
            contextMenu.Dispose();
            contextMenu = null;
        }
        base.Dispose();
    }

    #region IFrameTemplate Members

    public IActionContainer DefaultContainer {
        get { return ViewPresentationActionContainer; }
    }

    public ICollection<IActionContainer> GetContainers() {
        List<IActionContainer> result = new List<IActionContainer>();
        result.AddRange(contextMenu.Containers);
        result.AddRange(new IActionContainer[] {
			//!!!
            NavigationBarActionContainer1,
			//!!!
            SearchActionContainer,
			ContextObjectsCreationActionContainer,
			RecordsNavigationContainer,
			ListViewDataManagementActionContainer,
			ViewPresentationActionContainer,
			TopRecordEditActionContainer,
			BottomRecordEditActionContainer,
			DiagnosticActionContainer,
			ViewsHistoryNavigationContainer
		});
        return result.ToArray();
    }

    public void SetView(DevExpress.ExpressApp.View view) {
        ViewSite.Controls.Clear();
        if (view != null) {
            contextMenu.CreateControls(view);
            view.CreateControls();
            if (ViewControlAdding != null) {
                ViewControlAdding(this, EventArgs.Empty);
            }
            ViewSite.Controls.Add((Control)view.Control);
            view.DataBind();
            ViewCaption.Text = view.Caption;

            ImageInfo imageInfo = ImageLoader.Instance.GetLargeImageInfo(view.Info.GetAttributeValue("ImageName"));
            if (imageInfo.IsEmpty) {
                ViewImage.Visible = false;
            }
            else {
                ViewImage.ImageUrl = imageInfo.ImageUrl;
            }
            string colorString = view.Info.GetAttributeValue("BackColor");
            if (!string.IsNullOrEmpty(colorString)) {
                try {
                    KnownColor _color = (KnownColor)Enum.Parse(typeof(KnownColor), colorString);
                    ViewTitle.BackColor = Color.FromKnownColor(_color);
                } catch (Exception) { }
            }
        }
    }

    public void SetSettings(DictionaryNode settingsNode) { }
    public void ReloadSettings() { }
    public void SaveSettings() { }

    public void SetCaption(string caption) {
        Header.Title = caption;
    }

    public void SetStatus(System.Collections.Generic.ICollection<string> statusMessages) {
        InfoMessagesPanel.Text = string.Join("<br>", new List<string>(statusMessages).ToArray());
    }
    private bool isSizeable;
    public bool IsSizeable {
        get { return isSizeable; }
        set { isSizeable = value; }
    }
    public object ViewSiteControl {
        get { return ViewSite; }
    }
    public event EventHandler ViewControlAdding;
    #endregion
}
