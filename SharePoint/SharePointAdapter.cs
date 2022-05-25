using System;
using System.Collections.Generic;
using System.Net;
using Domain;
using Domain.Entities;
using SharePoint.Interfaces;

namespace SharePoint
{
    public sealed class SharePointAdapter : SharePointAdapterBase, ISharePointAdapter
    {
        public SharePointAdapter(
            Uri sharepointSiteUrl, NetworkCredential credentials)
            : base(sharepointSiteUrl, credentials)
        {
        }

        public IEnumerable<AllVersion> AllVersions()
        {
            return GetAllEntities(
                Constants.Root.Lists.AllVersions.TITLE,
                item => Mapper.MapAllVersionToEntity(item));
        }

        public IEnumerable<AllOmItem> AllOmItems()
        {
            return GetAllEntities(
                Constants.Root.Lists.AllProducts.TITLE,
                item => Mapper.MapAllOmItemToEntity(item));
        }

        public OmItemHeader ProductRecord()
        {
            return GetFirstEntity(
                Constants.Product.Lists.ProductRecord.TITLE,
                item => Mapper.MapProductRecordToEntity(item));
        }

        public IEnumerable<OlmPhase> OlmPhase()
        {
            return GetAllEntities(
                Constants.Product.Lists.OlmPhases.TITLE,
                item => Mapper.MapOlmPhasesToEntity(item));
        }

        public IEnumerable<Milestone> Milestones()
        {
            return GetAllEntities(
                Constants.Product.Lists.Milestones.TITLE,
                item => Mapper.MapMilestoneToEntity(item));
        }

        public IEnumerable<int> VersionNumbers()
        {
            return GetAllEntities(
                Constants.Product.Lists.Versions.TITLE,
                item => Mapper.MapVersionToInt(item));
        }

        public VersionHeader ProductVersion()
        {
            return GetFirstEntity(
                Constants.Version.Lists.ProductVersion.TITLE,
                item => Mapper.MapProductVersionToEntity(item));
        }

        public IEnumerable<VersionBudget> VersionBudgets()
        {
            return GetAllEntities(
                Constants.Version.Lists.VersionBudget.TITLE,
                item => Mapper.MapVersionBudgetToEntity(item));
        }

        public IEnumerable<Team> Teams()
        {
            return GetAllEntities(
                Constants.Product.Lists.Team.TITLE,
                item => Mapper.MapTeamsToEntity(item));
        }

        public IEnumerable<VersionTeam> VersionTeams()
        {
            return GetAllEntities(
                Constants.Version.Lists.VersionTeam.TITLE,
                item => Mapper.MapVersionTeamsToEntity(item));
        }

        public IEnumerable<CoSignatureHeader> CoSignatureHeaders()
        {
            return GetAllEntities(
                Constants.Version.Lists.CoSignaturesList.TITLE,
                item => Mapper.MapCoSignaturesListToEntity(item));
        }

        public IEnumerable<VersionDocument> VersionDocuments()
        {
            return GetAllEntities(
                Constants.Version.Lists.VersionDocument.TITLE,
                item => Mapper.MapVersionDocumentsToEntity(item));
        }

        public IEnumerable<VersionChangeLog> VersionChangeLogs()
        {
            return GetAllEntities(
                Constants.Version.Lists.VersionChangeLog.TITLE,
                item => Mapper.MapVersionChangeLogToEntity(item));
        }

        public IEnumerable<CoSignatureCoSigner> CoSignatureCoSigners()
        {
            return GetAllEntities(
                Constants.Version.Lists.CoSigners.TITLE,
                item => Mapper.MapCoSignatureCoSignersListToEntity(item));
        }

        public IEnumerable<OmItemDocument> Documents()
        {
            return GetAllEntities(
                Constants.Product.Lists.Documents.TITLE,
                item => Mapper.MapDocumentsToEntity(item));
        }

        public IEnumerable<RelatedOmItem> RelatedOmItems()
        {
            return GetAllEntities(
                Constants.Product.Lists.RelatedOMItems.TITLE,
                item => Mapper.MapRelatedOmItemsToEntity(item));
        }

        public IEnumerable<CoSignatureDocument> CoSignatureDocuments()
        {
            return GetAllEntities(
                Constants.Version.Lists.CoSignatureDocuments.TITLE,
                item => Mapper.MapCoSignatureDocumentsListToEntity(item));
        }

        public IEnumerable<Lookup> Lookups()
        {
            return GetAllEntities(
                Constants.Root.Lists.Lookups.TITLE,
                item => Mapper.MapLookupToEntity(item));
        }
    }
}