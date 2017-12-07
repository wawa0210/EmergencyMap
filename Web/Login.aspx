<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录界面</title>
    <link href="css/drag.css" rel="stylesheet" type="text/css" />
    <link href="css/home.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hidFlag" value="0" />
        <div class="banner-show" id="js_ban_content">
            <div class="cell bns-01">
                <div class="con"></div>
            </div>
        </div>
        <div class="container">
            <div class="register-box">
                <div class="reg-slogan">登录</div>
                <div class="reg-form" id="js-form-mobile">
                    <br />
                    <br />
                    <div class="cell">
                        <input type="text" runat="server" id="txtUserName" placeholder="账号" class="text" maxlength="11" />
                    </div>
                    <div class="cell">
                        <input type="password" runat="server" id="txtPassword" placeholder="密码" name="passwd" class="text" />
                    </div>
                    <div class="cell" id="drag"></div>


                    <div class="bottom">
                        <asp:Button ID="Button1" runat="server" CssClass="button btn-green" Text="登录" OnClientClick="return Hello();" OnClick="btnSubmit_Click" />
                    </div>
                </div>
                <div class="reg-form" id="js-form-mail" style="display: none;">
                </div>
            </div>
        </div>
    </form>

</body>
</html>

<script src="Script/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="js/drag.js" type="text/javascript"></script>

<script type="text/javascript">
    $('#drag').drag();
    $(function () {
        $("#hidFlag").val("0");

        var defaultInd = 0;
        var list = $('#js_ban_content').children();
        var count = 0;
        var change = function (newInd, callback) {
            if (count) return;
            count = 2;
            $(list[defaultInd]).fadeOut(400, function () {
                count--;
                if (count <= 0) {
                    if (start.timer) window.clearTimeout(start.timer);
                    callback && callback();
                }
            });
            $(list[newInd]).fadeIn(400, function () {
                defaultInd = newInd;
                count--;
                if (count <= 0) {
                    if (start.timer) window.clearTimeout(start.timer);
                    callback && callback();
                }
            });
        }

        var next = function (callback) {
            var newInd = defaultInd + 1;
            if (newInd >= list.length) {
                newInd = 0;
            }
            change(newInd, callback);
        }

        var start = function () {
            if (start.timer) window.clearTimeout(start.timer);
            start.timer = window.setTimeout(function () {
                next(function () {
                    start();
                });
            }, 8000);
        }

        start();

        $('#js_ban_button_box').on('click', 'a', function () {
            var btn = $(this);
            if (btn.hasClass('right')) {
                //next
                next(function () {
                    start();
                });
            }
            else {
                //prev
                var newInd = defaultInd - 1;
                if (newInd < 0) {
                    newInd = list.length - 1;
                }
                change(newInd, function () {
                    start();
                });
            }
            return false;
        });

    });

    function Hello() {
        var flag = $("#hidFlag").val();
        if (flag == "1") {
            return true;
        } else {
            return false;
        }
    }
</script>

