﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Http;
using System.Web.Http.Controllers;

using Nutrition.Models;

namespace Nutrition.Authentication
{
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {

        private NutritionContext db = new NutritionContext();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);

            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if ((authorization != null) && !string.IsNullOrEmpty(authorization.Value))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Value;
                if (ValidateTicket(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

        //校验用户名密码（正式环境中应该是数据库校验）
        private bool ValidateTicket(string encryptTicket)
        {
            var ticket = FormsAuthentication.Decrypt(encryptTicket);

            if (db.Users.Any(user =>  user.Username + ":" + user.UserId.ToString() == ticket.UserData)) {
                return true;
            }

            return false;
        }
    }
}