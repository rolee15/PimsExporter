﻿using Domain.Entities;
using System.Collections.Generic;

namespace PimsExporter.Services.OutputRepositories
{
    public interface IOutputRepository
    {
        void SaveAllOmItems(IEnumerable<AllOmItem> omItems);
        void SaveAllVersions(IEnumerable<AllVersion> versions);
        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders);
        void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases);
        void SaveMilestones(IEnumerable<Milestone> milestones);
        void SaveVersionHeader(VersionHeader versionHeader);
    }
}