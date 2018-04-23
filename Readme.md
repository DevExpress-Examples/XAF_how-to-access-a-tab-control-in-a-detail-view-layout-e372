# How to access a tab control in a Detail View layout


<p><strong>Scenario</strong><br> This example demonstrates how to implement a View Controller that will access layout controls and customize them as required. In particular, the second tab in the tab control should become active when opening the detail form.<br><br></p>
<p><strong>Steps to implement</strong></p>
<p><strong>1.</strong> This functionality is implemented in the <em>WinCustomizeTabControlViewController</em> and <em>WebCustomizeTabControlViewController</em> classes that are added into the WinForms and ASP.NET module projects respectively (copy these classes into the respective projects of your test solution). Take special note that on the Web we are activating a required tab on the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument6908">client side</a> instead of using the server-side <a href="https://documentation.devexpress.com/AspNet/clsDevExpressWebASPxTabControlBasetopic.aspx">ASPxTabControlBase</a> > <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxTabControlBase_ActiveTabIndextopic.aspx">ActiveTabIndex</a> property, which is not appropriate for updating tab control on external callbacks (<a href="https://www.devexpress.com/Support/Center/p/K18387">learn more...</a>).</p>
<p><strong>2.</strong> To identify the layout element by the "TabbedGroup" string, make sure this identifier is specified under the Views | YourBusinessObject_DetailView | Layout node in the Model Editor invoked for the YourSolutionName.Module/<em>Model.DesignedDiffs.xafml</em> file.<br><strong><br>See also:</strong> <br><a href="http://documentation.devexpress.com/#Xaf/CustomDocument2817"><u>eXpressApp Framework > Concepts > UI Construction > View Items Layout<br></u></a><u><a href="https://www.devexpress.com/Support/Center/p/T386111">How to show the number of the nested list view's items in the tab caption (Web)</a><br><a href="https://www.devexpress.com/Support/Center/p/T586150">How to set active tab in a Web DetailView layout after executing an Action</a><br></u></p>

<br/>


