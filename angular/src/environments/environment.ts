import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'BookCafeAutomation',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44390', 
    redirectUri: baseUrl, // Giriş sonrası döneceği ana adres
    clientId: 'BookCafeAutomation_App', 
    responseType: 'code',
    scope: 'openid profile offline_access BookCafeAutomation', 
    requireHttps: false, // KRİTİK DÜZELTME: Localde sorun çıkmaması için false olmalı
    showDebugInformation: true, 
  },
  apis: {
    default: {
      url: 'https://localhost:44390',
      rootNamespace: 'BookCafeAutomation',
    },
  },
} as Environment;