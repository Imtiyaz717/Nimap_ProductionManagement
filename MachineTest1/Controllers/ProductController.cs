using MachineTest1.EF;
using MachineTest1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace MachineTest1.Controllers
{
    
    public class ProductController : Controller
    {
        // GET: Product
        private readonly MyContext db;

        public ProductController()
        {
            db = new MyContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        [HttpGet]
        public ActionResult ProductList(string SortOrder,string SortBy,int PageNumber=1)
        {
            try
            {
                int i = 1;
                var list = db.TblProductMaster.ToList();
                var newlist = list.Select(x => new CategoryProductVM()
                {
                    Id =i++,
               
                    ProductID=x.ProductId,
                    ProductName=x.ProductName,
                    CategoryID = x.CategoryId,
                    CategoryName=x.CategoryMaster.CategoryName
                });

                ViewBag.SortOrder = SortOrder;
                ViewBag.SortBy = SortBy;

                if(SortBy == "ProductName")
                {
                    switch (SortOrder)
                    {
                        case "Asc":
                            {
                                newlist = newlist.OrderBy(x => x.ProductName);
                                break;
                            }
                        case "Desc":
                            {
                                newlist = newlist.OrderByDescending(x => x.ProductName);
                                break;
                            }

                        default:
                            {
                                newlist = newlist.OrderBy(x => x.ProductName);
                                break;
                            }

                    }
                }
                if (SortBy == "CategoryName")
                {
                    switch (SortOrder)
                    {
                        case "Asc":
                            {
                                newlist = newlist.OrderBy(x => x.CategoryName);
                                break;
                            }
                        case "Desc":
                            {
                                newlist = newlist.OrderByDescending(x => x.CategoryName);
                                break;
                            }

                        default:
                            {
                                newlist = newlist.OrderBy(x => x.CategoryName);
                                break;
                            }

                    }
                }

                if (SortBy == "Id")
                {
                    switch (SortOrder)
                    {
                        case "Asc":
                            {
                                newlist = newlist.OrderBy(x => x.Id);
                                break;
                            }
                        case "Desc":
                            {
                                newlist = newlist.OrderByDescending(x => x.Id);
                                break;
                            }

                        default:
                            {
                                newlist = newlist.OrderBy(x => x.Id);
                                break;
                            }

                    }
                }
                if (SortBy == "ProductID")
                {
                    switch (SortOrder)
                    {
                        case "Asc":
                            {
                                newlist = newlist.OrderBy(x => x.ProductID);
                                break;
                            }
                        case "Desc":
                            {
                                newlist = newlist.OrderByDescending(x => x.ProductID);
                                break;
                            }

                        default:
                            {
                                newlist = newlist.OrderBy(x => x.ProductID);
                                break;
                            }

                    }
                }

                if (SortBy == "CategoryID")
                {
                    switch (SortOrder)
                    {
                        case "Asc":
                            {
                                newlist = newlist.OrderBy(x => x.CategoryID);
                                break;
                            }
                        case "Desc":
                            {
                                newlist = newlist.OrderByDescending(x => x.CategoryID);
                                break;
                            }

                        default:
                            {
                                newlist = newlist.OrderBy(x => x.CategoryID);
                                break;
                            }

                    }
                }

                ViewBag.totalPages = Math.Ceiling(newlist.Count()/10.0);
                ViewBag.PageNumber = PageNumber;
                newlist = newlist.Skip((PageNumber - 1) * 10).Take(10).ToList();

                return View(newlist);
               
            }
            catch (Exception ex)
            {
                
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
           
           
        }

        [HttpPost]
        public ActionResult ProductList(string searchTxt)
        {
            try
            {
                int i = 1;
                var list = db.TblProductMaster.ToList();
               
                var newlist = list.Select(x => new CategoryProductVM()
                {
                    Id = i++,

                    ProductID = x.ProductId,
                    ProductName = x.ProductName,
                    CategoryID = x.CategoryId,
                    CategoryName = x.CategoryMaster.CategoryName
                });

                
                if (searchTxt != null)
                {
                   
                    newlist = newlist.Where(x=>x.ProductName.Contains(searchTxt) || x.CategoryName.Contains(searchTxt)).ToList();
                }
                else
                {
                    ViewBag.NotFound = "Please Enter Correct Record!";
                }
                return View(newlist);
                

            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return View();
            }


        }

        public void ApplySorting(string SortOrder, string SortBy,CategoryProductVM a)
        {
            int i = 1;
            var list = db.TblProductMaster.ToList();

            var newlist = list.Select(x => new CategoryProductVM()
            {
                Id = i++,

                ProductID = x.ProductId,
                ProductName = x.ProductName,
                CategoryID = x.CategoryId,
                CategoryName = x.CategoryMaster.CategoryName
            });


            if (SortBy == "ProductName")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        {
                            newlist = newlist.OrderBy(x => x.ProductName);
                            break;
                        }
                    case "Desc":
                        {
                            newlist = newlist.OrderByDescending(x => x.ProductName);
                            break;
                        }

                    default:
                        {
                            newlist = newlist.OrderBy(x => x.ProductName);
                            break;
                        }

                }
            }
            if (SortBy == "CategoryName")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        {
                            newlist = newlist.OrderBy(x => x.CategoryName);
                            break;
                        }
                    case "Desc":
                        {
                            newlist = newlist.OrderByDescending(x => x.CategoryName);
                            break;
                        }

                    default:
                        {
                            newlist = newlist.OrderBy(x => x.CategoryName);
                            break;
                        }

                }
            }

            if (SortBy == "Id")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        {
                            newlist = newlist.OrderBy(x => x.Id);
                            break;
                        }
                    case "Desc":
                        {
                            newlist = newlist.OrderByDescending(x => x.Id);
                            break;
                        }

                    default:
                        {
                            newlist = newlist.OrderBy(x => x.Id);
                            break;
                        }

                }
            }
            if (SortBy == "ProductID")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        {
                            newlist = newlist.OrderBy(x => x.ProductID);
                            break;
                        }
                    case "Desc":
                        {
                            newlist = newlist.OrderByDescending(x => x.ProductID);
                            break;
                        }

                    default:
                        {
                            newlist = newlist.OrderBy(x => x.ProductID);
                            break;
                        }

                }
            }

            if (SortBy == "CategoryID")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        {
                            newlist = newlist.OrderBy(x => x.CategoryID);
                            break;
                        }
                    case "Desc":
                        {
                            newlist = newlist.OrderByDescending(x => x.CategoryID);
                            break;
                        }

                    default:
                        {
                            newlist = newlist.OrderBy(x => x.CategoryID);
                            break;
                        }

                }
            }
        }
       

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.list = db.TblCategoryMaster.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult AddProduct(ProductMaster PM)
        {
           

            try
            {
                if (PM!=null)
                {
                     
                            db.TblProductMaster.Add(PM);
                            db.SaveChanges();
                            return RedirectToAction("ProductList");
                        
                }
                else
                {
                    return View();
                }
               
            }
            catch (Exception ex)
            {

               ViewBag.AddExp = ex.Message;
                return View();
            }

            
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            try
            {
                var obj = db.TblProductMaster.FirstOrDefault(x => x.ProductId == id);
                
                if (obj != null)
                {
                    return View(obj);
                }
                else
                {
                    ViewBag.notfound = "No Record found for this request!";
                    return View();
                }

            }
            catch (Exception ex)
            {

                ViewBag.msg = ex.Message;
                return View();
            }
            
           
           
        }




        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            try
            {
                ViewBag.list = db.TblCategoryMaster.ToList();
                var obj = db.TblProductMaster.First(x => x.ProductId == id);
                
                if (obj != null)
                {
                    return View(obj);
                }
                else
                {
                    ViewBag.NFdata = "This Record is not found in the table";
                    return View();
                }
                
            }
            catch (Exception ex)
            {

                ViewBag.except = ex.Message;
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductMaster PM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                        db.Entry(PM).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("ProductList");
                }
                else
                {
                ViewBag.Model = "Model State is no valid";
                return View();
                }
                

            }
            catch (Exception ex)
            {

               ViewBag.Exception = ex.Message;
                return View();
            }
            //
           
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var obj = db.TblProductMaster.FirstOrDefault(x => x.ProductId == id);
                if (obj != null)
                {
                    return View(obj);
                }
                else
                {
                    ViewBag.NotFound = "Record not found!";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View();
            }
           
           
        }

        [HttpPost]
        [ActionName("DeleteProduct")]
        public ActionResult DeleteProductPost(int id)
        {
            try
            {
                var obj = db.TblProductMaster.FirstOrDefault(x => x.ProductId == id);
                if (obj != null)
                {
                    db.TblProductMaster.Remove(obj);
                    db.SaveChanges();
                    return RedirectToAction("ProductList");
                }
                else
                {
                    ViewBag.NotFound = "Record not found!";
                    return View();
                }

            }
            catch (Exception ex)
            {

                ViewBag.Exception = ex.Message;
                return View();
            }
            
            
           
        }




    }
}
