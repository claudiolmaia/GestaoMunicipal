// use log;
// db.createCollection("ppgm-log", { capped : true, size : 5242880, max : 5000 } )
print('Start #################################################################');

db = db.getSiblingDB('ppgm-db');
db.createUser(
  {
    user: 'ppgm',
    pwd: '@ppgm2021',
    roles: [{ role: 'readWrite', db: 'ppgm-db' }],
  },
);
db.createCollection('log');
print('END #################################################################');