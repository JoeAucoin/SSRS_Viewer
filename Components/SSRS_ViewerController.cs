using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.SSRS_Viewer.Components
{
    public class SSRS_ViewerController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the SSRS_ViewerInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<SSRS_ViewerInfo> GetSSRS_Viewers(int moduleId)
        {
            return CBO.FillCollection<SSRS_ViewerInfo>(DataProvider.Instance().GetSSRS_Viewers(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public SSRS_ViewerInfo GetSSRS_Viewer(int moduleId, int itemId)
        {
            return (SSRS_ViewerInfo)CBO.FillObject(DataProvider.Instance().GetSSRS_Viewer(moduleId, itemId), typeof(SSRS_ViewerInfo));
        }


        /// <summary>
        /// Adds a new SSRS_ViewerInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddSSRS_Viewer(SSRS_ViewerInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddSSRS_Viewer(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateSSRS_Viewer(SSRS_ViewerInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateSSRS_Viewer(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteSSRS_Viewer(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteSSRS_Viewer(moduleId, itemId);
        }


        #endregion

        #region ISearchable Members

        /// <summary>
        /// Implements the search interface required to allow DNN to index/search the content of your
        /// module
        /// </summary>
        /// <param name="modInfo"></param>
        /// <returns></returns>
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
        {
            SearchItemInfoCollection searchItems = new SearchItemInfoCollection();

            List<SSRS_ViewerInfo> infos = GetSSRS_Viewers(modInfo.ModuleID);

            foreach (SSRS_ViewerInfo info in infos)
            {
                SearchItemInfo searchInfo = new SearchItemInfo(modInfo.ModuleTitle, info.Content, info.CreatedByUser, info.CreatedDate,
                                                    modInfo.ModuleID, info.ItemId.ToString(), info.Content, "Item=" + info.ItemId.ToString());
                searchItems.Add(searchInfo);
            }

            return searchItems;
        }

        #endregion

        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();

            List<SSRS_ViewerInfo> infos = GetSSRS_Viewers(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<SSRS_Viewers>");
                foreach (SSRS_ViewerInfo info in infos)
                {
                    sb.Append("<SSRS_Viewer>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</SSRS_Viewer>");
                }
                sb.Append("</SSRS_Viewers>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "SSRS_Viewers");

            foreach (XmlNode info in infos.SelectNodes("SSRS_Viewer"))
            {
                SSRS_ViewerInfo SSRS_ViewerInfo = new SSRS_ViewerInfo();
                SSRS_ViewerInfo.ModuleId = ModuleID;
                SSRS_ViewerInfo.Content = info.SelectSingleNode("content").InnerText;
                SSRS_ViewerInfo.CreatedByUser = UserID;

                AddSSRS_Viewer(SSRS_ViewerInfo);
            }
        }

        #endregion
    }
}
