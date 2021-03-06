﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class SignalRTriggerAttribute : Attribute
    {
        public SignalRTriggerAttribute(string hubName, string category, string @event, params string[] parameterNames)
        {
            HubName = hubName;
            Category = category;
            Event = @event;
            ParameterNames = parameterNames;
        }

        /// <summary>
        /// Connection string that connect to Azure SignalR Service
        /// </summary>
        [AppSetting(Default = Constants.AzureSignalRConnectionStringName)]
        public string ConnectionStringSetting { get; set; }

        /// <summary>
        /// The hub of request belongs to.
        /// </summary>
        [AutoResolve]
        public string HubName { get; set; }

        /// <summary>
        /// The event of the request.
        /// </summary>
        [AutoResolve]
        public string Event { get; set; }

        /// <summary>
        /// Two optional value: connections and messages
        /// </summary>
        [AutoResolve]
        public string Category { get; set; }

        /// <summary>
        /// Used for messages category. All the name defined in <see cref="ParameterNames"/> will map to
        /// Arguments in InvocationMessage by order. And the name can be used in parameters of method
        /// directly.
        /// </summary>
        public string[] ParameterNames { get; set; }
    }
}
