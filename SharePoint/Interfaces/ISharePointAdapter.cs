﻿using System.Collections.Generic;
using Domain.Entities;

namespace SharePoint.Interfaces
{
    public interface ISharePointAdapter
    {
        IEnumerable<AllOmItem> AllOmItems();
        IEnumerable<AllVersion> AllVersions();
        OmItemHeader ProductRecord();
        IEnumerable<OlmPhase> OlmPhase();
        IEnumerable<Milestone> Milestones();
        VersionHeader ProductVersion();
        IEnumerable<int> VersionNumbers();
        IEnumerable<VersionBudget> VersionBudgets();
        IEnumerable<Team> Teams();
        IEnumerable<VersionTeam> VersionTeams();
        IEnumerable<CoSignatureHeader> CoSignatureHeaders();
        IEnumerable<VersionDocument> VersionDocuments();
        IEnumerable<VersionChangeLog> VersionChangeLogs();
        IEnumerable<CoSignatureCoSigner> CoSignatureCoSigners();
        IEnumerable<RelatedOmItem> RelatedOmItems();
        IEnumerable<VersionRelatedOmItem> VersionRelatedOmItems();
        IEnumerable<OmItemDocument> Documents();
        IEnumerable<CoSignatureDocument> CoSignatureDocuments();
        IEnumerable<Lookup> Lookups();
    }
}