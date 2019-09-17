using System.Web;
using System.Web.Mvc;

namespace Web.HMS
{
    public static class LinkGenerator
    {
        public static string GetGeneratedLink(string detailAction, string detailController, string editAction, string editController, string deleteAction, string deleteController, long id)
        {
            //var requestContext = HttpContext.Current.Request.RequestContext;
            var generateLink = GetDetailsLink(detailAction, detailController, id) + GetEditLink(editAction, editController, id) + GetDeleteLink(deleteAction, deleteController, id);
            return generateLink;
        }


        public static string GetGeneratedLink(string detailAction, string editAction, string deleteAction, string controller, long id, string name)
        {
            //var requestContext = HttpContext.Current.Request.RequestContext;
            var generateLink = GetDetailsLink(detailAction, controller, id) + GetEditLink(editAction, controller, id) + GetDeleteLinkForModal(id, name);
            return generateLink;
        }

        public static string GetGeneratedDetailsEditLink(string detailAction, string editAction, string controller, long id)
        {
            var generateLink = GetDetailsLink(detailAction, controller, id) + GetEditLink(editAction, controller, id);
            return generateLink;
        }

        public static string GetGeneratedDetailsEditModelDeleteLink(string detailAction, string editAction, string controller, long id, string name)
        {
            var generateLink = GetDetailsLink(detailAction, controller, id) + GetEditLink(editAction, controller, id) + GetDeleteLinkForModal(id, name);
            return generateLink;
        }

        public static string GetGeneratedLink(string editAction, string deleteAction, string controller, long id, string name)
        {
            //var requestContext = HttpContext.Current.Request.RequestContext;
            var generateLink = GetEditLink(editAction, controller, id) + GetDeleteLinkForModal(id, name);
            return generateLink;
        }

        //public static string GetGeneratedLink(string detailAction, string detailController, string editAction, string editController, string deleteAction, string deleteController, long id, string name)
        //{
        //    //var requestContext = HttpContext.Current.Request.RequestContext;
        //    var generateLink = GetDetailsLink(detailAction, detailController, id) + GetEditLink(editAction, editController, id) + GetDeleteLinkForModal(id,name);
        //    return generateLink;
        //}

        public static string GetDetailsLink(string action, string controller, long id)
        {
            var requestContext = HttpContext.Current.Request.RequestContext;
            //new UrlHelper url = requestContext;

            var generateLink = "<a href='" + new UrlHelper(requestContext).Action(action, controller)
                + "?Id=" + id + "' data-id='" + id + "' class='glyphicon glyphicon-th-list'></a>&nbsp;&nbsp;&nbsp;";

            //throw new NotImplementedException();
            return generateLink;
        }

        public static string GetDynamicLink(string action, string controller, long id, string iconClass)
        {
            var requestContext = HttpContext.Current.Request.RequestContext;
            //new UrlHelper url = requestContext;

            var generateLink = "<a href='" + new UrlHelper(requestContext).Action(action, controller)
                + "?Id=" + id + "' data-id='" + id + "' class='glyphicon " + iconClass + "'></a>&nbsp;&nbsp;&nbsp;";

            //throw new NotImplementedException();
            return generateLink;
        }
        public static string GetDynamicLabelLink(string action, string controller, long id, string linkLabel)
        {
            var requestContext = HttpContext.Current.Request.RequestContext;
            var link = "<a href='" + new UrlHelper(requestContext).Action(action, controller) + "?Id=" + id + " ' data-id='" + id + "' target='_blank' >" + linkLabel + "</a>";
            return link;
        }



        public static string GetEditLink(string action, string controller, long id)
        {
            var requestContext = HttpContext.Current.Request.RequestContext;
            var generateLink = "<a href='" + new UrlHelper(requestContext).Action(action, controller)
                + "?Id=" + id + "' data-id='" + id + "' class='glyphicon glyphicon-pencil'> </a>&nbsp;&nbsp; ";
            return generateLink;
        }

        public static string GetMemberAchievementGraphLink(string action, string controller, long id, string extraParams = "")
        {
            var requestContext = HttpContext.Current.Request.RequestContext;
            var generateLink = "<a href='" + new UrlHelper(requestContext).Action(action, controller)
                + "?Id=" + id + extraParams + "' data-id='" + id + "' class='glyphicon glyphicon-stats'> </a>&nbsp;&nbsp; ";
            return generateLink;
        }

        public static string GetDeleteLink(string action, string controller, long id)
        {
            var requestContext = HttpContext.Current.Request.RequestContext;
            var generateLink = "<a href='" + new UrlHelper(requestContext).Action(action, controller)
                + "?Id=" + id + "' data-id='" + id + "' title='delete or cancel' class='glyphicon glyphicon-trash'> </a> ";
            return generateLink;
        }

        public static string GetDeleteLinkForModal(long id, string name)
        {
            var generateLink = "<a data-id='" + id + "'  id='" + id + "'    href='#' data-name='" + name + "' class='glyphicon glyphicon-trash'></a>";

            //throw new NotImplementedException();
            return generateLink;
        }

        public static string GetRankLinkForModal(long id, int currentReank, int minRank, int maxRank)
        {
            string rankbtn = currentReank.ToString();
            if (currentReank > minRank)
            {
                rankbtn += "<a href='#'  id='" + id + "' class='glyphicon glyphicon-arrow-up' data-action='up'></a>";
            }
            if (currentReank < maxRank)
            {
                rankbtn += "<a href='#'  id='" + id + "' class='glyphicon glyphicon-arrow-down' data-action='down'></a>";
            }

            return rankbtn;
        }

        internal static string GetInvoiceLink(string action, string controller, long id)
        {
            var requestContext = HttpContext.Current.Request.RequestContext;
            var generateLink = "<a href='" + new UrlHelper(requestContext).Action(action, controller)
                + "?Id=" + id + "' data-id='" + id + "' title='Invoice' class='glyphicon glyphicon-usd'> </a> ";
            return generateLink;
        }
    }
}