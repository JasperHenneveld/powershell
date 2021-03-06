﻿using System.Collections.Generic;
using System.Management.Automation;
using PnP.Framework.Entities;
using PnP.Framework.Graph;
using PnP.PowerShell.Commands.Attributes;
using PnP.PowerShell.Commands.Base;
using PnP.PowerShell.Commands.Base.PipeBinds;

namespace PnP.PowerShell.Commands.Microsoft365Groups
{
    [Cmdlet(VerbsCommon.Get, "PnPDeletedMicrosoft365Group")]
    [RequiredMinimalApiPermissions("Group.Read.All")]
    public class GetDeletedMicrosoft365Group : PnPGraphCmdlet
    {
        [Parameter(Mandatory = false)]
        public Microsoft365GroupPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            UnifiedGroupEntity group = null;
            List<UnifiedGroupEntity> groups = null;

            if (Identity != null)
            {
                group = Identity.GetDeletedGroup(AccessToken);
            }
            else
            {
                groups = UnifiedGroupsUtility.ListDeletedUnifiedGroups(AccessToken, azureEnvironment: PnPConnection.Current.AzureEnvironment);
            }

            if (group != null)
            {
                WriteObject(group);
            }
            else if (groups != null)
            {
                WriteObject(groups, true);
            }
        }
    }
}