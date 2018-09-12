


 

var AthDirectives= angular.module("AthDirectives",[]);



AthDirectives.directive('uiDataGrid', function () {
    return{
        restrict: 'E',
        scope: {

            datasource: '=datasource',
            col: '=col', // objects
            func: '&func',   // it will be assigned with function 
            col1: '@test'   // it will be string only no object
            
        },

        link: function (scope, element, attrs) {
           // scope.func({ ftn: "hi all" });
            scope.testdata = "from Isolated Scope";
            scope.testdatafrommain =scope.col1;
        },

        templateUrl: '/App/Directives/data/UIGrid.html'
    }
});