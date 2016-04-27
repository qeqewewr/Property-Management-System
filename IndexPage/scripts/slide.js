$(function () {
    (function ($) {
        var $slide = $('.slide');
        var $lists = $slide.find("li");
        var num = $lists.length;
        var firstShowNum = 0;
        var timeout = 4000;
        var mark;
        var currentNum = firstShowNum;

        var currentStyle = {
            color: 'white',
            background: "#1A4963"
        };
        var commonStyle = {
            color: '#1A4963',
            background: "white"
        }

        var init = function () {
            $slide.css('position', 'relative');
            var spanHtml = '', Html = '';

            for (var ii = 1; ii <= num; ii++) {
                spanHtml += '<span i="' + (ii - 1) + '" style="padding:3px 8px;display:inline-block;cursor:pointer;">' + ii + "</span>";
            }
            Html = '<div style="position:absolute;right:0;bottom:0;">' + spanHtml + "</div>";
            $slide.append(Html);

            if (firstShowNum > num) firstShowNum = num;
            $lists.hide().eq(firstShowNum).show();
            $slide.find('span').css(commonStyle).eq(firstShowNum).css(currentStyle);
        }

        var slide = function () {

            //var index = (i == undefined) ? currentNum : parseInt(i);
            var index = currentNum;
            $lists.hide().eq(index).show();
            $slide.find("span").css(commonStyle).eq(index).css(currentStyle);

            index = (index >= num - 1) ? 0 : (index + 1);
            
            currentNum = index;
        }

        var go = function () {
            window.clearInterval(mark);
            mark = window.setInterval(slide, timeout);
        }

        var stop = function () {
            window.clearInterval(mark);
        }
        init();
        $slide.hover(stop, go);

        $slide.find("span").hover(function () {
            stop();
            var index = parseInt($(this).attr('i'));
         
            currentNum = index;

            slide();
            $slide.find("span").css(commonStyle);
            $(this).css(currentStyle);
        }, go)

        go();
        //window.setInterval(go, timeout);
    })(jQuery);
});
