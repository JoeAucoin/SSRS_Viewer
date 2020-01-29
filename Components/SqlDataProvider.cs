using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace GIBS.SSRS_Viewer.Components
{
    public class SqlDataProvider : DataProvider
    {


        #region vars

        private const string providerType = "data";
        private const string moduleQualifier = "GIBS_";

        private ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);
        private string connectionString;
        private string providerPath;
        private string objectQualifier;
        private string databaseOwner;

        #endregion

        #region cstor

        /// <summary>
        /// cstor used to create the sqlProvider with required parameters from the configuration
        /// section of web.config file
        /// </summary>
        public SqlDataProvider()
        {
            Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];
            connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

            if (connectionString == string.Empty)
                connectionString = provider.Attributes["connectionString"];

            providerPath = provider.Attributes["providerPath"];

            objectQualifier = provider.Attributes["objectQualifier"];
            if (objectQualifier != string.Empty && !objectQualifier.EndsWith("_"))
                objectQualifier += "_";

            databaseOwner = provider.Attributes["databaseOwner"];
            if (databaseOwner != string.Empty && !databaseOwner.EndsWith("."))
                databaseOwner += ".";
        }

        #endregion

        #region properties

        public string ConnectionString
        {
            get { return connectionString; }
        }


        public string ProviderPath
        {
            get { return providerPath; }
        }

        public string ObjectQualifier
        {
            get { return objectQualifier; }
        }


        public string DatabaseOwner
        {
            get { return databaseOwner; }
        }

        #endregion

        #region private methods

        private string GetFullyQualifiedName(string name)
        {
            return DatabaseOwner + ObjectQualifier + moduleQualifier + name;
        }

        private object GetNull(object field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(field, DBNull.Value);
        }

        #endregion

        #region override methods

        public override IDataReader GetSSRS_Viewers(int moduleId)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("GetSSRS_Viewers"), moduleId);
        }

        public override IDataReader GetSSRS_Viewer(int moduleId, int itemId)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("GetSSRS_Viewer"), moduleId, itemId);
        }

        public override void AddSSRS_Viewer(int moduleId, string content, int userId)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("AddSSRS_Viewer"), moduleId, content, userId);
        }

        public override void UpdateSSRS_Viewer(int moduleId, int itemId, string content, int userId)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("UpdateSSRS_Viewer"), moduleId, itemId, content, userId);
        }

        public override void DeleteSSRS_Viewer(int moduleId, int itemId)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("DeleteSSRS_Viewer"), moduleId, itemId);
        }

        #endregion
    }
}
