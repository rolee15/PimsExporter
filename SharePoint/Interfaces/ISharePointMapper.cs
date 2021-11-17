using Domain.Entities;
using Microsoft.SharePoint.Client;

namespace SharePoint
{
    internal interface ISharePointMapper
    {
        AllVersion MapAllVersionToEntity(ListItem item);
        AllOmItem MapAllOmItemToEntity(ListItem item);
        OmItemHeader MapProductRecordToEntity(ListItem item);
        OlmPhase MapOlmPhasesToEntity(ListItem item);
        Milestone MapMilestoneToEntity(ListItem item);
        int MapVersionToInt(ListItem item);
        VersionHeader MapProductVersionToEntity(ListItem item);
        VersionBudget MapVersionBudgetToEntity(ListItem item);
        Team MapTeamsToEntity(ListItem item);
        VersionTeam MapVersionTeamsToEntity(ListItem item);
    }
}