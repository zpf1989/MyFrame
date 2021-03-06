﻿using MyFrame.RBAC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebApp.Core.Models;

namespace WebApp.Extensions.Session
{
    public static class SessionExtension
    {
        const string KEY_USER_ID = "UserId";
        const string KEY_USER_NAME = "UserName";
        const string KEY_USER_DETAIL = "UserDetail";
        const string KEY_ROLEID_LIST = "RoleIds";
        const string KEY_ROLE_TEXT = "RoleText";
        public static int? GetUserId(this HttpSessionStateBase state)
        {
            return state.Get<int?>(KEY_USER_ID);
        }

        public static string GetUserName(this HttpSessionStateBase state)
        {
            return state.Get<string>(KEY_USER_NAME);
        }

        public static void SetUser(this HttpSessionStateBase state, User usr)
        {
            state.Set(KEY_USER_ID, usr.Id);
            state.Set(KEY_USER_NAME, usr.UserName);
        }

        public static void SetUserDetail(this HttpSessionStateBase state, UserDetails usrDetails)
        {
            state.Set(KEY_USER_DETAIL, usrDetails);
        }

        public static UserDetails GetUserDetail(this HttpSessionStateBase state)
        {
            return state.Get<UserDetails>(KEY_USER_DETAIL);
        }

        public static void SetRoleIds(this HttpSessionStateBase state, int[] roleIds)
        {
            state.Set(KEY_ROLEID_LIST, roleIds);
        }

        public static void SetRoleText(this HttpSessionStateBase state, string roles)
        {
            state.Set(KEY_ROLE_TEXT, roles);
        }

        public static int[] GetRoleIds(this HttpSessionStateBase state)
        {
            return state.Get<int[]>(KEY_ROLEID_LIST);
        }

        public static string GetRoleText(this HttpSessionStateBase state)
        {
            return state.Get<string>(KEY_ROLE_TEXT);
        }

        public static void Set(this HttpSessionStateBase state, string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            state.Add(key, value);
        }

        public static TResult Get<TResult>(this HttpSessionStateBase state, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return default(TResult);
            }
            return (TResult)state[key];
        }
    }
}