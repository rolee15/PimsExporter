using System;
using System.Collections.Generic;
using System.Net;
using Domain.Entities;

namespace SharePoint
{
    public class SharePointAdapter : SharePointAdapterBase, ISharePointAdapter
    {
        private readonly Mapper _mapper = new Mapper();

        public SharePointAdapter(Uri sharepointSiteUrl, NetworkCredential credentials) : base(sharepointSiteUrl,
            credentials)
        {
        }

        public IEnumerable<AllVersion> AllVersions()
        {
            return GetAllEntities(
                Constants.Root.Lists.AllVersions.TITLE,
                item => _mapper.MapAllVersionToEntity(item));
        }

        public IEnumerable<AllOmItem> AllOmItems()
        {
            return GetAllEntities(
                Constants.Root.Lists.AllProducts.TITLE,
                item => _mapper.MapAllOmItemToEntity(item));
        }

        public OmItemHeader ProductRecord()
        {
            return GetEntity(
                Constants.Product.Lists.ProductRecord.TITLE,
                item => _mapper.MapProductRecordToEntity(item));
        }

        public IEnumerable<OlmPhase> OlmPhase()
        {
            return GetAllEntities(
                Constants.Product.Lists.OlmPhases.TITLE,
                item => _mapper.MapOlmPhasesToEntity(item));
        }

        public IEnumerable<Milestone> Milestones()
        {
            return GetAllEntities(
                Constants.Product.Lists.Milestones.TITLE,
                item => _mapper.MapMilestoneToEntity(item));
        }

        public IEnumerable<int> VersionNumbers()
        {
            return GetAllEntities(
                Constants.Product.Lists.Versions.TITLE,
                item => _mapper.MapVersionToInt(item));
        }

        public VersionHeader ProductVersion()
        {
            return GetEntity(
                Constants.Version.Lists.ProductVersion.TITLE,
                item => _mapper.MapProductVersionToEntity(item));
        }

        public IEnumerable<VersionBudget> VersionBudgets()
        {
            return GetAllEntities(
                Constants.Version.Lists.VersionBudget.TITLE,
                item => _mapper.MapVersionBudgetToEntity(item));
        }

        public IEnumerable<Team> Teams()
        {
            return GetAllEntities(
                Constants.Product.Lists.Team.TITLE,
                item => _mapper.MapTeamsToEntity(item));
        }
    }
}