using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace GIBS.SSRS_Viewer.Components
{
    public class SSRS_ViewerInfo
    {
        //private vars exposed thro the
        //properties
        private int moduleId;
        private int itemId;
        private string content;
        private int createdByUser = -1;
        private DateTime createdDate;
        private string createdByUserName = null;


        /// <summary>
        /// empty cstor
        /// </summary>
        public SSRS_ViewerInfo()
        {
        }


        #region properties

        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public int CreatedByUser
        {
            get { return createdByUser; }
            set { createdByUser = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public string CreatedByUserName
        {
            get
            {
                //if (createdByUserName == null)
                //{
                //    int portalId = PortalController.Instance.GetCurrentPortalSettings().PortalId;
                //    UserInfo user = UserController.GetUser(portalId, createdByUser);
                //    createdByUserName = user.DisplayName;
                //}

                return createdByUserName;
            }
        }

        #endregion
    }
}
