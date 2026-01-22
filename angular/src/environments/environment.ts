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
    issuer: 'https://localhost:44390/', // Backend adresin
    redirectUri: baseUrl,
    clientId: 'BookCafeAutomation_App', // Backend'deki ClientId ile aynı olmalı
    responseType: 'code',
    scope: 'openid profile offline_access BookCafeAutomation', // openid ve profile standarttır, ekledim
    requireHttps: true, // Localde SSL (https) kullanıyorsan true kalmalı
    showDebugInformation: true, // Hata alırsan konsolda detay görmek için ekledim
  },
  apis: {
    default: {
      url: 'https://localhost:44390',
      rootNamespace: 'BookCafeAutomation',
    },
  },
} as Environment;