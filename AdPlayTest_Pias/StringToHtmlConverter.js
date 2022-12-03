function ConvertStringToHtml(stingHtml) {
    var htmlContent = stingHtml;
    var e = document.createElement('div');
    e.setAttribute('style', 'display: none;');
    e.innerHTML = htmlContent;
    document.body.appendChild(e);
    var htmlConvertedIntoDom = e.lastChild.childNodes; 
    document.body.removeChild(e);
    return htmlConvertedIntoDom;
}