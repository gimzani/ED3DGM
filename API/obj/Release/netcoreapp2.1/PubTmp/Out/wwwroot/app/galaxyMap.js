(function () {
  //-----------------------------------
  'use strict';
  var app = angular.module('edgm');
  //---------------------------------------------------------------------------------
  app.directive('galaxyMap', [function () {
    return {
      restrict: 'A',
      scope:{
        mapData: "="
      },
      link: function(scope, el, attr){
        //-----------------------------------
        //-----------------------------------
        scope.$on("init", function(){
          setTimeout(function(){ Init(); }, 300);
        });
        //-----------------------------------
        //-----------------------------------
        function buildMap(){
          //----------------------
          angular.element(el).empty();
          //----------------------
          var galaxy = document.createElement('div');
          galaxy.setAttribute("id","edmap");
          //----------------------
          angular.element(el).append(galaxy);
          //----------------------
          Ed3d.init({
            container: "edmap",
            json: scope.mapData,
            startAnim: false,
            cameraPos: [0, 500, -500],
            effectScaleSystem : [128,1500]
          });  
          //----------------------
        }
        //-----------------------------------
        function Init(){
          buildMap();
        }
        //-----------------------------------
      }
    }
  }]);
    //---------------------------------------------------------------------------------
})()