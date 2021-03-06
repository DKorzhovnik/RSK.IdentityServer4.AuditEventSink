﻿using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Events;
using RSK.Audit;
using RSK.IdentityServer4.AuditEventSink.Adapters;

namespace RSK.IdentityServer4.AuditEventSink
{
    public class AdapterFactory : IAdapterFactory
    {
        public IAuditEventArguments Create(Event evt)
        {
            if (evt != null)
            {
                switch (evt)
                {
                    case TokenIssuedSuccessEvent tokenIssuedSuccessEvent:
                        return new TokenIssuedSuccessEventAdapter(tokenIssuedSuccessEvent);
                    case UserLoginSuccessEvent userLoginSuccess:
                        return new UserLoginSuccessEventAdapter(userLoginSuccess);
                    case UserLoginFailureEvent userLoginFailure:
                        return new UserLoginFailureEventAdapter(userLoginFailure);
                    case UserLogoutSuccessEvent userLogoutSuccess:
                        return new UserLogoutSuccessEventAdapter(userLogoutSuccess);
                    case ConsentGrantedEvent consentGranted:
                        return new ConsentGrantedEventAdapter(consentGranted);
                    case ConsentDeniedEvent consentDenied:
                        return new ConsentDeniedEventAdapter(consentDenied);
                    case TokenIssuedFailureEvent tokenIssuedFailure:
                        return new TokenIssuedFailureEventAdapter(tokenIssuedFailure);
                    case GrantsRevokedEvent grantsRevoked:
                        return new GrantsRevokedEventAdapter(grantsRevoked);
                }
            }

            return null;
        }
    }
}
