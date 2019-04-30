(function () {
  //-----------------------------------
  'use strict';
  var app = angular.module('edgm', []);
  //---------------------------------------------------------------------------------
  app.controller('main', ['$scope', '$q', 'data', function ($scope, $q, data) {
    //-----------------------------------
    //-----------------------------------  map obj selected
    $(document).on("systemClick", function( event, name, infos, url ) {
      //console.log(event, name, infos, url);
      $scope.areaSearch.query = name;
      runSystemSearch(name);
    })

    //---------------------------------------------------------  map context
    $scope.mapContext = {
      journalId : 1,
      category: "Economy",
      setCategory: function(category){
        $scope.mapContext.category = category;
        getJournalData();
      }
    }

    //---------------------------------------------------------  system search
    $scope.systemSearch = {
      query: null,
      selectedSystem: null,
      search: function(){
        runSystemSearch($scope.systemSearch.query);
      },
      checkEnter: function(evt){
        if(evt.keyCode == 13){
          runSystemSearch($scope.systemSearch.query);
        }
      },
      clearSearch: function(){
        $scope.systemSearch.query = null;
        $scope.systemSearch.selectedSystem = null;
      },
      addToLibrary: function(){
        var system = Object.assign({}, $scope.systemSearch.selectedSystem);
        data.systems.add($scope.mapContext.journalId, system).then(function(res){
          $scope.systemSearch.clearSearch();
          getJournalData();
        });
      }
    }

    //---------------------------------------------------------  area search
    $scope.areaSearch = {
      query: null,
      min: 0,
      max: 25,
      systems: [] ,
      search: function(){
        runAreaSearch($scope.areaSearch.query, $scope.areaSearch.min, $scope.areaSearch.max);
      },
      checkEnter: function(evt){
        if(evt.keyCode == 13){
          runAreaSearch($scope.areaSearch.query, $scope.areaSearch.min, $scope.areaSearch.max);
        }
      },
      clearSearch: function(){
        $scope.areaSearch.query = null;
        $scope.areaSearch.systems = [];
      },
      details: function(systemName){
        $scope.systemSearch.query = systemName;
        $scope.systemSearch.search();
      }

    }


    //---------------------------------------------------------
    //---------------------------------------------------------  run system search
    function runSystemSearch(systemName){
      if(systemName){
        $scope.systemSearch.selectedSystem = null;
        data.find.system(systemName).then(function(res){
          if(Array.isArray(res.data) && res.data.length==0){
            console.log('empty array', res.data);
          }else if((typeof res.data === "object") && (res.data.length !== null)){
            $scope.systemSearch.selectedSystem = res.data;
          }
        });        
      }else{
        console.log('no name selected');
      }
    } 
    //---------------------------------------------------------
    //---------------------------------------------------------  run area search
    function runAreaSearch(systemName, min, max){
      if(systemName){
        $scope.areaSearch.systems = [];
        data.find.area(systemName, min, max).then(function(res){  
          console.log(res);        
          $scope.areaSearch.systems = res.data;   
        });        
      }else{
        console.log('no name selected');
      }
    }
    //---------------------------------------------------------
    //---------------------------------------------------------  build map data
    function buildMapData(categories, systems){

      //console.log("categories?", categories);
      //console.log("systems?", systems);

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
      //console.log("mapData?", mapData);
      //-------------------    
      return mapData;
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
    //---------------------------------------------------------  get Journal data
    function getJournalData(){
      //-------------------
      var p = [
        data.categories.get($scope.mapContext.category), 
        data.systems.list($scope.mapContext.journalId)
      ];
      //-------------------
      return $q.all(p).then(function(res){
        //-------------------
        var categories = res[0].data.Data;
        var systems = res[1].data.Data.JournalStarSystems;        
        //-------------------
        $scope.mapData = buildMapData(categories, systems);
        //-------------------
        $scope.$broadcast('init');
      })
    }
    //---------------------------------------------------------
    function init(){
      getJournalData();
    }
    init();
    //-----------------------------------
  }]);
  //---------------------------------------------------------------------------------
})()