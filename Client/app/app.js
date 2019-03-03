(function () {
  //-----------------------------------
  'use strict';
  var app = angular.module('edgm', []);
  //---------------------------------------------------------------------------------
  app.controller('main', ['$scope', '$q', 'data', function ($scope, $q, data) {

    //-----------------------------------
    $(document).on("systemClick", function( event, name, infos, url ) {
      console.log(event, name, infos, url);
      runSystemSearch(name);
    })
    //-----------------------------------
    $scope.checkEnter = function(evt){
      if(evt.keyCode ==13){
        runSystemSearch($scope.form.systemInfoQuery);
      }
    }
    //-----------------------------------
    $scope.form = {
      systemInfoQuery: null,
      selectedSystem: null,
      getSystemInfo: function(){
        runSystemSearch($scope.form.systemInfoQuery);
      },
      clearSearch: function(){
        $scope.form.systemInfoQuery = null;
        $scope.form.selectedSystem = null;
      },
      addToLibrary: function(){
        var system = Object.assign({}, $scope.form.selectedSystem);
        data.system.addSystem(system).then(function(res){
          $scope.form.clearSearch();
          getStarsystems().then(function(){              
            $scope.$broadcast('init');
          });
        });
      }
    }


    //-----------------------------------
    //-----------------------------------
    function runSystemSearch(systemName){
      if(systemName){
        $scope.form.selectedSystem = null;
        data.find.system(systemName).then(function(res){
          if(Array.isArray(res.data) && res.data.length==0){
            console.log('empty array', res.data);
          }else if((typeof res.data === "object") && (res.data.length !== null)){
            $scope.form.selectedSystem = res.data;
          }
        });        
      }else{
        console.log('no name selected');
      }
    } 




    //-----------------------------------
    function buildMapData(categories, systems){


      console.log("categories?", categories);
      console.log("systems?", systems);

      //-------------------  prep map obj
      var mapData = {
        categories:{},
        systems:[]
      };
      //-------------------  sort out categories
      var catName = categories.Name;
      mapData.categories[catName] = {};
      var obj = mapData.categories[catName];
      //-------------------  
      var id =0;
      categories.ColorLabels.forEach(function(col){
        id++;
        obj[id.toString()] = { name: col.Name, color:col.Color };
      });
      //-------------------  sort ad match star systems ...
      systems.forEach(function(sys){
        var obj = JSON.parse(sys.StarSystem.json);
        var ind = findIndex(categories.ColorLabels, obj.information[catName.toLowerCase()]);
        obj.cat = [ind+1];
        mapData.systems.push(obj);
      });
      //-------------------  
      
      console.log("mapData?", mapData);

      return mapData;
    }
    //-----------------------------------
    function getData(category, journalId){
      //-------------------
      var p = [
        data.categories.get(category), 
        data.systems.list(journalId)
      ];
      //-------------------
      $q.all(p).then(function(res){
        //-------------------
        var category = res[0].data.Data;
        var systems = res[1].data.Data.JournalStarSystems;        
        //-------------------
        $scope.mapData = buildMapData(category, systems);
        $scope.$broadcast('init');
      })
    }
    //-----------------------------------
    function findIndex(array, name) {
      var ind=-1;
      for(var i=0; i < array.length; i++){
        if(array[i].Name == name)
          ind = i;
      }
      return ind;
    }
    //-----------------------------------
    function init(){
      getData('Allegiance', 1);
    }
    init();
    //-----------------------------------
  }]);
  //---------------------------------------------------------------------------------
})()