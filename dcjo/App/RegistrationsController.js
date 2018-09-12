RegistrationLayer.factory("data1", function ($http)
{
    return {  y :   "this is from data1  service"};
    


}
);
//using inline array to pass the value to  let us change the parameters name so the minifier will not effect 
RegistrationLayer.controller("Registrations", ['$scope', '$http', '$location','data1' , function ($scope, $http, $location,Ourdataservice)


{
    
    

    var Model= $scope;
    var i = $http;
    Model.testdata = "ahmad";
    Model.Emp = null;
    Model.Columns = [{ cols: 'FirstName' }, { cols: 'LastName' }, { cols: 'Salary' }];
    var x = new ServicesLayer.Registration(i, Model);
    Model.AthamnehRows = {};
    Model.func1 = function () { alert(Ourdataservice.y) };
     
    $scope.updateHelloMessage = setTimeout(function () { Model.helloMessage = Ourdataservice.y; });
       
    
    x.GetALL();
    debugger;
    x.GetRows();

    Model.GetAllEmployee = function () {

        
        x.GetALL();
       
       

       
    };
    Model.InsertEmp = function (Emp) {


     


       
        x.Insert(Emp);
         
        Model.Update = true;
        Model.List = false;
        Model.GetALL();
        Model.Update = true;
        Model.Insert = true;
    };
    Model.PrepareInsert = function () {


        Model.Emp = null;
        Model.Update = true;
        Model.Insert = false;

        


    };

    Model.UpdateEmp = function (Emp,id) {


        x.Update(Emp,id);
        Model.Update = true;
        Model.List = false;
        x.GetALL();
    };
    Model.Delete = function () {


     


        var x = new ServicesLayer.Registration(i, s);
        x.GetALL($http, Model);


    };
    Model.GetByID = function (id) {

             


        Model.Update = false;
        Model.List = true;
        x.GetEmployeeByID(id);
      

    };
}]);



//RegistrationLayer.controller("Registrations1", ['$scope', '$http', '$location', 'data1', function ($scope, $http, $location, data1) {

  

//    $scope.i = 1;


       
      

//}]);

