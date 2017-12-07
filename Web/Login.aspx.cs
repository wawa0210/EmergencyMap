using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Value.Trim();
            string userPwd = txtPassword.Value.Trim();

            if (userName.Equals("") || userPwd.Equals(""))
            {
                return;
            }
            if (Session["AdminLoginSun"] == null)
            {
                Session["AdminLoginSun"] = 1;
            }
            else
            {
                Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
            }
            //判断登录错误次数
            if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 10)
            {
                // msgtip.InnerHtml = "错误超过10次，关闭浏览器重新登录！";
                return;
            }

            var manager = BLL_Manager.GetManager(userName, userPwd); //根据用户名 账号 判断是否存在用户
            if (manager == null)
            {
                //msgtip.InnerHtml = "用户名或密码有误，请重试！";
                return;
            }

            Session["ManagerModel"] = manager; //存入session
            Session["UserName"] = manager.UserName; //存入session
            Session.Timeout = 180; //过期时间 session（3小时过期）

            ////记录操作日志
            //Med_Model.Sys_Log sysLog = new Med_Model.Sys_Log
            //{
            //    UserId = manager.Id,
            //    UserName = manager.UserName,
            //    ActionType = CommonEnum.ActionType.Login.ToString(),
            //    ActionDetails = "登录操作",
            //    UserIp = DTRequest.GetIP()
            //};
            //if (BLL_SysLog.AddLog(sysLog) > 1) //登录日志记录成功
            //{
            //    //写入Cookies
            //    Utils.WriteCookie("AdminName", "Med", manager.UserName);
            //    Utils.WriteCookie("AdminPwd", "Med", manager.UserPwd);
            //    Response.Redirect("Main.aspx");
            //}

        }
    }
}