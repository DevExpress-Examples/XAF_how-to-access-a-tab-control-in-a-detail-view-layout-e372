var DXagent = navigator.userAgent.toLowerCase();
var DXopera = (DXagent.indexOf("opera") > -1);
var DXsafari = DXagent.indexOf("safari") > -1;
var DXie = (DXagent.indexOf("msie") > -1 && !DXopera);
var DXns = (DXagent.indexOf("mozilla") > -1 || DXagent.indexOf("netscape") > -1 || DXagent.indexOf("firefox") > -1) && !DXsafari && !DXie && !DXopera;
var resizeTimeout = null;

function DXattachEventToElement(element, eventName, func) {
    if (element) {
        if (DXns || DXsafari)
            element.addEventListener(eventName, func, true);
        else {
            if (eventName.toLowerCase().indexOf("on") != 0)
                eventName = "on" + eventName;
            element.attachEvent(eventName, func);
        }
    }
}
function DXGetElement(id) {
    if(document.getElementById != null) {
        return document.getElementById(id);
    }
    if(document.all != null) {
        return document.all[id];
    }
    if(document.layers != null) {
        return document.layers[id];
    }
    return null;
}
function DXGetElementHeight(id) {
    var el = DXGetElement(id);
    if(el) {
        return parseInt(el.offsetHeight);
    }
    return 0;
}
function DXGetWindowHeight() {
    var height = 0;
    if(typeof(window.innerHeight) == 'number') {
	    height = window.innerHeight;
    } else if(document.documentElement && document.documentElement.clientHeight) {
    	height = document.documentElement.clientHeight;
    } else if(document.body && document.body.clientHeight) {
	    height = document.body.clientHeight;                                                                                                                   
	}
    return parseInt(height);
}
function DXMoveFooter() {
    DXUpdateSplitterSize();
    resizeTimeout = null;
}
function DXUpdateSplitterSize() {
    DXUpdateSplitterWidth();
    DXUpdateSplitterHeight();
}
function DXUpdateSplitterHeight() {
    if (window.splitter) {
        splitter.width = "100%";
        var leftHeight = DXGetElementHeight('LeftPane');
        var rightHeight = DXGetElementHeight('ContentPane');
        var vAddition = 4;
        var newHeight = (leftHeight > rightHeight ? leftHeight : rightHeight) + vAddition;
        var currentHeight = splitter.GetHeight();

        var newMoveFooterHeight = DXGetWindowHeight() - (DXGetElementHeight('PageContent') - currentHeight);
        newHeight = newMoveFooterHeight > newHeight ? newMoveFooterHeight : newHeight;
        if(currentHeight < newHeight) {
            splitter.SetHeight(newHeight);
        }
    }
}
function DXUpdateSplitterWidth() {
    if (window.splitter) {
        splitter.width = "100%";
        var hAddition = -2;
        var paneElement = splitter.GetPaneByName('Content').helper.GetContentContainerElement();
        var scrollWidth = paneElement.scrollWidth;
        var offsetWidth = paneElement.offsetWidth;
        if (scrollWidth != offsetWidth) {
            splitter.SetWidth(splitter.GetWidth() + scrollWidth - offsetWidth + hAddition);
        }
    }
}
function DXWindowOnResize(evt) {
    if (resizeTimeout) {
        window.clearTimeout(resizeTimeout);
    }
    resizeTimeout = window.setTimeout(DXMoveFooter, 100);
}
