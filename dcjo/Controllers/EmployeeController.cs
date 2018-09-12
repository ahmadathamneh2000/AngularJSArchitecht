using CRUDwithAngularJSAndWebAPI.Models;
using CRUDwithAngularJSAndWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CRUDwithAngularJSAndWebAPI.Controllers
{
    
    public class EmployeeController : ApiController
    {

        public static  List<EmployeeViewModel> lst = new List<EmployeeViewModel>();
        public static List<EmployeeRows> lst1 = new List<EmployeeRows>();
        
        DataAccessContext context = new DataAccessContext();

        //Get All Employees
        [HttpGet]        
        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {

            if (lst.Count == 0 )
            {

                lst.Add(new EmployeeViewModel {DOB=DateTime.Parse("01/01/2010"),Salary=500, FirstName = "ahmad", LastName = "ali", EmployeeID = 1, Address ="s"});
                lst.Add(new EmployeeViewModel { DOB=DateTime.Parse("01/01/2010"), Salary = 500, FirstName = "ahmad1", LastName = "ali", EmployeeID = 2, Address = "s" });
                lst.Add(new EmployeeViewModel {DOB=DateTime.Parse("01/01/2010"), Salary = 500, FirstName = "ahmad2", LastName = "ali", EmployeeID = 3, Address = "s" });

                
            }
            else
            {
               
            
            }



            return lst;


            //var data = lst;

            //var result = data.Select(x => new EmployeeViewModel()
            //{
            //    EmployeeID = x.EmployeeID,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    Address = x.Address,
            //    Salary = x.Salary,
            //    DOB = x.DOB
            //});
            //return result.ToList();
        }
         [HttpGet]
        public IEnumerable<EmployeeRows> GetAllEmployeeRows()
        {

            if (lst1.Count == 0)
            {

                lst1.Add(new EmployeeRows { DOB = DateTime.Parse("01/01/2010"), Salary = 500, FirstName = "ahmad", LastName = "ali", EmployeeID = 1, Address = "s",  Cels =new List<string> { "FirstName", "LastName", "Salary" } });
                lst1.Add(new EmployeeRows { DOB = DateTime.Parse("01/01/2010"), Salary = 500, FirstName = "ahmad1", LastName = "ali", EmployeeID = 2, Address = "s", Cels = new List<string> { "FirstName", "LastName", "Salary" } });
                lst1.Add(new EmployeeRows { DOB = DateTime.Parse("01/01/2010"), Salary = 500, FirstName = "ahmad2", LastName = "ali", EmployeeID = 3, Address = "s", Cels = new List<string> { "FirstName", "LastName", "Salary" } });

                
            }
            else
            {
               
            
            }




            



            return lst1;
        }

        
        //Get the single employee data
        [HttpGet]
        public EmployeeViewModel GetEmployee(int Id)
        {

          




            var data =  lst.Where(x => x.EmployeeID == Id).ToList<EmployeeViewModel>().FirstOrDefault();
            return data;

           
        }

        //Add new employee

        [HttpPost]
        public HttpResponseMessage AddEmployee(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeViewModel emp = new EmployeeViewModel();
                    emp.FirstName = model.FirstName;
                    emp.LastName = model.LastName;
                    emp.Address = model.Address;
                    emp.Salary = model.Salary;
                    emp.DOB = Convert.ToDateTime(model.DOB.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    lst.Add(emp);
                 
                    //context.Employees.Add(emp);
                    //var result = context.SaveChanges();
                    //if (result > 0)
                    //{
                       return Request.CreateResponse(HttpStatusCode.Created, "Submitted Successfully");
                    //}
                    //else1111
                    //{
                    //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                    //}
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
            }
        }

        //Update the employee

        [HttpPut]
        public HttpResponseMessage UpdateEmployee(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    EmployeeViewModel emp = lst.Where(x => x.EmployeeID == model.EmployeeID).ToList<EmployeeViewModel>().FirstOrDefault();
                    emp.FirstName = model.FirstName;
                    emp.LastName = model.LastName;
                    emp.Address = model.Address;
                    emp.Salary = model.Salary;

                  
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
                   
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
            }
        }

        //Delete the employee

        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int Id)
        {
            EmployeeModel emp = new EmployeeModel();
            emp = context.Employees.Find(Id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something wrong !");
            }
        }
    }
}
