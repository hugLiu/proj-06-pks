(function () {
    //页面初始化
    $(document).ready(function () {
        getMenuInfo();
    });
    ///调用API得到菜单
    function getMenuInfo()
    {
        try {
            var link = "/scripts/HeaderController/MenuFunction.json";
            var promise = ajaxCallByURL(link, "GET", { userid: 1 }, false);
            promise.fail(function (jqXHR, textStatus, err) {
                console.log(textStatus + " - " + err.message);
            });
            promise.done(function (result) {
                if (typeof (result) != "undefined" ) 
                {
                    buildMenu(result);
                }
            });
        }
        catch (err) {
            console.error("ERROR - Get Menu - Unable to getMenuInfo: " + err.message);
        }
    }
    //创建菜单
    function buildMenu(menuObj)
    {

    }
    ///ajax调用
    function ajaxCallByURL(link, method, data, async)
    {
        if(link.indexOf("data") == 0 || link.indexOf("/data") == 0){
            method = "POST"; 
        }
        else if (link.indexOf(".json") > 0 || link.indexOf(".txt") > 0) {
            method = "GET"; // Override for DEV/Test development, for your local env, we have freedom to do POST
        }
        var way = true;	
        if (typeof(async) == "boolean" ) {
            way = async;
        }
	
        if(typeof data == "object")
            data = JSON.stringify(data);
		
        try {
            if (link) {	
                var promise = $.ajax({
                    url : link,
                    dataType : "json",
                    data : data,
                    type: method,
                    async: way,
                    contentType: "application/json; charset=utf-8",
                    processData: false,
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.error("ERROR - ajaxCallByURL() - Unable to retrieve URL: " + link + ". " + errorThrown);
                    }
                });						
                return promise;	
            }
            else {
                return null;
            }
        }
        catch(err) {
            console.error("ERROR - URLManager.ajaxCallByURL() - Unable to retrieve URL: " + err.message);
            return "";
        }
    };

})();