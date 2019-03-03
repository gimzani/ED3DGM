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
        scope.render = (attr.render=="true");
        //-----------------------------------
        scope.$on("refresh",function(){
          setTimeout(function(){ Refresh(); }, 300);
        });
        //-----------------------------------
        scope.$on("init", function(){
          setTimeout(function(){ Init(); }, 300);
        });
        //-----------------------------------
        //-----------------------------------
        function Refresh(){
            Ed3d.rebuild();
        }
        //-----------------------------------
        function Init(){
            Ed3d.init({
              container: el.attr("id"),
              json: scope.mapData,
              effectScaleSystem : [128,1500]
            });   
        }
        //-----------------------------------
      }
    }
  }]);
    //---------------------------------------------------------------------------------
})()