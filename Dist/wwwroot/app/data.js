(function () {
  //------------------------------------------  script globals
  "use strict";
  var app = angular.module('edgm');
  const dbApi = "http://localhost:7000/api";
  const edsmInfoApi = "https://www.edsm.net/api-v1";
  const edsmSystemApi = "https://www.edsm.net/api-system-v1";
  //---------------------------------------------------------------------------------
  const opt = "&showCoordinates=1&showPermit=1&showInformation=1&showPrimaryStar=1";
  //---------------------------------------------------------------------------------
  //---------------------------------------------------------------------------  data
  app.factory('data',
    ['$http',
      function ($http) {
        //---------------------------------------------------------------------------------  data calls
        return {
          categories: {
            get: function (name) { return $http.get(dbApi + `/categories/${name}`); },
          },
          find: {
            area: function (systemName, min, max) { return $http.get(edsmInfoApi + "/sphere-systems?systemName=" + systemName + "&minRadius=" + min + "&radius=" + max + "&showCoordinates=1"); },
            systems: function (systemName) { return $http.get(edsmInfoApi + "/system?systemName[]=" + systemName + opt); },
            system: function (systemName) { return $http.get(edsmInfoApi + "/system?systemName=" + systemName + opt); },
          },
          info: {
            bodies: function (systemName) { return $http.get(edsmSystemApi + "/bodies?systemName=" + systemName); },
            scanValue: function (systemName) { return $http.get(edsmSystemApi + "/estimated-values?systemName=" + systemName); },
            stations: function (systemName) { return $http.get(edsmSystemApi + "/stations?systemName=" + systemName); },
            market: function (systemName, stationName) { return $http.get(edsmSystemApi + "/stations/market?systemName=" + systemName + "&stationName=" + stationName); },
            shipyard: function (systemName, stationName) { return $http.get(edsmSystemApi + "/stations/shipyard?systemName=" + systemName + "&stationName=" + stationName); },
            outfitting: function (systemName, stationName) { return $http.get(edsmSystemApi + "/stations/outfitting?systemName=" + systemName + "&stationName=" + stationName); },
            factions: function (systemName) { return $http.get(edsmSystemApi + "/factions?systemName=" + systemName); },
            traffic: function (systemName) { return $http.get(edsmSystemApi + "/traffic?systemName=" + systemName); },
          },
          journal: {
            get: function (journalId) { return $http.get(dbApi + `/journal/${journalId}`); }
          },
          systems: {
            list: function (journalId) { return $http.get(dbApi + `/starsystems/${journalId}`); },
            add: function (journalId, system) { return $http.post(dbApi + `/starsystems/${journalId}`, system) },
            remove: function (journalId, systemId) { return $http.delete(dbApi + `/starsystems/${journalId}/${systemId}`); }
          },
        }

      }
    ]);
  //-----------------------------------------------------------------------------  
}());


