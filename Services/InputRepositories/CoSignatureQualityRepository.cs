using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using PimsExporter.Services.InputRepositories;
using Services.Dto;
using CoSignatureQuality = Domain.Entities.CoSignatureQuality;

namespace Services.InputRepositories
{
    internal class CoSignatureQualityRepository : ICoSignatureQualityRepository
    {
        private const int Logon32ProviderDefault = 0;

        //This parameter causes LogonUser to create a primary token.   
        private const int Logon32LogonInteractive = 2;
        private readonly NetworkCredential _networkCredential;

        private readonly Uri _uri;

        public CoSignatureQualityRepository(Uri uri, NetworkCredential networkCredential)
        {
            _uri = uri;
            _networkCredential = networkCredential;
        }

        public async Task<IEnumerable<CoSignatureQuality>> GetCoSignatureQualitiesAsync(int omItemNumber,
            int versionNumber, int coSignatureId)
        {
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                var contentString = string.Empty;

                var returnValue = LogonUser
                (
                    _networkCredential.UserName,
                    _networkCredential.Domain,
                    _networkCredential.Password, Logon32LogonInteractive,
                    Logon32ProviderDefault,
                    out var safeAccessTokenHandle);

                if (false == returnValue)
                {
                    var ret = Marshal.GetLastWin32Error();
                    throw new Win32Exception(ret);
                }

                var url =
                    $"{_uri.OriginalString}/api/CoSignatureQuality/GetMandatoryDocumentsAndTeamRoles?omItemNumber={omItemNumber}&versionNumber={versionNumber}&coSingnatureId={coSignatureId}";

                await WindowsIdentity.RunImpersonated(safeAccessTokenHandle, async () =>
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    contentString = await response.Content.ReadAsStringAsync();
                });

                var coSignQualityWithDateTime = JsonConvert.DeserializeObject<CoSignQualityWithDateTime>(contentString);
                return coSignQualityWithDateTime.QualityMapping.Select(item => new CoSignatureQuality
                {
                    OmItemNumber = omItemNumber,
                    VersionNumber = versionNumber,
                    CoSignatureId = coSignatureId,
                    LastCheckTime = item.LastCheckTime,
                    CoSignatureQualityIndex =
                        coSignQualityWithDateTime.QualityIndex.ToString(CultureInfo.InvariantCulture),
                    MandatoryDocumentOrRole = item.MandatoryDocumentOrRole,
                    OptOutRemark = item.OptOutRemark,
                    IsOptOut = item.OptOutRuleId.HasValue && item.OptOutRuleId.Value > 0,
                    Result = item.Result,
                    ResultStatus = item.ResultStatus,
                    Type = item.Type
                });
            }
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeAccessTokenHandle phToken);
    }
}