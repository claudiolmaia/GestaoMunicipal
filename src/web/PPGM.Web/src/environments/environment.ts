// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrlv1: 'https://localhost:5901/api/',
  //apiUrlAutenticacao: 'https://ppgm-api-autenticacao:5101/api/',
  apiUrlAutenticacao: 'https://localhost:5101/api/',
  imagensUrl: 'https://localhost:5901/',  
  apiUrlIntegracao: 'https://localhost:5901/',
  apiUrlIbge: 'https://servicodados.ibge.gov.br/api/'
};

/*

 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
