var loginUrl = "http://localhost:5313/account/login";
if (!_ssoToken) {
    location.replace(loginUrl);
}

$(function () {
    $('#mainBanner a').click(function (e) {
        e.preventDefault();
        var href = this.href;
        if (href.indexOf('http') == 0) {
            var rootPath = getRootPath(href);
            location.assign(rootPath + "/ssologin?u=" + _ssoUser + "&t=" + _ssoToken + "&s=" + _ssoSession + "&r=" + encodeURI(href));
        }
    });
});

function getRootPath(href) {
    href = href.split("?")[0];
    var ss = href.split("/");
    ss.length = ss.length - 1;
    href = ss.join("/");
    return href;
}
