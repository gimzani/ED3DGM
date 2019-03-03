(function () {
  //-----------------------------------
  'use strict';
  var app = angular.module('edgm');
  //---------------------------------------------------------------------------------
  app.directive('findStarSystem', [function () {
    return {
      restrict: 'E',
      scope:{
        mapData: "="
      },
      templateUrl:"templates/findStarSystem.html",
      link: function(scope, el, attr){
        //-----------------------------------

        //-----------------------------------
      }
    }
  }]);
    //---------------------------------------------------------------------------------
})()