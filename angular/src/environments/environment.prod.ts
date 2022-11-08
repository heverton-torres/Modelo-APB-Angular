import { Environment } from '@abp/ng.core';

const baseUrl = 'https://modeloui.azurewebsites.net';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Demo',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://modeloweb.azurewebsites.net/',
    redirectUri: baseUrl,
    clientId: 'Demo_App',
    responseType: 'code',
    scope: 'offline_access Demo',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://modeloweb.azurewebsites.net',
      rootNamespace: 'Hvt.Demo',
    },
  },
} as Environment;
