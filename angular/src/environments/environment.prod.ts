import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'BookCafeAutomation',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44390/',
    redirectUri: baseUrl,
    clientId: 'BookCafeAutomation_App',
    responseType: 'code',
    scope: 'offline_access BookCafeAutomation',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44390',
      rootNamespace: 'BookCafeAutomation',
    },
  },
} as Environment;
