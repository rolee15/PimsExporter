using Domain.Entities;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using PimsExporter.Services.InputRepositories;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Services.InputRepositories
{
    internal class CoSignatureQualityRepository : ICoSignatureQualityRepository
    {
        private const int LOGON32_PROVIDER_DEFAULT = 0;
        //This parameter causes LogonUser to create a primary token.   
        private const int LOGON32_LOGON_INTERACTIVE = 2;
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeAccessTokenHandle phToken);

        private readonly Uri _uri;
        private readonly NetworkCredential _networkCredential;

        public CoSignatureQualityRepository(Uri uri, NetworkCredential networkCredential)
        {
            _uri = uri;
            _networkCredential = networkCredential;
        }
        public async Task<IEnumerable<Domain.Entities.CoSignatureQuality>> GetCoSignatureQualitiesAsync(int omItemNumber, int versionNumber, int coSingnatureId)
        {
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                var contentString = string.Empty;

                var returnValue = LogonUser
                (
                    _networkCredential.UserName,
                    _networkCredential.Domain,
                    _networkCredential.Password, LOGON32_LOGON_INTERACTIVE,
                    LOGON32_PROVIDER_DEFAULT,
                    out var safeAccessTokenHandle);

                if (false == returnValue)
                {
                    var ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }

                var url = $"{_uri.OriginalString}/api/CoSignatureQuality/GetMandatoryDocumentsAndTeamRoles?omItemNumber={omItemNumber}&versionNumber={versionNumber}&coSingnatureId={coSingnatureId}";

                await WindowsIdentity.RunImpersonated(safeAccessTokenHandle, async () =>
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    contentString = await response.Content.ReadAsStringAsync();
                });

                var coSignQualityWithDateTime = JsonConvert.DeserializeObject<CoSignQualityWithDateTime>(contentString);
                return coSignQualityWithDateTime.QualityMapping.Select(item => new Domain.Entities.CoSignatureQuality() 
                {
                    OmItemNumber = omItemNumber,
                    VersionNumber = versionNumber,
                    CoSignatureId = coSingnatureId,
                    LastCheckTime = item.LastCheckTime,
                    CoSignatureQualityIndex = coSignQualityWithDateTime.QualityIndex.ToString(),
                    MandatoryDocumentOrRole = item.MandatoryDocumentOrRole,
                    OptOutRemark = item.OptOutRemark,
                    IsOptOut = item.OptOutRuleId.HasValue && item.OptOutRuleId.Value > 0,
                    Result = item.Result,
                    ResultStatus = item.ResultStatus,
                    Type = item.Type
                });
            }
        }
    }
}
