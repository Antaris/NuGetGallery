// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace NuGetGallery {
    public partial class PackagesController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected PackagesController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult DisplayPackage() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.DisplayPackage);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ListPackages() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ListPackages);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ReportAbuse() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ReportAbuse);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ContactOwners() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ContactOwners);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult DownloadPackage() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.DownloadPackage);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ManagePackageOwners() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ManagePackageOwners);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Delete() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Edit() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ConfirmOwner() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ConfirmOwner);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public PackagesController Actions { get { return MVC.Packages; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Packages";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string UploadPackage = "UploadPackage";
            public readonly string DisplayPackage = "DisplayPackage";
            public readonly string ListPackages = "ListPackages";
            public readonly string ReportAbuse = "ReportAbuse";
            public readonly string ContactOwners = "ContactOwners";
            public readonly string Download = "Download";
            public readonly string DownloadPackage = "DownloadPackage";
            public readonly string ManagePackageOwners = "ManagePackageOwners";
            public readonly string Delete = "Delete";
            public readonly string Edit = "Edit";
            public readonly string ConfirmOwner = "ConfirmOwner";
            public readonly string VerifyPackage = "VerifyPackage";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string _ListPackage = "~/Views/Packages/_ListPackage.cshtml";
            public readonly string ConfirmOwner = "~/Views/Packages/ConfirmOwner.cshtml";
            public readonly string ContactOwners = "~/Views/Packages/ContactOwners.cshtml";
            public readonly string Delete = "~/Views/Packages/Delete.cshtml";
            public readonly string DisplayPackage = "~/Views/Packages/DisplayPackage.cshtml";
            public readonly string Download = "~/Views/Packages/Download.cshtml";
            public readonly string Edit = "~/Views/Packages/Edit.cshtml";
            public readonly string ListPackages = "~/Views/Packages/ListPackages.cshtml";
            public readonly string ManagePackageOwners = "~/Views/Packages/ManagePackageOwners.cshtml";
            public readonly string ReportAbuse = "~/Views/Packages/ReportAbuse.cshtml";
            public readonly string UploadPackage = "~/Views/Packages/UploadPackage.cshtml";
            public readonly string VerifyPackage = "~/Views/Packages/VerifyPackage.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_PackagesController: NuGetGallery.PackagesController {
        public T4MVC_PackagesController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult UploadPackage() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.UploadPackage);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult UploadPackage(System.Web.HttpPostedFileBase packageFile) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.UploadPackage);
            callInfo.RouteValueDictionary.Add("packageFile", packageFile);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult DisplayPackage(string id, string version) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.DisplayPackage);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ListPackages(string q, string sortOrder, int page) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ListPackages);
            callInfo.RouteValueDictionary.Add("q", q);
            callInfo.RouteValueDictionary.Add("sortOrder", sortOrder);
            callInfo.RouteValueDictionary.Add("page", page);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ReportAbuse(string id, string version) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ReportAbuse);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ReportAbuse(string id, string version, NuGetGallery.ReportAbuseViewModel reportForm) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ReportAbuse);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            callInfo.RouteValueDictionary.Add("reportForm", reportForm);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ContactOwners(string id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ContactOwners);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ContactOwners(string id, NuGetGallery.ContactOwnersViewModel contactForm) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ContactOwners);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("contactForm", contactForm);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Download() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Download);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult DownloadPackage(string id, string version) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.DownloadPackage);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ManagePackageOwners(string id, string version) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ManagePackageOwners);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Delete(string id, string version) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Delete(string id, string version, bool? listed) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            callInfo.RouteValueDictionary.Add("listed", listed);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(string id, string version) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(string id, string version, bool? listed) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            callInfo.RouteValueDictionary.Add("listed", listed);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ConfirmOwner(string id, string username, string token) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ConfirmOwner);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("username", username);
            callInfo.RouteValueDictionary.Add("token", token);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult VerifyPackage() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.VerifyPackage);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult VerifyPackage(bool? listed) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.VerifyPackage);
            callInfo.RouteValueDictionary.Add("listed", listed);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
