﻿using System;
using System.Collections.Generic;
using System.Net;
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
                item => mapper.MapAllVersionToEntity(item));
        }

        public IEnumerable<AllOmItem> AllOmItems()
        {
            return GetAllEntities(
                Constants.Root.Lists.AllProducts.TITLE,
                item => mapper.MapAllOmItemToEntity(item));
        }

        public OmItemHeader ProductRecord()
        {
            return GetFirstEntity(
                Constants.Product.Lists.ProductRecord.TITLE,
                item => mapper.MapProductRecordToEntity(item));
        }

        public IEnumerable<OlmPhase> OlmPhase()
        {
            return GetAllEntities(
                Constants.Product.Lists.OlmPhases.TITLE,
                item => mapper.MapOlmPhasesToEntity(item));
        }

        public IEnumerable<Milestone> Milestones()
        {
            return GetAllEntities(
                Constants.Product.Lists.Milestones.TITLE,
                item => mapper.MapMilestoneToEntity(item));
        }

        public IEnumerable<int> VersionNumbers()
        {
            return GetAllEntities(
                Constants.Product.Lists.Versions.TITLE,
                item => mapper.MapVersionToInt(item));
        }

        public VersionHeader ProductVersion()
        {
            return GetFirstEntity(
                Constants.Version.Lists.ProductVersion.TITLE,
                item => mapper.MapProductVersionToEntity(item));
        }

        public IEnumerable<VersionBudget> VersionBudgets()
        {
            return GetAllEntities(
                Constants.Version.Lists.VersionBudget.TITLE,
                item => mapper.MapVersionBudgetToEntity(item));
        }

        public IEnumerable<Team> Teams()
        {
            return GetAllEntities(
                Constants.Product.Lists.Team.TITLE,
                item => mapper.MapTeamsToEntity(item));
        }

        public IEnumerable<VersionTeam> VersionTeams()
        {
            return GetAllEntities(
                Constants.Version.Lists.VersionTeam.TITLE,
                item => mapper.MapVersionTeamsToEntity(item));
        }

        public IEnumerable<CoSignatureHeader> CoSignatureHeaders()
        {
            return GetAllCoSignatureEntities();
        }

        public IEnumerable<VersionDocument> VersionDocuments()
        {
            return GetAllEntities(
                Constants.Version.Lists.VersionDocument.TITLE,
                item => mapper.MapVersionDocumentsToEntity(item));
        }
    }
}