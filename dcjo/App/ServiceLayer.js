


var ServicesLayer = {};



ServicesLayer.Registration = function (i, s)
    {
        //public property
        this.GetALL = function ( )
        
        {
            
            i.get("/api/employee/GetAllEmployee").then(function (re) {  s.ListOfEmployee = re.data; });
        
        };
        this.GetRows = function () {
            debugger;
            i.get("/api/employee/GetAllEmployee").then(function (re) { s.AthamnehRows = re.data; });

        };

        this.GetEmployeeByID = function (id) {
        
            i.get("/api/employee/GetEmployee?id=" + id).then(function (re) { s.Emp = re.data; });

        };
        this.Update = function (Emp,id) {
           
            i.put("/api/employee/UpdateEmployee?Emp=" + id, Emp).then(function (re) {   });

        };
        this.Insert = function (Emp) {

            i.post("/api/employee/AddEmployee", Emp).then(function (re) { });

        };
        
    
    }




    
    
    
        
    



 
 




 