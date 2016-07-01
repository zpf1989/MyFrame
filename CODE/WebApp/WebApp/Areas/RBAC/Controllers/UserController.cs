﻿using MyFrame.IService.RBAC;
using MyFrame.Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using WebApp.ViewModels.RBAC;
using MyFrame.Infrastructure.Extension;
using MyFrame.Infrastructure.Expression;
using MyFrame.Infrastructure.Pagination;
using MyFrame.Infrastructure.OptResult;
using WebApp.Extensions.Session;
using WebApp.Extensions.ActionResult;
using WebApp.Controllers;
using WebApp.Extensions.Filters;

namespace WebApp.Areas.RBAC.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userSrv;

        public UserController(IUserService userSrv)
        {
            _userSrv = userSrv;
        }

        /// <summary>
        /// 列表界面
        /// </summary>
        /// <returns></returns>
        [LoginCheckFilter]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetUsersByPage(int pageNumber, int pageSize)
        {
            Expression<Func<User, bool>> where = u => true;
            var userName = HttpContext.Request["UserName"];
            if (!string.IsNullOrEmpty(userName))
            {
                where = where.And(u => u.UserName.Contains(userName));
            }
            var pageArgs = new PageArgs { PageSize = pageSize, PageIndex = pageNumber };
            var result = _userSrv.FindByPage(where, new List<OrderByArgs<User>>()
            {
                new OrderByArgs<User>{
                    Expression = u => u.UserName,
                    OrderByType = OrderByType.Asc
                }
            }, pageArgs);

            if (result.ResultType == OperationResultType.Success)
            {
                return new JsonNetResult
                {
                    Data = new { code = result.ResultType, message = "数据获取成功", total = pageArgs.RecordsCount, rows = (result.AppendData as List<User>) },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    DateTimeFormat = "yyyy-MM-dd"
                };
            }
            else
            {
                return Json(new { code = result.ResultType, message = result.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            UserVM usrVM = new UserVM();
            return PartialView(usrVM);
        }

        [HttpPost]
        public JsonResult Add(UserVM usrVM)
        {
            if (!ModelState.IsValid)
            {

                return Json(new { code = OperationResultType.ParamError, message = base.ParseModelStateErrorMessage(ModelState) });
            }

            OperationResult result = _userSrv.Add(new User
              {
                  UserName = usrVM.UserName,
                  Email = usrVM.Email,
                  Phone = usrVM.Phone,
                  Address = usrVM.Address,
                  Enabled = usrVM.Enabled,
                  Creator = HttpContext.Session.GetUserId(),
                  CreateTime = DateTime.Now,
                  Remark = usrVM.Remark
              });
            if (result.ResultType != OperationResultType.Success)
            {
                return Json(new { code = result.ResultType, message = result.Message });
            }
            return Json(new { code = OperationResultType.Success, message = "添加成功" });
        }

        [HttpPost]
        public JsonResult Edit(UserVM usrVM)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { code = OperationResultType.ParamError, message = base.ParseModelStateErrorMessage(ModelState) });
            }

            var usr = new User
            {
                Id = usrVM.Id,
                UserName = usrVM.UserName,
                Email = usrVM.Email,
                Phone = usrVM.Phone,
                Address = usrVM.Address,
                Enabled = usrVM.Enabled,
                IsDeleted = usrVM.IsDeleted,
                LastModifier = HttpContext.Session.GetUserId(),
                LastModifyTime = DateTime.Now,
                Remark = usrVM.Remark
            };
            OperationResult result = _userSrv.UpdateDetail(usr);
            if (result.ResultType != OperationResultType.Success)
            {
                return Json(new { code = result.ResultType, message = result.Message });
            }
            return Json(new { code = OperationResultType.Success, message = "修改成功" });
        }

        [HttpPost]
        public JsonResult Delete()
        {
            int[] usrIds = null;
            using (var reader = new System.IO.StreamReader(HttpContext.Request.InputStream))
            {
                string data = reader.ReadToEnd();
                try
                {
                    usrIds = data.DeSerializeFromJson<int[]>();
                }
                catch (Exception ex)
                {
                    return Json(new { code = OperationResultType.ParamError, message = ex.GetDeepestException().Message });
                }
            }
            if (usrIds == null || usrIds.Length < 1)
            {
                return Json(new { code = OperationResultType.ParamError, message = "用户id列表不能为空" });
            }
            OperationResult result = _userSrv.Delete(u => usrIds.Contains(u.Id));
            if (result.ResultType != OperationResultType.Success)
            {
                return Json(new { code = result.ResultType, message = result.Message });
            }
            return Json(new { code = OperationResultType.Success, message = "修改成功" });
        }
    }
}