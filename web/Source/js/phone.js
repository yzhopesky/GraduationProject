$(document).ready(function () {
    //手机效果显示或隐藏
    $(".phone-button").click(function () {
        var div = $(".CRight-phone");
        var wth = $(".CRight-phone").width();
        if (wth < 299) {
            div.animate({ right: '5px', opacity: '1' }, "slow");
            div.animate({ width: '299px', opacity: '1' }, "slow");
            div.children(".phone-ys").animate({ right: '22px', opacity: '1' }, "slow");
            div.children(".phone-ys").animate({ width: '252px', opacity: '1' }, "slow");
            $(".phone-content").show("slow");
        } else {
            div.animate({ width: '5px', opacity: '1' }, "slow");
            div.animate({ right: '0px', opacity: '1' }, "slow");
            div.children(".phone-ys").animate({ width: '0px', opacity: '1' }, "slow");
            div.children(".phone-ys").animate({ right: '0px', opacity: '1' }, "slow");
            $(".phone-content").hide("slow");
        }

    });
});