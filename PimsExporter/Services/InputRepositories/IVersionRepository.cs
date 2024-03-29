﻿using System.Collections.Generic;
using Domain.Entities;

namespace PimsExporter.Services.InputRepositories
{
    public interface IVersionRepository
    {
        VersionHeader GetHeader();
        IEnumerable<VersionBudget> GetVersionBudgets();
        IEnumerable<VersionTeam> GetVersionTeams();
        IEnumerable<CoSignatureHeader> GetCoSignatureHeaders();
        IEnumerable<VersionDocument> GetVersionDocuments();
        IEnumerable<VersionChangeLog> GetVersionChangeLogs();
        IEnumerable<Milestone> GetVersionMilestones();
        IEnumerable<CoSignatureCoSigner> GetCoSignatureCoSigners();
        IEnumerable<VersionRelatedOmItem> GetVersionRelatedOmItems();
        IEnumerable<CoSignatureDocument> GetCoSignatureDocuments();
    }
}