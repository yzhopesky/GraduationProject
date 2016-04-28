
//动态添加新的标签
function addTab(title, url) {
    var y = document.body.clientHeight - 130;
    var x = document.body.clientWidth;

    if ($('#div_main').tabs('exists', title)) {
        $('#div_main').tabs('select', title);
    } else {
        var content = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:' + y + 'px;margin:0;"></iframe>';
        $('#div_main').tabs('add', {
            title: title,
            content: content,
            closable: true
        });
    }
}
//退出的方法
function logout() {
    if ($.messager.confirm("确定要退出登陆吗？")) {

        $.ajax({
            url: '@Url.Action("Logout", "Home")',
            success: function () {
                window.location.href = '@Url.Action("Login", "Home")';
            }
        });
    }
}
//更改页面显示时间格式
function reSetTime(retime) {
    if (retime != null && retime.substr(0, 4) != "1799" && retime.substr(0, 4) != "0001" && retime.substr(0, 4) != "1970") {
        var msg = new Date(retime.replace("T", " ").replace("-", "/").replace("-", "/").substr(0, 19));
        var finalTime = msg.getFullYear() + "-" + (msg.getMonth() + 1) + "-" + msg.getDate();
        return finalTime;
        //return msg.toLocaleString();
        //return msg.toString().substr(0, 10);
    } else {
        return "";
    }

}
//更改页面显示时间格式
function reSetTimeLong(retime) {
    if (retime != null && retime.substr(0, 4) != "1799" && retime.substr(0, 4) != "0001" && retime.substr(0, 4) != "1970") {
        var msg = new Date(retime.replace("T", " ").replace("-", "/").replace("-", "/").substr(0, 19));

        var finalTime = msg.getFullYear() + "-" + (msg.getMonth() + 1) + "-" + msg.getDate() + " " + msg.getHours() + ":" + ("00" + msg.getMinutes()).substring(msg.getMinutes().toString().length, msg.getMinutes().toString().length + 2);
        return finalTime;
        //return msg.toLocaleString();
        //return msg.toString().substr(0, 10);
    } else {
        return "";
    }

}

//将时间戳形式的时间转换为时间
function ChangeDateFormat(val) {
    if (val != null) {
        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
        //月份为0-11，所以+1，月份小于10时补个0
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        return date.getFullYear() + "-" + month + "-" + currentDate;
    }

    return "";
}

//得到url中的数值
function GetRequest() {
    var url = location.search;//获取url中？后面的字符串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = strs[i].split("=")[1];
        }

    }
    return theRequest;
}